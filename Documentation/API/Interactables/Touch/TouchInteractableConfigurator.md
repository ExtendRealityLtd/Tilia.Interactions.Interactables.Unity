# Class TouchInteractableConfigurator

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [isFirstTouched]
  * [touchingInteractors]
* [Properties]
  * [ActiveInteractorCounter]
  * [AddActiveInteractor]
  * [CurrentTouchingObjects]
  * [CurrentUntouchingEventProxy]
  * [CurrentUntouchingObjects]
  * [Facade]
  * [PotentialInteractors]
  * [RemoveActiveInteractor]
  * [TouchConsumer]
  * [TouchingInteractors]
  * [TouchValidity]
  * [UntouchConsumer]
* [Methods]
  * [ConfigureContainer()]
  * [GetTouchingInteractors()]
  * [LinkActiveInteractorCollisions()]
  * [NotifyTouch(GameObject)]
  * [NotifyUntouch(GameObject)]
  * [OnDisable()]
  * [OnEnable()]
  * [ProcessPotentialInteractorContentChange(CollisionNotifier.EventData)]
  * [UnlinkActiveInteractorCollisions()]
  * [UntouchAllTouchingInteractors()]

## Details

##### Inheritance

* System.Object
* TouchInteractableConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Touch]

##### Syntax

```
public class TouchInteractableConfigurator : MonoBehaviour
```

### Fields

#### isFirstTouched

Whether this is being first touched.

##### Declaration

```
protected bool isFirstTouched
```

#### touchingInteractors

A reusable collection to hold the returned touching interactors.

##### Declaration

```
protected readonly List<InteractorFacade> touchingInteractors
```

### Properties

#### ActiveInteractorCounter

The GameObjectObservableCounter for counting active interactors.

##### Declaration

```
public GameObjectObservableCounter ActiveInteractorCounter { get; protected set; }
```

#### AddActiveInteractor

The NotifierContainerExtractor for adding active interactors.

##### Declaration

```
public NotifierContainerExtractor AddActiveInteractor { get; protected set; }
```

#### CurrentTouchingObjects

The GameObjectObservableList that holds the current touching objects data.

##### Declaration

```
public GameObjectObservableList CurrentTouchingObjects { get; protected set; }
```

#### CurrentUntouchingEventProxy

The GameObjectEventProxyEmitter used to determine the untouch actions.

##### Declaration

```
public GameObjectEventProxyEmitter CurrentUntouchingEventProxy { get; protected set; }
```

#### CurrentUntouchingObjects

The GameObjectObservableList that holds the current untouching objects data.

##### Declaration

```
public GameObjectObservableList CurrentUntouchingObjects { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractableFacade Facade { get; protected set; }
```

#### PotentialInteractors

The ActiveCollisionsContainer for potential interactors.

##### Declaration

```
public ActiveCollisionsContainer PotentialInteractors { get; protected set; }
```

#### RemoveActiveInteractor

The NotifierContainerExtractor for removing active interactors.

##### Declaration

```
public NotifierContainerExtractor RemoveActiveInteractor { get; protected set; }
```

#### TouchConsumer

The ActiveCollisionConsumer that listens for the touch payload.

##### Declaration

```
public ActiveCollisionConsumer TouchConsumer { get; protected set; }
```

#### TouchingInteractors

A collection of Interactors that are currently touching the Interactable.

##### Declaration

```
public virtual IReadOnlyList<InteractorFacade> TouchingInteractors { get; }
```

#### TouchValidity

The GameObjectEventProxyEmitter used to determine the touch validity.

##### Declaration

```
public GameObjectEventProxyEmitter TouchValidity { get; protected set; }
```

#### UntouchConsumer

The ActiveCollisionConsumer that listens for the untouch payload.

##### Declaration

```
public ActiveCollisionConsumer UntouchConsumer { get; protected set; }
```

### Methods

#### ConfigureContainer()

Sets the consumer containers to the current active container.

##### Declaration

```
public virtual void ConfigureContainer()
```

#### GetTouchingInteractors()

Retrieves a collection of Interactors that are touching the Interactable.

##### Declaration

```
protected virtual IReadOnlyList<InteractorFacade> GetTouchingInteractors()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | The touching Interactors. |

#### LinkActiveInteractorCollisions()

Links the CollisionNotifier to the potential and active interactor logic.

##### Declaration

```
protected virtual void LinkActiveInteractorCollisions()
```

#### NotifyTouch(GameObject)

Notifies that the Interactable is being touched.

##### Declaration

```
public virtual void NotifyTouch(GameObject data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | data | The touching object. |

#### NotifyUntouch(GameObject)

Notifies that the Interactable is being no longer touched.

##### Declaration

```
public virtual void NotifyUntouch(GameObject data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | data | The previous touching object. |

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### ProcessPotentialInteractorContentChange(CollisionNotifier.EventData)

Handles any change of collision contents.

##### Declaration

```
protected virtual void ProcessPotentialInteractorContentChange(CollisionNotifier.EventData data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| CollisionNotifier.EventData | data | The changed collision data. |

#### UnlinkActiveInteractorCollisions()

Unlinks the CollisionNotifier to the potential and active interactor logic.

##### Declaration

```
protected virtual void UnlinkActiveInteractorCollisions()
```

#### UntouchAllTouchingInteractors()

Enforces that all the existing touching interactors are no longer actually touching.

##### Declaration

```
public virtual void UntouchAllTouchingInteractors()
```

[Tilia.Interactions.Interactables.Interactables.Touch]: README.md
[InteractorFacade]: ../../Interactors/InteractorFacade.md
[InteractableFacade]: ../../Interactables/InteractableFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[isFirstTouched]: #isFirstTouched
[touchingInteractors]: #touchingInteractors
[Properties]: #Properties
[ActiveInteractorCounter]: #ActiveInteractorCounter
[AddActiveInteractor]: #AddActiveInteractor
[CurrentTouchingObjects]: #CurrentTouchingObjects
[CurrentUntouchingEventProxy]: #CurrentUntouchingEventProxy
[CurrentUntouchingObjects]: #CurrentUntouchingObjects
[Facade]: #Facade
[PotentialInteractors]: #PotentialInteractors
[RemoveActiveInteractor]: #RemoveActiveInteractor
[TouchConsumer]: #TouchConsumer
[TouchingInteractors]: #TouchingInteractors
[TouchValidity]: #TouchValidity
[UntouchConsumer]: #UntouchConsumer
[Methods]: #Methods
[ConfigureContainer()]: #ConfigureContainer
[GetTouchingInteractors()]: #GetTouchingInteractors
[LinkActiveInteractorCollisions()]: #LinkActiveInteractorCollisions
[NotifyTouch(GameObject)]: #NotifyTouchGameObject
[NotifyUntouch(GameObject)]: #NotifyUntouchGameObject
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[ProcessPotentialInteractorContentChange(CollisionNotifier.EventData)]: #ProcessPotentialInteractorContentChangeCollisionNotifier.EventData
[UnlinkActiveInteractorCollisions()]: #UnlinkActiveInteractorCollisions
[UntouchAllTouchingInteractors()]: #UntouchAllTouchingInteractors
