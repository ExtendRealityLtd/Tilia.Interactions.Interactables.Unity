namespace Tilia.Interactions.Interactables
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using Tilia.Interactions.Interactables.Interactors;
    using Tilia.Interactions.Interactables.Interactors.Collection;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// The public interface into the Interactor Action Receiver Prefab.
    /// </summary>
    public class InteractableActionReceiverFacade : MonoBehaviour
    {
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
        /// <summary>
        /// The <see cref="InteractableFacade"/> that the action receiver will target.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Receiver Settings"), DocumentedByXml]
        public InteractableFacade TargetInteractable { get; set; }
        /// <summary>
        /// The <see cref="InteractionState"/> that determies when to activate the action receiver.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public InteractionState ActivationState { get; set; } = InteractionState.Grab;
        /// <summary>
        /// The <see cref="InteractorActionPublisherFacade"/> collection of the publishers to receive data from.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public InteractorActionPublisherFacadeObservableList SourcePublishers { get; set; }
        #endregion

        #region Reference Settings
        /// <summary>
        /// The <see cref="Action"/> that will be linked to the <see cref="SourceAction"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public InteractableActionReceiverConfigurator Configuration { get; protected set; }
        #endregion

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
        [CalledBeforeChangeOf(nameof(TargetInteractable))]
        protected virtual void OnBeforeTargetInteractableChange()
        {
            Configuration.UnregisterInteractableEvents(TargetInteractable, ActivationState);
        }

        /// <summary>
        /// Called after <see cref="TargetInteractable"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(TargetInteractable))]
        protected virtual void OnAfterTargetInteractableChange()
        {
            Configuration.LinkInteractableToConsumers();
            Configuration.RegisterInteractableEvents(TargetInteractable, ActivationState);
        }

        /// <summary>
        /// Called before <see cref="ActivationState"/> has been changed.
        /// </summary>
        [CalledBeforeChangeOf(nameof(ActivationState))]
        protected virtual void OnBeforeActivationStateChange()
        {
            Configuration.UnregisterInteractableEvents(TargetInteractable, ActivationState);
        }

        /// <summary>
        /// Called after <see cref="ActivationState"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(ActivationState))]
        protected virtual void OnAfterActivationStateChange()
        {
            Configuration.RegisterInteractableEvents(TargetInteractable, ActivationState);
        }
    }
}