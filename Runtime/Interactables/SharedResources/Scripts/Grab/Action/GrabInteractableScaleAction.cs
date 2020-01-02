namespace Tilia.Interactions.Interactables.Grab.Action
{
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Tracking.Modification;

    /// <summary>
    /// Describes an action that allows the Interactable to be scaled in size between the points of two specified Interactors.
    /// </summary>
    public class GrabInteractableScaleAction : GrabInteractableAction
    {
        #region Interactable Settings
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Modification.PinchScaler"/> to process the scale control.
        /// </summary>
        [Serialized]
        [field: Header("Interactable Settings"), DocumentedByXml, Restricted]
        public PinchScaler PinchScaler { get; protected set; }
        #endregion

        /// <inheritdoc />
        protected override void OnAfterGrabSetupChange()
        {
            PinchScaler.Target = GrabSetup.Facade.Configuration.ConsumerContainer;
        }
    }
}