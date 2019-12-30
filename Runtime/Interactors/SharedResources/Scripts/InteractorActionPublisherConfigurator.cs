namespace Tilia.Interactions.Interactables.Interactors
{
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Action.Collection;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Tracking.Collision.Active;

    /// <summary>
    /// Sets up the Interactor Action Publisher Prefab action settings based on the provided user settings.
    /// </summary>
    public class InteractorActionPublisherConfigurator : MonoBehaviour
    {
        #region Facade Settings
        /// <summary>
        /// The public interface facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public InteractorActionPublisherFacade Facade { get; protected set; }
        #endregion

        #region Reference Settings
        /// <summary>
        /// The <see cref="ActionObservableList"/> that containts the <see cref="Action"/> collection that can be linked to the <see cref="InteractorActionFacade.SourceAction"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public ActionObservableList TargetActions { get; protected set; }
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid start action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActiveCollisionPublisher StartActionPublisher { get; protected set; }
        /// <summary>
        /// The <see cref="StringObservableList"/> for tagging the valid start action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public StringObservableList StartActionStringCollection { get; protected set; }
        /// <summary>
        /// The <see cref="ActiveCollisionPublisher"/> for checking valid stop action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActiveCollisionPublisher StopActionPublisher { get; protected set; }
        /// <summary>
        /// The <see cref="StringObservableList"/> for tagging the valid stop action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public StringObservableList StopActionStringCollection { get; protected set; }
        #endregion

        /// <summary>
        /// The current active <see cref="Action"/>.
        /// </summary>
        public Action ActiveAction { get; protected set; }

        protected virtual void OnEnable()
        {
            LinkSourceActionToTargetAction();
            LinkSourceContainerToPublishers();
            LinkActiveCollisions();
            SetPublisherTags();
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
        /// Unlinks the start publisher from the <see cref="InteractorActionFacade.SourceInteractor"/>.
        /// </summary>
        public virtual void UnlinkActiveCollisions()
        {
            if (Facade == null || Facade.SourceInteractor == null)
            {
                return;
            }

            Facade.SourceInteractor.TouchConfiguration.ExternalEmitters.Emitted.RemoveListener(StartActionPublisher.SetActiveCollisions);
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

            Facade.SourceInteractor.TouchConfiguration.ExternalEmitters.Emitted.AddListener(StartActionPublisher.SetActiveCollisions);
        }

        /// <summary>
        /// Sets the tags of the relevant publishers to the facade identifier.
        /// </summary>
        public virtual void SetPublisherTags()
        {
            StartActionStringCollection.RunWhenActiveAndEnabled(() => StartActionStringCollection.Clear());
            StartActionStringCollection.RunWhenActiveAndEnabled(() => StartActionStringCollection.Add("Start" + Facade.PublisherIdentifier));
            StopActionStringCollection.RunWhenActiveAndEnabled(() => StopActionStringCollection.Clear());
            StopActionStringCollection.RunWhenActiveAndEnabled(() => StopActionStringCollection.Add("Stop" + Facade.PublisherIdentifier));
        }
    }
}