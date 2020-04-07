namespace Tilia.Interactions.Interactables.Grab
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Grab.Action;
    using Tilia.Interactions.Interactables.Grab.Provider;
    using Tilia.Interactions.Interactables.Grab.Receiver;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;

    /// <summary>
    /// Sets up the Interactable Prefab grab settings based on the provided user settings.
    /// </summary>
    public class GrabInteractableConfigurator : MonoBehaviour
    {
        #region Facade Settings
        /// <summary>
        /// The public interface facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public InteractableFacade Facade { get; protected set; }
        #endregion

        #region Action Settings
        /// <summary>
        /// The action to perform when grabbing the interactable for the first time.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Action Settings"), DocumentedByXml]
        public GrabInteractableAction PrimaryAction { get; set; }
        /// <summary>
        /// The action to perform when grabbing the interactable for the second time.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public GrabInteractableAction SecondaryAction { get; set; }
        #endregion

        #region Reference Settings
        /// <summary>
        /// The Grab Receiver setup.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public GrabInteractableReceiver GrabReceiver { get; protected set; }
        /// <summary>
        /// The Grab Provider setup.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GrabInteractableInteractorProvider GrabProvider { get; protected set; }
        /// <summary>
        /// The potential options for the <see cref="GrabProvider"/>.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GrabInteractableInteractorProvider[] GrabProviderOptions { get; protected set; } = new GrabInteractableInteractorProvider[0];
        /// <summary>
        /// The <see cref="GameObjectObservableList"/> that contains the available grab action prefabs.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml, Restricted]
        public GameObjectObservableList ActionTypes { get; protected set; }
        #endregion

        /// <summary>
        /// A collection of Interactors that are currently grabbing the Interactable.
        /// </summary>
        public IReadOnlyList<InteractorFacade> GrabbingInteractors => GrabProvider.GrabbingInteractors;
        /// <summary>
        /// Determines if the grab type is set to toggle.
        /// </summary>
        public bool IsGrabTypeToggle => GrabReceiver.GrabType == GrabInteractableReceiver.ActiveType.Toggle;

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void Grab(InteractorFacade interactor)
        {
            interactor.Grab(Facade);
        }

        /// <summary>
        /// Attempt to ungrab the Interactable.
        /// </summary>
        /// <param name="sequenceIndex">The Interactor sequence index to ungrab from.</param>
        public virtual void Ungrab(int sequenceIndex = 0)
        {
            if (GrabbingInteractors == null || GrabbingInteractors.Count == 0 || sequenceIndex >= GrabbingInteractors.Count)
            {
                return;
            }

            Ungrab(GrabbingInteractors[sequenceIndex]);
        }

        /// <summary>
        /// Attempts to ungrab the Interactable.
        /// </summary>
        /// <param name="interactor">The Interactor to ungrab from.</param>
        public virtual void Ungrab(InteractorFacade interactor)
        {
            interactor.Ungrab();
        }

        /// <summary>
        /// Notifies that the Interactable is being grabbed.
        /// </summary>
        /// <param name="data">The grabbing object.</param>
        public virtual void NotifyGrab(GameObject data)
        {
            InteractorFacade interactor = data.TryGetComponent<InteractorFacade>(true, true);
            if (interactor != null)
            {
                if (Facade.GrabbingInteractors.Count == 1)
                {
                    Facade.FirstGrabbed?.Invoke(interactor);
                }
                Facade.Grabbed?.Invoke(interactor);
                interactor.NotifyOfGrab(Facade);
            }
        }

        /// <summary>
        /// Notifies that the Interactable is no longer being grabbed.
        /// </summary>
        /// <param name="data">The previous grabbing object.</param>
        public virtual void NotifyUngrab(GameObject data)
        {
            InteractorFacade interactor = data.TryGetComponent<InteractorFacade>(true, true);
            if (interactor != null)
            {
                Facade.Ungrabbed?.Invoke(interactor);
                interactor.NotifyOfUngrab(Facade);
                if (Facade.GrabbingInteractors.Count == 0)
                {
                    Facade.LastUngrabbed?.Invoke(interactor);
                }
            }
        }

        /// <summary>
        /// Sets the consumer containers to the current active container.
        /// </summary>
        public virtual void ConfigureContainer()
        {
            GrabReceiver.ConfigureConsumerContainers(Facade.Configuration.ConsumerContainer);
            ConfigureActionContainer(PrimaryAction);
            ConfigureActionContainer(SecondaryAction);
        }

        /// <summary>
        /// Sets the <see cref="GrabProvider"/> to the index of the <see cref="GrabProviderOptions"/> collection.
        /// </summary>
        /// <param name="providerIndex">The index of the <see cref="GrabProviderOptions"/> to set the <see cref="GrabProvider"/> to.</param>
        public virtual void SetGrabProvider(int providerIndex)
        {
            if (providerIndex >= GrabProviderOptions.Length)
            {
                return;
            }

            GrabProvider = GrabProviderOptions[providerIndex];

            for (int index = 0; index < GrabProviderOptions.Length; index++)
            {
                GrabProviderOptions[index].gameObject.SetActive(index == providerIndex);
            }

            UnlinkReceiverToProvider();
            UnlinkToPrimaryAction();
            UnlinkToSecondaryAction();

            LinkReceiverToProvider();
            LinkToPrimaryAction();
            LinkToSecondaryAction();
        }

        protected virtual void OnEnable()
        {
            SetGrabProvider(Facade.GrabProviderIndex);
            ConfigureContainer();
            GrabReceiver.GrabValidity.ReceiveValidity = Facade.Configuration.DisallowedGrabInteractors;
            GrabReceiver.GrabType = Facade.GrabType;
        }

        protected virtual void OnDisable()
        {
            UnlinkReceiverToProvider();
            UnlinkToPrimaryAction();
            UnlinkToSecondaryAction();
        }

        /// <summary>
        /// Configures the action containers.
        /// </summary>
        /// <param name="action">The action to configure.</param>
        protected virtual void ConfigureActionContainer(GrabInteractableAction action)
        {
            if (action == null)
            {
                return;
            }

            action.RunWhenActiveAndEnabled(() => action.GrabSetup = this);
        }

        /// <summary>
        /// Links the Grab Receiver to the Grab Provider.
        /// </summary>
        protected virtual void LinkReceiverToProvider()
        {
            GrabReceiver.OutputGrabAction.Emitted.AddListener(GrabProvider.InputGrabReceived.Receive);
            GrabReceiver.OutputUngrabAction.Emitted.AddListener(GrabProvider.InputUngrabReceived.Receive);
            GrabReceiver.OutputUngrabOnUntouchAction.Emitted.AddListener(Facade.Ungrab);
        }

        /// <summary>
        /// Unlinks the Grab Receiver to the Grab Provider.
        /// </summary>
        protected virtual void UnlinkReceiverToProvider()
        {
            GrabReceiver.OutputGrabAction.Emitted.RemoveListener(GrabProvider.InputGrabReceived.Receive);
            GrabReceiver.OutputUngrabAction.Emitted.RemoveListener(GrabProvider.InputUngrabReceived.Receive);
            GrabReceiver.OutputUngrabOnUntouchAction.Emitted.RemoveListener(Facade.Ungrab);
        }

        /// <summary>
        /// Links the Grab Receiver and Grab Provider to the Primary Grab Action.
        /// </summary>
        protected virtual void LinkToPrimaryAction()
        {
            if (PrimaryAction == null)
            {
                return;
            }

            GrabReceiver.OutputActiveCollisionConsumer.Emitted.AddListener(PrimaryAction.InputActiveCollisionConsumer.Receive);
            GrabProvider.OutputPrimaryGrabAction.Emitted.AddListener(PrimaryAction.InputGrabReceived.Receive);
            GrabProvider.OutputPrimaryUngrabAction.Emitted.AddListener(PrimaryAction.InputUngrabReceived.Receive);
        }

        /// <summary>
        /// Unlinks the Grab Receiver and Grab Provider to the Primary Grab Action.
        /// </summary>
        protected virtual void UnlinkToPrimaryAction()
        {
            if (PrimaryAction == null)
            {
                return;
            }

            GrabReceiver.OutputActiveCollisionConsumer.Emitted.RemoveListener(PrimaryAction.InputActiveCollisionConsumer.Receive);
            GrabProvider.OutputPrimaryGrabAction.Emitted.RemoveListener(PrimaryAction.InputGrabReceived.Receive);
            GrabProvider.OutputPrimaryUngrabAction.Emitted.RemoveListener(PrimaryAction.InputUngrabReceived.Receive);
        }

        /// <summary>
        /// Links the Grab Receiver and Grab Provider to the Secondary Grab Action.
        /// </summary>
        protected virtual void LinkToSecondaryAction()
        {
            if (SecondaryAction == null)
            {
                return;
            }

            GrabReceiver.OutputActiveCollisionConsumer.Emitted.AddListener(SecondaryAction.InputActiveCollisionConsumer.Receive);
            GrabProvider.OutputPrimaryGrabSetupOnSecondaryAction.Emitted.AddListener(SecondaryAction.InputGrabSetup.Receive);
            GrabProvider.OutputPrimaryUngrabResetOnSecondaryAction.Emitted.AddListener(SecondaryAction.InputUngrabReset.Receive);
            GrabProvider.OutputSecondaryGrabAction.Emitted.AddListener(SecondaryAction.InputGrabReceived.Receive);
            GrabProvider.OutputSecondaryUngrabAction.Emitted.AddListener(SecondaryAction.InputUngrabReceived.Receive);
        }

        /// <summary>
        /// Unlinks the Grab Receiver and Grab Provider to the Secondary Grab Action.
        /// </summary>
        protected virtual void UnlinkToSecondaryAction()
        {
            if (SecondaryAction == null)
            {
                return;
            }

            GrabReceiver.OutputActiveCollisionConsumer.Emitted.RemoveListener(SecondaryAction.InputActiveCollisionConsumer.Receive);
            GrabProvider.OutputPrimaryGrabSetupOnSecondaryAction.Emitted.RemoveListener(SecondaryAction.InputGrabSetup.Receive);
            GrabProvider.OutputPrimaryUngrabResetOnSecondaryAction.Emitted.RemoveListener(SecondaryAction.InputUngrabReset.Receive);
            GrabProvider.OutputSecondaryGrabAction.Emitted.RemoveListener(SecondaryAction.InputGrabReceived.Receive);
            GrabProvider.OutputSecondaryUngrabAction.Emitted.RemoveListener(SecondaryAction.InputUngrabReceived.Receive);
        }

        /// <summary>
        /// Called after <see cref="PrimaryAction"/> has been changed.
        /// </summary>
        [CalledBeforeChangeOf(nameof(PrimaryAction))]
        protected virtual void OnBeforePrimaryActionChange()
        {
            UnlinkToPrimaryAction();
        }

        /// <summary>
        /// Called after <see cref="PrimaryAction"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(PrimaryAction))]
        protected virtual void OnAfterPrimaryActionChange()
        {
            LinkToPrimaryAction();
            ConfigureActionContainer(PrimaryAction);
        }

        /// <summary>
        /// Called after <see cref="SecondaryAction"/> has been changed.
        /// </summary>
        [CalledBeforeChangeOf(nameof(SecondaryAction))]
        protected virtual void OnBeforeSecondaryActionChange()
        {
            UnlinkToSecondaryAction();
        }

        /// <summary>
        /// Called after <see cref="SecondaryAction"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(SecondaryAction))]
        protected virtual void OnAfterSecondaryActionChange()
        {
            LinkToSecondaryAction();
            ConfigureActionContainer(SecondaryAction);
        }
    }
}