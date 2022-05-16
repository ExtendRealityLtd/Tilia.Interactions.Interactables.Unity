namespace Tilia.Interactions.Interactables.Interactors
{
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Action.Collection;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision.Active;
    using Zinnia.Tracking.Collision.Active.Event.Proxy;

    /// <summary>
    /// Sets up the Interactor Action Publisher Prefab action settings based on the provided user settings.
    /// </summary>
    public class InteractorActionPublisherConfigurator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private InteractorActionPublisherFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public InteractorActionPublisherFacade Facade
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

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The ActionObservableList that contains the Action collection that can be linked to the InteractorActionFacade.SourceAction.")]
        [SerializeField]
        [Restricted]
        private ActionObservableList targetActions;
        /// <summary>
        /// The <see cref="ActionObservableList"/> that contains the <see cref="Action"/> collection that can be linked to the <see cref="InteractorActionFacade.SourceAction"/>.
        /// </summary>
        public ActionObservableList TargetActions
        {
            get
            {
                return targetActions;
            }
            protected set
            {
                targetActions = value;
            }
        }
        [Tooltip("The ActiveCollisionPublisher for checking valid start action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionPublisher startActionPublisher;
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid start action.
        /// </summary>
        public ActiveCollisionPublisher StartActionPublisher
        {
            get
            {
                return startActionPublisher;
            }
            protected set
            {
                startActionPublisher = value;
            }
        }
        [Tooltip("The ActiveCollisionPublisher for checking valid stop action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionPublisher stopActionPublisher;
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid stop action.
        /// </summary>
        public ActiveCollisionPublisher StopActionPublisher
        {
            get
            {
                return stopActionPublisher;
            }
            protected set
            {
                stopActionPublisher = value;
            }
        }
        [Tooltip("The ActiveCollisionsContainerEventProxyEmitter setting the active collisions on the StartActionPublisher on touch.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionsContainerEventProxyEmitter setOnTouchEmitter;
        /// <summary>
        /// The <see cref="ActiveCollisionsContainerEventProxyEmitter"/> setting the active collisions on the <see cref="StartActionPublisher"/> on touch.
        /// </summary>
        public ActiveCollisionsContainerEventProxyEmitter SetOnTouchEmitter
        {
            get
            {
                return setOnTouchEmitter;
            }
            protected set
            {
                setOnTouchEmitter = value;
            }
        }
        [Tooltip("The ActiveCollisionPublisherEventProxyEmitter setting the active collisions on the StartActionPublisher on grab.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionPublisherEventProxyEmitter setOnGrabEmitter;
        /// <summary>
        /// The <see cref="ActiveCollisionPublisherEventProxyEmitter"/> setting the active collisions on the <see cref="StartActionPublisher"/> on grab.
        /// </summary>
        public ActiveCollisionPublisherEventProxyEmitter SetOnGrabEmitter
        {
            get
            {
                return setOnGrabEmitter;
            }
            protected set
            {
                setOnGrabEmitter = value;
            }
        }
        #endregion

        /// <summary>
        /// The current active <see cref="Action"/>.
        /// </summary>
        public virtual Action ActiveAction { get; protected set; }

        protected virtual void OnEnable()
        {
            SetOnGrabEmitter.gameObject.SetActive(false);
            SetOnTouchEmitter.gameObject.SetActive(true);
            LinkSourceActionToTargetAction();
            LinkSourceContainerToPublishers();
            LinkActiveCollisions();
        }

        protected virtual void OnDisable()
        {
            UnlinkActiveCollisions();
        }

        /// <summary>
        /// Links the <see cref="InteractorActionFacade.SourceAction"/> to the valid <see cref="TargetActions"/> <see cref="Action"/>.
        /// </summary>
        public virtual void LinkSourceActionToTargetAction()
        {
            if (Facade == null || Facade.SourceAction == null || TargetActions == null)
            {
                return;
            }

            foreach (Action action in TargetActions.NonSubscribableElements)
            {
                action.RunWhenActiveAndEnabled(() => action.ClearSources());
                if (action.GetType().IsAssignableFrom(Facade.SourceAction.GetType()))
                {
                    action.RunWhenActiveAndEnabled(() => action.AddSource(Facade.SourceAction));
                    ActiveAction = action;
                }
            }
        }

        /// <summary>
        /// Links the <see cref="InteractorActionFacade.SourceInteractor"/> to the payload source containers on the start and stop publishers.
        /// </summary>
        public virtual void LinkSourceContainerToPublishers()
        {
            if (Facade == null || Facade.SourceInteractor == null)
            {
                return;
            }

            StartActionPublisher.Payload.SourceContainer = Facade.SourceInteractor.gameObject;
            StopActionPublisher.Payload.SourceContainer = Facade.SourceInteractor.gameObject;
        }

        /// <summary>
        /// Links the start publisher to the <see cref="InteractorActionFacade.SourceInteractor"/>.
        /// </summary>
        public virtual void LinkActiveCollisions()
        {
            if (Facade == null || Facade.SourceInteractor == null)
            {
                return;
            }

            Facade.SourceInteractor.TouchConfiguration.ExternalEmitters.Emitted.AddListener(SetOnTouchEmitter.Receive);
            Facade.SourceInteractor.GrabConfiguration.StartGrabbingPublisher.Published.AddListener(SetOnGrabEmitter.Receive);

            Facade.SourceInteractor.Grabbed.AddListener(InteractorGrabbed);
            Facade.SourceInteractor.Ungrabbed.AddListener(InteractorUngrabbed);
        }

        /// <summary>
        /// Unlinks the start publisher from the <see cref="InteractorActionFacade.SourceInteractor"/>.
        /// </summary>
        public virtual void UnlinkActiveCollisions()
        {
            if (Facade == null || Facade.SourceInteractor == null)
            {
                return;
            }

            Facade.SourceInteractor.TouchConfiguration.ExternalEmitters.Emitted.RemoveListener(SetOnTouchEmitter.Receive);
            Facade.SourceInteractor.GrabConfiguration.StartGrabbingPublisher.Published.RemoveListener(SetOnGrabEmitter.Receive);

            Facade.SourceInteractor.Grabbed.RemoveListener(InteractorGrabbed);
            Facade.SourceInteractor.Ungrabbed.RemoveListener(InteractorUngrabbed);
        }

        /// <summary>
        /// Determines what to do when the Interactor grabs.
        /// </summary>
        /// <param name="interactable">The Interactable being grabbed.</param>
        protected virtual void InteractorGrabbed(InteractableFacade interactable)
        {
            SetOnTouchEmitter.gameObject.SetActive(false);
            SetOnGrabEmitter.gameObject.SetActive(true);
        }

        /// <summary>
        /// Determines what to do when the Interactor ungrabs.
        /// </summary>
        /// <param name="interactable">The Interactable being grabbed.</param>
        protected virtual void InteractorUngrabbed(InteractableFacade interactable)
        {
            SetOnGrabEmitter.gameObject.SetActive(false);
            SetOnTouchEmitter.gameObject.SetActive(true);
        }
    }
}