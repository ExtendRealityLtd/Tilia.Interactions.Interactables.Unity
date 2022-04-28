namespace Tilia.Interactions.Interactables.Interactables
{
    using System;
    using System.Collections;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Extension;

    /// <summary>
    /// Attempts to grab the given Interactable to the given Interactor.
    /// </summary>
    public class InteractableGrabber : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="InteractableFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractableFacade> { }

        [Tooltip("The Interactor to grab to.")]
        [SerializeField]
        private InteractorFacade interactor;
        /// <summary>
        /// The Interactor to grab to.
        /// </summary>
        public InteractorFacade Interactor
        {
            get
            {
                return interactor;
            }
            set
            {
                interactor = value;
            }
        }
        [Tooltip("The Interactable to grab.")]
        [SerializeField]
        private InteractableFacade interactable;
        /// <summary>
        /// The Interactable to grab.
        /// </summary>
        public InteractableFacade Interactable
        {
            get
            {
                return interactable;
            }
            set
            {
                interactable = value;
            }
        }

        /// <summary>
        /// Emitted when the Grab has occurred.
        /// </summary>
        public UnityEvent Grabbed = new UnityEvent();

        /// <summary>
        /// A reusable instance of <see cref="WaitForEndOfFrame"/>.
        /// </summary>
        protected static readonly WaitForEndOfFrame DelayInstruction = new WaitForEndOfFrame();
        /// <summary>
        /// The routine for managing the grab.
        /// </summary>
        protected Coroutine grabRoutine;

        /// <summary>
        /// Clears <see cref="Interactor"/>.
        /// </summary>
        public virtual void ClearInteractor()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Interactor = default;
        }

        /// <summary>
        /// Clears <see cref="Interactable"/>.
        /// </summary>
        public virtual void ClearInteractable()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Interactable = default;
        }

        /// <summary>
        /// Sets the <see cref="InteractorFacade"/> from the given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="interactor">The object to search for the Interactor on.</param>
        public virtual void SetInteractorFromGameObject(GameObject interactor)
        {
            Interactor = interactor.TryGetComponent<InteractorFacade>(true, true);
        }

        /// <summary>
        /// Sets the <see cref="InteractableFacade"/> from the given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="interactable">The object to search for the Interactable on.</param>
        public virtual void SetInteractableFromGameObject(GameObject interactable)
        {
            Interactable = interactable.TryGetComponent<InteractableFacade>(true, true);
        }

        /// <summary>
        /// Attempts to grab the <see cref="Interactable"/> to the <see cref="Interactor"/>.
        /// </summary>
        public virtual void DoGrab()
        {
            if (!this.IsValidState() || Interactor == null || Interactable == null)
            {
                return;
            }

            if (Interactable.IsGrabbed)
            {
                Interactable.Ungrab();
            }

            CancelGrabRoutine();
            grabRoutine = StartCoroutine(GrabAtEndOfFrame());
        }

        protected virtual void OnDisable()
        {
            CancelGrabRoutine();
        }

        /// <summary>
        /// Performs the grab at the end of the current frame.
        /// </summary>
        /// <returns>Coroutine enumerator.</returns>
        protected virtual IEnumerator GrabAtEndOfFrame()
        {
            yield return DelayInstruction;

            if (Interactor.GrabConfiguration.GrabAction.Value)
            {
                bool cachedSetting = Interactor.GrabConfiguration.TouchBeforeForceGrab;
                Interactor.GrabConfiguration.TouchBeforeForceGrab = false;
                Interactor.Grab(Interactable);
                Interactor.GrabConfiguration.TouchBeforeForceGrab = cachedSetting;
                Grabbed?.Invoke(Interactable);
            }
        }

        /// <summary>
        /// Cancels the existing running grab coroutine.
        /// </summary>
        protected virtual void CancelGrabRoutine()
        {
            if (grabRoutine == null)
            {
                return;
            }

            StopCoroutine(grabRoutine);
            grabRoutine = null;
        }
    }
}