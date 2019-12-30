namespace Tilia.Interactions.Interactables
{
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Action.Collection;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;
    using Zinnia.Rule;
    using Zinnia.Tracking.Collision.Active;
    using Action = Zinnia.Action.Action;

    /// <summary>
    /// Sets up the Interactor Action Receiver Prefab action settings based on the provided user settings.
    /// </summary>
    public class InteractableActionReceiverConfigurator : MonoBehaviour
    {
        #region Facade Settings
        /// <summary>
        /// The public interface facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public InteractableActionReceiverFacade Facade { get; protected set; }
        #endregion

        #region Reference Settings
        /// <summary>
        /// The <see cref="ActionObservableList"/> that containts the <see cref="Action"/> collection that can be linked to the <see cref="InteractorActionFacade.SourceAction"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public ActionObservableList TargetActions { get; protected set; }
        /// <summary>
        /// The <see cref="ActionRegistrar"/> to create the appropriate action links.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActionRegistrar ActionRegistrar { get; protected set; }
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> for checking valid start action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActiveCollisionConsumer StartActionConsumer { get; protected set; }
        /// <summary>
        /// The <see cref="StringInListRule"/> for the start action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public StringInListRule ReceiveStartActionStringRule { get; protected set; }
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> for checking valid stop action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ActiveCollisionConsumer StopActionConsumer { get; protected set; }
        /// <summary>
        /// The <see cref="StringInListRule"/> for the stop action.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public StringInListRule ReceiveStopActionStringRule { get; protected set; }
        #endregion

        /// <summary>
        /// The parent <see cref="Transform"/> to child the <see cref="InteractableActionReceiverFacade"/> by default.
        /// </summary>
        protected Transform defaultParent;

        /// <summary>
        /// Links the <see cref="InteractorActionFacade.SourceInteractor"/> to the payload source containers on the start and stop publishers.
        /// </summary>
        public virtual void LinkInteractableToConsumers()
        {
            Facade.transform.SetParent(defaultParent);

            if (Facade == null || Facade.TargetInteractable == null)
            {
                return;
            }

            Facade.transform.SetParent(Facade.TargetInteractable.transform);

            StartActionConsumer.Container = Facade.TargetInteractable.gameObject;
            StopActionConsumer.Container = Facade.TargetInteractable.gameObject;
        }

        /// <summary>
        /// Registers the activation/deactivation events for the <see cref="interactable"/> on the appropraite <see cref="interactionState"/>.
        /// </summary>
        /// <param name="interactable">The interactable to register the events on.</param>
        /// <param name="interactionState">The interaction state of the interactable to register the events on.</param>
        public virtual void RegisterInteractableEvents(InteractableFacade interactable, InteractableActionReceiverFacade.InteractionState interactionState)
        {
            if (interactable == null)
            {
                return;
            }

            switch (interactionState)
            {
                case InteractableActionReceiverFacade.InteractionState.FirstTouch:
                    interactable.FirstTouched.AddListener(Facade.EnableActionRegistrar);
                    interactable.LastUntouched.AddListener(Facade.DisableActionRegistrar);
                    break;
                case InteractableActionReceiverFacade.InteractionState.Touch:
                    interactable.Touched.AddListener(Facade.EnableActionRegistrar);
                    interactable.Untouched.AddListener(Facade.DisableActionRegistrar);
                    break;
                case InteractableActionReceiverFacade.InteractionState.FirstGrab:
                    interactable.FirstGrabbed.AddListener(Facade.EnableActionRegistrar);
                    interactable.LastUngrabbed.AddListener(Facade.DisableActionRegistrar);
                    break;
                case InteractableActionReceiverFacade.InteractionState.Grab:
                    interactable.Grabbed.AddListener(Facade.EnableActionRegistrar);
                    interactable.Ungrabbed.AddListener(Facade.DisableActionRegistrar);
                    break;
            }
        }

        /// <summary>
        /// Unregisters the activation/deactivation events for the <see cref="interactable"/> from the appropraite <see cref="interactionState"/>.
        /// </summary>
        /// <param name="interactable">The interactable to unregister the events from.</param>
        /// <param name="interactionState">The interaction state of the interactable to unregister the events from.</param>
        public virtual void UnregisterInteractableEvents(InteractableFacade interactable, InteractableActionReceiverFacade.InteractionState interactionState)
        {
            if (interactable == null)
            {
                return;
            }

            switch (interactionState)
            {
                case InteractableActionReceiverFacade.InteractionState.FirstTouch:
                    interactable.FirstTouched.RemoveListener(Facade.EnableActionRegistrar);
                    interactable.LastUntouched.RemoveListener(Facade.DisableActionRegistrar);
                    break;
                case InteractableActionReceiverFacade.InteractionState.Touch:
                    interactable.Touched.RemoveListener(Facade.EnableActionRegistrar);
                    interactable.Untouched.RemoveListener(Facade.DisableActionRegistrar);
                    break;
                case InteractableActionReceiverFacade.InteractionState.FirstGrab:
                    interactable.FirstGrabbed.RemoveListener(Facade.EnableActionRegistrar);
                    interactable.LastUngrabbed.RemoveListener(Facade.DisableActionRegistrar);
                    break;
                case InteractableActionReceiverFacade.InteractionState.Grab:
                    interactable.Grabbed.RemoveListener(Facade.EnableActionRegistrar);
                    interactable.Ungrabbed.RemoveListener(Facade.DisableActionRegistrar);
                    break;
            }
        }

        /// <summary>
        /// Processes the publishers linked in the <see cref="Facade.SourcePublishers"/> collection.
        /// </summary>
        public virtual void ProcessPublisherList()
        {
            ClearPublisherSetup();

            string currentIdentifier = null;
            Type currentActionType = null;
            foreach (InteractorActionPublisherFacade publisher in Facade.SourcePublishers.SubscribableElements)
            {
                publisher.Configuration.RunWhenActiveAndEnabled(() => ProcessPublisher(publisher, ref currentIdentifier, ref currentActionType));
            }
        }

        protected virtual void Awake()
        {
            defaultParent = Facade.transform.parent;
        }

        protected virtual void OnEnable()
        {
            LinkInteractableToConsumers();
            RegisterInteractableEvents(Facade.TargetInteractable, Facade.ActivationState);
        }

        protected virtual void OnDisable()
        {
            UnregisterInteractableEvents(Facade.TargetInteractable, Facade.ActivationState);
        }

        /// <summary>
        /// Clears the publisher setup.
        /// </summary>
        protected virtual void ClearPublisherSetup()
        {
            ActionRegistrar.Target = null;
            ActionRegistrar.Sources.Clear();
            ReceiveStartActionStringRule.InListPattern = "";
            ReceiveStopActionStringRule.InListPattern = "";
        }

        /// <summary>
        /// Determines if the given publisher element is valid.
        /// </summary>
        /// <param name="cachedValue">The cached value to check against.</param>
        /// <param name="currentValue">The current value to check with.</param>
        /// <param name="exceptionMessage">The message to display in the exception if the element is not valid.</param>
        /// <returns>Whether the given publisher element is valid.</returns>
        protected virtual bool IsValidPublisherElement(object cachedValue, object currentValue, string exceptionMessage)
        {
            if (cachedValue != null && !cachedValue.Equals(currentValue))
            {
                ClearPublisherSetup();
                throw new ArgumentException(exceptionMessage);
            }

            return true;
        }

        /// <summary>
        /// Activates the correct output <see cref="Action"/> based on the linked <see cref="Action"/> from the publisher.
        /// </summary>
        /// <param name="actionType">The <see cref="Action"/> type to activate.</param>
        protected virtual void ActivateOutputAction(Type actionType)
        {
            foreach (Action action in TargetActions.NonSubscribableElements)
            {
                action.gameObject.SetActive(false);
                if (action.GetType().IsAssignableFrom(actionType))
                {
                    action.gameObject.SetActive(true);
                    ActionRegistrar.Target = action;
                }
            }
        }

        /// <summary>
        /// Sets up the links from the publisher to the receiver.
        /// </summary>
        /// <param name="publisher">The publisher to link to.</param>
        protected virtual void SetupPublisherLinks(InteractorActionPublisherFacade publisher)
        {
            ActionRegistrar.ActionSource actionSource = new ActionRegistrar.ActionSource()
            {
                Enabled = false,
                Container = publisher.SourceInteractor.gameObject,
                Action = publisher.ActiveAction
            };

            ActionRegistrar.Sources.Add(actionSource);

            ReceiveStartActionStringRule.InListPattern = string.Format("^Start{0}$", publisher.PublisherIdentifier);
            ReceiveStopActionStringRule.InListPattern = string.Format("^Stop{0}$", publisher.PublisherIdentifier);
        }

        /// <summary>
        /// Processes the given publisher data.
        /// </summary>
        /// <param name="publisher">The publisher to process.</param>
        /// <param name="previousIdentifier">The previous publisher's identifier.</param>
        /// <param name="previousActionType">The previous publisher's action type.</param>
        protected virtual void ProcessPublisher(InteractorActionPublisherFacade publisher, ref string previousIdentifier, ref Type previousActionType)
        {
            Type publisherActionType = publisher.ActiveAction.GetType();

            IsValidPublisherElement(previousIdentifier, publisher.PublisherIdentifier, string.Format("All `SourcePublishers` identifiers must be identical. Mismatch found between previous value of `{0}` and the publisher `{1}` which has a value of `{2}`.", previousIdentifier, publisher.name, publisher.PublisherIdentifier));
            IsValidPublisherElement(previousActionType, publisherActionType, string.Format("All `SourcePublishers` Action types must be identical. Mismatch found between previous value of `{0}` and the publisher `{1}` which has a value of `{2}`.", previousActionType, publisher.name, publisherActionType));

            ActivateOutputAction(publisherActionType);
            SetupPublisherLinks(publisher);

            previousIdentifier = publisher.PublisherIdentifier;
            previousActionType = publisherActionType;
        }
    }
}