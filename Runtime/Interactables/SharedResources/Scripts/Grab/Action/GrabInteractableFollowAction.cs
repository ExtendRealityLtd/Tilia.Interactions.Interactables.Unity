namespace Tilia.Interactions.Interactables.Interactables.Grab.Action
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
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

        #region Interactable Settings
        /// <summary>
        /// Determines how to track the movement of Interactable to the Interactor.
        /// </summary>
        [Serialized]
        [field: Header("Follow Settings"), DocumentedByXml]
        public TrackingType FollowTracking { get; set; }
        /// <summary>
        /// The offset to apply when grabbing the Interactable.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public OffsetType GrabOffset { get; set; }
        /// <summary>
        /// Whether the <see cref="Rigidbody"/> of the Interactable should be in a kinematic state when the follow action is active.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public bool IsKinematicWhenActive { get; set; } = true;
        /// <summary>
        /// Whether the <see cref="Rigidbody"/> of the Interactable should be in a kinematic state when the follow action is inactive.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public bool IsKinematicWhenInactive { get; set; }
        /// <summary>
        /// Whether the <see cref="IsKinematicWhenInactive"/> property inherits the kinematic state from <see cref="GrabSetup.Facade.ConsumerRigidbody.isKinematic"/>.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public bool WillInheritIsKinematicWhenInactiveFromConsumerRigidbody { get; set; } = true;
        #endregion

        #region Tracking Settings
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Follow.ObjectFollower"/> for tracking movement.
        /// </summary>
        [Serialized]
        [field: Header("Interactable Settings"), DocumentedByXml, Restricted]
        public ObjectFollower ObjectFollower { get; protected set; }
        /// <summary>
        /// A <see cref="GameObjectObservableList"/> collection of all position modifiers used within the follow modifiers.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObjectObservableList PositionModifiers { get; protected set; }
        /// <summary>
        /// A <see cref="GameObjectObservableList"/> collection of all rotation modifiers used within the follow modifiers.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObjectObservableList RotationModifiers { get; protected set; }
        /// <summary>
        /// A <see cref="GameObjectObservableList"/> collection of all scale modifiers used within the follow modifiers.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObjectObservableList ScaleModifiers { get; protected set; }
        /// <summary>
        /// The <see cref="FollowModifier"/> to move by following the transform.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public FollowModifier FollowTransformModifier { get; protected set; }
        /// <summary>
        /// The <see cref="FollowModifier"/> to move by applying velocities to the <see cref="Rigidbody"/>.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public FollowModifier FollowRigidbodyModifier { get; protected set; }
        /// <summary>
        /// The <see cref="FollowModifier"/> to rotate by applying a force to the <see cref="Rigidbody"/>.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public FollowModifier FollowRigidbodyForceRotateModifier { get; protected set; }
        /// <summary>
        /// The <see cref="FollowModifier"/> to rotate by the angle difference between the source positions.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public FollowModifier FollowTransformRotateOnPositionDifferenceModifier { get; protected set; }
        /// <summary>
        /// The <see cref="FollowModifier"/> to rotate by the angular velocity of the source Interactor.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public FollowModifier FollowRotateAroundAngularVelocityModifier { get; protected set; }
        /// <summary>
        /// The <see cref="ObjectFollower"/> to force snap the Interactable to the Interactor.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ObjectFollower ForceSnapFollower { get; protected set; }
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Velocity.VelocityApplier"/> to apply velocity on ungrab.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public VelocityApplier VelocityApplier { get; protected set; }
        #endregion

        #region Grab Offset Settings
        /// <summary>
        /// The container for the precision point logic.
        /// </summary>
        [Serialized]
        [field: Header("Grab Offset Settings"), DocumentedByXml, Restricted]
        public GameObject PrecisionLogicContainer { get; protected set; }
        /// <summary>
        /// The container for the precision point creation logic.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObject PrecisionCreateContainer { get; protected set; }
        /// <summary>
        /// The container for the precision point force creation logic.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObject PrecisionForceCreateContainer { get; protected set; }
        /// <summary>
        /// The container for the orientation handle  logic.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObject OrientationLogicContainer { get; protected set; }
        #endregion

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

        protected virtual void OnEnable()
        {
            ConfigureFollowTracking();
            ConfigureGrabOffset();
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
        [CalledAfterChangeOf(nameof(FollowTracking))]
        protected virtual void OnAfterFollowTrackingChange()
        {
            ConfigureFollowTracking();
        }

        /// <summary>
        /// Called after <see cref="GrabOffset"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(GrabOffset))]
        protected virtual void OnAfterGrabOffsetChange()
        {
            ConfigureGrabOffset();
        }
    }
}