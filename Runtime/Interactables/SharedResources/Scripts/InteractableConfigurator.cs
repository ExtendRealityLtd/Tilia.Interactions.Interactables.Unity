﻿namespace Tilia.Interactions.Interactables.Interactables
{
    using Tilia.Interactions.Interactables.Interactables.Grab;
    using Tilia.Interactions.Interactables.Interactables.Grab.Action;
    using Tilia.Interactions.Interactables.Interactables.Touch;
    using Tilia.Interactions.Interactables.Interactables.Utility;
#if UNITY_EDITOR
    using UnityEditor;
#endif
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Rule;
    using Zinnia.Tracking.Collision;

    /// <summary>
    /// Sets up the Interactable Prefab based on the provided user settings.
    /// </summary>
    public class InteractableConfigurator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private InteractableFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public InteractableFacade Facade
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

        #region Restriction Settings
        [Header("Restriction Settings")]
        [Tooltip("The rule to determine what is not allowed to touch this interactable.")]
        [SerializeField]
        private RuleContainer disallowedTouchInteractors;
        /// <summary>
        /// The rule to determine what is not allowed to touch this interactable.
        /// </summary>
        public RuleContainer DisallowedTouchInteractors
        {
            get
            {
                return disallowedTouchInteractors;
            }
            set
            {
                disallowedTouchInteractors = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterDisallowedTouchInteractorsChange();
                }
            }
        }
        [Tooltip("The rule to determine what is not allowed to grab this interactable.")]
        [SerializeField]
        private RuleContainer disallowedGrabInteractors;
        /// <summary>
        /// The rule to determine what is not allowed to grab this interactable.
        /// </summary>
        public RuleContainer DisallowedGrabInteractors
        {
            get
            {
                return disallowedGrabInteractors;
            }
            set
            {
                disallowedGrabInteractors = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterDisallowedGrabInteractorsChange();
                }
            }
        }
        #endregion

        #region Container Settings
        [Header("Container Settings")]
        [Tooltip("The overall container for the interactable consumers.")]
        [SerializeField]
        private GameObject consumerContainer;
        /// <summary>
        /// The overall container for the interactable consumers.
        /// </summary>
        public GameObject ConsumerContainer
        {
            get
            {
                return consumerContainer;
            }
            set
            {
                consumerContainer = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterConsumerContainerChange();
                }
            }
        }
        [Tooltip("The Rigidbody for the overall collisions.")]
        [SerializeField]
        private Rigidbody consumerRigidbody;
        /// <summary>
        /// The <see cref="Rigidbody"/> for the overall collisions.
        /// </summary>
        public Rigidbody ConsumerRigidbody
        {
            get
            {
                return consumerRigidbody;
            }
            set
            {
                consumerRigidbody = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterConsumerRigidbodyChange();
                }
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked CollisionNotifier.")]
        [SerializeField]
        [Restricted]
        private CollisionNotifier collisionNotifier;
        /// <summary>
        /// The linked <see cref="CollisionNotifier"/>.
        /// </summary>
        public CollisionNotifier CollisionNotifier
        {
            get
            {
                return collisionNotifier;
            }
            protected set
            {
                collisionNotifier = value;
            }
        }
        [Tooltip("The GameObject that contains the mesh for the Interactable.")]
        [SerializeField]
        [Restricted]
        private GameObject meshContainer;
        /// <summary>
        /// The <see cref="GameObject"/> that contains the mesh for the Interactable.
        /// </summary>
        public GameObject MeshContainer
        {
            get
            {
                return meshContainer;
            }
            protected set
            {
                meshContainer = value;
            }
        }
        [Tooltip("The linked GameObjectObservableList.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList activeCollisions;
        /// <summary>
        /// The linked <see cref="GameObjectObservableList"/>.
        /// </summary>
        public GameObjectObservableList ActiveCollisions
        {
            get
            {
                return activeCollisions;
            }
            protected set
            {
                activeCollisions = value;
            }
        }
        [Tooltip("The linked Touch Internal Setup.")]
        [SerializeField]
        [Restricted]
        private TouchInteractableConfigurator touchConfiguration;
        /// <summary>
        /// The linked Touch Internal Setup.
        /// </summary>
        public TouchInteractableConfigurator TouchConfiguration
        {
            get
            {
                return touchConfiguration;
            }
            protected set
            {
                touchConfiguration = value;
            }
        }
        [Tooltip("The linked Grab Internal Setup.")]
        [SerializeField]
        [Restricted]
        private GrabInteractableConfigurator grabConfiguration;
        /// <summary>
        /// The linked Grab Internal Setup.
        /// </summary>
        public GrabInteractableConfigurator GrabConfiguration
        {
            get
            {
                return grabConfiguration;
            }
            protected set
            {
                grabConfiguration = value;
            }
        }
        #endregion

        /// <summary>
        /// The total number of available grab action types.
        /// </summary>
        public virtual int GrabActionTypesCount => GrabConfiguration.ActionTypes.NonSubscribableElements.Count;

        /// <summary>
        /// Clears <see cref="DisallowedTouchInteractors"/>.
        /// </summary>
        public virtual void ClearDisallowedTouchInteractors()
        {
            if (!this.IsValidState())
            {
                return;
            }

            DisallowedTouchInteractors = default;
        }

        /// <summary>
        /// Clears <see cref="DisallowedGrabInteractors"/>.
        /// </summary>
        public virtual void ClearDisallowedGrabInteractors()
        {
            if (!this.IsValidState())
            {
                return;
            }

            DisallowedGrabInteractors = default;
        }

        /// <summary>
        /// Clears <see cref="ConsumerContainer"/>.
        /// </summary>
        public virtual void ClearConsumerContainer()
        {
            if (!this.IsValidState())
            {
                return;
            }

            ConsumerContainer = default;
        }

        /// <summary>
        /// Clears <see cref="ConsumerRigidbody"/>.
        /// </summary>
        public virtual void ClearConsumerRigidbody()
        {
            if (!this.IsValidState())
            {
                return;
            }

            ConsumerRigidbody = default;
        }

        /// <summary>
        /// Determines whether the grab configuration is set.
        /// </summary>
        /// <returns>Whether the grab configuration is set.</returns>
        public virtual bool IsGrabConfigurationSet()
        {
            return GrabConfiguration != null;
        }

        /// <summary>
        /// Gets the <see cref="GameObject"/> for the given Grab <see cref="InteractableFactory.ActionType"/>.
        /// </summary>
        /// <param name="type">The action type to attempt to get.</param>
        /// <returns>The GameObject for the given action type.</returns>
        public virtual GameObject GetGrabActionTypeObject(InteractableFactory.ActionType type)
        {
            return GetGrabActionTypeObject((int)type);
        }

        /// <summary>
        /// Gets the <see cref="GameObject"/> for the given Grab Action Type index.
        /// </summary>
        /// <param name="index">The index to attempt to get.</param>
        /// <returns>The found GameObject for the given index type.</returns>
        public virtual GameObject GetGrabActionTypeObject(int index)
        {
            return GrabConfiguration.ActionTypes.NonSubscribableElements[index];
        }

        /// <summary>
        /// Gets the current grab configuration primary action.
        /// </summary>
        /// <returns>The current primary action.</returns>
        public virtual GrabInteractableAction GetPrimaryAction()
        {
            return IsGrabConfigurationSet() && GrabConfiguration.PrimaryAction != null ? GrabConfiguration.PrimaryAction : null;
        }

        /// <summary>
        /// Gets the current grab configuration secondary action.
        /// </summary>
        /// <returns>The current secondary action.</returns>
        public virtual GrabInteractableAction GetSecondaryAction()
        {
            return IsGrabConfigurationSet() && GrabConfiguration.SecondaryAction != null ? GrabConfiguration.SecondaryAction : null;
        }

        /// <summary>
        /// Updates the primary grab action to the given type.
        /// </summary>
        /// <param name="type">The grab action type.</param>
        /// <returns>The new grab action.</returns>
        public virtual GrabInteractableAction UpdatePrimaryAction(InteractableFactory.ActionType type)
        {
            return UpdatePrimaryAction((int)type);
        }

        /// <summary>
        /// Updates the primary grab action to the given type index.
        /// </summary>
        /// <param name="index">The grab action type index.</param>
        /// <returns>The new grab action.</returns>
        public virtual GrabInteractableAction UpdatePrimaryAction(int index)
        {
            GrabInteractableAction action = CreateGrabAction(GetPrimaryAction(), index, 0);
            GrabConfiguration.PrimaryAction = action;
            SetFollowAndControlDirectionPair();
            return action;
        }

        /// <summary>
        /// Updates the secondary grab action to the given type.
        /// </summary>
        /// <param name="type">The grab action type.</param>
        /// <returns>The new grab action.</returns>
        public virtual GrabInteractableAction UpdateSecondaryAction(InteractableFactory.ActionType type)
        {
            return UpdateSecondaryAction((int)type);
        }

        /// <summary>
        /// Updates the secondary grab action to the given type index.
        /// </summary>
        /// <param name="index">The grab action type index.</param>
        /// <returns>The new grab action.</returns>
        public virtual GrabInteractableAction UpdateSecondaryAction(int index)
        {
            GrabInteractableAction action = CreateGrabAction(GetSecondaryAction(), index, 1);
            GrabConfiguration.SecondaryAction = action;
            SetFollowAndControlDirectionPair();
            return action;
        }

        /// <summary>
        /// Sets up the relevant linkages if the follow and control direction actions are selected in a pairing.
        /// </summary>
        protected virtual void SetFollowAndControlDirectionPair()
        {
            GrabInteractableAction primaryAction = GetPrimaryAction();
            GrabInteractableAction secondaryAction = GetSecondaryAction();
            GrabInteractableFollowAction followAction;
            GrabInteractableControlDirectionAction controlDirectionAction;

            if (secondaryAction != null && typeof(GrabInteractableControlDirectionAction).IsAssignableFrom(secondaryAction.GetType()))
            {
                controlDirectionAction = (GrabInteractableControlDirectionAction)secondaryAction;
                controlDirectionAction.LinkedObjects = null;
            }

            if (primaryAction == null ||
                secondaryAction == null ||
                !typeof(GrabInteractableFollowAction).IsAssignableFrom(primaryAction.GetType()) ||
                !typeof(GrabInteractableControlDirectionAction).IsAssignableFrom(secondaryAction.GetType()))
            {
                return;
            }

            followAction = (GrabInteractableFollowAction)primaryAction;
            controlDirectionAction = (GrabInteractableControlDirectionAction)secondaryAction;

            controlDirectionAction.LinkedObjects = followAction.RotationModifiers;
        }

        /// <summary>
        /// Creates a grab action for the given type.
        /// </summary>
        /// <param name="currentAction">The current action.</param>
        /// <param name="newActionType">The new action type to create.</param>
        /// <param name="siblingPosition">The position the action should take in the hierarcy.</param>
        /// <returns>The created Grab Action.</returns>
        protected virtual GrabInteractableAction CreateGrabAction(GrabInteractableAction currentAction, int newActionType, int siblingPosition)
        {
            if (!IsGrabConfigurationSet())
            {
                return null;
            }

            if (currentAction != null)
            {
                DestroyImmediate(currentAction.gameObject);
            }

            GameObject toInstantiate = GrabConfiguration.ActionTypes.NonSubscribableElements[newActionType];
            GameObject actionObject = null;
#if UNITY_EDITOR
            actionObject = (GameObject)PrefabUtility.InstantiatePrefab(toInstantiate);
#else
            actionObject = Instantiate(toInstantiate);
#endif
            actionObject.name = actionObject.name.Replace("(Clone)", "(Generated)");
            actionObject.transform.SetParent(facade.Configuration.GrabConfiguration.ActionTypes.transform);
            actionObject.transform.SetSiblingIndex(siblingPosition);
            actionObject.transform.localPosition = Vector3.zero;
            actionObject.transform.localRotation = Quaternion.identity;
            actionObject.transform.localScale = Vector3.zero;

            return actionObject.GetComponent<GrabInteractableAction>();
        }

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
        protected virtual void OnAfterDisallowedTouchInteractorsChange()
        {
            TouchConfiguration.TouchValidity.ReceiveValidity = DisallowedTouchInteractors;
        }

        /// <summary>
        /// Called after <see cref="DisallowedGrabInteractors"/> has been changed.
        /// </summary>
        protected virtual void OnAfterDisallowedGrabInteractorsChange()
        {
            GrabConfiguration.GrabReceiver.GrabValidity.ReceiveValidity = DisallowedGrabInteractors;
        }

        /// <summary>
        /// Called after <see cref="ConsumerContainer"/> has been changed.
        /// </summary>
        protected virtual void OnAfterConsumerContainerChange()
        {
            ConfigureContainer();
        }

        /// <summary>
        /// Called after <see cref="ConsumerRigidbody"/> has been changed.
        /// </summary>
        protected virtual void OnAfterConsumerRigidbodyChange()
        {
            ConfigureContainer();
        }
    }
}