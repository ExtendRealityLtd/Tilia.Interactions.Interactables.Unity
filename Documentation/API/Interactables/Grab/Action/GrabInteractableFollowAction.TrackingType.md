## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]

## Details

# Enum GrabInteractableFollowAction.TrackingType

The way in which the object is moved.

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab.Action]

##### Syntax

```
public enum TrackingType
```

### Fields

| Name | Description |
| --- | --- |
| FollowRigidbody | Updates the Rigidbody using velocity to stay within the bounds of the physics system. |
| FollowRigidbodyForceRotate | Updates the Rigidbody rotation by using a force at position. |
| FollowRotateAroundAngularVelocity | Updates the transform rotation based on the rotation of the Interactor's angular velocity around a given axis. |
| FollowTransform | Updates the transform data directly, outside of the physics system. |
| FollowTransformPositionDifferenceRotate | Updates the transform rotation based on the position difference of the source. |

[Tilia.Interactions.Interactables.Interactables.Grab.Action]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
