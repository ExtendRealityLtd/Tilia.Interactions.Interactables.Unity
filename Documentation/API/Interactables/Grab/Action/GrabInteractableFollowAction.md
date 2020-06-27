# Class GrabInteractableFollowAction

Describes an action that allows the Interactable to follow an Interactor's position, rotation and scale.

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

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Grab.Action]

##### Syntax

```
public class GrabInteractableFollowAction : GrabInteractableAction
```

### Properties

#### FollowRigidbodyForceRotateModifier

The FollowModifier to rotate by applying a force to the rigidbody.

##### Declaration

```
public FollowModifier FollowRigidbodyForceRotateModifier { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| FollowModifier | n/a |

#### FollowRigidbodyModifier

The FollowModifier to move by applying velocities to the rigidbody.

##### Declaration

```
public FollowModifier FollowRigidbodyModifier { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| FollowModifier | n/a |

#### FollowRotateAroundAngularVelocityModifier

The FollowModifier to rotate by the angular velocity of the source interactor.

##### Declaration

```
public FollowModifier FollowRotateAroundAngularVelocityModifier { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| FollowModifier | n/a |

#### FollowTracking

Determines how to track the movement of interactable to the interactor.

##### Declaration

```
public GrabInteractableFollowAction.TrackingType FollowTracking { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableFollowAction.TrackingType] | n/a |

#### FollowTransformModifier

The FollowModifier to move by following the transform.

##### Declaration

```
public FollowModifier FollowTransformModifier { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| FollowModifier | n/a |

#### FollowTransformRotateOnPositionDifferenceModifier

The FollowModifier to rotate by the angle difference between the source positions.

##### Declaration

```
public FollowModifier FollowTransformRotateOnPositionDifferenceModifier { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| FollowModifier | n/a |

#### GrabOffset

The offset to apply when grabbing the Interactable.

##### Declaration

```
public GrabInteractableFollowAction.OffsetType GrabOffset { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableFollowAction.OffsetType] | n/a |

#### IsKinematicWhenActive

Whether the Rigidbody of the interactable should be in a kinematic state when the follow action is active.

##### Declaration

```
public bool IsKinematicWhenActive { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### IsKinematicWhenInactive

Whether the Rigidbody of the interactable should be in a kinematic state when the follow action is inactive.

##### Declaration

```
public bool IsKinematicWhenInactive { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### ObjectFollower

The Zinnia.Tracking.Follow.ObjectFollower for tracking movement.

##### Declaration

```
public ObjectFollower ObjectFollower { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ObjectFollower | n/a |

#### OrientationLogicContainer

The container for the orientation handle logic.

##### Declaration

```
public GameObject OrientationLogicContainer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### PositionModifiers

A GameObjectObservableList collection of all position modifiers used within the follow modifiers.

##### Declaration

```
public GameObjectObservableList PositionModifiers { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### PrecisionCreateContainer

The container for the precision point creation logic.

##### Declaration

```
public GameObject PrecisionCreateContainer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### PrecisionForceCreateContainer

The container for the precision point force creation logic.

##### Declaration

```
public GameObject PrecisionForceCreateContainer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### PrecisionLogicContainer

The container for the precision point logic.

##### Declaration

```
public GameObject PrecisionLogicContainer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### RotationModifiers

A GameObjectObservableList collection of all rotation modifiers used within the follow modifiers.

##### Declaration

```
public GameObjectObservableList RotationModifiers { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### ScaleModifiers

A GameObjectObservableList collection of all scale modifiers used within the follow modifiers.

##### Declaration

```
public GameObjectObservableList ScaleModifiers { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### VelocityApplier

The Zinnia.Tracking.Velocity.VelocityApplier to apply velocity on ungrab.

##### Declaration

```
public VelocityApplier VelocityApplier { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| VelocityApplier | n/a |

#### WillInheritIsKinematicWhenInactiveFromConsumerRigidbody

Whether the [IsKinematicWhenInactive] property inherits the kinematic state from GrabSetup.Facade.ConsumerRigidbody.isKinematic.

##### Declaration

```
public bool WillInheritIsKinematicWhenInactiveFromConsumerRigidbody { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

### Methods

#### ApplyActiveKinematicState()

Applies the active kinematic state to the Rigidbody of the interactable.

##### Declaration

```
public virtual void ApplyActiveKinematicState()
```

#### ApplyInactiveKinematicState()

Applies the inactive kinematic state to the Rigidbody of the interactable.

##### Declaration

```
public virtual void ApplyInactiveKinematicState()
```

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

##### Declaration

```
protected override void OnAfterGrabSetupChange()
```

##### Overrides

[GrabInteractableAction.OnAfterGrabSetupChange()]

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
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
[GrabInteractableFollowAction.TrackingType]: GrabInteractableFollowAction.TrackingType.md
[GrabInteractableFollowAction.OffsetType]: GrabInteractableFollowAction.OffsetType.md
[IsKinematicWhenInactive]: GrabInteractableFollowAction.md#IsKinematicWhenInactive
[FollowTracking]: GrabInteractableFollowAction.md#FollowTracking
[GrabOffset]: GrabInteractableFollowAction.md#GrabOffset
[FollowTracking]: GrabInteractableFollowAction.md#FollowTracking
[GrabOffset]: GrabInteractableFollowAction.md#GrabOffset
[GrabInteractableAction.OnAfterGrabSetupChange()]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_OnAfterGrabSetupChange