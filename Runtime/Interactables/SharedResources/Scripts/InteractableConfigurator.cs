namespace Tilia.Interactions.Interactables.Interactables
{
    using System;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactables.ComponentTags;
    using Tilia.Interactions.Interactables.Interactables.Grab;
    using Tilia.Interactions.Interactables.Interactables.Grab.Action;
    using Tilia.Interactions.Interactables.Interactables.Touch;
    using Tilia.Interactions.Interactables.Interactables.Utility;
    using Tilia.Interactions.Interactables.Interactors;
#if UNITY_EDITOR
    using UnityEditor;
#endif
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Rule;
    using Zinnia.Tracking.Collision;
    using Zinnia.Tracking.Collision.Active.Operation.Extraction;

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
            set
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
            set
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
            set
            {
                meshContainer = value;
            }
        }
        [Tooltip("The linked NotifierContainerExtractor for adding collisions.")]
        [SerializeField]
        [Restricted]
        private NotifierContainerExtractor addCollisionExtractor;
        /// <summary>
        /// The linked <see cref="NotifierContainerExtractor"/> for adding collisions.
        /// </summary>
        public NotifierContainerExtractor AddCollisionExtractor
        {
            get
            {
                return addCollisionExtractor;
            }
            set
            {
                addCollisionExtractor = value;
            }
        }
        [Tooltip("The linked NotifierContainerExtractor for removing collisions.")]
        [SerializeField]
        [Restricted]
        private NotifierContainerExtractor removeCollisionExtractor;
        /// <summary>
        /// The linked <see cref="NotifierContainerExtractor"/> for removing collisions.
        /// </summary>
        public NotifierContainerExtractor RemoveCollisionExtractor
        {
            get
            {
                return removeCollisionExtractor;
            }
            set
            {
                removeCollisionExtractor = value;
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
            set
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
            set
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
            set
            {
                grabConfiguration = value;
            }
        }
        [Tooltip("The linked Interactable Visibility Status Tag.")]
        [SerializeField]
        [Restricted]
        private InteractableVisibilityStatusTag interactableVisibilityStatusTagContainer;
        /// <summary>
        /// The linked Interactable Visibility Status Tag.
        /// </summary>
        public InteractableVisibilityStatusTag InteractableVisibilityStatusTagContainer
        {
            get
            {
                return interactableVisibilityStatusTagContainer;
            }
            set
            {
                interactableVisibilityStatusTagContainer = value;
            }
        }
        #endregion

        /// <summary>
        /// The total number of available grab action types.
        /// </summary>
        public virtual int GrabActionTypesCount => GrabConfiguration.ActionTypes.NonSubscribableElements.Count;

        /// <summary>
        /// Whether the Interactable is visible or not.
        /// </summary>
        public virtual bool IsVisible
        {
            get
            {
                return meshColliderTriggerStates.Count == 0;
            }
            set
            {
                if (value)
                {
                    RestoreGrabStateFromCache();
                    RestoreConsumerRigidbodyKinematicStateFromCache();
                    RestoreCollidersAndRenderers();
                    if (InteractableVisibilityStatusTagContainer != null)
                    {
                        InteractableVisibilityStatusTagContainer.enabled = true;
                    }
                }
                else
                {
                    CacheAndSetConsumerRigidbodyKinematicState();
                    CacheAndDisableGrabState();
                    DisableCollidersAndRenderers();
                    if (InteractableVisibilityStatusTagContainer != null)
                    {
                        InteractableVisibilityStatusTagContainer.enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// A collection of trigger states for the colliders held within the <see cref="MeshContainer"/>.
        /// </summary>
        protected Dictionary<Collider, bool> meshColliderTriggerStates = new Dictionary<Collider, bool>();
        /// <summary>
        /// A collection of enabled states for the renderers held within the <see cref="MeshContainer"/>.
        /// </summary>
        protected Dictionary<Renderer, bool> meshRendererEnabledStates = new Dictionary<Renderer, bool>();
        /// <summary>
        /// The cached <see cref="GrabInteractableFollowAction"/> for when the follow/control direction pairing is required to be set up.
        /// </summary>
        protected GrabInteractableFollowAction followCachedAction;
        /// <summary>
        /// The cached <see cref="GrabInteractableControlDirectionAction"/> for when the follow/control direction pairing is required to be set up.
        /// </summary>
        protected GrabInteractableControlDirectionAction controlDirectionCachedAction;
        /// <summary>
        /// The cached kinematic state of the <see cref="Rigidbody"/> when changing the visibility state.
        /// </summary>
        protected bool cachedKinematicState;
        /// <summary>
        /// The cached active state of the <see cref="GrabConfiguration.gameObject"/> when changing the visibility state.
        /// </summary>
        protected bool cachedGrabAllowanceState;

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
        /// Sets the Maximum Angular Velocity of the <see cref="Rigidbody"/> in radians per seconds.
        /// </summary>
        /// <param name="angularVelocity">The maximum angular velocity in radians per seconds.</param>
        public virtual void SetRigidbodyMaxAngularVelocity(float angularVelocity)
        {
            if (consumerRigidbody == null)
            {
                return;
            }

            consumerRigidbody.maxAngularVelocity = angularVelocity;
        }

        protected virtual void OnEnable()
        {
            SetFollowAndControlDirectionPair();
        }

        /// <summary>
        /// Sets up the relevant linkages if the follow and control direction actions are selected in a pairing.
        /// </summary>
        protected virtual void SetFollowAndControlDirectionPair()
        {
            GrabInteractableAction primaryAction = GetPrimaryAction();
            GrabInteractableAction secondaryAction = GetSecondaryAction();

            if (secondaryAction != null && typeof(GrabInteractableControlDirectionAction).IsAssignableFrom(secondaryAction.GetType()))
            {
                controlDirectionCachedAction = (GrabInteractableControlDirectionAction)secondaryAction;
                controlDirectionCachedAction.LinkedObjects = null;
            }

            if (primaryAction == null ||
                secondaryAction == null ||
                !typeof(GrabInteractableFollowAction).IsAssignableFrom(primaryAction.GetType()) ||
                !typeof(GrabInteractableControlDirectionAction).IsAssignableFrom(secondaryAction.GetType()))
            {
                if (followCachedAction != null)
                {
                    followCachedAction.CollisionPointContainerComponent.PointSet.RemoveListener(SetFollowPrecisionPointToDirectionModifierPivot);
                    followCachedAction.CollisionPointContainerComponent.PointUnset.RemoveListener(UnsetFollowPrecisionPointToDirectionModifierPivot);
                    followCachedAction = null;
                    controlDirectionCachedAction = null;
                }
                return;
            }

            followCachedAction = (GrabInteractableFollowAction)primaryAction;
            controlDirectionCachedAction = (GrabInteractableControlDirectionAction)secondaryAction;

            controlDirectionCachedAction.LinkedObjects = followCachedAction.RotationModifiers;

            followCachedAction.CollisionPointContainerComponent.PointSet.AddListener(SetFollowPrecisionPointToDirectionModifierPivot);
            followCachedAction.CollisionPointContainerComponent.PointUnset.AddListener(UnsetFollowPrecisionPointToDirectionModifierPivot);
        }

        /// <summary>
        /// Sets up the link between the primary <see cref="GrabInteractableFollowAction"/> and the secondary <see cref="GrabInteractableControlDirectionAction"/> to mirror the follow precision point to the control direction pivot.
        /// </summary>
        /// <param name="precisionPointContainer">The precision point container.</param>
        protected virtual void SetFollowPrecisionPointToDirectionModifierPivot(GameObject precisionPointContainer)
        {
            if (controlDirectionCachedAction.DirectionModifier.ResetOrientationSpeed < float.MaxValue)
            {
                return;
            }

            controlDirectionCachedAction.DirectionModifier.PivotRotationMirror = precisionPointContainer;
        }

        /// <summary>
        /// Unsets the set up done in the <see cref="SetFollowPrecisionPointToDirectionModifierPivot"/> method.
        /// </summary>
        /// <param name="precisionPointContainer">The precision point container.</param>
        protected virtual void UnsetFollowPrecisionPointToDirectionModifierPivot(GameObject precisionPointContainer)
        {
            controlDirectionCachedAction.DirectionModifier.ClearPivotRotationMirror();
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
                try
                {
                    //If the Unity version supports destroying the nested prefab then do that.
                    DestroyImmediate(currentAction.gameObject);
                }
                catch (InvalidOperationException)
                {
                    //Otherwise just disable that GameObject.
                    currentAction.gameObject.SetActive(false);
                }
            }

            GameObject toInstantiate = GrabConfiguration.ActionTypes.NonSubscribableElements[newActionType];
            GameObject actionObject = null;
#if UNITY_EDITOR
            actionObject = Application.isPlaying ? Instantiate(toInstantiate) : (GameObject)PrefabUtility.InstantiatePrefab(toInstantiate, facade.Configuration.GrabConfiguration.ActionTypes.transform);
#else
            actionObject = Instantiate(toInstantiate);
#endif
            actionObject.transform.position = facade.transform.position;
            actionObject.transform.rotation = facade.transform.rotation;
            actionObject.transform.SetGlobalScale(facade.transform.lossyScale);
            actionObject.transform.SetParent(facade.Configuration.GrabConfiguration.ActionTypes.transform);

            actionObject.name = actionObject.name.Replace("(Clone)", "(Generated)");
            actionObject.transform.SetSiblingIndex(siblingPosition);


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
        /// Caches the existing <see cref="consumerRigidbody"/> kinematic state and sets it to kinematic.
        /// </summary>
        protected virtual void CacheAndSetConsumerRigidbodyKinematicState()
        {
            if (consumerRigidbody != null)
            {
                cachedKinematicState = consumerRigidbody.isKinematic;
                consumerRigidbody.isKinematic = true;

                if (facade.IsGrabbed)
                {
                    facade.LastUngrabbed.AddListener(HandleHiddenLastUngrab);
                }
            }
        }

        /// <summary>
        /// Deals with when a hidden object is last ungrabbed to ensure the kinematic state is correct.
        /// </summary>
        /// <param name="_">unused.</param>
        protected virtual void HandleHiddenLastUngrab(InteractorFacade _)
        {
            cachedKinematicState = consumerRigidbody.isKinematic;
            consumerRigidbody.isKinematic = true;
        }

        /// <summary>
        /// Restores the kinematic state of the <see cref="consumerRigidbody"/> to the cached state.
        /// </summary>
        protected virtual void RestoreConsumerRigidbodyKinematicStateFromCache()
        {
            if (consumerRigidbody != null)
            {
                facade.LastUngrabbed.RemoveListener(HandleHiddenLastUngrab);

                consumerRigidbody.isKinematic = cachedKinematicState;

                if (facade.IsGrabbed)
                {
                    facade.SnapFollowOrientation();
                }
            }
        }

        /// <summary>
        /// Caches the existing grab state of the <see cref="GrabConfiguration"/> and hides the <see cref="GameObject"/> to prevent grab logic.
        /// </summary>
        protected virtual void CacheAndDisableGrabState()
        {
            if (GrabConfiguration != null && GrabConfiguration.GrabReceiver != null && GrabConfiguration.GrabReceiver.GrabConsumer != null)
            {
                cachedGrabAllowanceState = GrabConfiguration.GrabReceiver.GrabConsumer.gameObject.activeInHierarchy;
                GrabConfiguration.GrabReceiver.GrabConsumer.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Restores the grab state of the <see cref="GrabConfiguration"/> and applies the active state to the <see cref="GameObject"/> from the cached state.
        /// </summary>
        protected virtual void RestoreGrabStateFromCache()
        {
            if (GrabConfiguration != null && GrabConfiguration.GrabReceiver != null && GrabConfiguration.GrabReceiver.GrabConsumer != null)
            {
                GrabConfiguration.GrabReceiver.GrabConsumer.gameObject.SetActive(cachedGrabAllowanceState);
            }
        }


        /// <summary>
        /// Hides all of the found <see cref="Collider"/> and <see cref="Renderer"/> components in the <see cref="MeshContainer"/> and saves their current state for later restore.
        /// </summary>
        protected virtual void DisableCollidersAndRenderers()
        {
            if (MeshContainer == null)
            {
                return;
            }

            meshColliderTriggerStates.Clear();
            foreach (Collider current in MeshContainer.GetComponentsInChildren<Collider>())
            {
                meshColliderTriggerStates.Add(current, current.isTrigger);
                current.isTrigger = true;
            }

            meshRendererEnabledStates.Clear();
            foreach (Renderer current in MeshContainer.GetComponentsInChildren<Renderer>())
            {
                meshRendererEnabledStates.Add(current, current.enabled);
                current.enabled = false;
            }
        }

        /// <summary>
        /// Restores all of the current saved states for the found <see cref="Collider"/> and <see cref="Renderer"/> components found in the <see cref="MeshContainer"/>.
        /// </summary>
        protected virtual void RestoreCollidersAndRenderers()
        {
            if (MeshContainer == null)
            {
                return;
            }

            foreach (Collider current in MeshContainer.GetComponentsInChildren<Collider>())
            {
                if (meshColliderTriggerStates.TryGetValue(current, out bool state))
                {
                    current.isTrigger = state;
                }
            }
            meshColliderTriggerStates.Clear();

            foreach (Renderer current in MeshContainer.GetComponentsInChildren<Renderer>())
            {
                if (meshRendererEnabledStates.TryGetValue(current, out bool state))
                {
                    current.enabled = state;
                }
            }
            meshRendererEnabledStates.Clear();
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