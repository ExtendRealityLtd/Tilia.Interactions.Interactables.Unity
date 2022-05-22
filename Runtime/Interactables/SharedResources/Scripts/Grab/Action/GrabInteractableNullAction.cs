namespace Tilia.Interactions.Interactables.Interactables.Grab.Action
{
    using UnityEngine;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// Describes an action that performs no action.
    /// </summary>
    public class GrabInteractableNullAction : GrabInteractableAction
    {
        [Tooltip("The container of the grab event logic.")]
        [SerializeField]
        [Restricted]
        private GameObject grabEventContainer;
        /// <summary>
        /// The container of the grab event logic.
        /// </summary>
        public GameObject GrabEventContainer
        {
            get
            {
                return grabEventContainer;
            }
            protected set
            {
                grabEventContainer = value;
            }
        }
        [Tooltip("The container of the ungrab event logic.")]
        [SerializeField]
        [Restricted]
        private GameObject ungrabEventContainer;
        /// <summary>
        /// The container of the ungrab event logic.
        /// </summary>
        public GameObject UngrabEventContainer
        {
            get
            {
                return ungrabEventContainer;
            }
            protected set
            {
                ungrabEventContainer = value;
            }
        }
        [Tooltip("Determines whether to force the grabbed/ungrabbed events even though no grab is occurring.")]
        [SerializeField]
        private bool forceEmitEvents;
        /// <summary>
        /// Determines whether to force the grabbed/ungrabbed events even though no grab is occurring.
        /// </summary>
        public bool ForceEmitEvents
        {
            get
            {
                return forceEmitEvents;
            }
            set
            {
                forceEmitEvents = value;
            }
        }

        protected virtual void OnEnable()
        {
            OnForceEmitEventsChange();
        }

        /// <summary>
        /// Called after <see cref="ForceEmitEvents"/> has been changed.
        /// </summary>
        protected virtual void OnForceEmitEventsChange()
        {
            GrabEventContainer.SetActive(ForceEmitEvents);
            UngrabEventContainer.SetActive(ForceEmitEvents);
        }
    }
}