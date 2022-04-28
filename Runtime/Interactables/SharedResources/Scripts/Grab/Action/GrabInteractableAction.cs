namespace Tilia.Interactions.Interactables.Interactables.Grab.Action
{
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Event.Proxy;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision.Active.Event.Proxy;

    /// <summary>
    /// Describes an action to perform when a Grab Process is executed.
    /// </summary>
    public class GrabInteractableAction : MonoBehaviour
    {
        #region Input Settings
        [Header("Input Settings")]
        [Tooltip("The input ActiveCollisionConsumerEventProxyEmitter for the grab action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumerEventProxyEmitter inputActiveCollisionConsumer;
        /// <summary>
        /// The input <see cref="ActiveCollisionConsumerEventProxyEmitter"/> for the grab action.
        /// </summary>
        public ActiveCollisionConsumerEventProxyEmitter InputActiveCollisionConsumer
        {
            get
            {
                return inputActiveCollisionConsumer;
            }
            protected set
            {
                inputActiveCollisionConsumer = value;
            }
        }
        [Tooltip("The input GameObjectEventProxyEmitter for the grab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter inputGrabReceived;
        /// <summary>
        /// The input <see cref="GameObjectEventProxyEmitter"/> for the grab action.
        /// </summary>
        public GameObjectEventProxyEmitter InputGrabReceived
        {
            get
            {
                return inputGrabReceived;
            }
            protected set
            {
                inputGrabReceived = value;
            }
        }
        [Tooltip("The input GameObjectEventProxyEmitter for the grab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter inputUngrabReceived;
        /// <summary>
        /// The input <see cref="GameObjectEventProxyEmitter"/> for the grab action.
        /// </summary>
        public GameObjectEventProxyEmitter InputUngrabReceived
        {
            get
            {
                return inputUngrabReceived;
            }
            protected set
            {
                inputUngrabReceived = value;
            }
        }
        [Tooltip("The input GameObjectEventProxyEmitter for any pre setup on grab.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter inputGrabSetup;
        /// <summary>
        /// The input <see cref="GameObjectEventProxyEmitter"/> for any pre setup on grab.
        /// </summary>
        public GameObjectEventProxyEmitter InputGrabSetup
        {
            get
            {
                return inputGrabSetup;
            }
            protected set
            {
                inputGrabSetup = value;
            }
        }
        [Tooltip("The input GameObjectEventProxyEmitter for any post reset on ungrab.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter inputUngrabReset;
        /// <summary>
        /// The input <see cref="GameObjectEventProxyEmitter"/> for any post reset on ungrab.
        /// </summary>
        public GameObjectEventProxyEmitter InputUngrabReset
        {
            get
            {
                return inputUngrabReset;
            }
            protected set
            {
                inputUngrabReset = value;
            }
        }
        #endregion

        /// <summary>
        /// Backing field for <see cref="GrabSetup"/>
        /// </summary>
        private GrabInteractableConfigurator grabSetup;
        /// <summary>
        /// The internal setup for the grab action.
        /// </summary>
        public GrabInteractableConfigurator GrabSetup
        {
            get
            {
                return grabSetup;
            }
            set
            {
                grabSetup = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterGrabSetupChange();
                }
            }
        }

        /// <summary>
        /// Notifies that the Interactable is being grabbed.
        /// </summary>
        /// <param name="data">The grabbing object.</param>
        public virtual void NotifyGrab(GameObject data)
        {
            GrabSetup.NotifyGrab(data);
        }

        /// <summary>
        /// Notifies that the Interactable is no longer being grabbed.
        /// </summary>
        /// <param name="data">The previous grabbing object.</param>
        public virtual void NotifyUngrab(GameObject data)
        {
            GrabSetup.NotifyUngrab(data);
        }

        /// <summary>
        /// Called after <see cref="GrabSetup"/> has been changed.
        /// </summary>
        protected virtual void OnAfterGrabSetupChange() { }
    }
}