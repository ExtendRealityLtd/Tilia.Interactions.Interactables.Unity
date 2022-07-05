namespace Tilia.Interactions.Interactables.Interactables.Grab.Action
{
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Tracking.Follow;
    using Zinnia.Tracking.Follow.Modifier;
    using Zinnia.Tracking.Velocity;

    /// <summary>
    /// Describes an action that allows the Interactable to follow an Interactor's position, rotation and scale.
    /// </summary>
    public class GrabInteractableFollowAction : GrabInteractableAction
    {
        /// <summary>
        /// The way in which the object is moved.
        /// </summary>
        public enum TrackingType
        {
            /// <summary>
            /// Updates the transform data directly, outside of the physics system.
            /// </summary>
            FollowTransform,
            /// <summary>
            /// Updates the <see cref="Rigidbody"/> using velocity to stay within the bounds of the physics system.
            /// </summary>
            FollowRigidbody,
            /// <summary>
            /// Updates the <see cref="Rigidbody"/> rotation by using a force at position.
            /// </summary>
            FollowRigidbodyForceRotate,
            /// <summary>
            /// Updates the transform rotation based on the position difference of the source.
            /// </summary>
            FollowTransformPositionDifferenceRotate,
            /// <summary>
            /// Updates the transform rotation based on the rotation of the Interactor's angular velocity around a given axis.
            /// </summary>
            FollowRotateAroundAngularVelocity
        }

        /// <summary>
        /// The offset to apply on grab.
        /// </summary>
        public enum OffsetType
        {
            /// <summary>
            /// No offset is applied.
            /// </summary>
            None,
            /// <summary>
            /// An offset of a specified <see cref="GameObject"/> is applied to orientate the Interactable on grab.
            /// </summary>
            OrientationHandle,
            /// <summary>
            /// An offset of where the collision between the Interactor and Interactable is applied for precision grabbing.
            /// </summary>
            PrecisionPoint,
            /// <summary>
            /// The precision point offset will always be re-created based on the latest Interactor grabbing the Interactable.
            /// </summary>
            ForcePrecisionPoint
        }

        /// <summary>
        /// The type of processing for the orientation handle.
        /// </summary>
        public enum OrientationProcessorType
        {
            /// <summary>
            /// Uses the GameObjectRelations logic.
            /// </summary>
            GameObjectRelation,
            /// <summary>
            /// Uses the Rules Matcherr logic.
            /// </summary>
            RuleBased
        }

        #region Interactable Settings
        [Header("Follow Settings")]
        [Tooltip("Determines how to track the movement of Interactable to the Interactor.")]
        [SerializeField]
        private TrackingType followTracking;
        /// <summary>
        /// Determines how to track the movement of Interactable to the Interactor.
        /// </summary>
        public TrackingType FollowTracking
        {
            get
            {
                return followTracking;
            }
            set
            {
                followTracking = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterFollowTrackingChange();
                }
            }
        }
        [Tooltip("The offset to apply when grabbing the Interactable.")]
        [SerializeField]
        private OffsetType grabOffset;
        /// <summary>
        /// The offset to apply when grabbing the Interactable.
        /// </summary>
        public OffsetType GrabOffset
        {
            get
            {
                return grabOffset;
            }
            set
            {
                grabOffset = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterGrabOffsetChange();
                }
            }
        }
        [Tooltip("The type of orientation handle logic to use.")]
        [SerializeField]
        private OrientationProcessorType orientationHandleLogic;
        /// <summary>
        /// The type of orientation handle logic to use.
        /// </summary>
        public OrientationProcessorType OrientationHandleLogic
        {
            get
            {
                return orientationHandleLogic;
            }
            set
            {
                orientationHandleLogic = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterOrientationHandleLogicChange();
                }
            }
        }
        [Tooltip("Whether the Rigidbody of the Interactable should be in a kinematic state when the follow action is active.")]
        [SerializeField]
        private bool isKinematicWhenActive = true;
        /// <summary>
        /// Whether the <see cref="Rigidbody"/> of the Interactable should be in a kinematic state when the follow action is active.
        /// </summary>
        public bool IsKinematicWhenActive
        {
            get
            {
                return isKinematicWhenActive;
            }
            set
            {
                isKinematicWhenActive = value;
            }
        }
        [Tooltip("Whether the Rigidbody of the Interactable should be in a kinematic state when the follow action is inactive.")]
        [SerializeField]
        private bool isKinematicWhenInactive;
        /// <summary>
        /// Whether the <see cref="Rigidbody"/> of the Interactable should be in a kinematic state when the follow action is inactive.
        /// </summary>
        public bool IsKinematicWhenInactive
        {
            get
            {
                return isKinematicWhenInactive;
            }
            set
            {
                isKinematicWhenInactive = value;
            }
        }
        [Tooltip("Whether the IsKinematicWhenInactive property inherits the kinematic state from GrabSetup.Facade.ConsumerRigidbody.isKinematic.")]
        [SerializeField]
        private bool willInheritIsKinematicWhenInactiveFromConsumerRigidbody = true;
        /// <summary>
        /// Whether the <see cref="IsKinematicWhenInactive"/> property inherits the kinematic state from <see cref="GrabSetup.Facade.ConsumerRigidbody.isKinematic"/>.
        /// </summary>
        public bool WillInheritIsKinematicWhenInactiveFromConsumerRigidbody
        {
            get
            {
                return willInheritIsKinematicWhenInactiveFromConsumerRigidbody;
            }
            set
            {
                willInheritIsKinematicWhenInactiveFromConsumerRigidbody = value;
            }
        }
        #endregion

        #region Tracking Settings
        [Header("Interactable Settings")]
        [Tooltip("The Zinnia.Tracking.Follow.ObjectFollower for tracking movement.")]
        [SerializeField]
        [Restricted]
        private ObjectFollower objectFollower;
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Follow.ObjectFollower"/> for tracking movement.
        /// </summary>
        public ObjectFollower ObjectFollower
        {
            get
            {
                return objectFollower;
            }
            protected set
            {
                objectFollower = value;
            }
        }
        [Tooltip("A GameObjectObservableList collection of all position modifiers used within the follow modifiers.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList positionModifiers;
        /// <summary>
        /// A <see cref="GameObjectObservableList"/> collection of all position modifiers used within the follow modifiers.
        /// </summary>
        public GameObjectObservableList PositionModifiers
        {
            get
            {
                return positionModifiers;
            }
            protected set
            {
                positionModifiers = value;
            }
        }
        [Tooltip("A GameObjectObservableList collection of all rotation modifiers used within the follow modifiers.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList rotationModifiers;
        /// <summary>
        /// A <see cref="GameObjectObservableList"/> collection of all rotation modifiers used within the follow modifiers.
        /// </summary>
        public GameObjectObservableList RotationModifiers
        {
            get
            {
                return rotationModifiers;
            }
            protected set
            {
                rotationModifiers = value;
            }
        }
        [Tooltip("A GameObjectObservableList collection of all scale modifiers used within the follow modifiers.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList scaleModifiers;
        /// <summary>
        /// A <see cref="GameObjectObservableList"/> collection of all scale modifiers used within the follow modifiers.
        /// </summary>
        public GameObjectObservableList ScaleModifiers
        {
            get
            {
                return scaleModifiers;
            }
            protected set
            {
                scaleModifiers = value;
            }
        }
        [Tooltip("The FollowModifier to move by following the transform.")]
        [SerializeField]
        [Restricted]
        private FollowModifier followTransformModifier;
        /// <summary>
        /// The <see cref="FollowModifier"/> to move by following the transform.
        /// </summary>
        public FollowModifier FollowTransformModifier
        {
            get
            {
                return followTransformModifier;
            }
            protected set
            {
                followTransformModifier = value;
            }
        }
        [Tooltip("The FollowModifier to move by applying velocities to the Rigidbody.")]
        [SerializeField]
        [Restricted]
        private FollowModifier followRigidbodyModifier;
        /// <summary>
        /// The <see cref="FollowModifier"/> to move by applying velocities to the <see cref="Rigidbody"/>.
        /// </summary>
        public FollowModifier FollowRigidbodyModifier
        {
            get
            {
                return followRigidbodyModifier;
            }
            protected set
            {
                followRigidbodyModifier = value;
            }
        }
        [Tooltip("The FollowModifier to rotate by applying a force to the Rigidbody.")]
        [SerializeField]
        [Restricted]
        private FollowModifier followRigidbodyForceRotateModifier;
        /// <summary>
        /// The <see cref="FollowModifier"/> to rotate by applying a force to the <see cref="Rigidbody"/>.
        /// </summary>
        public FollowModifier FollowRigidbodyForceRotateModifier
        {
            get
            {
                return followRigidbodyForceRotateModifier;
            }
            protected set
            {
                followRigidbodyForceRotateModifier = value;
            }
        }
        [Tooltip("The FollowModifier to rotate by the angle difference between the source positions.")]
        [SerializeField]
        [Restricted]
        private FollowModifier followTransformRotateOnPositionDifferenceModifier;
        /// <summary>
        /// The <see cref="FollowModifier"/> to rotate by the angle difference between the source positions.
        /// </summary>
        public FollowModifier FollowTransformRotateOnPositionDifferenceModifier
        {
            get
            {
                return followTransformRotateOnPositionDifferenceModifier;
            }
            protected set
            {
                followTransformRotateOnPositionDifferenceModifier = value;
            }
        }
        [Tooltip("The FollowModifier to rotate by the angular velocity of the source Interactor.")]
        [SerializeField]
        [Restricted]
        private FollowModifier followRotateAroundAngularVelocityModifier;
        /// <summary>
        /// The <see cref="FollowModifier"/> to rotate by the angular velocity of the source Interactor.
        /// </summary>
        public FollowModifier FollowRotateAroundAngularVelocityModifier
        {
            get
            {
                return followRotateAroundAngularVelocityModifier;
            }
            protected set
            {
                followRotateAroundAngularVelocityModifier = value;
            }
        }
        [Tooltip("The ObjectFollower to force snap the Interactable to the Interactor.")]
        [SerializeField]
        [Restricted]
        private ObjectFollower forceSnapFollower;
        /// <summary>
        /// The <see cref="ObjectFollower"/> to force snap the Interactable to the Interactor.
        /// </summary>
        public ObjectFollower ForceSnapFollower
        {
            get
            {
                return forceSnapFollower;
            }
            protected set
            {
                forceSnapFollower = value;
            }
        }
        [Tooltip("The Zinnia.Tracking.Velocity.VelocityApplier to apply velocity on ungrab.")]
        [SerializeField]
        [Restricted]
        private VelocityApplier velocityApplier;
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Velocity.VelocityApplier"/> to apply velocity on ungrab.
        /// </summary>
        public VelocityApplier VelocityApplier
        {
            get
            {
                return velocityApplier;
            }
            protected set
            {
                velocityApplier = value;
            }
        }
        [Tooltip("The Zinnia.Tracking.Velocity.VelocityMultiplier to multiply the applied velocity on ungrab.")]
        [SerializeField]
        [Restricted]
        private VelocityMultiplier velocityMultiplier;
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Velocity.VelocityMultiplier"/> to multiply the applied velocity on ungrab.
        /// </summary>
        public VelocityMultiplier VelocityMultiplier
        {
            get
            {
                return velocityMultiplier;
            }
            protected set
            {
                velocityMultiplier = value;
            }
        }
        #endregion

        #region Grab Offset Settings
        [Header("Grab Offset Settings")]
        [Tooltip("The container for the precision point logic.")]
        [SerializeField]
        [Restricted]
        private GameObject precisionLogicContainer;
        /// <summary>
        /// The container for the precision point logic.
        /// </summary>
        public GameObject PrecisionLogicContainer
        {
            get
            {
                return precisionLogicContainer;
            }
            protected set
            {
                precisionLogicContainer = value;
            }
        }
        [Tooltip("The container for the precision point creation logic.")]
        [SerializeField]
        [Restricted]
        private GameObject precisionCreateContainer;
        /// <summary>
        /// The container for the precision point creation logic.
        /// </summary>
        public GameObject PrecisionCreateContainer
        {
            get
            {
                return precisionCreateContainer;
            }
            protected set
            {
                precisionCreateContainer = value;
            }
        }
        [Tooltip("The container for the precision point force creation logic.")]
        [SerializeField]
        [Restricted]
        private GameObject precisionForceCreateContainer;
        /// <summary>
        /// The container for the precision point force creation logic.
        /// </summary>
        public GameObject PrecisionForceCreateContainer
        {
            get
            {
                return precisionForceCreateContainer;
            }
            protected set
            {
                precisionForceCreateContainer = value;
            }
        }
        [Tooltip("The container for the orientation handles.")]
        [SerializeField]
        [Restricted]
        private GameObject orientationHandleContainer;
        /// <summary>
        /// The container for the orientation handles.
        /// </summary>
        public GameObject OrientationHandleContainer
        {
            get
            {
                return orientationHandleContainer;
            }
            protected set
            {
                orientationHandleContainer = value;
            }
        }
        [Tooltip("The container for the orientation handle logic.")]
        [SerializeField]
        [Restricted]
        private GameObject orientationLogicContainer;
        /// <summary>
        /// The container for the orientation handle logic.
        /// </summary>
        public GameObject OrientationLogicContainer
        {
            get
            {
                return orientationLogicContainer;
            }
            protected set
            {
                orientationLogicContainer = value;
            }
        }
        [Tooltip("The container for the orientation GameObject Relations logic.")]
        [SerializeField]
        [Restricted]
        private GameObject orientationRelationsLogicContainer;
        /// <summary>
        /// The container for the orientation GameObject Relations logic.
        /// </summary>
        public GameObject OrientationRelationsLogicContainer
        {
            get
            {
                return orientationRelationsLogicContainer;
            }
            protected set
            {
                orientationRelationsLogicContainer = value;
            }
        }
        [Tooltip("The container for the orientation Rules Matcher logic.")]
        [SerializeField]
        [Restricted]
        private GameObject orientationRulesMatcherLogicContainer;
        /// <summary>
        /// The container for the orientation Rules Matcher logic.
        /// </summary>
        public GameObject OrientationRulesMatcherLogicContainer
        {
            get
            {
                return orientationRulesMatcherLogicContainer;
            }
            protected set
            {
                orientationRulesMatcherLogicContainer = value;
            }
        }
        #endregion

        /// <summary>
        /// The collsiion point <see cref="GameObject"/> that is created upon a precision grab occurring.
        /// </summary>
        public virtual GameObject PrecisionCollisionPoint => ObjectFollower != null && ObjectFollower.TargetOffsets != null && ObjectFollower.TargetOffsets.NonSubscribableElements.Count > 0 ? ObjectFollower.TargetOffsets.NonSubscribableElements[0] : null;

        /// <summary>
        /// Sets the <see cref="FollowTracking"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="TrackingType"/>.</param>
        public virtual void SetFollowTracking(int index)
        {
            FollowTracking = EnumExtensions.GetByIndex<TrackingType>(index);
        }

        /// <summary>
        /// Sets the <see cref="GrabOffset"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="OffsetType"/>.</param>
        public virtual void SetGrabOffset(int index)
        {
            GrabOffset = EnumExtensions.GetByIndex<OffsetType>(index);
        }

        /// <summary>
        /// Sets the <see cref="OrientationHandleLogic"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="OrientationProcessorType"/>.</param>
        public virtual void SetOrientationHandleLogic(int index)
        {
            OrientationHandleLogic = EnumExtensions.GetByIndex<OrientationProcessorType>(index);
        }

        /// <summary>
        /// Applies the active kinematic state to the <see cref="Rigidbody"/> of the Interactable.
        /// </summary>
        /// <param name="initiator">The initiator that is causing this state change.</param>
        public virtual void ApplyActiveKinematicState(GameObject initiator)
        {
            PrepareColliderForKinematicChange(initiator);
            GrabSetup.Facade.Configuration.ConsumerRigidbody.isKinematic = IsKinematicWhenActive;
        }

        /// <summary>
        /// Applies the inactive kinematic state to the <see cref="Rigidbody"/> of the Interactable.
        /// </summary>
        /// <param name="initiator">The initiator that is causing this state change.</param>
        public virtual void ApplyInactiveKinematicState(GameObject initiator)
        {
            PrepareColliderForKinematicChange(initiator);
            GrabSetup.Facade.Configuration.ConsumerRigidbody.isKinematic = IsKinematicWhenInactive;
        }

        /// <summary>
        /// Force snaps the Interactable to the following Interactor.
        /// </summary>
        public virtual void ForceSnapOrientation()
        {
            ForceSnapFollower.Process();
        }

        /// <summary>
        /// Enables the GameObject Relations Orientation Handle logic.
        /// </summary>
        public virtual void UseGameObjectRelationsOrientationHandleLogic()
        {
            orientationRelationsLogicContainer.SetActive(true);
            orientationRulesMatcherLogicContainer.SetActive(false);
        }

        /// <summary>
        /// Enables the Rules Matcher Orientation Handle logic.
        /// </summary>
        public virtual void UseRulesMatcherOrientationHandleLogic()
        {
            orientationRelationsLogicContainer.SetActive(false);
            orientationRulesMatcherLogicContainer.SetActive(true);
        }

        protected virtual void OnEnable()
        {
            ConfigureFollowTracking();
            ConfigureGrabOffset();
            OnAfterOrientationHandleLogicChange();
        }

        /// <summary>
        /// Prepares the initiator for a kinematic change if the initiator is an Interactor.
        /// </summary>
        /// <param name="initiator">The potential Interactor causing this state change.</param>
        protected virtual void PrepareColliderForKinematicChange(GameObject initiator)
        {
            InteractorFacade interactor = initiator.GetComponent<InteractorFacade>();
            if (interactor == null)
            {
                return;
            }

            interactor.TouchConfiguration.TouchTracker.PrepareKinematicStateChange(GrabSetup.Facade.Configuration.ConsumerRigidbody);
            GrabSetup.KinematicStateToChange?.Invoke(GrabSetup.Facade.Configuration.ConsumerRigidbody);
        }

        /// <summary>
        /// Configures the appropriate processes to be used for follow tracking based on the <see cref="FollowTracking"/> setting.
        /// </summary>
        protected virtual void ConfigureFollowTracking()
        {
            if (WillInheritIsKinematicWhenInactiveFromConsumerRigidbody)
            {
                IsKinematicWhenInactive = GrabSetup != null ? GrabSetup.Facade.Configuration.ConsumerRigidbody.isKinematic : false;
            }
            switch (FollowTracking)
            {
                case TrackingType.FollowTransform:
                    FollowTransformModifier.gameObject.SetActive(true);
                    FollowRigidbodyModifier.gameObject.SetActive(false);
                    FollowRigidbodyForceRotateModifier.gameObject.SetActive(false);
                    FollowTransformRotateOnPositionDifferenceModifier.gameObject.SetActive(false);
                    FollowRotateAroundAngularVelocityModifier.gameObject.SetActive(false);
                    ObjectFollower.FollowModifier = FollowTransformModifier;
                    IsKinematicWhenActive = true;
                    break;
                case TrackingType.FollowRigidbody:
                    FollowTransformModifier.gameObject.SetActive(false);
                    FollowRigidbodyModifier.gameObject.SetActive(true);
                    FollowRigidbodyForceRotateModifier.gameObject.SetActive(false);
                    FollowTransformRotateOnPositionDifferenceModifier.gameObject.SetActive(false);
                    FollowRotateAroundAngularVelocityModifier.gameObject.SetActive(false);
                    ObjectFollower.FollowModifier = FollowRigidbodyModifier;
                    IsKinematicWhenActive = false;
                    break;
                case TrackingType.FollowRigidbodyForceRotate:
                    FollowTransformModifier.gameObject.SetActive(false);
                    FollowRigidbodyModifier.gameObject.SetActive(false);
                    FollowRigidbodyForceRotateModifier.gameObject.SetActive(true);
                    FollowTransformRotateOnPositionDifferenceModifier.gameObject.SetActive(false);
                    FollowRotateAroundAngularVelocityModifier.gameObject.SetActive(false);
                    ObjectFollower.FollowModifier = FollowRigidbodyForceRotateModifier;
                    IsKinematicWhenActive = false;
                    break;
                case TrackingType.FollowTransformPositionDifferenceRotate:
                    FollowTransformModifier.gameObject.SetActive(false);
                    FollowRigidbodyModifier.gameObject.SetActive(false);
                    FollowRigidbodyForceRotateModifier.gameObject.SetActive(false);
                    FollowTransformRotateOnPositionDifferenceModifier.gameObject.SetActive(true);
                    FollowRotateAroundAngularVelocityModifier.gameObject.SetActive(false);
                    ObjectFollower.FollowModifier = FollowTransformRotateOnPositionDifferenceModifier;
                    IsKinematicWhenActive = true;
                    break;
                case TrackingType.FollowRotateAroundAngularVelocity:
                    FollowTransformModifier.gameObject.SetActive(false);
                    FollowRigidbodyModifier.gameObject.SetActive(false);
                    FollowRigidbodyForceRotateModifier.gameObject.SetActive(false);
                    FollowTransformRotateOnPositionDifferenceModifier.gameObject.SetActive(false);
                    FollowRotateAroundAngularVelocityModifier.gameObject.SetActive(true);
                    ObjectFollower.FollowModifier = FollowRotateAroundAngularVelocityModifier;
                    IsKinematicWhenActive = true;
                    break;
            }
        }

        /// <summary>
        /// Configures the appropriate processes to be used for grab offset based on the <see cref="GrabOffset"/> setting.
        /// </summary>
        protected virtual void ConfigureGrabOffset()
        {
            switch (GrabOffset)
            {
                case OffsetType.None:
                    PrecisionLogicContainer.TrySetActive(false);
                    OrientationLogicContainer.TrySetActive(false);
                    break;
                case OffsetType.PrecisionPoint:
                    PrecisionLogicContainer.TrySetActive(true);
                    PrecisionCreateContainer.TrySetActive(true);
                    PrecisionForceCreateContainer.TrySetActive(false);
                    OrientationLogicContainer.TrySetActive(false);
                    break;
                case OffsetType.ForcePrecisionPoint:
                    PrecisionLogicContainer.TrySetActive(true);
                    PrecisionForceCreateContainer.TrySetActive(true);
                    PrecisionCreateContainer.TrySetActive(false);
                    OrientationLogicContainer.TrySetActive(false);
                    break;
                case OffsetType.OrientationHandle:
                    PrecisionLogicContainer.TrySetActive(false);
                    OrientationLogicContainer.TrySetActive(true);
                    break;
            }
        }

        /// <inheritdoc />
        protected override void OnAfterGrabSetupChange()
        {
            ObjectFollower.Targets.RunWhenActiveAndEnabled(() => ObjectFollower.Targets.Clear());
            ObjectFollower.Targets.RunWhenActiveAndEnabled(() => ObjectFollower.Targets.Add(GrabSetup.Facade.Configuration.ConsumerContainer));
            VelocityApplier.Target = GrabSetup.Facade.Configuration.ConsumerRigidbody != null ? GrabSetup.Facade.Configuration.ConsumerRigidbody : null;
            ConfigureFollowTracking();
        }

        /// <summary>
        /// Called after <see cref="FollowTracking"/> has been changed.
        /// </summary>
        protected virtual void OnAfterFollowTrackingChange()
        {
            ConfigureFollowTracking();
        }

        /// <summary>
        /// Called after <see cref="GrabOffset"/> has been changed.
        /// </summary>
        protected virtual void OnAfterGrabOffsetChange()
        {
            ConfigureGrabOffset();
        }

        /// <summary>
        /// Called after <see cref="OrientationHandleLogic"/> has been changed.
        /// </summary>
        protected virtual void OnAfterOrientationHandleLogicChange()
        {
            switch (orientationHandleLogic)
            {
                case OrientationProcessorType.GameObjectRelation:
                    UseGameObjectRelationsOrientationHandleLogic();
                    break;
                case OrientationProcessorType.RuleBased:
                    UseRulesMatcherOrientationHandleLogic();
                    break;
            }
        }
    }
}