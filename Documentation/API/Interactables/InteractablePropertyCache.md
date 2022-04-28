# Class InteractablePropertyCache

Caches common properties for an [InteractableFacade] to be restored at a later point in time.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedLocalPosition]
  * [cachedLocalRotation]
  * [cachedLocalScale]
  * [cachedRigidbodyKinematicState]
* [Properties]
  * [Source]
* [Methods]
  * [CacheAll()]
  * [CachePosition()]
  * [CacheRigidbodyKinematicState()]
  * [CacheRotation()]
  * [CacheScale()]
  * [ClearSource()]
  * [RestoreAll()]
  * [RestorePosition()]
  * [RestoreRigidbodyKinematicState()]
  * [RestoreRotation()]
  * [RestoreScale()]
  * [SetSource(GameObject)]

## Details

##### Inheritance

* System.Object
* InteractablePropertyCache

##### Namespace

* [Tilia.Interactions.Interactables.Interactables]

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

#### cachedLocalRotation

The cached local rotation of the [Source]

##### Declaration

```
protected Quaternion cachedLocalRotation
```

#### cachedLocalScale

The cached local scale of the [Source]

##### Declaration

```
protected Vector3 cachedLocalScale
```

#### cachedRigidbodyKinematicState

The cached kinematic state of the the [Source]

##### Declaration

```
protected bool cachedRigidbodyKinematicState
```

### Properties

#### Source

The source to cache properties for.

##### Declaration

```
public InteractableFacade Source { get; set; }
```

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

#### ClearSource()

Clears [Source].

##### Declaration

```
public virtual void ClearSource()
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

[Tilia.Interactions.Interactables.Interactables]: README.md
[Source]: InteractablePropertyCache.md#Source
[Source]: InteractablePropertyCache.md#Source
[Source]: InteractablePropertyCache.md#Source
[Source]: InteractablePropertyCache.md#Source
[InteractableFacade]: InteractableFacade.md
[Source]: InteractablePropertyCache.md#Source
[Source]: InteractablePropertyCache.md#Source
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedLocalPosition]: #cachedLocalPosition
[cachedLocalRotation]: #cachedLocalRotation
[cachedLocalScale]: #cachedLocalScale
[cachedRigidbodyKinematicState]: #cachedRigidbodyKinematicState
[Properties]: #Properties
[Source]: #Source
[Methods]: #Methods
[CacheAll()]: #CacheAll
[CachePosition()]: #CachePosition
[CacheRigidbodyKinematicState()]: #CacheRigidbodyKinematicState
[CacheRotation()]: #CacheRotation
[CacheScale()]: #CacheScale
[ClearSource()]: #ClearSource
[RestoreAll()]: #RestoreAll
[RestorePosition()]: #RestorePosition
[RestoreRigidbodyKinematicState()]: #RestoreRigidbodyKinematicState
[RestoreRotation()]: #RestoreRotation
[RestoreScale()]: #RestoreScale
[SetSource(GameObject)]: #SetSourceGameObject
