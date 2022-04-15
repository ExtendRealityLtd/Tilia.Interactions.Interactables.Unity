namespace Tilia.Interactions.Interactables.Interactables
{
    using Tilia.Interactions.Interactables.Interactables.Grab;
    using Tilia.Interactions.Interactables.Interactables.Touch;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Rule;
    using Zinnia.Tracking.Collision;

    /// <summary>
    /// Sets up the Interactable Prefab based on the provided user settings.
    /// </summary>
    public class InteractableConfigurator : MonoBehaviour
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

        #region Restriction Settings
        [Header("Restriction Settings")]
        [Tooltip("The rule to determine what is not allowed to touch this interactable.")]
        [SerializeField]
        private RuleContainer disallowedTouchInteractors;
        /// <summary>
        /// The rule to determine what is not allowed to touch this interactable.
        /// </summary>
        public RuleContainer DisallowedTouchInteractors
        {
            get
            {
                return disallowedTouchInteractors;
            }
            set
            {
                disallowedTouchInteractors = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterDisallowedTouchInteractorsChange();
                }
            }
        }
        [Tooltip("The rule to determine what is not allowed to grab this interactable.")]
        [SerializeField]
        private RuleContainer disallowedGrabInteractors;
        /// <summary>
        /// The rule to determine what is not allowed to grab this interactable.
        /// </summary>
        public RuleContainer DisallowedGrabInteractors
        {
            get
            {
                return disallowedGrabInteractors;
            }
            set
            {
                disallowedGrabInteractors = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterDisallowedGrabInteractorsChange();
                }
            }
        }
        #endregion

        #region Container Settings
        [Header("Container Settings")]
        [Tooltip("The overall container for the interactable consumers.")]
        [SerializeField]
        private GameObject consumerContainer;
        /// <summary>
        /// The overall container for the interactable consumers.
        /// </summary>
        public GameObject ConsumerContainer
        {
            get
            {
                return consumerContainer;
            }
            set
            {
                consumerContainer = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterConsumerContainerChange();
                }
            }
        }
        [Tooltip("The Rigidbody for the overall collisions.")]
        [SerializeField]
        private Rigidbody consumerRigidbody;
        /// <summary>
        /// The <see cref="Rigidbody"/> for the overall collisions.
        /// </summary>
        public Rigidbody ConsumerRigidbody
        {
            get
            {
                return consumerRigidbody;
            }
            set
            {
                consumerRigidbody = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterConsumerRigidbodyChange();
                }
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked CollisionNotifier.")]
        [SerializeField]
        [Restricted]
        private CollisionNotifier collisionNotifier;
        /// <summary>
        /// The linked <see cref="CollisionNotifier"/>.
        /// </summary>
        public CollisionNotifier CollisionNotifier
        {
            get
            {
                return collisionNotifier;
            }
            protected set
            {
                collisionNotifier = value;
            }
        }
        [Tooltip("The GameObject that contains the mesh for the Interactable.")]
        [SerializeField]
        [Restricted]
        private GameObject meshContainer;
        /// <summary>
        /// The <see cref="GameObject"/> that contains the mesh for the Interactable.
        /// </summary>
        public GameObject MeshContainer
        {
            get
            {
                return meshContainer;
            }
            protected set
            {
                meshContainer = value;
            }
        }
        [Tooltip("The linked GameObjectObservableList.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList activeCollisions;
        /// <summary>
        /// The linked <see cref="GameObjectObservableList"/>.
        /// </summary>
        public GameObjectObservableList ActiveCollisions
        {
            get
            {
                return activeCollisions;
            }
            protected set
            {
                activeCollisions = value;
            }
        }
        [Tooltip("The linked Touch Internal Setup.")]
        [SerializeField]
        [Restricted]
        private TouchInteractableConfigurator touchConfiguration;
        /// <summary>
        /// The linked Touch Internal Setup.
        /// </summary>
        public TouchInteractableConfigurator TouchConfiguration
        {
            get
            {
                return touchConfiguration;
            }
            protected set
            {
                touchConfiguration = value;
            }
        }
        [Tooltip("The linked Grab Internal Setup.")]
        [SerializeField]
        [Restricted]
        private GrabInteractableConfigurator grabConfiguration;
        /// <summary>
        /// The linked Grab Internal Setup.
        /// </summary>
        public GrabInteractableConfigurator GrabConfiguration
        {
            get
            {
                return grabConfiguration;
            }
            protected set
            {
                grabConfiguration = value;
            }
        }
        #endregion

        /// <summary>
        /// Clears <see cref="DisallowedTouchInteractors"/>.
        /// </summary>
        public virtual void ClearDisallowedTouchInteractors()
        {
            if (!this.IsValidState())
            {
                return;
            }

            DisallowedTouchInteractors = default;
        }

        /// <summary>
        /// Clears <see cref="DisallowedGrabInteractors"/>.
        /// </summary>
        public virtual void ClearDisallowedGrabInteractors()
        {
            if (!this.IsValidState())
            {
                return;
            }

            DisallowedGrabInteractors = default;
        }

        /// <summary>
        /// Clears <see cref="ConsumerContainer"/>.
        /// </summary>
        public virtual void ClearConsumerContainer()
        {
            if (!this.IsValidState())
            {
                return;
            }

            ConsumerContainer = default;
        }

        /// <summary>
        /// Clears <see cref="ConsumerRigidbody"/>.
        /// </summary>
        public virtual void ClearConsumerRigidbody()
        {
            if (!this.IsValidState())
            {
                return;
            }

            ConsumerRigidbody = default;
        }

        /// <summary>
        /// Configures any container data to the sub setup components.
        /// </summary>
        protected virtual void ConfigureContainer()
        {
            TouchConfiguration.ConfigureContainer();
            GrabConfiguration.ConfigureContainer();
        }

        /// <summary>
        /// Called after <see cref="DisallowedTouchInteractors"/> has been changed.
        /// </summary>
        protected virtual void OnAfterDisallowedTouchInteractorsChange()
        {
            TouchConfiguration.TouchValidity.ReceiveValidity = DisallowedTouchInteractors;
        }

        /// <summary>
        /// Called after <see cref="DisallowedGrabInteractors"/> has been changed.
        /// </summary>
        protected virtual void OnAfterDisallowedGrabInteractorsChange()
        {
            GrabConfiguration.GrabReceiver.GrabValidity.ReceiveValidity = DisallowedGrabInteractors;
        }

        /// <summary>
        /// Called after <see cref="ConsumerContainer"/> has been changed.
        /// </summary>
        protected virtual void OnAfterConsumerContainerChange()
        {
            ConfigureContainer();
        }

        /// <summary>
        /// Called after <see cref="ConsumerRigidbody"/> has been changed.
        /// </summary>
        protected virtual void OnAfterConsumerRigidbodyChange()
        {
            ConfigureContainer();
        }
    }
}