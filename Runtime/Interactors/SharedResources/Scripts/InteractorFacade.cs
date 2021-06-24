namespace Tilia.Interactions.Interactables.Interactors
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Action;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Type;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision;
    using Zinnia.Tracking.Velocity;

    /// <summary>
    /// The public interface into the Interactor Prefab.
    /// </summary>
    public class InteractorFacade : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="InteractableFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractableFacade> { }

        #region Interactor Settings
        /// <summary>
        /// The <see cref="BooleanAction"/> that will initiate the Interactor grab mechanism.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Interactor Settings"), DocumentedByXml]
        public BooleanAction GrabAction { get; set; }
        /// <summary>
        /// The <see cref="VelocityTracker"/> to measure the interactors current velocity.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public VelocityTracker VelocityTracker { get; set; }
        /// <summary>
        /// The time between initiating the <see cref="GrabAction"/> and touching an Interactable to be considered a valid grab.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public float GrabPrecognition { get; set; } = 0.1f;
        #endregion

        #region Interactor Events
        /// <summary>
        /// Emitted when the Interactor starts touching a valid Interactable.
        /// </summary>
        [Header("Interactor Events"), DocumentedByXml]
        public UnityEvent Touched = new UnityEvent();
        /// <summary>
        /// Emitted when the Interactor stops touching a valid Interactable.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Untouched = new UnityEvent();
        /// <summary>
        /// Emitted when the Interactor starts grabbing a valid Interactable.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Grabbed = new UnityEvent();
        /// <summary>
        /// Emitted when the Interactor stops grabbing a valid Interactable.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Ungrabbed = new UnityEvent();
        #endregion

        #region Reference Settings
        /// <summary>
        /// The point at which the grabbed Interactable will be attached to the Interactor.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Reference Settings"), DocumentedByXml]
        public GameObject GrabAttachPoint { get; set; }
        /// <summary>
        /// The point at which the grabbed Interactable will be attached to the Interactor via precision grabbing.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObject PrecisionAttachPoint { get; protected set; }
        /// <summary>
        /// The container of the Interactor avatar components.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObject AvatarContainer { get; protected set; }
        /// <summary>
        /// The linked Touch Internal Setup.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public TouchInteractorConfigurator TouchConfiguration { get; protected set; }
        /// <summary>
        /// The linked Grab Internal Setup.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GrabInteractorConfigurator GrabConfiguration { get; protected set; }
        #endregion

        /// <summary>
        /// A collection of currently touched GameObjects.
        /// </summary>
        public IReadOnlyList<GameObject> TouchedObjects => TouchConfiguration.TouchedObjects;
        /// <summary>
        /// The currently active touched GameObject.
        /// </summary>
        public GameObject ActiveTouchedObject => TouchConfiguration.ActiveTouchedObject;
        /// <summary>
        /// A collection of currently grabbed GameObjects.
        /// </summary>
        public IReadOnlyList<GameObject> GrabbedObjects => GrabConfiguration.GrabbedObjects;

        /// <summary>
        /// The routine for clearing grab state.
        /// </summary>
        protected Coroutine ClearGrabStateRoutine;
        /// <summary>
        /// A reusable instance of <see cref="WaitForEndOfFrame"/>.
        /// </summary>
        protected WaitForEndOfFrame delayInstruction = new WaitForEndOfFrame();

        /// <summary>
        /// Simulates this Interactor touching a given Interactable.
        /// </summary>
        /// <param name="interactable">The GameObject containing the Interactable.</param>
        public virtual void SimulateTouch(GameObject interactable)
        {
            if (interactable == null)
            {
                return;
            }

            GetComponent<CollisionTracker>().OnCollisionStarted(CreateCollisionPayload(interactable));
        }

        /// <summary>
        /// Simulates this Interactor touching a given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable.</param>
        public virtual void SimulateTouch(InteractableFacade interactable)
        {
            if (interactable == null)
            {
                return;
            }

            SimulateTouch(interactable.gameObject);
        }

        /// <summary>
        /// Simulates this Interactor untouching a given Interactable.
        /// </summary>
        /// <param name="interactable">The GameObject containing the Interactable.</param>
        public virtual void SimulateUntouch(GameObject interactable)
        {
            if (interactable == null)
            {
                return;
            }

            GetComponent<CollisionTracker>().OnCollisionStopped(CreateCollisionPayload(interactable));
        }

        /// <summary>
        /// Simulates this Interactor untouching a given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable.</param>
        public virtual void SimulateUntouch(InteractableFacade interactable)
        {
            if (interactable == null)
            {
                return;
            }

            SimulateUntouch(interactable.gameObject);
        }

        /// <summary>
        /// Attempt to attach a <see cref="GameObject"/> that contains an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/> and ungrabs any existing grab.
        /// </summary>
        /// <param name="interactable">The GameObject that the Interactable is on.</param>
        public virtual void Grab(GameObject interactable)
        {
            Grab(interactable, true);
        }

        /// <summary>
        /// Attempt to attach a <see cref="GameObject"/> that contains an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/> and does not ungrab any existing grab.
        /// </summary>
        /// <param name="interactable">The GameObject that the Interactable is on.</param>
        public virtual void GrabIgnoreUngrab(GameObject interactable)
        {
            Grab(interactable, false);
        }

        /// <summary>
        /// Attempt to attach a <see cref="GameObject"/> that contains an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/>.
        /// </summary>
        /// <param name="interactable">The GameObject that the Interactable is on.</param>
        /// <param name="ungrabExistingGrab">Whether to ungrab any existing grab.</param>
        public virtual void Grab(GameObject interactable, bool ungrabExistingGrab)
        {
            Grab(interactable.TryGetComponent<InteractableFacade>(true, true), ungrabExistingGrab);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/> and ungrabs any existing grab.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        public virtual void Grab(InteractableFacade interactable)
        {
            Grab(interactable, true);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/> and does not ungrab any existing grab.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        public virtual void GrabIgnoreUngrab(InteractableFacade interactable)
        {
            Grab(interactable, false);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/>.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        /// <param name="ungrabExistingGrab">Whether to ungrab any existing grab.</param>
        public virtual void Grab(InteractableFacade interactable, bool ungrabExistingGrab)
        {
            Grab(interactable, null, null, ungrabExistingGrab);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> found in the given <see cref="SurfaceData"/> to this <see cref="InteractorFacade"/> and ungrabs any existing grab.
        /// </summary>
        /// <param name="data">The collision data containing a valid Interactable.</param>
        public virtual void Grab(SurfaceData data)
        {
            Grab(data, true);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> found in the given <see cref="SurfaceData"/> to this <see cref="InteractorFacade"/> and does not ungrab any existing grab.
        /// </summary>
        /// <param name="data">The collision data containing a valid Interactable.</param>
        public virtual void GrabIgnoreUngrab(SurfaceData data)
        {
            Grab(data, false);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> found in the given <see cref="SurfaceData"/> to this <see cref="InteractorFacade"/>.
        /// </summary>
        /// <param name="data">The collision data containing a valid Interactable.</param>
        /// <param name="ungrabExistingGrab">Whether to ungrab any existing grab.</param>
        public virtual void Grab(SurfaceData data, bool ungrabExistingGrab)
        {
            if (data == null || data.CollisionData.transform == null)
            {
                return;
            }

            Grab(data.CollisionData.transform.gameObject.TryGetComponent<InteractableFacade>(true, true), null, null, ungrabExistingGrab);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/> utilizing custom collision data and ungrabs any existing grab.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        /// <param name="collision">Custom collision data.</param>
        /// <param name="collider">Custom collider data.</param>
        public virtual void Grab(InteractableFacade interactable, Collision collision, Collider collider)
        {
            GrabConfiguration.Grab(interactable, collision, collider, true);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/> utilizing custom collision data and does not ungrab any existing grab.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        /// <param name="collision">Custom collision data.</param>
        /// <param name="collider">Custom collider data.</param>
        public virtual void GrabIgnoreUngrab(InteractableFacade interactable, Collision collision, Collider collider)
        {
            GrabConfiguration.Grab(interactable, collision, collider, false);
        }

        /// <summary>
        /// Attempt to attach an <see cref="InteractableFacade"/> to this <see cref="InteractorFacade"/> utilizing custom collision data.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        /// <param name="collision">Custom collision data.</param>
        /// <param name="collider">Custom collider data.</param>
        /// <param name="ungrabExistingGrab">Whether to ungrab any existing grab.</param>
        public virtual void Grab(InteractableFacade interactable, Collision collision, Collider collider, bool ungrabExistingGrab)
        {
            GrabConfiguration.Grab(interactable, collision, collider, ungrabExistingGrab);
        }

        /// <summary>
        /// Attempt to ungrab currently grabbed Interactables to the current Interactor.
        /// </summary>
        public virtual void Ungrab()
        {
            GrabConfiguration.Ungrab();
        }

        /// <summary>
        /// Notifies the Interactor that it is touching an Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable being touched.</param>
        public virtual void NotifyOfTouch(InteractableFacade interactable)
        {
            TouchConfiguration.IsTouchingAction.Receive(true);
            Touched?.Invoke(interactable);
        }

        /// <summary>
        /// Notifies the Interactor that it is no longer touching an Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable being untouched.</param>
        public virtual void NotifyOfUntouch(InteractableFacade interactable)
        {
            TouchConfiguration.IsTouchingAction.Receive(false);
            Untouched?.Invoke(interactable);
        }

        /// <summary>
        /// Notifies the Interactor that it is grabbing an Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable being grabbed.</param>
        public virtual void NotifyOfGrab(InteractableFacade interactable)
        {
            GrabConfiguration.GrabbedObjectsCollection.AddUnique(interactable.gameObject);
            if (ClearGrabStateRoutine != null)
            {
                StopCoroutine(ClearGrabStateRoutine);
                ClearGrabStateRoutine = null;
            }
            GrabConfiguration.IsGrabbingAction.Receive(true);
            Grabbed?.Invoke(interactable);
        }

        /// <summary>
        /// Notifies the Interactor that it is no longer grabbing an Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable being ungrabbed.</param>
        public virtual void NotifyOfUngrab(InteractableFacade interactable)
        {
            ClearGrabState(interactable);
            Ungrabbed?.Invoke(interactable);
            ClearGrabStateRoutine = StartCoroutine(ClearGrabStateAtEndOfFrame(interactable));
        }

        /// <summary>
        /// Snaps the orientation of all grabbed Interactables to this Interactor.
        /// </summary>
        public virtual void SnapAllGrabbedInteractableOrientations()
        {
            for (int index = 0; index < GrabbedObjects.Count; index++)
            {
                SnapGrabbedInteractableOrientation(index);
            }
        }

        /// <summary>
        /// Snaps the orientation of the grabbed Interactable at the given index to this Interactor.
        /// </summary>
        /// <param name="index">The index of the grabbed Interactable.</param>
        public virtual void SnapGrabbedInteractableOrientation(int index)
        {
            if (index < 0 || index >= GrabbedObjects.Count)
            {
                return;
            }

            InteractableFacade interactable = GrabbedObjects[index].TryGetComponent<InteractableFacade>(true, true);
            if (interactable != null)
            {
                interactable.SnapFollowOrientation();
            }
        }

        /// <summary>
        /// Creates a collision payload for a given Interactable <see cref="GameObject"/>
        /// </summary>
        /// <param name="interactable">The GameObject that the Interactable is on.</param>
        /// <returns>A collision payload.</returns>
        protected virtual CollisionNotifier.EventData CreateCollisionPayload(GameObject interactable)
        {
            return new CollisionNotifier.EventData()
            {
                ForwardSource = GetComponent<CollisionTracker>(),
                IsTrigger = true,
                CollisionData = null,
                ColliderData = interactable.GetComponentInChildren<Collider>()
            };
        }

        /// <summary>
        /// Clears the grab state for the given <see cref="InteractableFacade"/>.
        /// </summary>
        /// <param name="interactable">The Interactable to clear grab state on.</param>
        protected virtual void ClearGrabState(InteractableFacade interactable)
        {
            GrabConfiguration.IsGrabbingAction.Receive(false);
            GrabConfiguration.GrabbedObjectsCollection.Remove(interactable.TryGetGameObject());
            GrabConfiguration.GrabbedObjectsCollection.Remove(interactable.Configuration.ConsumerContainer);
            GrabConfiguration.StopGrabbingPublisher.ClearActiveCollisions();
            GrabConfiguration.StartGrabbingPublisher.RegisteredConsumerContainer.UnregisterConsumersOnContainer(interactable.Configuration.ConsumerContainer);
        }

        /// <summary>
        /// Clears the grab state at the end of the frame.
        /// </summary>
        /// <param name="interactable"></param>
        /// <returns>An Enumerator to manage the running of the Coroutine.</returns>
        protected virtual IEnumerator ClearGrabStateAtEndOfFrame(InteractableFacade interactable)
        {
            yield return delayInstruction;
            ClearGrabState(interactable);
            ClearGrabStateRoutine = null;
        }

        /// <summary>
        /// Called after <see cref="GrabAction"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(GrabAction))]
        protected virtual void OnAfterGrabActionChange()
        {
            GrabConfiguration.ConfigureGrabAction();
        }

        /// <summary>
        /// Called after <see cref="VelocityTracker"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(VelocityTracker))]
        protected virtual void OnAfterVelocityTrackerChange()
        {
            GrabConfiguration.ConfigureVelocityTrackers();
        }

        /// <summary>
        /// Called after <see cref="GrabPrecognition"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(GrabPrecognition))]
        protected virtual void OnAfterGrabPrecognitionChange()
        {
            GrabConfiguration.ConfigureGrabPrecognition();
        }
    }
}