# Class GrabInteractableFollowAction

Describes an action that allows the Interactable to follow an Interactor's position, rotation and scale.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [FollowRigidbodyForceRotateModifier]
  * [FollowRigidbodyModifier]
  * [FollowRotateAroundAngularVelocityModifier]
  * [FollowTracking]
  * [FollowTransformModifier]
  * [FollowTransformRotateOnPositionDifferenceModifier]
  * [ForceSnapFollower]
  * [GrabOffset]
  * [IsKinematicWhenActive]
  * [IsKinematicWhenInactive]
  * [ObjectFollower]
  * [OrientationHandleContainer]
  * [OrientationHandleLogic]
  * [OrientationLogicContainer]
  * [OrientationRelationsLogicContainer]
  * [OrientationRulesMatcherLogicContainer]
  * [PositionModifiers]
  * [PrecisionCollisionPoint]
  * [PrecisionCreateContainer]
  * [PrecisionForceCreateContainer]
  * [PrecisionLogicContainer]
  * [RotationModifiers]
  * [ScaleModifiers]
  * [VelocityApplier]
  * [VelocityMultiplier]
  * [WillInheritIsKinematicWhenInactiveFromConsumerRigidbody]
* [Methods]
  * [ApplyActiveKinematicState(GameObject)]
  * [ApplyInactiveKinematicState(GameObject)]
  * [ConfigureFollowTracking()]
  * [ConfigureGrabOffset()]
  * [ForceSnapOrientation()]
  * [OnAfterFollowTrackingChange()]
  * [OnAfterGrabOffsetChange()]
  * [OnAfterGrabSetupChange()]
  * [OnAfterOrientationHandleLogicChange()]
  * [OnEnable()]
  * [PrepareColliderForKinematicChange(GameObject)]
  * [SetFollowTracking(Int32)]
  * [SetGrabOffset(Int32)]
  * [SetOrientationHandleLogic(Int32)]
  * [UseGameObjectRelationsOrientationHandleLogic()]
  * [UseRulesMatcherOrientationHandleLogic()]

## Details

##### Inheritance

* System.Object
* [GrabInteractableAction]
* GrabInteractableFollowAction

##### Inherited Members

[GrabInteractableAction.InputActiveCollisionConsumer]

[GrabInteractableAction.InputGrabReceived]

[GrabInteractableAction.InputUngrabReceived]

[GrabInteractableAction.InputGrabSetup]

[GrabInteractableAction.InputUngrabReset]

[GrabInteractableAction.GrabSetup]

[GrabInteractableAction.NotifyGrab(GameObject)]

[GrabInteractableAction.NotifyUngrab(GameObject)]

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab.Action]

##### Syntax

```
public class GrabInteractableFollowAction : GrabInteractableAction
```

### Properties

#### FollowRigidbodyForceRotateModifier

The FollowModifier to rotate by applying a force to the Rigidbody.

##### Declaration

```
public FollowModifier FollowRigidbodyForceRotateModifier { get; protected set; }
```

#### FollowRigidbodyModifier

The FollowModifier to move by applying velocities to the Rigidbody.

##### Declaration

```
public FollowModifier FollowRigidbodyModifier { get; protected set; }
```

#### FollowRotateAroundAngularVelocityModifier

The FollowModifier to rotate by the angular velocity of the source Interactor.

##### Declaration

```
public FollowModifier FollowRotateAroundAngularVelocityModifier { get; protected set; }
```

#### FollowTracking

Determines how to track the movement of Interactable to the Interactor.

##### Declaration

```
public GrabInteractableFollowAction.TrackingType FollowTracking { get; set; }
```

#### FollowTransformModifier

The FollowModifier to move by following the transform.

##### Declaration

```
public FollowModifier FollowTransformModifier { get; protected set; }
```

#### FollowTransformRotateOnPositionDifferenceModifier

The FollowModifier to rotate by the angle difference between the source positions.

##### Declaration

```
public FollowModifier FollowTransformRotateOnPositionDifferenceModifier { get; protected set; }
```

#### ForceSnapFollower

The [ObjectFollower] to force snap the Interactable to the Interactor.

##### Declaration

```
public ObjectFollower ForceSnapFollower { get; protected set; }
```

#### GrabOffset

The offset to apply when grabbing the Interactable.

##### Declaration

```
public GrabInteractableFollowAction.OffsetType GrabOffset { get; set; }
```

#### IsKinematicWhenActive

Whether the Rigidbody of the Interactable should be in a kinematic state when the follow action is active.

##### Declaration

```
public bool IsKinematicWhenActive { get; set; }
```

#### IsKinematicWhenInactive

Whether the Rigidbody of the Interactable should be in a kinematic state when the follow action is inactive.

##### Declaration

```
public bool IsKinematicWhenInactive { get; set; }
```

#### ObjectFollower

The Zinnia.Tracking.Follow.ObjectFollower for tracking movement.

##### Declaration

```
public ObjectFollower ObjectFollower { get; protected set; }
```

#### OrientationHandleContainer

The container for the orientation handles.

##### Declaration

```
public GameObject OrientationHandleContainer { get; protected set; }
```

#### OrientationHandleLogic

The type of orientation handle logic to use.

##### Declaration

```
public GrabInteractableFollowAction.OrientationProcessorType OrientationHandleLogic { get; set; }
```

#### OrientationLogicContainer

The container for the orientation handle logic.

##### Declaration

```
public GameObject OrientationLogicContainer { get; protected set; }
```

#### OrientationRelationsLogicContainer

The container for the orientation GameObject Relations logic.

##### Declaration

```
public GameObject OrientationRelationsLogicContainer { get; protected set; }
```

#### OrientationRulesMatcherLogicContainer

The container for the orientation Rules Matcher logic.

##### Declaration

```
public GameObject OrientationRulesMatcherLogicContainer { get; protected set; }
```

#### PositionModifiers

A GameObjectObservableList collection of all position modifiers used within the follow modifiers.

##### Declaration

```
public GameObjectObservableList PositionModifiers { get; protected set; }
```

#### PrecisionCollisionPoint

The collsiion point GameObject that is created upon a precision grab occurring.

##### Declaration

```
public virtual GameObject PrecisionCollisionPoint { get; }
```

#### PrecisionCreateContainer

The container for the precision point creation logic.

##### Declaration

```
public GameObject PrecisionCreateContainer { get; protected set; }
```

#### PrecisionForceCreateContainer

The container for the precision point force creation logic.

##### Declaration

```
public GameObject PrecisionForceCreateContainer { get; protected set; }
```

#### PrecisionLogicContainer

The container for the precision point logic.

##### Declaration

```
public GameObject PrecisionLogicContainer { get; protected set; }
```

#### RotationModifiers

A GameObjectObservableList collection of all rotation modifiers used within the follow modifiers.

##### Declaration

```
public GameObjectObservableList RotationModifiers { get; protected set; }
```

#### ScaleModifiers

A GameObjectObservableList collection of all scale modifiers used within the follow modifiers.

##### Declaration

```
public GameObjectObservableList ScaleModifiers { get; protected set; }
```

#### VelocityApplier

The Zinnia.Tracking.Velocity.VelocityApplier to apply velocity on ungrab.

##### Declaration

```
public VelocityApplier VelocityApplier { get; protected set; }
```

#### VelocityMultiplier

The Zinnia.Tracking.Velocity.VelocityMultiplier to multiply the applied velocity on ungrab.

##### Declaration

```
public VelocityMultiplier VelocityMultiplier { get; protected set; }
```

#### WillInheritIsKinematicWhenInactiveFromConsumerRigidbody

Whether the [IsKinematicWhenInactive] property inherits the kinematic state from GrabSetup.Facade.ConsumerRigidbody.isKinematic.

##### Declaration

```
public bool WillInheritIsKinematicWhenInactiveFromConsumerRigidbody { get; set; }
```

### Methods

#### ApplyActiveKinematicState(GameObject)

Applies the active kinematic state to the Rigidbody of the Interactable.

##### Declaration

```
public virtual void ApplyActiveKinematicState(GameObject initiator)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | initiator | The initiator that is causing this state change. |

#### ApplyInactiveKinematicState(GameObject)

Applies the inactive kinematic state to the Rigidbody of the Interactable.

##### Declaration

```
public virtual void ApplyInactiveKinematicState(GameObject initiator)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | initiator | The initiator that is causing this state change. |

#### ConfigureFollowTracking()

Configures the appropriate processes to be used for follow tracking based on the [FollowTracking] setting.

##### Declaration

```
protected virtual void ConfigureFollowTracking()
```

#### ConfigureGrabOffset()

Configures the appropriate processes to be used for grab offset based on the [GrabOffset] setting.

##### Declaration

```
protected virtual void ConfigureGrabOffset()
```

#### ForceSnapOrientation()

Force snaps the Interactable to the following Interactor.

##### Declaration

```
public virtual void ForceSnapOrientation()
```

#### OnAfterFollowTrackingChange()

Called after [FollowTracking] has been changed.

##### Declaration

```
protected virtual void OnAfterFollowTrackingChange()
```

#### OnAfterGrabOffsetChange()

Called after [GrabOffset] has been changed.

##### Declaration

```
protected virtual void OnAfterGrabOffsetChange()
```

#### OnAfterGrabSetupChange()

Called after [GrabSetup] has been changed.

##### Declaration

```
protected override void OnAfterGrabSetupChange()
```

##### Overrides

[GrabInteractableAction.OnAfterGrabSetupChange()]

#### OnAfterOrientationHandleLogicChange()

Called after [OrientationHandleLogic] has been changed.

##### Declaration

```
protected virtual void OnAfterOrientationHandleLogicChange()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### PrepareColliderForKinematicChange(GameObject)

Prepares the initiator for a kinematic change if the initiator is an Interactor.

##### Declaration

```
protected virtual void PrepareColliderForKinematicChange(GameObject initiator)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | initiator | The potential Interactor causing this state change. |

#### SetFollowTracking(Int32)

Sets the [FollowTracking].

##### Declaration

```
public virtual void SetFollowTracking(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index of the [GrabInteractableFollowAction.TrackingType]. |

#### SetGrabOffset(Int32)

Sets the [GrabOffset].

##### Declaration

```
public virtual void SetGrabOffset(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index of the [GrabInteractableFollowAction.OffsetType]. |

#### SetOrientationHandleLogic(Int32)

Sets the [OrientationHandleLogic].

##### Declaration

```
public virtual void SetOrientationHandleLogic(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index of the [GrabInteractableFollowAction.OrientationProcessorType]. |

#### UseGameObjectRelationsOrientationHandleLogic()

Enables the GameObject Relations Orientation Handle logic.

##### Declaration

```
public virtual void UseGameObjectRelationsOrientationHandleLogic()
```

#### UseRulesMatcherOrientationHandleLogic()

Enables the Rules Matcher Orientation Handle logic.

##### Declaration

```
public virtual void UseRulesMatcherOrientationHandleLogic()
```

[GrabInteractableAction]: GrabInteractableAction.md
[GrabInteractableAction.InputActiveCollisionConsumer]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputActiveCollisionConsumer
[GrabInteractableAction.InputGrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabReceived
[GrabInteractableAction.InputUngrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReceived
[GrabInteractableAction.InputGrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabSetup
[GrabInteractableAction.InputUngrabReset]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReset
[GrabInteractableAction.GrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_GrabSetup
[GrabInteractableAction.NotifyGrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyGrab_GameObject_
[GrabInteractableAction.NotifyUngrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyUngrab_GameObject_
[Tilia.Interactions.Interactables.Interactables.Grab.Action]: README.md
[ObjectFollower]: GrabInteractableFollowAction.md#ObjectFollower
[IsKinematicWhenInactive]: GrabInteractableFollowAction.md#IsKinematicWhenInactive
[FollowTracking]: GrabInteractableFollowAction.md#FollowTracking
[GrabOffset]: GrabInteractableFollowAction.md#GrabOffset
[FollowTracking]: GrabInteractableFollowAction.md#FollowTracking
[GrabOffset]: GrabInteractableFollowAction.md#GrabOffset
[GrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_GrabSetup
[GrabInteractableAction.OnAfterGrabSetupChange()]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_OnAfterGrabSetupChange
[OrientationHandleLogic]: GrabInteractableFollowAction.md#OrientationHandleLogic
[FollowTracking]: GrabInteractableFollowAction.md#FollowTracking
[GrabInteractableFollowAction.TrackingType]: GrabInteractableFollowAction.TrackingType.md
[GrabOffset]: GrabInteractableFollowAction.md#GrabOffset
[GrabInteractableFollowAction.OffsetType]: GrabInteractableFollowAction.OffsetType.md
[OrientationHandleLogic]: GrabInteractableFollowAction.md#OrientationHandleLogic
[GrabInteractableFollowAction.OrientationProcessorType]: GrabInteractableFollowAction.OrientationProcessorType.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[FollowRigidbodyForceRotateModifier]: #FollowRigidbodyForceRotateModifier
[FollowRigidbodyModifier]: #FollowRigidbodyModifier
[FollowRotateAroundAngularVelocityModifier]: #FollowRotateAroundAngularVelocityModifier
[FollowTracking]: #FollowTracking
[FollowTransformModifier]: #FollowTransformModifier
[FollowTransformRotateOnPositionDifferenceModifier]: #FollowTransformRotateOnPositionDifferenceModifier
[ForceSnapFollower]: #ForceSnapFollower
[GrabOffset]: #GrabOffset
[IsKinematicWhenActive]: #IsKinematicWhenActive
[IsKinematicWhenInactive]: #IsKinematicWhenInactive
[ObjectFollower]: #ObjectFollower
[OrientationHandleContainer]: #OrientationHandleContainer
[OrientationHandleLogic]: #OrientationHandleLogic
[OrientationLogicContainer]: #OrientationLogicContainer
[OrientationRelationsLogicContainer]: #OrientationRelationsLogicContainer
[OrientationRulesMatcherLogicContainer]: #OrientationRulesMatcherLogicContainer
[PositionModifiers]: #PositionModifiers
[PrecisionCollisionPoint]: #PrecisionCollisionPoint
[PrecisionCreateContainer]: #PrecisionCreateContainer
[PrecisionForceCreateContainer]: #PrecisionForceCreateContainer
[PrecisionLogicContainer]: #PrecisionLogicContainer
[RotationModifiers]: #RotationModifiers
[ScaleModifiers]: #ScaleModifiers
[VelocityApplier]: #VelocityApplier
[VelocityMultiplier]: #VelocityMultiplier
[WillInheritIsKinematicWhenInactiveFromConsumerRigidbody]: #WillInheritIsKinematicWhenInactiveFromConsumerRigidbody
[Methods]: #Methods
[ApplyActiveKinematicState(GameObject)]: #ApplyActiveKinematicStateGameObject
[ApplyInactiveKinematicState(GameObject)]: #ApplyInactiveKinematicStateGameObject
[ConfigureFollowTracking()]: #ConfigureFollowTracking
[ConfigureGrabOffset()]: #ConfigureGrabOffset
[ForceSnapOrientation()]: #ForceSnapOrientation
[OnAfterFollowTrackingChange()]: #OnAfterFollowTrackingChange
[OnAfterGrabOffsetChange()]: #OnAfterGrabOffsetChange
[OnAfterGrabSetupChange()]: #OnAfterGrabSetupChange
[OnAfterOrientationHandleLogicChange()]: #OnAfterOrientationHandleLogicChange
[OnEnable()]: #OnEnable
[PrepareColliderForKinematicChange(GameObject)]: #PrepareColliderForKinematicChangeGameObject
[SetFollowTracking(Int32)]: #SetFollowTrackingInt32
[SetGrabOffset(Int32)]: #SetGrabOffsetInt32
[SetOrientationHandleLogic(Int32)]: #SetOrientationHandleLogicInt32
[UseGameObjectRelationsOrientationHandleLogic()]: #UseGameObjectRelationsOrientationHandleLogic
[UseRulesMatcherOrientationHandleLogic()]: #UseRulesMatcherOrientationHandleLogic
