namespace Tilia.Interactions.Interactables.Interactables.Grab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tilia.Interactions.Interactables.Interactables.Grab.Action;
    using Tilia.Interactions.Interactables.Interactables.Grab.Provider;
    using Tilia.Interactions.Interactables.Interactables.Grab.Receiver;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;

    /// <summary>
    /// Sets up the Interactable Prefab grab settings based on the provided user settings.
    /// </summary>
    public class GrabInteractableConfigurator : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="Rigidbody"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<Rigidbody> { }

        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private InteractableFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public InteractableFacade Facade
        {
            get
            {
                return facade;
            }
            protected set
            {
                facade = value;
            }
        }
        #endregion

        #region Action Settings
        [Header("Action Settings")]
        [Tooltip("The action to perform when grabbing the interactable for the first time.")]
        [SerializeField]
        private GrabInteractableAction primaryAction;
        /// <summary>
        /// The action to perform when grabbing the interactable for the first time.
        /// </summary>
        public GrabInteractableAction PrimaryAction
        {
            get
            {
                return primaryAction;
            }
            set
            {
                if (this.IsMemberChangeAllowed())
                {
                    OnBeforePrimaryActionChange();
                }
                primaryAction = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterPrimaryActionChange();
                }
            }
        }
        [Tooltip("The action to perform when grabbing the interactable for the second time.")]
        [SerializeField]
        private GrabInteractableAction secondaryAction;
        /// <summary>
        /// The action to perform when grabbing the interactable for the second time.
        /// </summary>
        public GrabInteractableAction SecondaryAction
        {
            get
            {
                return secondaryAction;
            }
            set
            {
                if (this.IsMemberChangeAllowed())
                {
                    OnBeforeSecondaryActionChange();
                }
                secondaryAction = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterSecondaryActionChange();
                }
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The Grab Receiver setup.")]
        [SerializeField]
        [Restricted]
        private GrabInteractableReceiver grabReceiver;
        /// <summary>
        /// The Grab Receiver setup.
        /// </summary>
        public GrabInteractableReceiver GrabReceiver
        {
            get
            {
                return grabReceiver;
            }
            protected set
            {
                grabReceiver = value;
            }
        }
        [Tooltip("The Grab Provider setup.")]
        [SerializeField]
        [Restricted]
        private GrabInteractableInteractorProvider grabProvider;
        /// <summary>
        /// The Grab Provider setup.
        /// </summary>
        public GrabInteractableInteractorProvider GrabProvider
        {
            get
            {
                return grabProvider;
            }
            protected set
            {
                grabProvider = value;
            }
        }
        [Tooltip("The potential options for the GrabProvider.")]
        [SerializeField]
        [Restricted]
        private GrabInteractableInteractorProvider[] grabProviderOptions = new GrabInteractableInteractorProvider[0];
        /// <summary>
        /// The potential options for the <see cref="GrabProvider"/>.
        /// </summary>
        public GrabInteractableInteractorProvider[] GrabProviderOptions
        {
            get
            {
                return grabProviderOptions;
            }
            protected set
            {
                grabProviderOptions = value;
            }
        }
        [Tooltip("The GameObjectObservableList that contains the available grab action prefabs.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList actionTypes;
        /// <summary>
        /// The <see cref="GameObjectObservableList"/> that contains the available grab action prefabs.
        /// </summary>
        public GameObjectObservableList ActionTypes
        {
            get
            {
                return actionTypes;
            }
            protected set
            {
                actionTypes = value;
            }
        }
        #endregion

        #region Events
        [Header("Events")]
        public UnityEvent KinematicStateToChange = new UnityEvent();
        #endregion

        /// <summary>
        /// A collection of Interactors that are currently grabbing the Interactable.
        /// </summary>
        public virtual IReadOnlyList<InteractorFacade> GrabbingInteractors => GrabProvider.GrabbingInteractors;
        /// <summary>
        /// Determines if the grab type is set to toggle.
        /// </summary>
        public virtual bool IsGrabTypeToggle => GrabReceiver.GrabType == GrabInteractableReceiver.ActiveType.Toggle;

        /// <summary>
        /// Clears <see cref="PrimaryAction"/>.
        /// </summary>
        public virtual void ClearPrimaryAction()
        {
            if (!this.IsValidState())
            {
                return;
            }

            PrimaryAction = default;
        }

        /// <summary>
        /// Clears <see cref="SecondaryAction"/>.
        /// </summary>
        public virtual void ClearSecondaryAction()
        {
            if (!this.IsValidState())
            {
                return;
            }

            SecondaryAction = default;
        }

        /// <summary>
        /// Clears <see cref="ActionTypes"/>.
        /// </summary>
        public virtual void ClearActionTypes()
        {
            if (!this.IsValidState())
            {
                return;
            }

            ActionTypes = default;
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and ungrabs any existing grab.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void Grab(InteractorFacade interactor)
        {
            if (interactor == null)
            {
                return;
            }

            interactor.Grab(Facade);
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grab.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void GrabIgnoreUngrab(InteractorFacade interactor)
        {
            if (interactor == null)
            {
                return;
            }

            interactor.GrabIgnoreUngrab(Facade);
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
            if (interactor == null)
            {
                return;
            }

            interactor.Ungrab();

            //If the ungrab hasn't happened for some reason, then let's check to see if the interactor is still grabbing and force a stop grab.
            if (GrabbingInteractors.Contains(interactor))
            {
                GrabReceiver.UngrabConsumer.Consume(interactor.GrabConfiguration.StopGrabbingPublisher.Payload, null);
            }
        }

        /// <summary>
        /// Notifies that the Interactable is being grabbed.
        /// </summary>
        /// <param name="data">The grabbing object.</param>
        public virtual void NotifyGrab(GameObject data)
        {
            InteractorFacade interactor = data.TryGetComponent<InteractorFacade>(true, true);
            if (interactor == null)
            {
                return;
            }

            if (Facade.GrabbingInteractors.Count == 1 || PrimaryGrabIsNone(1))
            {
                Facade.FirstGrabbed?.Invoke(interactor);
            }
            Facade.Grabbed?.Invoke(interactor);
            interactor.NotifyOfGrab(Facade);
        }

        /// <summary>
        /// Notifies that the Interactable is no longer being grabbed.
        /// </summary>
        /// <param name="data">The previous grabbing object.</param>
        public virtual void NotifyUngrab(GameObject data)
        {
            InteractorFacade interactor = data.TryGetComponent<InteractorFacade>(true, true);
            if (interactor == null)
            {
                return;
            }

            Facade.Ungrabbed?.Invoke(interactor);
            interactor.NotifyOfUngrab(Facade);
            if (Facade.GrabbingInteractors.Count == 0 || PrimaryGrabIsNone(0))
            {
                Facade.LastUngrabbed?.Invoke(interactor);
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

        /// <summary>
        /// Snaps the follow on the primary and secondary action if they are <see cref="GrabInteractableFollowAction"/> type.
        /// </summary>
        public virtual void SnapFollowOrientation()
        {
            if (PrimaryAction != null && PrimaryAction.GetType() == typeof(GrabInteractableFollowAction))
            {
                GrabInteractableFollowAction action = (GrabInteractableFollowAction)PrimaryAction;
                action.ForceSnapOrientation();
            }

            if (SecondaryAction != null && SecondaryAction.GetType() == typeof(GrabInteractableFollowAction))
            {
                GrabInteractableFollowAction action = (GrabInteractableFollowAction)SecondaryAction;
                action.ForceSnapOrientation();
            }
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

            action.GrabSetup = this;
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

            GrabProvider.OutputPrimaryGrabAction.Emitted.AddListener(EnableSecondaryInputActiveCollisionConsumer);
            GrabProvider.OutputPrimaryUngrabAction.Emitted.AddListener(DisableSecondaryInputActiveCollisionConsumer);
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

            GrabProvider.OutputPrimaryGrabAction.Emitted.RemoveListener(EnableSecondaryInputActiveCollisionConsumer);
            GrabProvider.OutputPrimaryUngrabAction.Emitted.RemoveListener(DisableSecondaryInputActiveCollisionConsumer);
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

            DisableSecondaryInputActiveCollisionConsumer(null);
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
        /// Determines whether the primary grab action is of type <see cref="GrabInteractableNullAction"/>.
        /// </summary>
        /// <param name="interactorCount">The amount of grabbing Interactors.</param>
        /// <returns>Whether the primary grab is of type <see cref="GrabInteractableNullAction"/>.</returns>
        protected virtual bool PrimaryGrabIsNone(int interactorCount)
        {
            bool validNullAction = false;
            if (PrimaryAction.GetType() == typeof(GrabInteractableNullAction))
            {
                GrabInteractableNullAction checkAction = (GrabInteractableNullAction)PrimaryAction;
                validNullAction = checkAction.ForceEmitEvents ? false : true;
            }
            return Facade.GrabbingInteractors.Count > interactorCount && validNullAction;
        }

        /// <summary>
        /// Enables the Secondary Input Active Collision Consumer component.
        /// </summary>
        /// <param name="_">unused</param>
        protected virtual void EnableSecondaryInputActiveCollisionConsumer(GameObject _)
        {
            SecondaryAction.InputActiveCollisionConsumer.enabled = true;
        }

        /// <summary>
        /// Disables the Secondary Input Active Collision Consumer component.
        /// </summary>
        /// <param name="_">unused</param>
        protected virtual void DisableSecondaryInputActiveCollisionConsumer(GameObject _)
        {
            SecondaryAction.InputActiveCollisionConsumer.enabled = false;
        }

        /// <summary>
        /// Called after <see cref="PrimaryAction"/> has been changed.
        /// </summary>
        protected virtual void OnBeforePrimaryActionChange()
        {
            UnlinkToPrimaryAction();
        }

        /// <summary>
        /// Called after <see cref="PrimaryAction"/> has been changed.
        /// </summary>
        protected virtual void OnAfterPrimaryActionChange()
        {
            LinkToPrimaryAction();
            ConfigureActionContainer(PrimaryAction);
        }

        /// <summary>
        /// Called after <see cref="SecondaryAction"/> has been changed.
        /// </summary>
        protected virtual void OnBeforeSecondaryActionChange()
        {
            UnlinkToSecondaryAction();
        }

        /// <summary>
        /// Called after <see cref="SecondaryAction"/> has been changed.
        /// </summary>
        protected virtual void OnAfterSecondaryActionChange()
        {
            LinkToSecondaryAction();
            ConfigureActionContainer(SecondaryAction);
        }
    }
}