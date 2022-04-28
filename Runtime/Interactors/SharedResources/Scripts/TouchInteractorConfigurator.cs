namespace Tilia.Interactions.Interactables.Interactors
{
    using System.Collections.Generic;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision;
    using Zinnia.Tracking.Collision.Active;
    using Zinnia.Tracking.Collision.Active.Event.Proxy;
    using Zinnia.Tracking.Collision.Active.Operation;

    /// <summary>
    /// Sets up the Interactor Prefab touch settings based on the provided user settings.
    /// </summary>
    public class TouchInteractorConfigurator : MonoBehaviour
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

        #region Touch Settings
        [Header("Touch Settings")]
        [Tooltip("The Zinnia.Tracking.Collision.Active.ActiveCollisionsContainer that holds all current collisions.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionsContainer activeCollisionsContainer;
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Collision.Active.ActiveCollisionsContainer"/> that holds all current collisions.
        /// </summary>
        public ActiveCollisionsContainer ActiveCollisionsContainer
        {
            get
            {
                return activeCollisionsContainer;
            }
            protected set
            {
                activeCollisionsContainer = value;
            }
        }
        [Tooltip("The Slicer that holds the current active collision.")]
        [SerializeField]
        [Restricted]
        private Slicer currentActiveCollision;
        /// <summary>
        /// The <see cref="Slicer"/> that holds the current active collision.
        /// </summary>
        public Slicer CurrentActiveCollision
        {
            get
            {
                return currentActiveCollision;
            }
            protected set
            {
                currentActiveCollision = value;
            }
        }
        [Tooltip("The link to any external emitters of the touch state.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionsContainerEventProxyEmitter externalEmitters;
        /// <summary>
        /// The link to any external emitters of the touch state.
        /// </summary>
        public ActiveCollisionsContainerEventProxyEmitter ExternalEmitters
        {
            get
            {
                return externalEmitters;
            }
            protected set
            {
                externalEmitters = value;
            }
        }
        [Tooltip("The ActiveCollisionPublisher for checking valid start touching collisions.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionPublisher startTouchingPublisher;
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid start touching collisions.
        /// </summary>
        public ActiveCollisionPublisher StartTouchingPublisher
        {
            get
            {
                return startTouchingPublisher;
            }
            protected set
            {
                startTouchingPublisher = value;
            }
        }
        [Tooltip("The ActiveCollisionPublisher for checking valid stop touching collisions.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionPublisher stopTouchingPublisher;
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid stop touching collisions.
        /// </summary>
        public ActiveCollisionPublisher StopTouchingPublisher
        {
            get
            {
                return stopTouchingPublisher;
            }
            protected set
            {
                stopTouchingPublisher = value;
            }
        }
        [Tooltip("A BooleanAction for holding the state of whether the Interactor is touching something.")]
        [SerializeField]
        [Restricted]
        private BooleanAction isTouchingAction;
        /// <summary>
        /// A <see cref="BooleanAction"/> for holding the state of whether the Interactor is touching something.
        /// </summary>
        public BooleanAction IsTouchingAction
        {
            get
            {
                return isTouchingAction;
            }
            protected set
            {
                isTouchingAction = value;
            }
        }
        [Tooltip("A CollisionTracker for tracking collisions/touches on this Interactor.")]
        [SerializeField]
        [Restricted]
        private CollisionTracker touchTracker;
        /// <summary>
        /// A <see cref="CollisionTracker"/> for tracking collisions/touches on this Interactor.
        /// </summary>
        public CollisionTracker TouchTracker
        {
            get
            {
                return touchTracker;
            }
            protected set
            {
                touchTracker = value;
            }
        }
        #endregion

        /// <summary>
        /// A collection of currently touched GameObjects.
        /// </summary>
        public virtual IReadOnlyList<GameObject> TouchedObjects => GetTouchedObjects();
        /// <summary>
        /// The currently active touched GameObject.
        /// </summary>
        public virtual GameObject ActiveTouchedObject => GetActiveTouchedObject();

        /// <summary>
        /// A reusable collection to hold the returned touched objects.
        /// </summary>
        protected readonly List<GameObject> touchedObjects = new List<GameObject>();

        protected virtual void OnDisable()
        {
            StopTouchingPublisher.SetActiveCollisionsEvenWhenDisabled(StartTouchingPublisher.Payload);
            StopTouchingPublisher.ForcePublish();
        }

        /// <summary>
        /// Retrieves a collection of currently touched GameObjects.
        /// </summary>
        /// <returns>The currently touched GameObjects.</returns>
        protected virtual IReadOnlyList<GameObject> GetTouchedObjects()
        {
            touchedObjects.Clear();

            if (ActiveCollisionsContainer == null)
            {
                return touchedObjects;
            }

            foreach (CollisionNotifier.EventData element in ActiveCollisionsContainer.Elements)
            {
                touchedObjects.Add(element.ColliderData.GetContainingTransform().gameObject);
            }

            return touchedObjects;
        }

        /// <summary>
        /// Retrieves the currently active touched GameObject.
        /// </summary>
        /// <returns>The currently active touched GameObject.</returns>
        protected virtual GameObject GetActiveTouchedObject()
        {
            if (CurrentActiveCollision == null || CurrentActiveCollision.SlicedList.ActiveCollisions.Count == 0)
            {
                return null;
            }

            return CurrentActiveCollision.SlicedList.ActiveCollisions[0].ColliderData.GetContainingTransform().gameObject;
        }
    }
}