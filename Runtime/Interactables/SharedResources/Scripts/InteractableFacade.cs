namespace Tilia.Interactions.Interactables.Interactables
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactables.Grab.Receiver;
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
        public class UnityEvent : UnityEvent<InteractorFacade> { }

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
        /// The <see cref="Rigidbody"/> attached to the Interactable.
        /// </summary>
        public Rigidbody InteractableRigidbody => Configuration.ConsumerRigidbody;
        /// <summary>
        /// The mesh container.
        /// </summary>
        public GameObject MeshContainer => Configuration.MeshContainer;
        /// <summary>
        /// Returns a <see cref="MeshRenderer"/> collection of all the <see cref="MeshContainer"/> child meshes.
        /// </summary>
        public MeshRenderer[] Meshes => MeshContainer.GetComponentsInChildren<MeshRenderer>();
        /// <summary>
        /// Returns a <see cref="Collider"/> collection of all the <see cref="MeshContainer"/> child colliders.
        /// </summary>
        public Collider[] Colliders => MeshContainer.GetComponentsInChildren<Collider>();
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
        /// Whether the touch functionality is enabled.
        /// </summary>
        public bool TouchEnabled => Configuration.TouchConfiguration.TouchConsumer.gameObject.activeInHierarchy && Configuration.TouchConfiguration.UntouchConsumer.gameObject.activeInHierarchy;
        /// <summary>
        /// Whether the grab functionality is enabled.
        /// </summary>
        public bool GrabEnabled => Configuration.GrabConfiguration.gameObject.activeInHierarchy;
        /// <summary>
        /// Whether the primary grab action functionality is enabled.
        /// </summary>
        public bool PrimaryGrabEnabled => Configuration.GrabConfiguration.PrimaryAction.gameObject.activeInHierarchy;
        /// <summary>
        /// Whether the secondary grab action functionality is enabled.
        /// </summary>
        public bool SecondaryGrabEnabled => Configuration.GrabConfiguration.PrimaryAction.gameObject.activeInHierarchy;

        /// <summary>
        /// The routine for grabbing after a certain instruction.
        /// </summary>
        protected Coroutine grabRoutine;
        /// <summary>
        /// The routine for ungrabbing after a certain instruction.
        /// </summary>
        protected Coroutine ungrabRoutine;
        /// <summary>
        /// A reusable instance of <see cref="WaitForEndOfFrame"/>.
        /// </summary>
        protected WaitForEndOfFrame delayInstruction = new WaitForEndOfFrame();

        /// <summary>
        /// Attempt to grab the Interactable to the given <see cref="GameObject"/> that contains an Interactor and ungrabs any existing grabbed Interactable.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void Grab(GameObject interactor)
        {
            Grab(interactor.TryGetComponent<InteractorFacade>(true, true));
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given <see cref="GameObject"/> that contains an Interactor and ungrabs any existing grabbed Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void GrabAtEndOfFrame(GameObject interactor)
        {
            GrabAtEndOfFrame(GetInteractorFromGameObject(interactor));
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given <see cref="GameObject"/> that contains an Interactor and does not ungrab any existing grabbed Interactable.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void GrabIgnoreUngrab(GameObject interactor)
        {
            GrabIgnoreUngrab(GetInteractorFromGameObject(interactor));
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given <see cref="GameObject"/> that contains an Interactor and does not ungrab any existing grabbed Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void GrabIgnoreUngrabAtEndOfFrame(GameObject interactor)
        {
            GrabIgnoreUngrabAtEndOfFrame(GetInteractorFromGameObject(interactor));
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and ungrabs any existing grabbed Interactable.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void Grab(InteractorFacade interactor)
        {
            Configuration.GrabConfiguration.Grab(interactor);
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and ungrabs any existing grabbed Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void GrabAtEndOfFrame(InteractorFacade interactor)
        {
            if (grabRoutine != null)
            {
                StopCoroutine(grabRoutine);
            }

            grabRoutine = StartCoroutine(DoGrabAtEndOfFrame(interactor));
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grabbed Interactable.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void GrabIgnoreUngrab(InteractorFacade interactor)
        {
            Configuration.GrabConfiguration.GrabIgnoreUngrab(interactor);
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grabbed Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        public virtual void GrabIgnoreUngrabAtEndOfFrame(InteractorFacade interactor)
        {
            if (grabRoutine != null)
            {
                StopCoroutine(grabRoutine);
            }

            grabRoutine = StartCoroutine(DoGrabIgnoreUngrabAtEndOfFrame(interactor));
        }

        /// <summary>
        /// Attempt to ungrab the Interactable to the given <see cref="GameObject"/> that contains an Interactor.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void Ungrab(GameObject interactor)
        {
            Ungrab(GetInteractorFromGameObject(interactor));
        }

        /// <summary>
        /// Attempt to ungrab the Interactable to the given <see cref="GameObject"/> that contains an Interactor at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The GameObject that the Interactor is on.</param>
        public virtual void UngrabAtEndOfFrame(GameObject interactor)
        {
            UngrabAtEndOfFrame(GetInteractorFromGameObject(interactor));
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
        /// Attempt to ungrab the Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The Interactor to ungrab from.</param>
        public virtual void UngrabAtEndOfFrame(InteractorFacade interactor)
        {
            if (ungrabRoutine != null)
            {
                StopCoroutine(ungrabRoutine);
            }

            ungrabRoutine = StartCoroutine(DoUngrabAtEndOfFrame(interactor));
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
        /// Attempt to ungrab the Interactable at a specific grabbing index at the end of the current frame.
        /// </summary>
        /// <param name="sequenceIndex">The Interactor sequence index to ungrab from.</param>
        public virtual void UngrabAtEndOfFrame(int sequenceIndex = 0)
        {
            if (ungrabRoutine != null)
            {
                StopCoroutine(ungrabRoutine);
            }

            ungrabRoutine = StartCoroutine(DoUngrabAtEndOfFrame(sequenceIndex));
        }

        /// <summary>
        /// Enables the touch logic.
        /// </summary>
        public virtual void EnableTouch()
        {
            Configuration.TouchConfiguration.TouchConsumer.gameObject.SetActive(true);
            Configuration.TouchConfiguration.UntouchConsumer.gameObject.SetActive(true);
        }

        /// <summary>
        /// Disables the touch logic.
        /// </summary>
        public virtual void DisableTouch()
        {
            Configuration.TouchConfiguration.UntouchAllTouchingInteractors();
            Configuration.TouchConfiguration.TouchConsumer.gameObject.SetActive(false);
            Configuration.TouchConfiguration.UntouchConsumer.gameObject.SetActive(false);
        }

        /// <summary>
        /// Enables the grab logic.
        /// </summary>
        public virtual void EnableGrab()
        {
            Configuration.GrabConfiguration.gameObject.SetActive(true);
        }

        /// <summary>
        /// Disables the grab logic.
        /// </summary>
        public virtual void DisableGrab()
        {
            Ungrab();
            Configuration.GrabConfiguration.gameObject.SetActive(false);
        }

        /// <summary>
        /// Enables the primary grab action logic.
        /// </summary>
        public virtual void EnablePrimaryGrabAction()
        {
            Configuration.GrabConfiguration.PrimaryAction.gameObject.SetActive(true);
        }

        /// <summary>
        /// Disables the primary grab action logic.
        /// </summary>
        public virtual void DisablePrimaryGrabAction()
        {
            Configuration.GrabConfiguration.Ungrab(0);
            Configuration.GrabConfiguration.PrimaryAction.gameObject.SetActive(false);
        }

        /// <summary>
        /// Enables the secondary grab action logic.
        /// </summary>
        public virtual void EnableSecondaryGrabAction()
        {
            Configuration.GrabConfiguration.SecondaryAction.gameObject.SetActive(true);
        }

        /// <summary>
        /// Disables the secondary grab action logic.
        /// </summary>
        public virtual void DisableSecondaryGrabAction()
        {
            Configuration.GrabConfiguration.Ungrab(1);
            Configuration.GrabConfiguration.SecondaryAction.gameObject.SetActive(false);
        }

        /// <summary>
        /// Gets the <see cref="InteractorFacade"/> from the given <see cref="GameObject"/> or if not found searches for one on all desdendants then ancestors.
        /// </summary>
        /// <param name="source">The source to search on.</param>
        /// <returns>The found component if exists.</returns>
        protected virtual InteractorFacade GetInteractorFromGameObject(GameObject source)
        {
            return source.TryGetComponent<InteractorFacade>(true, true);
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and ungrabs any existing grabbed Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        /// <returns>An Enumerator to manage the running of the Coroutine.</returns>
        protected virtual IEnumerator DoGrabAtEndOfFrame(InteractorFacade interactor)
        {
            yield return delayInstruction;
            Configuration.GrabConfiguration.Grab(interactor);
            grabRoutine = null;
        }

        /// <summary>
        /// Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grabbed Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The Interactor to attach the Interactable to.</param>
        /// <returns>An Enumerator to manage the running of the Coroutine.</returns>
        protected virtual IEnumerator DoGrabIgnoreUngrabAtEndOfFrame(InteractorFacade interactor)
        {
            yield return delayInstruction;
            Configuration.GrabConfiguration.GrabIgnoreUngrab(interactor);
            grabRoutine = null;
        }

        /// <summary>
        /// Attempt to ungrab the Interactable at the end of the current frame.
        /// </summary>
        /// <param name="interactor">The Interactor to ungrab from.</param>
        /// <returns>An Enumerator to manage the running of the Coroutine.</returns>
        protected virtual IEnumerator DoUngrabAtEndOfFrame(InteractorFacade interactor)
        {
            yield return delayInstruction;
            Configuration.GrabConfiguration.Ungrab(interactor);
            ungrabRoutine = null;
        }

        /// <summary>
        /// Attempt to ungrab the Interactable at a specific grabbing index at the end of the current frame.
        /// </summary>
        /// <param name="sequenceIndex">The Interactor sequence index to ungrab from.</param>
        /// <returns>An Enumerator to manage the running of the Coroutine.</returns>
        protected virtual IEnumerator DoUngrabAtEndOfFrame(int sequenceIndex = 0)
        {
            yield return delayInstruction;
            Configuration.GrabConfiguration.Ungrab(sequenceIndex);
            ungrabRoutine = null;
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