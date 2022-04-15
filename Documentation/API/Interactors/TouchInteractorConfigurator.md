# Class TouchInteractorConfigurator

Sets up the Interactor Prefab touch settings based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [touchedObjects]
* [Properties]
  * [ActiveCollisionsContainer]
  * [ActiveTouchedObject]
  * [CurrentActiveCollision]
  * [ExternalEmitters]
  * [Facade]
  * [IsTouchingAction]
  * [StartTouchingPublisher]
  * [StopTouchingPublisher]
  * [TouchedObjects]
  * [TouchTracker]
* [Methods]
  * [GetActiveTouchedObject()]
  * [GetTouchedObjects()]
  * [OnDisable()]

## Details

##### Inheritance

* System.Object
* TouchInteractorConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class TouchInteractorConfigurator : MonoBehaviour
```

### Fields

#### touchedObjects

A reusable collection to hold the returned touched objects.

##### Declaration

```
protected readonly List<GameObject> touchedObjects
```

### Properties

#### ActiveCollisionsContainer

The Zinnia.Tracking.Collision.Active.ActiveCollisionsContainer that holds all current collisions.

##### Declaration

```
public ActiveCollisionsContainer ActiveCollisionsContainer { get; protected set; }
```

#### ActiveTouchedObject

The currently active touched GameObject.

##### Declaration

```
public virtual GameObject ActiveTouchedObject { get; }
```

#### CurrentActiveCollision

The Slicer that holds the current active collision.

##### Declaration

```
public Slicer CurrentActiveCollision { get; protected set; }
```

#### ExternalEmitters

The link to any external emitters of the touch state.

##### Declaration

```
public ActiveCollisionsContainerEventProxyEmitter ExternalEmitters { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractorFacade Facade { get; protected set; }
```

#### IsTouchingAction

A BooleanAction for holding the state of whether the Interactor is touching something.

##### Declaration

```
public BooleanAction IsTouchingAction { get; protected set; }
```

#### StartTouchingPublisher

The ActiveCollisionPublisher for checking valid start touching collisions.

##### Declaration

```
public ActiveCollisionPublisher StartTouchingPublisher { get; protected set; }
```

#### StopTouchingPublisher

The ActiveCollisionPublisher for checking valid stop touching collisions.

##### Declaration

```
public ActiveCollisionPublisher StopTouchingPublisher { get; protected set; }
```

#### TouchedObjects

A collection of currently touched GameObjects.

##### Declaration

```
public virtual IReadOnlyList<GameObject> TouchedObjects { get; }
```

#### TouchTracker

A CollisionTracker for tracking collisions/touches on this Interactor.

##### Declaration

```
public CollisionTracker TouchTracker { get; protected set; }
```

### Methods

#### GetActiveTouchedObject()

Retrieves the currently active touched GameObject.

##### Declaration

```
protected virtual GameObject GetActiveTouchedObject()
```

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The currently active touched GameObject. |

#### GetTouchedObjects()

Retrieves a collection of currently touched GameObjects.

##### Declaration

```
protected virtual IReadOnlyList<GameObject> GetTouchedObjects()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<GameObject\> | The currently touched GameObjects. |

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorFacade]: InteractorFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[touchedObjects]: #touchedObjects
[Properties]: #Properties
[ActiveCollisionsContainer]: #ActiveCollisionsContainer
[ActiveTouchedObject]: #ActiveTouchedObject
[CurrentActiveCollision]: #CurrentActiveCollision
[ExternalEmitters]: #ExternalEmitters
[Facade]: #Facade
[IsTouchingAction]: #IsTouchingAction
[StartTouchingPublisher]: #StartTouchingPublisher
[StopTouchingPublisher]: #StopTouchingPublisher
[TouchedObjects]: #TouchedObjects
[TouchTracker]: #TouchTracker
[Methods]: #Methods
[GetActiveTouchedObject()]: #GetActiveTouchedObject
[GetTouchedObjects()]: #GetTouchedObjects
[OnDisable()]: #OnDisable
