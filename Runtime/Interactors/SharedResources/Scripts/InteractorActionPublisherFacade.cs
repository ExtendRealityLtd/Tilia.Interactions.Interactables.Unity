namespace Tilia.Interactions.Interactables.Interactors
{
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;

    /// <summary>
    /// The public interface into the Interactor Action Publisher Prefab.
    /// </summary>
    public class InteractorActionPublisherFacade : MonoBehaviour
    {
        #region Action Settings
        [Header("Action Settings")]
        [Tooltip("The Action to be monitored to control the interaction.")]
        [SerializeField]
        private Action sourceAction;
        /// <summary>
        /// The <see cref="Action"/> to be monitored to control the interaction.
        /// </summary>
        public Action SourceAction
        {
            get
            {
                return sourceAction;
            }
            set
            {
                sourceAction = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterSourceActionChange();
                }
            }
        }
        [Tooltip("The source InteractorFacade that the action will be processed through.")]
        [SerializeField]
        private InteractorFacade sourceInteractor;
        /// <summary>
        /// The source <see cref="InteractorFacade"/> that the action will be processed through.
        /// </summary>
        public InteractorFacade SourceInteractor
        {
            get
            {
                return sourceInteractor;
            }
            set
            {
                if (this.IsMemberChangeAllowed())
                {
                    OnBeforeSourceInteractorChange();
                }
                sourceInteractor = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterSourceInteractorChange();
                }
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The Action that will be linked to the SourceAction.")]
        [SerializeField]
        [Restricted]
        private InteractorActionPublisherConfigurator configuration;
        /// <summary>
        /// The <see cref="Action"/> that will be linked to the <see cref="SourceAction"/>.
        /// </summary>
        public InteractorActionPublisherConfigurator Configuration
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
        /// The current active <see cref="Action"/>.
        /// </summary>
        public virtual Action ActiveAction => Configuration.ActiveAction;

        /// <summary>
        /// Clears <see cref="SourceAction"/>.
        /// </summary>
        public virtual void ClearSourceAction()
        {
            if (!this.IsValidState())
            {
                return;
            }

            SourceAction = default;
        }

        /// <summary>
        /// Clears <see cref="SourceInteractor"/>.
        /// </summary>
        public virtual void ClearSourceInteractor()
        {
            if (!this.IsValidState())
            {
                return;
            }

            SourceInteractor = default;
        }

        /// <summary>
        /// Called after <see cref="SourceAction"/> has been changed.
        /// </summary>
        protected virtual void OnAfterSourceActionChange()
        {
            Configuration.LinkSourceActionToTargetAction();
        }

        /// <summary>
        /// Called before <see cref="SourceInteractor"/> has been changed.
        /// </summary>
        protected virtual void OnBeforeSourceInteractorChange()
        {
            Configuration.UnlinkActiveCollisions();
        }

        /// <summary>
        /// Called after <see cref="SourceInteractor"/> has been changed.
        /// </summary>
        protected virtual void OnAfterSourceInteractorChange()
        {
            Configuration.LinkSourceContainerToPublishers();
            Configuration.LinkActiveCollisions();
        }
    }
}