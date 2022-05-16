# Class InteractorActionPublisherConfigurator

Sets up the Interactor Action Publisher Prefab action settings based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ActiveAction]
  * [Facade]
  * [SetOnGrabEmitter]
  * [SetOnTouchEmitter]
  * [StartActionPublisher]
  * [StopActionPublisher]
  * [TargetActions]
* [Methods]
  * [InteractorGrabbed(InteractableFacade)]
  * [InteractorUngrabbed(InteractableFacade)]
  * [LinkActiveCollisions()]
  * [LinkSourceActionToTargetAction()]
  * [LinkSourceContainerToPublishers()]
  * [OnDisable()]
  * [OnEnable()]
  * [UnlinkActiveCollisions()]

## Details

##### Inheritance

* System.Object
* InteractorActionPublisherConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class InteractorActionPublisherConfigurator : MonoBehaviour
```

### Properties

#### ActiveAction

The current active Action.

##### Declaration

```
public virtual Action ActiveAction { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractorActionPublisherFacade Facade { get; protected set; }
```

#### SetOnGrabEmitter

The ActiveCollisionPublisherEventProxyEmitter setting the active collisions on the [StartActionPublisher] on grab.

##### Declaration

```
public ActiveCollisionPublisherEventProxyEmitter SetOnGrabEmitter { get; protected set; }
```

#### SetOnTouchEmitter

The ActiveCollisionsContainerEventProxyEmitter setting the active collisions on the [StartActionPublisher] on touch.

##### Declaration

```
public ActiveCollisionsContainerEventProxyEmitter SetOnTouchEmitter { get; protected set; }
```

#### StartActionPublisher

The ActiveCollisionPublisher for checking valid start action.

##### Declaration

```
public ActiveCollisionPublisher StartActionPublisher { get; protected set; }
```

#### StopActionPublisher

The ActiveCollisionPublisher for checking valid stop action.

##### Declaration

```
public ActiveCollisionPublisher StopActionPublisher { get; protected set; }
```

#### TargetActions

The ActionObservableList that contains the Action collection that can be linked to the InteractorActionFacade.SourceAction.

##### Declaration

```
public ActionObservableList TargetActions { get; protected set; }
```

### Methods

#### InteractorGrabbed(InteractableFacade)

Determines what to do when the Interactor grabs.

##### Declaration

```
protected virtual void InteractorGrabbed(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable being grabbed. |

#### InteractorUngrabbed(InteractableFacade)

Determines what to do when the Interactor ungrabs.

##### Declaration

```
protected virtual void InteractorUngrabbed(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable being grabbed. |

#### LinkActiveCollisions()

Links the start publisher to the InteractorActionFacade.SourceInteractor.

##### Declaration

```
public virtual void LinkActiveCollisions()
```

#### LinkSourceActionToTargetAction()

Links the InteractorActionFacade.SourceAction to the valid [TargetActions] Action.

##### Declaration

```
public virtual void LinkSourceActionToTargetAction()
```

#### LinkSourceContainerToPublishers()

Links the InteractorActionFacade.SourceInteractor to the payload source containers on the start and stop publishers.

##### Declaration

```
public virtual void LinkSourceContainerToPublishers()
```

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

#### UnlinkActiveCollisions()

Unlinks the start publisher from the InteractorActionFacade.SourceInteractor.

##### Declaration

```
public virtual void UnlinkActiveCollisions()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorActionPublisherFacade]: InteractorActionPublisherFacade.md
[StartActionPublisher]: InteractorActionPublisherConfigurator.md#StartActionPublisher
[StartActionPublisher]: InteractorActionPublisherConfigurator.md#StartActionPublisher
[InteractableFacade]: ../Interactables/InteractableFacade.md
[TargetActions]: InteractorActionPublisherConfigurator.md#TargetActions
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ActiveAction]: #ActiveAction
[Facade]: #Facade
[SetOnGrabEmitter]: #SetOnGrabEmitter
[SetOnTouchEmitter]: #SetOnTouchEmitter
[StartActionPublisher]: #StartActionPublisher
[StopActionPublisher]: #StopActionPublisher
[TargetActions]: #TargetActions
[Methods]: #Methods
[InteractorGrabbed(InteractableFacade)]: #InteractorGrabbedInteractableFacade
[InteractorUngrabbed(InteractableFacade)]: #InteractorUngrabbedInteractableFacade
[LinkActiveCollisions()]: #LinkActiveCollisions
[LinkSourceActionToTargetAction()]: #LinkSourceActionToTargetAction
[LinkSourceContainerToPublishers()]: #LinkSourceContainerToPublishers
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[UnlinkActiveCollisions()]: #UnlinkActiveCollisions
