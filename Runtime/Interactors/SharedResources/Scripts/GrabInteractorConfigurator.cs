namespace Tilia.Interactions.Interactables.Interactors
{
    using System.Collections;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision;
    using Zinnia.Tracking.Collision.Active;
    using Zinnia.Tracking.Velocity;
    using Zinnia.Utility;

    /// <summary>
    /// Sets up the Interactor Prefab grab settings based on the provided user settings.
    /// </summary>
    public class GrabInteractorConfigurator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private InteractorFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public InteractorFacade Facade
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

        #region Grab Settings
        [Header("Grab Settings")]
        [Tooltip("The BooleanAction that will initiate the Interactor grab mechanism.")]
        [SerializeField]
        [Restricted]
        private BooleanAction grabAction;
        /// <summary>
        /// The <see cref="BooleanAction"/> that will initiate the Interactor grab mechanism.
        /// </summary>
        public BooleanAction GrabAction
        {
            get
            {
                return grabAction;
            }
            protected set
            {
                grabAction = value;
            }
        }
        [Tooltip("The VelocityTrackerProcessor to measure the interactors current velocity for throwing on release.")]
        [SerializeField]
        [Restricted]
        private VelocityTrackerProcessor velocityTracker;
        /// <summary>
        /// The <see cref="VelocityTrackerProcessor"/> to measure the interactors current velocity for throwing on release.
        /// </summary>
        public VelocityTrackerProcessor VelocityTracker
        {
            get
            {
                return velocityTracker;
            }
            protected set
            {
                velocityTracker = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterVelocityTrackerChange();
                }
            }
        }
        [Tooltip("The ActiveCollisionPublisher for checking valid start grabbing action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionPublisher startGrabbingPublisher;
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid start grabbing action.
        /// </summary>
        public ActiveCollisionPublisher StartGrabbingPublisher
        {
            get
            {
                return startGrabbingPublisher;
            }
            protected set
            {
                startGrabbingPublisher = value;
            }
        }
        [Tooltip("The ActiveCollisionPublisher for checking valid stop grabbing action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionPublisher stopGrabbingPublisher;
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid stop grabbing action.
        /// </summary>
        public ActiveCollisionPublisher StopGrabbingPublisher
        {
            get
            {
                return stopGrabbingPublisher;
            }
            protected set
            {
                stopGrabbingPublisher = value;
            }
        }
        [Tooltip("The processor for initiating an instant grab.")]
        [SerializeField]
        [Restricted]
        private GameObject instantGrabProcessor;
        /// <summary>
        /// The processor for initiating an instant grab.
        /// </summary>
        public GameObject InstantGrabProcessor
        {
            get
            {
                return instantGrabProcessor;
            }
            protected set
            {
                instantGrabProcessor = value;
            }
        }
        [Tooltip("The processor for initiating a precognitive grab.")]
        [SerializeField]
        [Restricted]
        private GameObject precognitionGrabProcessor;
        /// <summary>
        /// The processor for initiating a precognitive grab.
        /// </summary>
        public GameObject PrecognitionGrabProcessor
        {
            get
            {
                return precognitionGrabProcessor;
            }
            protected set
            {
                precognitionGrabProcessor = value;
            }
        }
        [Tooltip("The CountdownTimer to determine grab precognition.")]
        [SerializeField]
        [Restricted]
        private CountdownTimer precognitionTimer;
        /// <summary>
        /// The <see cref="CountdownTimer"/> to determine grab precognition.
        /// </summary>
        public CountdownTimer PrecognitionTimer
        {
            get
            {
                return precognitionTimer;
            }
            protected set
            {
                precognitionTimer = value;
            }
        }
        [Tooltip("The minimum timer value for the grab precognition CountdownTimer.")]
        [SerializeField]
        [Restricted]
        private float minPrecognitionTimer = 0.01f;
        /// <summary>
        /// The minimum timer value for the grab precognition <see cref="CountdownTimer"/>.
        /// </summary>
        public float MinPrecognitionTimer
        {
            get
            {
                return minPrecognitionTimer;
            }
            protected set
            {
                minPrecognitionTimer = value;
            }
        }
        [Tooltip("The GameObjectObservableSet containing the currently grabbed objects.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList grabbedObjectsCollection;
        /// <summary>
        /// The <see cref="GameObjectObservableSet"/> containing the currently grabbed objects.
        /// </summary>
        public GameObjectObservableList GrabbedObjectsCollection
        {
            get
            {
                return grabbedObjectsCollection;
            }
            protected set
            {
                grabbedObjectsCollection = value;
            }
        }
        [Tooltip("A BooleanAction for holding the state of whether the Interactor is grabbing something.")]
        [SerializeField]
        [Restricted]
        private BooleanAction isGrabbingAction;
        /// <summary>
        /// A <see cref="BooleanAction"/> for holding the state of whether the Interactor is grabbing something.
        /// </summary>
        public BooleanAction IsGrabbingAction
        {
            get
            {
                return isGrabbingAction;
            }
            protected set
            {
                isGrabbingAction = value;
            }
        }
        [Tooltip("Whether to simulate a touch before force grabbing.")]
        [SerializeField]
        [Restricted]
        private bool touchBeforeForceGrab = true;
        /// <summary>
        /// Whether to simulate a touch before force grabbing.
        /// </summary>
        public bool TouchBeforeForceGrab
        {
            get
            {
                return touchBeforeForceGrab;
            }
            set
            {
                touchBeforeForceGrab = value;
            }
        }
        #endregion

        /// <summary>
        /// A collection of currently grabbed GameObjects.
        /// </summary>
        public virtual IReadOnlyList<GameObject> GrabbedObjects => GrabbedObjectsCollection.NonSubscribableElements;

        /// <summary>
        /// Manages the reset simulate touch logic.
        /// </summary>
        protected Coroutine simulateTouchResetRoutine;
        /// <summary>
        /// A reusable instance of event data.
        /// </summary>
        protected readonly ActiveCollisionsContainer.EventData activeCollisionsEventData = new ActiveCollisionsContainer.EventData();

        /// <summary>
        /// Clears <see cref="VelocityTracker"/>.
        /// </summary>
        public virtual void ClearVelocityTracker()
        {
            if (!this.IsValidState())
            {
                return;
            }

            VelocityTracker = default;
        }

        /// <summary>
        /// Configures the action used to control grabbing.
        /// </summary>
        public virtual void ConfigureGrabAction()
        {
            if (GrabAction != null && Facade != null && Facade.GrabAction != null)
            {
                GrabAction.RunWhenActiveAndEnabled(() => GrabAction.ClearSources());
                GrabAction.RunWhenActiveAndEnabled(() => GrabAction.AddSource(Facade.GrabAction));
            }
        }

        /// <summary>
        /// Configures the velocity tracker used for grabbing.
        /// </summary>
        public virtual void ConfigureVelocityTrackers()
        {
            if (VelocityTracker != null && Facade != null && Facade.VelocityTracker != null)
            {
                VelocityTracker.VelocityTrackers.RunWhenActiveAndEnabled(() => VelocityTracker.VelocityTrackers.Clear());
                VelocityTracker.VelocityTrackers.RunWhenActiveAndEnabled(() => VelocityTracker.VelocityTrackers.Add(Facade.VelocityTracker));
            }
        }

        /// <summary>
        /// Configures the <see cref="CountdownTimer"/> components for grab precognition.
        /// </summary>
        public virtual void ConfigureGrabPrecognition()
        {
            if (Facade.GrabPrecognition < MinPrecognitionTimer && !Facade.GrabPrecognition.ApproxEquals(0f))
            {
                Facade.GrabPrecognition = MinPrecognitionTimer;
            }

            PrecognitionTimer.StartTime = Facade.GrabPrecognition;
            ChooseGrabProcessor();
        }

        /// <summary>
        /// Attempt to grab an Interactable to the current Interactor utilizing custom collision data and ungrabs any existing grab.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        /// <param name="collision">Custom collision data.</param>
        /// <param name="collider">Custom collider data.</param>
        public virtual void Grab(InteractableFacade interactable, Collision collision, Collider collider)
        {
            Grab(interactable, collision, collider, true);
        }

        /// <summary>
        /// Attempt to grab an Interactable to the current Interactor utilizing custom collision data and does not ungrab any existing grab..
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        /// <param name="collision">Custom collision data.</param>
        /// <param name="collider">Custom collider data.</param>
        public virtual void GrabIgnoreUngrab(InteractableFacade interactable, Collision collision, Collider collider)
        {
            Grab(interactable, collision, collider, false);
        }

        /// <summary>
        /// Attempt to grab an Interactable to the current Interactor utilizing custom collision data.
        /// </summary>
        /// <param name="interactable">The Interactable to attempt to grab.</param>
        /// <param name="collision">Custom collision data.</param>
        /// <param name="collider">Custom collider data.</param>
        /// <param name="ungrabExistingGrab">Whether to ungrab any existing grab.</param>
        public virtual void Grab(InteractableFacade interactable, Collision collision, Collider collider, bool ungrabExistingGrab)
        {
            if (interactable == null)
            {
                return;
            }

            if (ungrabExistingGrab)
            {
                Ungrab();
            }

            if (TouchBeforeForceGrab)
            {
                Facade.SimulateTouch(interactable);
                CancelSimulateTouchResetRoutine();
                simulateTouchResetRoutine = StartCoroutine(
                                                ResetSimulateTouchState(interactable,
                                                                        interactable.Configuration.CollisionNotifier.enabled,
                                                                        interactable.Configuration.CollisionNotifier.ProcessCollisionsWhenDisabled));
                interactable.Configuration.CollisionNotifier.ProcessCollisionsWhenDisabled = false;
                interactable.Configuration.CollisionNotifier.enabled = false;
            }

            StartGrabbingPublisher.SetActiveCollisions(CreateActiveCollisionsEventData(interactable.gameObject, collision, collider));
            ProcessGrabAction(StartGrabbingPublisher, true);
            if (interactable.IsGrabTypeToggle)
            {
                ProcessGrabAction(StartGrabbingPublisher, false);
            }
        }

        /// <summary>
        /// Attempt to ungrab currently grabbed Interactables to the current Interactor.
        /// </summary>
        public virtual void Ungrab()
        {
            if (GrabbedObjects.Count == 0)
            {
                return;
            }

            InteractableFacade interactable = GrabbedObjects[0].TryGetComponent<InteractableFacade>(true, true);
            if (interactable.IsGrabTypeToggle)
            {
                if (StartGrabbingPublisher.Payload.ActiveCollisions.Count == 0)
                {
                    StartGrabbingPublisher.SetActiveCollisions(CreateActiveCollisionsEventData(interactable.gameObject, null, null));
                }
                ProcessGrabAction(StartGrabbingPublisher, true);
            }
            ProcessGrabAction(StopGrabbingPublisher, false);
        }

        /// <summary>
        /// Attempts to automatically emit precognition grab if there are registered consumers.
        /// </summary>
        public virtual void PrecognitionGrabForRegisteredConsumers()
        {
            if (StartGrabbingPublisher.RegisteredConsumerContainer != null &&
                StartGrabbingPublisher.RegisteredConsumerContainer.RegisteredConsumers.Count > 0)
            {
                PrecognitionTimer.EmitStatus();
            }
        }

        protected virtual void OnEnable()
        {
            ConfigureGrabAction();
            ConfigureVelocityTrackers();
            ConfigureGrabPrecognition();
        }

        protected virtual void OnDisable()
        {
            CancelSimulateTouchResetRoutine();
        }

        /// <summary>
        /// Cancels the <see cref="simulateTouchResetRoutine"/> coroutine.
        /// </summary>
        protected virtual void CancelSimulateTouchResetRoutine()
        {
            if (simulateTouchResetRoutine != null)
            {
                StopCoroutine(simulateTouchResetRoutine);
                simulateTouchResetRoutine = null;
            }
        }

        /// <summary>
        /// Resets the state set by the simulate touch logic.
        /// </summary>
        /// <param name="interactable">The interactable to reset on.</param>
        /// <param name="collisionNotifierEnabled">The value to set the <see cref="CollisionNotifier.enabled"/> value to.</param>
        /// <param name="processCollisionsWhenDisabled">The value to set the <see cref="CollisionNotifier.ProcessCollisionsWhenDisabled"/> value to.</param>
        /// <returns>An enumerator for controlling the coroutine.</returns>
        protected virtual IEnumerator ResetSimulateTouchState(InteractableFacade interactable, bool collisionNotifierEnabled, bool processCollisionsWhenDisabled)
        {
            yield return new WaitForFixedUpdate();

            if (interactable != null)
            {
                interactable.Configuration.CollisionNotifier.enabled = collisionNotifierEnabled;
                interactable.Configuration.CollisionNotifier.ProcessCollisionsWhenDisabled = processCollisionsWhenDisabled;
            }
            simulateTouchResetRoutine = null;
        }

        /// <summary>
        /// Chooses which grab processing to perform on the grab action.
        /// </summary>
        protected virtual void ChooseGrabProcessor()
        {
            bool disablePrecognition = PrecognitionTimer.StartTime.ApproxEquals(0f);
            InstantGrabProcessor.SetActive(disablePrecognition);
            PrecognitionGrabProcessor.SetActive(!disablePrecognition);
        }

        /// <summary>
        /// Processes the given collision data into a grab action based on the given state.
        /// </summary>
        /// <param name="publisher">The collision data to process.</param>
        /// <param name="actionState">The grab state to check against.</param>
        protected virtual void ProcessGrabAction(ActiveCollisionPublisher publisher, bool actionState)
        {
            InstantGrabProcessor.SetActive(false);
            PrecognitionGrabProcessor.SetActive(false);
            if (GrabAction.Value != actionState)
            {
                GrabAction.Receive(actionState);
            }
            if (GrabAction.Value)
            {
                publisher.Publish();
            }
            ChooseGrabProcessor();
        }

        /// <summary>
        /// Creates Active Collision data based on the given parameters.
        /// </summary>
        /// <param name="forwardSource">The source of the <see cref="GameObject"/> forwarding the collision data.</param>
        /// <param name="collision">The data on the point of the collision for precision grabbing.</param> 
        /// <param name="collider">The collider that has been collided with.</param>
        /// <returns></returns>
        protected virtual ActiveCollisionsContainer.EventData CreateActiveCollisionsEventData(GameObject forwardSource, Collision collision = null, Collider collider = null)
        {
            collider = collider == null ? forwardSource.GetComponentInChildren<Collider>() : collider;
            if (activeCollisionsEventData.ActiveCollisions.Count == 0)
            {
                activeCollisionsEventData.ActiveCollisions.Add(new CollisionNotifier.EventData());
            }
            activeCollisionsEventData.ActiveCollisions[0].Set(forwardSource.TryGetComponent<Component>(), collider.isTrigger, collision, collider);
            return activeCollisionsEventData;
        }

        /// <summary>
        /// Called after <see cref="VelocityTracker"/> has been changed.
        /// </summary>
        protected virtual void OnAfterVelocityTrackerChange()
        {
            ConfigureVelocityTrackers();
        }
    }
}
