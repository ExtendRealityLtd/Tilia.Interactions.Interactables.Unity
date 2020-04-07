namespace Tilia.Interactions.Interactables
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Grab.Receiver;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;

    /// <summary>
    /// The public interface into the Interactable Prefab.
    /// </summary>
    public class InteractableFacade : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="InteractorFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractorFacade>
        {
        }

        #region Reference Settings
        /// <summary>
        /// The linked <see cref="InteractableConfigurator"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public InteractableConfigurator Configuration { get; protected set; }
        #endregion

        #region Touch Events
        /// <summary>
        /// Emitted when the Interactable is touched for the first time by an Interactor.
        /// </summary>
        [Header("Touch Events"), DocumentedByXml]
        public UnityEvent FirstTouched = new UnityEvent();
        /// <summary>
        /// Emitted when an Interactor touches the Interactable.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Touched = new UnityEvent();
        /// <summary>
        /// Emitted when an Interactor stops touching the Interactable.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Untouched = new UnityEvent();
        /// <summary>
        /// Emitted when the Interactable is untouched for the last time by an Interactor.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent LastUntouched = new UnityEvent();
        #endregion

        #region Grab Events
        /// <summary>
        /// Emitted when the Interactable is grabbed for the first time by an Interactor.
        /// </summary>
        [Header("Grab Events"), DocumentedByXml]
        public UnityEvent FirstGrabbed = new UnityEvent();
        /// <summary>
        /// Emitted when an Interactor grabs the Interactable.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Grabbed = new UnityEvent();
        /// <summary>
        /// Emitted when an Interactor ungrabs the Interactable.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Ungrabbed = new UnityEvent();
        /// <summary>
        /// Emitted when the Interactable is ungrabbed for the last time by an Interactor.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent LastUngrabbed = new UnityEvent();
        #endregion

        #region Grab Action Settings
        /// <summary>
        /// The linked <see cref="GrabInteractableReceiver.ActiveType"/>.
        /// </summary>
        [Serialized]
        [field: Header("Grab Action Settings"), DocumentedByXml]
        public GrabInteractableReceiver.ActiveType GrabType { get; set; }
        /// <summary>
        /// The <see cref="GrabInteractableInteractorProvider"/> to use.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public int GrabProviderIndex { get; set; }
        #endregion

        /// <summary>
        /// A collection of Interactors that are currently touching the Interactable.
        /// </summary>
        public IReadOnlyList<InteractorFacade> TouchingInteractors => Configuration.TouchConfiguration.TouchingInteractors;
        /// <summary>
        /// A collection of Interactors that are currently grabbing the Interactable.
        /// </summary>
        public IReadOnlyList<InteractorFacade> GrabbingInteractors => Configuration.GrabConfiguration.GrabbingInteractors;
        /// <summary>
        /// Determines if the grab type is set to toggle.
        /// </summary>
        public bool IsGrabTypeToggle => Configuration.GrabConfiguration.IsGrabTypeToggle;
        /// <summary>
        /// Whether the Interactable is currently being touched by any valid Interactor.
        /// </summary>
        public bool IsTouched => TouchingInteractors.Count > 0;
        /// <summary>
        /// Whether the Interactable is currently being grabbed by any valid Interactor.
        /// </summary>
        public bool IsGrabbed => GrabbingInteractors.Count > 0;

        /// <summary>
        /// Attempt to grab the Interactable to the given <see cref="GameObject"/> that contains an Interactor.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void Grab(GameObject interactor)
        {
            Grab(interactor.TryGetComponent<InteractorFacade>(true, true));
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void Grab(InteractorFacade interactor)
        {
            Configuration.GrabConfiguration.Grab(interactor);
        }

        /// <summary>
        /// Attempt to ungrab the Interactable to the given <see cref="GameObject"/> that contains an Interactor.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void Ungrab(GameObject interactor)
        {
            Ungrab(interactor.TryGetComponent<InteractorFacade>(true, true));
        }

        /// <summary>
        /// Attempt to ungrab the Interactable.
        /// </summary>
        /// <param name="interactor">The Interactor to ungrab from.</param>
        public virtual void Ungrab(InteractorFacade interactor)
        {
            Configuration.GrabConfiguration.Ungrab(interactor);
        }

        /// <summary>
        /// Attempt to ungrab the Interactable at a specific grabbing index.
        /// </summary>
        /// <param name="sequenceIndex">The Interactor sequence index to ungrab from.</param>
        public virtual void Ungrab(int sequenceIndex = 0)
        {
            Configuration.GrabConfiguration.Ungrab(sequenceIndex);
        }

        /// <summary>
        /// Called after <see cref="GrabType"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(GrabType))]
        protected virtual void OnAfterGrabTypeChange()
        {
            Configuration.GrabConfiguration.GrabReceiver.GrabType = GrabType;
        }

        /// <summary>
        /// Called after <see cref="GrabProviderIndex"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(GrabProviderIndex))]
        protected virtual void OnAfterGrabProviderIndexChange()
        {
            Configuration.GrabConfiguration.SetGrabProvider(GrabProviderIndex);
        }
    }
}