namespace Tilia.Interactions.Interactables
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using Tilia.Interactions.Interactables.Grab;
    using Tilia.Interactions.Interactables.Touch;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Rule;
    using Zinnia.Tracking.Collision;

    public class InteractableConfigurator : MonoBehaviour
    {
        #region Facade Settings
        /// <summary>
        /// The public interface facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public InteractableFacade Facade { get; protected set; }
        #endregion

        #region Restriction Settings
        /// <summary>
        /// The rule to determine what is not allowed to touch this interactable.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Restriction Settings"), DocumentedByXml]
        public RuleContainer DisallowedTouchInteractors { get; set; }
        /// <summary>
        /// The rule to determine what is not allowed to grab this interactable.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public RuleContainer DisallowedGrabInteractors { get; set; }
        #endregion

        #region Container Settings
        /// <summary>
        /// The overall container for the interactable consumers.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Container Settings"), DocumentedByXml]
        public GameObject ConsumerContainer { get; set; }
        [Serialized, Cleared]
        [field: DocumentedByXml]
        /// <summary>
        /// The <see cref="Rigidbody"/> for the overall collisions.
        /// </summary>
        public Rigidbody ConsumerRigidbody { get; set; }
        #endregion

        #region Reference Settings
        /// <summary>
        /// The linked <see cref="CollisionNotifier"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public CollisionNotifier CollisionNotifier { get; protected set; }
        /// <summary>
        /// The <see cref="GameObject"/> that contains the mesh for the Interactable.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObject MeshContainer { get; protected set; }
        /// <summary>
        /// The linked <see cref="GameObjectObservableList"/>.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObjectObservableList ActiveCollisions { get; protected set; }
        /// <summary>
        /// The linked Touch Internal Setup.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public TouchInteractableConfigurator TouchConfiguration { get; protected set; }
        /// <summary>
        /// The linked Grab Internal Setup.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GrabInteractableConfigurator GrabConfiguration { get; protected set; }
        #endregion

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
        [CalledAfterChangeOf(nameof(DisallowedTouchInteractors))]
        protected virtual void OnAfterDisallowedTouchInteractorsChange()
        {
            TouchConfiguration.TouchValidity.ReceiveValidity = DisallowedTouchInteractors;
        }

        /// <summary>
        /// Called after <see cref="DisallowedGrabInteractors"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(DisallowedGrabInteractors))]
        protected virtual void OnAfterDisallowedGrabInteractorsChange()
        {
            GrabConfiguration.GrabReceiver.GrabValidity.ReceiveValidity = DisallowedGrabInteractors;
        }

        /// <summary>
        /// Called after <see cref="ConsumerContainer"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(ConsumerContainer))]
        protected virtual void OnAfterConsumerContainerChange()
        {
            ConfigureContainer();
        }

        /// <summary>
        /// Called after <see cref="ConsumerRigidbody"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(ConsumerRigidbody))]
        protected virtual void OnAfterConsumerRigidbodyChange()
        {
            ConfigureContainer();
        }
    }
}