# Class InteractablePropertyCache

Caches common properties for an [InteractableFacade] to be restored at a later point in time.

##### Inheritance

* System.Object
* InteractablePropertyCache

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables]

##### Syntax

```
public class InteractablePropertyCache : MonoBehaviour
```

### Fields

#### cachedLocalPosition

The cached local position of the [Source]

##### Declaration

```
protected Vector3? cachedLocalPosition
```

##### Field Value

| Type | Description |
| --- | --- |
| System.Nullable<Vector3\> | n/a |

#### cachedLocalRotation

The cached local rotation of the [Source]

##### Declaration

```
protected Quaternion cachedLocalRotation
```

##### Field Value

| Type | Description |
| --- | --- |
| Quaternion | n/a |

#### cachedLocalScale

The cached local scale of the [Source]

##### Declaration

```
protected Vector3 cachedLocalScale
```

##### Field Value

| Type | Description |
| --- | --- |
| Vector3 | n/a |

#### cachedRigidbodyKinematicState

The cached kinematic state of the the [Source]

##### Declaration

```
protected bool cachedRigidbodyKinematicState
```

##### Field Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

### Properties

#### Source

The source to cache properties for.

##### Declaration

```
public InteractableFacade Source { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractableFacade] | n/a |

### Methods

#### CacheAll()

Caches all of the properties.

##### Declaration

```
public virtual void CacheAll()
```

#### CachePosition()

Caches the position.

##### Declaration

```
public virtual void CachePosition()
```

#### CacheRigidbodyKinematicState()

Caches the rigidbody kinematic state..

##### Declaration

```
public virtual void CacheRigidbodyKinematicState()
```

#### CacheRotation()

Caches the rotation.

##### Declaration

```
public virtual void CacheRotation()
```

#### CacheScale()

Caches the scale.

##### Declaration

```
public virtual void CacheScale()
```

#### RestoreAll()

Restores the all of cached properties.

##### Declaration

```
public virtual void RestoreAll()
```

#### RestorePosition()

Restores the cached position.

##### Declaration

```
public virtual void RestorePosition()
```

#### RestoreRigidbodyKinematicState()

Restores the cached rigidbody kinematic state.

##### Declaration

```
public virtual void RestoreRigidbodyKinematicState()
```

#### RestoreRotation()

Restores the cached rotation.

##### Declaration

```
public virtual void RestoreRotation()
```

#### RestoreScale()

Restores the cached scale.

##### Declaration

```
public virtual void RestoreScale()
```

#### SetSource(GameObject)

Sets the [Source] property from a given GameObject.

##### Declaration

```
public virtual void SetSource(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The source to set to. |

[InteractableFacade]: InteractableFacade.md
[Tilia.Interactions.Interactables.Interactables]: README.md
[Source]: InteractablePropertyCache.md#Source
[Source]: InteractablePropertyCache.md#Source
[Source]: InteractablePropertyCache.md#Source
[Source]: InteractablePropertyCache.md#Source
[InteractableFacade]: InteractableFacade.md
[Source]: InteractablePropertyCache.md#Source