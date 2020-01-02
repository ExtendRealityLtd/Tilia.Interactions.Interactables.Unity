namespace Tilia.Interactions.Interactables.Interactors
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// The public interface into the Interactor Action Publisher Prefab.
    /// </summary>
    public class InteractorActionPublisherFacade : MonoBehaviour
    {
        #region Action Settings
        /// <summary>
        /// The <see cref="Action"/> to be monitored to control the interaction.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Action Settings"), DocumentedByXml]
        public Action SourceAction { get; set; }
        /// <summary>
        /// The source <see cref="InteractorFacade"/> that the action will be processed through.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public InteractorFacade SourceInteractor { get; set; }
        /// <summary>
        /// An indentifier for the publisher that is used by the Action Receiver to create the link between publisher and receiver.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public string PublisherIdentifier { get; set; } = "ActionPublisher";
        #endregion

        #region Reference Settings
        /// <summary>
        /// The <see cref="Action"/> that will be linked to the <see cref="SourceAction"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public InteractorActionPublisherConfigurator Configuration { get; protected set; }
        #endregion

        /// <summary>
        /// The current active <see cref="Action"/>.
        /// </summary>
        public Action ActiveAction => Configuration.ActiveAction;

        /// <summary>
        /// Called after <see cref="SourceAction"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(SourceAction))]
        protected virtual void OnAfterSourceActionChange()
        {
            Configuration.LinkSourceActionToTargetAction();
        }

        /// <summary>
        /// Called before <see cref="SourceInteractor"/> has been changed.
        /// </summary>
        [CalledBeforeChangeOf(nameof(SourceInteractor))]
        protected virtual void OnBeforeSourceInteractorChange()
        {
            Configuration.UnlinkActiveCollisions();
        }

        /// <summary>
        /// Called after <see cref="SourceInteractor"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(SourceInteractor))]
        protected virtual void OnAfterSourceInteractorChange()
        {
            Configuration.LinkSourceContainerToPublishers();
            Configuration.LinkActiveCollisions();
        }

        /// <summary>
        /// Called after <see cref="PublisherIdentifier"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(PublisherIdentifier))]
        protected virtual void OnAfterPublisherIdentifierChange()
        {
            Configuration.SetPublisherTags();
        }
    }
}