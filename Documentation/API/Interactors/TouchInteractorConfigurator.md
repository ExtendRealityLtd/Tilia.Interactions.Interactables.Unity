# Class TouchInteractorConfigurator

Sets up the Interactor Prefab touch settings based on the provided user settings.

##### Inheritance

* System.Object
* TouchInteractorConfigurator

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors]

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

##### Field Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.List<GameObject\> | n/a |

### Properties

#### ActiveCollisionsContainer

The Zinnia.Tracking.Collision.Active.ActiveCollisionsContainer that holds all current collisions.

##### Declaration

```
public ActiveCollisionsContainer ActiveCollisionsContainer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionsContainer | n/a |

#### ActiveTouchedObject

The currently active touched GameObject.

##### Declaration

```
public GameObject ActiveTouchedObject { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### CurrentActiveCollision

The Slicer that holds the current active collision.

##### Declaration

```
public Slicer CurrentActiveCollision { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| Slicer | n/a |

#### ExternalEmitters

The link to any external emitters of the touch state.

##### Declaration

```
public ActiveCollisionsContainerEventProxyEmitter ExternalEmitters { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionsContainerEventProxyEmitter | n/a |

#### Facade

The public interface facade.

##### Declaration

```
public InteractorFacade Facade { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractorFacade] | n/a |

#### StartTouchingPublisher

The ActiveCollisionPublisher for checking valid start touching collisions.

##### Declaration

```
public ActiveCollisionPublisher StartTouchingPublisher { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionPublisher | n/a |

#### StopTouchingPublisher

The ActiveCollisionPublisher for checking valid stop touching collisions.

##### Declaration

```
public ActiveCollisionPublisher StopTouchingPublisher { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionPublisher | n/a |

#### TouchedObjects

A collection of currently touched GameObjects.

##### Declaration

```
public IReadOnlyList<GameObject> TouchedObjects { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<GameObject\> | n/a |

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