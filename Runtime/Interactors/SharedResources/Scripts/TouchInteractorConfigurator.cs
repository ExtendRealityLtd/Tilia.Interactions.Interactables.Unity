namespace Tilia.Interactions.Interactables.Interactors
{
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System.Collections.Generic;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision;
    using Zinnia.Tracking.Collision.Active;
    using Zinnia.Tracking.Collision.Active.Event.Proxy;
    using Zinnia.Tracking.Collision.Active.Operation;

    /// <summary>
    /// Sets up the Interactor Prefab touch settings based on the provided user settings.
    /// </summary>
    public class TouchInteractorConfigurator : MonoBehaviour
    {
        #region Facade Settings
        /// <summary>
        /// The public interface facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public InteractorFacade Facade { get; protected set; }
        #endregion

        #region Touch Settings
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Collision.Active.ActiveCollisionsContainer"/> that holds all current collisions.
        /// </summary>
        [Serialized]
        [field: Header("Touch Settings"), DocumentedByXml, Restricted]
        public ActiveCollisionsContainer ActiveCollisionsContainer { get; protected set; }
        /// <summary>
        /// The <see cref="Slicer"/> that holds the current active collision.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public Slicer CurrentActiveCollision { get; protected set; }
        /// <summary>
        /// The link to any external emitters of the touch state.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActiveCollisionsContainerEventProxyEmitter ExternalEmitters { get; protected set; }
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid start touching collisions.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActiveCollisionPublisher StartTouchingPublisher { get; protected set; }
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid stop touching collisions.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActiveCollisionPublisher StopTouchingPublisher { get; protected set; }
        #endregion

        /// <summary>
        /// A collection of currently touched GameObjects.
        /// </summary>
        public IReadOnlyList<GameObject> TouchedObjects => GetTouchedObjects();
        /// <summary>
        /// The currently active touched GameObject.
        /// </summary>
        public GameObject ActiveTouchedObject => GetActiveTouchedObject();

        /// <summary>
        /// A reusable collection to hold the returned touched objects.
        /// </summary>
        protected readonly List<GameObject> touchedObjects = new List<GameObject>();

        protected virtual void OnDisable()
        {
            StopTouchingPublisher.SetActiveCollisionsEvenWhenDisabled(StartTouchingPublisher.Payload);
            StopTouchingPublisher.ForcePublish();
        }

        /// <summary>
        /// Retrieves a collection of currently touched GameObjects.
        /// </summary>
        /// <returns>The currently touched GameObjects.</returns>
        protected virtual IReadOnlyList<GameObject> GetTouchedObjects()
        {
            touchedObjects.Clear();

            if (ActiveCollisionsContainer == null)
            {
                return touchedObjects;
            }

            foreach (CollisionNotifier.EventData element in ActiveCollisionsContainer.Elements)
            {
                touchedObjects.Add(element.ColliderData.GetContainingTransform().gameObject);
            }

            return touchedObjects;
        }

        /// <summary>
        /// Retrieves the currently active touched GameObject.
        /// </summary>
        /// <returns>The currently active touched GameObject.</returns>
        protected virtual GameObject GetActiveTouchedObject()
        {
            if (CurrentActiveCollision == null || CurrentActiveCollision.SlicedList.ActiveCollisions.Count == 0)
            {
                return null;
            }

            return CurrentActiveCollision.SlicedList.ActiveCollisions[0].ColliderData.GetContainingTransform().gameObject;
        }
    }
}