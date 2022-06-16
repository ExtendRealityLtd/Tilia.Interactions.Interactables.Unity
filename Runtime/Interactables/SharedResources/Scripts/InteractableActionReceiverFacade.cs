namespace Tilia.Interactions.Interactables.Interactables
{
    using System;
    using Tilia.Interactions.Interactables.Interactors;
    using Tilia.Interactions.Interactables.Interactors.Collection;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Action;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;

    /// <summary>
    /// The public interface into the Interactor Action Receiver Prefab.
    /// </summary>
    public class InteractableActionReceiverFacade : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="Action"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractorFacade> { }

        /// <summary>
        /// The states of interaction.
        /// </summary>
        public enum InteractionState
        {
            /// <summary>
            /// A custom state that will not automatically register any events.
            /// </summary>
            Custom,
            /// <summary>
            /// When the first interactor starts touching the interactable.
            /// </summary>
            FirstTouch,
            /// <summary>
            /// When an interactor touches the interactable.
            /// </summary>
            Touch,
            /// <summary>
            /// When the first interactor starts grabbing the interactable.
            /// </summary>
            FirstGrab,
            /// <summary>
            /// When an interactor grabs the interactable.
            /// </summary>
            Grab
        }

        #region Action Settings
        [Header("Receiver Settings")]
        [Tooltip("The InteractableFacade that the action receiver will target.")]
        [SerializeField]
        private InteractableFacade targetInteractable;
        /// <summary>
        /// The <see cref="InteractableFacade"/> that the action receiver will target.
        /// </summary>
        public InteractableFacade TargetInteractable
        {
            get
            {
                return targetInteractable;
            }
            set
            {
                if (this.IsMemberChangeAllowed())
                {
                    OnBeforeTargetInteractableChange();
                }
                targetInteractable = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterTargetInteractableChange();
                }
            }
        }
        [Tooltip("The InteractionState that determies when to activate the action receiver.")]
        [SerializeField]
        private InteractionState activationState = InteractionState.Grab;
        /// <summary>
        /// The <see cref="InteractionState"/> that determies when to activate the action receiver.
        /// </summary>
        public InteractionState ActivationState
        {
            get
            {
                return activationState;
            }
            set
            {
                if (this.IsMemberChangeAllowed())
                {
                    OnBeforeActivationStateChange();
                }
                activationState = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterActivationStateChange();
                }
            }
        }
        [Tooltip("The InteractorActionPublisherFacade collection of the publishers to receive data from.")]
        [SerializeField]
        private InteractorActionPublisherFacadeObservableList sourcePublishers;
        /// <summary>
        /// The <see cref="InteractorActionPublisherFacade"/> collection of the publishers to receive data from.
        /// </summary>
        public InteractorActionPublisherFacadeObservableList SourcePublishers
        {
            get
            {
                return sourcePublishers;
            }
            set
            {
                sourcePublishers = value;
            }
        }
        #endregion

        #region Publisher Events
        /// <summary>
        /// Emitted when the Receiver is activated by an allowed publisher.
        /// </summary>
        [Header("Publisher Events")]
        public UnityEvent Activated = new UnityEvent();
        /// <summary>
        /// Emitted when the Receiver is deactivated from an allowed publisher.
        /// </summary>
        public UnityEvent Deactivated = new UnityEvent();
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The Action that will be linked to the SourceAction.")]
        [SerializeField]
        [Restricted]
        private InteractableActionReceiverConfigurator configuration;
        /// <summary>
        /// The <see cref="Action"/> that will be linked to the <see cref="SourceAction"/>.
        /// </summary>
        public InteractableActionReceiverConfigurator Configuration
        {
            get
            {
                return configuration;
            }
            protected set
            {
                configuration = value;
            }
        }
        #endregion

        /// <summary>
        /// Clears <see cref="TargetInteractable"/>.
        /// </summary>
        public virtual void ClearTargetInteractable()
        {
            if (!this.IsValidState())
            {
                return;
            }

            TargetInteractable = default;
        }

        /// <summary>
        /// Clears <see cref="SourcePublishers"/>.
        /// </summary>
        public virtual void ClearSourcePublishers()
        {
            if (!this.IsValidState())
            {
                return;
            }

            SourcePublishers = default;
        }

        /// <summary>
        /// Sets the <see cref="ActivationState"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="InteractionState"/>.</param>
        public virtual void SetActivationState(int index)
        {
            ActivationState = EnumExtensions.GetByIndex<InteractionState>(index);
        }

        /// <summary>
        /// Enables the given source <see cref="InteractorFacade"/> on the <see cref="ActionRegistrar"/>.
        /// </summary>
        /// <param name="source">The source to enable.</param>
        public virtual void EnableActionRegistrar(InteractorFacade source)
        {
            if (source == null)
            {
                return;
            }

            EnableActionRegistrar(source.gameObject);
        }

        /// <summary>
        /// Enables the given source <see cref="GameObject"/> on the <see cref="ActionRegistrar"/>.
        /// </summary>
        /// <param name="source">The source to enable.</param>
        public virtual void EnableActionRegistrar(GameObject source)
        {
            if (source == null)
            {
                return;
            }

            Configuration.ActionRegistrar.enabled = true;
            Configuration.ActionRegistrar.Sources.EnableSource(source);
        }

        /// <summary>
        /// Disables the given source <see cref="InteractorFacade"/> on the <see cref="ActionRegistrar"/>.
        /// </summary>
        /// <param name="source">The source to disable.</param>
        public virtual void DisableActionRegistrar(InteractorFacade source)
        {
            if (source == null)
            {
                return;
            }

            DisableActionRegistrar(source.gameObject);
        }

        /// <summary>
        /// Disables the given source <see cref="GameObject"/> on the <see cref="ActionRegistrar"/>.
        /// </summary>
        /// <param name="source">The source to disable.</param>
        public virtual void DisableActionRegistrar(GameObject source)
        {
            if (source == null)
            {
                return;
            }

            Configuration.ActionRegistrar.Target.ReceiveDefaultValue();
            Configuration.ActionRegistrar.Sources.DisableSource(source);
            foreach (ActionRegistrar.ActionSource actionSource in Configuration.ActionRegistrar.Sources.SubscribableElements)
            {
                if (actionSource.Enabled)
                {
                    return;
                }
            }
            Configuration.ActionRegistrar.enabled = false;
        }

        /// <summary>
        /// Called before <see cref="TargetInteractable"/> has been changed.
        /// </summary>
        protected virtual void OnBeforeTargetInteractableChange()
        {
            Configuration.UnregisterInteractableEvents(TargetInteractable, ActivationState);
        }

        /// <summary>
        /// Called after <see cref="TargetInteractable"/> has been changed.
        /// </summary>
        protected virtual void OnAfterTargetInteractableChange()
        {
            Configuration.LinkInteractableToConsumers();
            Configuration.RegisterInteractableEvents(TargetInteractable, ActivationState);
        }

        /// <summary>
        /// Called before <see cref="ActivationState"/> has been changed.
        /// </summary>
        protected virtual void OnBeforeActivationStateChange()
        {
            Configuration.UnregisterInteractableEvents(TargetInteractable, ActivationState);
        }

        /// <summary>
        /// Called after <see cref="ActivationState"/> has been changed.
        /// </summary>
        protected virtual void OnAfterActivationStateChange()
        {
            Configuration.RegisterInteractableEvents(TargetInteractable, ActivationState);
        }
    }
}