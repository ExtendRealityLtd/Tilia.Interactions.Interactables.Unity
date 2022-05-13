namespace Tilia.Interactions.Interactables.Interactables.Grab.Receiver
{
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Event.Proxy;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision.Active;
    using Zinnia.Tracking.Collision.Active.Event.Proxy;

    /// <summary>
    /// Handles the way in which a grab event from an Interactor is received and processed by the Interactable.
    /// </summary>
    public class GrabInteractableReceiver : MonoBehaviour
    {
        /// <summary>
        /// The way in which the grab is kept active.
        /// </summary>
        public enum ActiveType
        {
            /// <summary>
            /// The grab will occur when the button is held down and will ungrab when the button is released.
            /// </summary>
            HoldTillRelease,
            /// <summary>
            /// The grab will occur on the first press of the button and stay grabbed until a second press of the button.
            /// </summary>
            Toggle
        }

        #region Interactable Settings
        [Header("Interactable Settings")]
        [Tooltip("The mechanism of how to keep the grab action active.")]
        [SerializeField]
        private ActiveType grabType = ActiveType.HoldTillRelease;
        /// <summary>
        /// The mechanism of how to keep the grab action active.
        /// </summary>
        public ActiveType GrabType
        {
            get
            {
                return grabType;
            }
            set
            {
                grabType = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterGrabTypeChange();
                }
            }
        }
        #endregion

        #region Grab Consumer Settings
        [Header("Grab Consumer Settings")]
        [Tooltip("The ActiveCollisionConsumer that listens for the grab payload.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumer grabConsumer;
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> that listens for the grab payload.
        /// </summary>
        public ActiveCollisionConsumer GrabConsumer
        {
            get
            {
                return grabConsumer;
            }
            protected set
            {
                grabConsumer = value;
            }
        }
        [Tooltip("The ActiveCollisionConsumer that listens for the ungrab payload.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumer ungrabConsumer;
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> that listens for the ungrab payload.
        /// </summary>
        public ActiveCollisionConsumer UngrabConsumer
        {
            get
            {
                return ungrabConsumer;
            }
            protected set
            {
                ungrabConsumer = value;
            }
        }
        #endregion

        #region Grab Action Settings
        [Header("Grab Action Settings")]
        [Tooltip("The GameObjectEventProxyEmitter used to determine the grab validity.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter grabValidity;
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> used to determine the grab validity.
        /// </summary>
        public GameObjectEventProxyEmitter GrabValidity
        {
            get
            {
                return grabValidity;
            }
            set
            {
                grabValidity = value;
            }
        }
        #endregion

        #region Active Type Settings
        [Header("Active Type Settings")]
        [Tooltip("The GameObject containing the logic for starting HoldTillRelease grabbing.")]
        [SerializeField]
        [Restricted]
        private GameObject startStateGrab;
        /// <summary>
        /// The <see cref="GameObject"/> containing the logic for starting HoldTillRelease grabbing.
        /// </summary>
        public GameObject StartStateGrab
        {
            get
            {
                return startStateGrab;
            }
            protected set
            {
                startStateGrab = value;
            }
        }
        [Tooltip("The GameObject containing the logic for ending HoldTillRelease grabbing.")]
        [SerializeField]
        [Restricted]
        private GameObject stopStateGrab;
        /// <summary>
        /// The <see cref="GameObject"/> containing the logic for ending HoldTillRelease grabbing.
        /// </summary>
        public GameObject StopStateGrab
        {
            get
            {
                return stopStateGrab;
            }
            protected set
            {
                stopStateGrab = value;
            }
        }
        [Tooltip("The GameObject containing the logic for starting and ending Toggle grabbing.")]
        [SerializeField]
        [Restricted]
        private GameObject toggleGrab;
        /// <summary>
        /// The <see cref="GameObject"/> containing the logic for starting and ending Toggle grabbing.
        /// </summary>
        public GameObject ToggleGrab
        {
            get
            {
                return toggleGrab;
            }
            protected set
            {
                toggleGrab = value;
            }
        }
        [Tooltip("The GameObjectObservableSet containing the logic for starting and ending Toggle grabbing.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList toggleList;
        /// <summary>
        /// The <see cref="GameObjectObservableSet"/> containing the logic for starting and ending Toggle grabbing.
        /// </summary>
        public GameObjectObservableList ToggleList
        {
            get
            {
                return toggleList;
            }
            protected set
            {
                toggleList = value;
            }
        }
        #endregion

        #region Output Settings
        [Header("Output Settings")]
        [Tooltip("The output ActiveCollisionConsumerEventProxyEmitter for the grab action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumerEventProxyEmitter outputActiveCollisionConsumer;
        /// <summary>
        /// The output <see cref="ActiveCollisionConsumerEventProxyEmitter"/> for the grab action.
        /// </summary>
        public ActiveCollisionConsumerEventProxyEmitter OutputActiveCollisionConsumer
        {
            get
            {
                return outputActiveCollisionConsumer;
            }
            protected set
            {
                outputActiveCollisionConsumer = value;
            }
        }
        [Tooltip("The output GameObjectEventProxyEmitter for the grab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputGrabAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the grab action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputGrabAction
        {
            get
            {
                return outputGrabAction;
            }
            protected set
            {
                outputGrabAction = value;
            }
        }
        [Tooltip("The output GameObjectEventProxyEmitter for the ungrab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputUngrabAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the ungrab action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputUngrabAction
        {
            get
            {
                return outputUngrabAction;
            }
            protected set
            {
                outputUngrabAction = value;
            }
        }
        [Tooltip("The output GameObjectEventProxyEmitter for the ungrab on untouch action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputUngrabOnUntouchAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the ungrab on untouch action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputUngrabOnUntouchAction
        {
            get
            {
                return outputUngrabOnUntouchAction;
            }
            protected set
            {
                outputUngrabOnUntouchAction = value;
            }
        }
        #endregion

        /// <summary>
        /// Sets the consumer containers to the current active container.
        /// </summary>
        /// <param name="container">The container for the consumer.</param>
        public virtual void ConfigureConsumerContainers(GameObject container)
        {
            GrabConsumer.Container = container;
            UngrabConsumer.Container = container;
        }

        /// <summary>
        /// Sets the <see cref="GrabType"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="ActiveType"/>.</param>
        public virtual void SetGrabType(int index)
        {
            GrabType = EnumExtensions.GetByIndex<ActiveType>(index);
        }

        /// <summary>
        /// Configures the Grab Type to be used.
        /// </summary>
        public virtual void ConfigureGrabType()
        {
            switch (GrabType)
            {
                case ActiveType.HoldTillRelease:
                    StartStateGrab.TrySetActive(true);
                    StopStateGrab.TrySetActive(true);
                    ToggleGrab.TrySetActive(false);
                    break;
                case ActiveType.Toggle:
                    StartStateGrab.TrySetActive(false);
                    StopStateGrab.TrySetActive(false);
                    ToggleGrab.TrySetActive(true);
                    break;
            }
        }

        protected virtual void OnEnable()
        {
            ConfigureGrabType();
        }

        /// <summary>
        /// Called after <see cref="GrabType"/> has been changed.
        /// </summary>
        protected virtual void OnAfterGrabTypeChange()
        {
            ConfigureGrabType();
        }
    }
}