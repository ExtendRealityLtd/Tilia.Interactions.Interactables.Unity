namespace Tilia.Interactions.Interactables.Interactables.Grab.Action
{
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Tracking.Modification;

    /// <summary>
    /// Describes an action that allows the Interactable to be scaled in size between the points of two specified Interactors.
    /// </summary>
    public class GrabInteractableScaleAction : GrabInteractableAction
    {
        #region Interactable Settings
        [Header("Interactable Settings")]
        [Tooltip("The Zinnia.Tracking.Modification.PinchScaler to process the scale control.")]
        [SerializeField]
        [Restricted]
        private PinchScaler pinchScaler;
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Modification.PinchScaler"/> to process the scale control.
        /// </summary>
        public PinchScaler PinchScaler
        {
            get
            {
                return pinchScaler;
            }
            protected set
            {
                pinchScaler = value;
            }
        }
        #endregion

        /// <inheritdoc />
        protected override void OnAfterGrabSetupChange()
        {
            PinchScaler.Target = GrabSetup.Facade.Configuration.ConsumerContainer;
        }
    }
}