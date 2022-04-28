namespace Tilia.Interactions.Interactables.Interactables.Touch
{
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.Counter;
    using Zinnia.Data.Collection.List;
    using Zinnia.Event.Proxy;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision;
    using Zinnia.Tracking.Collision.Active;
    using Zinnia.Tracking.Collision.Active.Operation.Extraction;

    public class TouchInteractableConfigurator : MonoBehaviour
    {
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

        #region Touch Consumer Settings
        [Header("Touch Consumer Settings")]
        [Tooltip("The ActiveCollisionConsumer that listens for the touch payload.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumer touchConsumer;
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> that listens for the touch payload.
        /// </summary>
        public ActiveCollisionConsumer TouchConsumer
        {
            get
            {
                return touchConsumer;
            }
            protected set
            {
                touchConsumer = value;
            }
        }
        [Tooltip("The ActiveCollisionConsumer that listens for the untouch payload.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumer untouchConsumer;
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> that listens for the untouch payload.
        /// </summary>
        public ActiveCollisionConsumer UntouchConsumer
        {
            get
            {
                return untouchConsumer;
            }
            protected set
            {
                untouchConsumer = value;
            }
        }
        #endregion

        #region Touch Settings
        [Header("Touch Settings")]
        [Tooltip("The GameObjectObservableList that holds the current touching objects data.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList currentTouchingObjects;
        /// <summary>
        /// The <see cref="GameObjectObservableList"/> that holds the current touching objects data.
        /// </summary>
        public GameObjectObservableList CurrentTouchingObjects
        {
            get
            {
                return currentTouchingObjects;
            }
            protected set
            {
                currentTouchingObjects = value;
            }
        }
        [Tooltip("The GameObjectObservableList that holds the current untouching objects data.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList currentUntouchingObjects;
        /// <summary>
        /// The <see cref="GameObjectObservableList"/> that holds the current untouching objects data.
        /// </summary>
        public GameObjectObservableList CurrentUntouchingObjects
        {
            get
            {
                return currentUntouchingObjects;
            }
            protected set
            {
                currentUntouchingObjects = value;
            }
        }
        [Tooltip("The GameObjectEventProxyEmitter used to determine the untouch actions.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter currentUntouchingEventProxy;
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> used to determine the untouch actions.
        /// </summary>
        public GameObjectEventProxyEmitter CurrentUntouchingEventProxy
        {
            get
            {
                return currentUntouchingEventProxy;
            }
            protected set
            {
                currentUntouchingEventProxy = value;
            }
        }
        [Tooltip("The GameObjectEventProxyEmitter used to determine the touch validity.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter touchValidity;
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> used to determine the touch validity.
        /// </summary>
        public GameObjectEventProxyEmitter TouchValidity
        {
            get
            {
                return touchValidity;
            }
            protected set
            {
                touchValidity = value;
            }
        }
        #endregion

        #region Interactor Settings
        [Header("Interactor Settings")]
        [Tooltip("The ActiveCollisionsContainer for potential interactors.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionsContainer potentialInteractors;
        /// <summary>
        /// The <see cref="ActiveCollisionsContainer"/> for potential interactors.
        /// </summary>
        public ActiveCollisionsContainer PotentialInteractors
        {
            get
            {
                return potentialInteractors;
            }
            protected set
            {
                potentialInteractors = value;
            }
        }
        [Tooltip("The GameObjectObservableCounter for counting active interactors.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableCounter activeInteractorCounter;
        /// <summary>
        /// The <see cref="GameObjectObservableCounter"/> for counting active interactors.
        /// </summary>
        public GameObjectObservableCounter ActiveInteractorCounter
        {
            get
            {
                return activeInteractorCounter;
            }
            protected set
            {
                activeInteractorCounter = value;
            }
        }
        [Tooltip("The NotifierContainerExtractor for adding active interactors.")]
        [SerializeField]
        [Restricted]
        private NotifierContainerExtractor addActiveInteractor;
        /// <summary>
        /// The <see cref="NotifierContainerExtractor"/> for adding active interactors.
        /// </summary>
        public NotifierContainerExtractor AddActiveInteractor
        {
            get
            {
                return addActiveInteractor;
            }
            protected set
            {
                addActiveInteractor = value;
            }
        }
        [Tooltip("The NotifierContainerExtractor for removing active interactors.")]
        [SerializeField]
        [Restricted]
        private NotifierContainerExtractor removeActiveInteractor;
        /// <summary>
        /// The <see cref="NotifierContainerExtractor"/> for removing active interactors.
        /// </summary>
        public NotifierContainerExtractor RemoveActiveInteractor
        {
            get
            {
                return removeActiveInteractor;
            }
            protected set
            {
                removeActiveInteractor = value;
            }
        }
        #endregion

        /// <summary>
        /// A collection of Interactors that are currently touching the Interactable.
        /// </summary>
        public virtual IReadOnlyList<InteractorFacade> TouchingInteractors => GetTouchingInteractors();

        /// <summary>
        /// A reusable collection to hold the returned touching interactors.
        /// </summary>
        protected readonly List<InteractorFacade> touchingInteractors = new List<InteractorFacade>();
        /// <summary>
        /// Whether this is being first touched.
        /// </summary>
        protected bool isFirstTouched;

        /// <summary>
        /// Enforces that all the existing touching interactors are no longer actually touching.
        /// </summary>
        public virtual void UntouchAllTouchingInteractors()
        {
            for (int index = TouchingInteractors.Count - 1; index >= 0; index--)
            {
                CurrentUntouchingEventProxy.Receive(TouchingInteractors[index].gameObject);
            }
        }

        /// <summary>
        /// Notifies that the Interactable is being touched.
        /// </summary>
        /// <param name="data">The touching object.</param>
        public virtual void NotifyTouch(GameObject data)
        {
            InteractorFacade interactor = data.TryGetComponent<InteractorFacade>(true, true);
            if (interactor != null)
            {
                if (TouchingInteractors.Count <= 1 && !isFirstTouched)
                {
                    isFirstTouched = true;
                    Facade.FirstTouched?.Invoke(interactor);
                }
                Facade.Touched?.Invoke(interactor);
                interactor.NotifyOfTouch(Facade);
            }
        }

        /// <summary>
        /// Notifies that the Interactable is being no longer touched.
        /// </summary>
        /// <param name="data">The previous touching object.</param>
        public virtual void NotifyUntouch(GameObject data)
        {
            InteractorFacade interactor = data.TryGetComponent<InteractorFacade>(true, true);
            if (interactor != null)
            {
                Facade.Untouched?.Invoke(interactor);
                interactor.NotifyOfUntouch(Facade);
                if (TouchingInteractors.Count == 0)
                {
                    isFirstTouched = false;
                    Facade.LastUntouched?.Invoke(interactor);
                }
            }
        }

        /// <summary>
        /// Sets the consumer containers to the current active container.
        /// </summary>
        public virtual void ConfigureContainer()
        {
            TouchConsumer.Container = Facade.Configuration.ConsumerContainer;
            UntouchConsumer.Container = Facade.Configuration.ConsumerContainer;
        }

        /// <summary>
        /// Retrieves a collection of Interactors that are touching the Interactable.
        /// </summary>
        /// <returns>The touching Interactors.</returns>
        protected virtual IReadOnlyList<InteractorFacade> GetTouchingInteractors()
        {
            touchingInteractors.Clear();

            if (CurrentTouchingObjects == null)
            {
                return touchingInteractors;
            }

            foreach (GameObject element in CurrentTouchingObjects.NonSubscribableElements)
            {
                InteractorFacade interactor = element.TryGetComponent<InteractorFacade>(true, true);
                if (interactor != null)
                {
                    touchingInteractors.Add(interactor);
                }
            }

            return touchingInteractors;
        }

        protected virtual void OnEnable()
        {
            ConfigureContainer();
            TouchValidity.ReceiveValidity = Facade.Configuration.DisallowedTouchInteractors;
            LinkActiveInteractorCollisions();
        }

        protected virtual void OnDisable()
        {
            UnlinkActiveInteractorCollisions();
        }

        /// <summary>
        /// Links the <see cref="CollisionNotifier"/> to the potential and active interactor logic.
        /// </summary>
        protected virtual void LinkActiveInteractorCollisions()
        {
            Facade.Configuration.CollisionNotifier.CollisionStarted.AddListener(PotentialInteractors.Add);
            Facade.Configuration.CollisionNotifier.CollisionStarted.AddListener(AddActiveInteractor.DoExtract);
            Facade.Configuration.CollisionNotifier.CollisionChanged.AddListener(ProcessPotentialInteractorContentChange);
            Facade.Configuration.CollisionNotifier.CollisionStopped.AddListener(PotentialInteractors.Remove);
            Facade.Configuration.CollisionNotifier.CollisionStopped.AddListener(RemoveActiveInteractor.DoExtract);
        }

        /// <summary>
        /// Unlinks the <see cref="CollisionNotifier"/> to the potential and active interactor logic.
        /// </summary>
        protected virtual void UnlinkActiveInteractorCollisions()
        {
            Facade.Configuration.CollisionNotifier.CollisionStarted.RemoveListener(PotentialInteractors.Add);
            Facade.Configuration.CollisionNotifier.CollisionStarted.RemoveListener(AddActiveInteractor.DoExtract);
            Facade.Configuration.CollisionNotifier.CollisionChanged.RemoveListener(ProcessPotentialInteractorContentChange);
            Facade.Configuration.CollisionNotifier.CollisionStopped.RemoveListener(PotentialInteractors.Remove);
            Facade.Configuration.CollisionNotifier.CollisionStopped.RemoveListener(RemoveActiveInteractor.DoExtract);
        }

        /// <summary>
        /// Handles any change of collision contents.
        /// </summary>
        /// <param name="data">The changed collision data.</param>
        protected virtual void ProcessPotentialInteractorContentChange(CollisionNotifier.EventData data)
        {
            PotentialInteractors.ProcessContentsChanged();
        }
    }
}