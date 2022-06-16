namespace Tilia.Interactions.Interactables.Interactables
{
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
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private InteractableActionReceiverFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public InteractableActionReceiverFacade Facade
        {
            get
            {
                return facade;
            }
            protected set
            {
                facade = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The ActionObservableList that containts the Action collection that can be linked to the InteractorActionFacade.SourceAction.")]
        [SerializeField]
        [Restricted]
        private ActionObservableList targetActions;
        /// <summary>
        /// The <see cref="ActionObservableList"/> that containts the <see cref="Action"/> collection that can be linked to the <see cref="InteractorActionFacade.SourceAction"/>.
        /// </summary>
        public ActionObservableList TargetActions
        {
            get
            {
                return targetActions;
            }
            protected set
            {
                targetActions = value;
            }
        }
        [Tooltip("The ActionRegistrar to create the appropriate action links.")]
        [SerializeField]
        [Restricted]
        private ActionRegistrar actionRegistrar;
        /// <summary>
        /// The <see cref="ActionRegistrar"/> to create the appropriate action links.
        /// </summary>
        public ActionRegistrar ActionRegistrar
        {
            get
            {
                return actionRegistrar;
            }
            protected set
            {
                actionRegistrar = value;
            }
        }
        [Tooltip("The ActiveCollisionConsumer for checking valid start action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumer startActionConsumer;
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> for checking valid start action.
        /// </summary>
        public ActiveCollisionConsumer StartActionConsumer
        {
            get
            {
                return startActionConsumer;
            }
            protected set
            {
                startActionConsumer = value;
            }
        }
        [Tooltip("The ListContainsRule for the start action.")]
        [SerializeField]
        [Restricted]
        private ListContainsRule receiveStartActionRule;
        /// <summary>
        /// The <see cref="ListContainsRule"/> for the start action.
        /// </summary>
        public ListContainsRule ReceiveStartActionRule
        {
            get
            {
                return receiveStartActionRule;
            }
            protected set
            {
                receiveStartActionRule = value;
            }
        }
        [Tooltip("The ActiveCollisionConsumer for checking valid stop action.")]
        [SerializeField]
        [Restricted]
        private ActiveCollisionConsumer stopActionConsumer;
        /// <summary>
        /// The <see cref="ActiveCollisionConsumer"/> for checking valid stop action.
        /// </summary>
        public ActiveCollisionConsumer StopActionConsumer
        {
            get
            {
                return stopActionConsumer;
            }
            protected set
            {
                stopActionConsumer = value;
            }
        }
        [Tooltip("The ListContainsRule for the stop action.")]
        [SerializeField]
        [Restricted]
        private ListContainsRule receiveStopActionRule;
        /// <summary>
        /// The <see cref="ListContainsRule"/> for the stop action.
        /// </summary>
        public ListContainsRule ReceiveStopActionRule
        {
            get
            {
                return receiveStopActionRule;
            }
            protected set
            {
                receiveStopActionRule = value;
            }
        }
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
                    interactable.Touched.AddListener(EnableFirstTouchedOnActionRegistrar);
                    interactable.Untouched.AddListener(DisableFirstTouchedOnActionRegistrar);
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
                    interactable.Touched.RemoveListener(EnableFirstTouchedOnActionRegistrar);
                    interactable.Untouched.RemoveListener(DisableFirstTouchedOnActionRegistrar);
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

            Type currentActionType = null;
            foreach (InteractorActionPublisherFacade publisher in Facade.SourcePublishers.SubscribableElements)
            {
                publisher.Configuration.RunWhenActiveAndEnabled(() => ProcessPublisher(publisher, ref currentActionType));
            }
        }

        /// <summary>
        /// Notifies the Activated event on the <see cref="Facade"/>.
        /// </summary>
        /// <param name="source">The source Interactor.</param>
        public virtual void NotifyActivated(GameObject source)
        {
            InteractorFacade interactor = source.TryGetComponent<InteractorFacade>();
            if (interactor == null)
            {
                return;
            }

            Facade.Activated?.Invoke(interactor);
        }

        /// <summary>
        /// Notifies the Deactivated event on the <see cref="Facade"/>.
        /// </summary>
        /// <param name="source">The source Interactor.</param>
        public virtual void NotifyDeactivated(GameObject source)
        {
            InteractorFacade interactor = source.TryGetComponent<InteractorFacade>();
            if (interactor == null)
            {
                return;
            }

            Facade.Deactivated?.Invoke(interactor);
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
        /// Enables the first touched <see cref="InteractorFacade"/> that is touching the <see cref="InteractableFacade"/> on the action registrar.
        /// </summary>
        /// <param name="_">Not used</param>
        protected virtual void EnableFirstTouchedOnActionRegistrar(InteractorFacade _)
        {
            if (Facade.TargetInteractable.Configuration.TouchConfiguration.CurrentTouchingObjects.NonSubscribableElements.Count > 0)
            {
                Facade.EnableActionRegistrar(Facade.TargetInteractable.Configuration.TouchConfiguration.CurrentTouchingObjects.NonSubscribableElements[0]);
            }
        }

        /// <summary>
        /// Disables the given <see cref="InteractorFacade"/> on the action registrar.
        /// </summary>
        /// <param name="interactor">The interactor to disable.</param>
        protected virtual void DisableFirstTouchedOnActionRegistrar(InteractorFacade interactor)
        {
            Facade.DisableActionRegistrar(interactor);
            EnableFirstTouchedOnActionRegistrar(null);
        }

        /// <summary>
        /// Clears the publisher setup.
        /// </summary>
        protected virtual void ClearPublisherSetup()
        {
            ActionRegistrar.Target = null;
            ActionRegistrar.Sources.Clear();
            ReceiveStartActionRule.RunWhenActiveAndEnabled(() => ReceiveStartActionRule.Objects.Clear());
            ReceiveStopActionRule.RunWhenActiveAndEnabled(() => ReceiveStopActionRule.Objects.Clear());
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

            ReceiveStartActionRule.Objects.Add(publisher.Configuration.StartActionPublisher.gameObject);
            ReceiveStopActionRule.Objects.Add(publisher.Configuration.StopActionPublisher.gameObject);
        }

        /// <summary>
        /// Processes the given publisher data.
        /// </summary>
        /// <param name="publisher">The publisher to process.</param>
        /// <param name="previousActionType">The previous publisher's action type.</param>
        protected virtual void ProcessPublisher(InteractorActionPublisherFacade publisher, ref Type previousActionType)
        {
            Type publisherActionType = publisher.ActiveAction.GetType();

            IsValidPublisherElement(previousActionType, publisherActionType, string.Format("All `SourcePublishers` Action types must be identical. Mismatch found between previous value of `{0}` and the publisher `{1}` which has a value of `{2}`.", previousActionType, publisher.name, publisherActionType));

            ActivateOutputAction(publisherActionType);
            SetupPublisherLinks(publisher);

            previousActionType = publisherActionType;
        }
    }
}