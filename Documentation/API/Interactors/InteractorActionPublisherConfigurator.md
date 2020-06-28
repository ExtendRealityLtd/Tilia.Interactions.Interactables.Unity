# Class InteractorActionPublisherConfigurator

Sets up the Interactor Action Publisher Prefab action settings based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ActiveAction]
  * [Facade]
  * [StartActionPublisher]
  * [StartActionStringCollection]
  * [StopActionPublisher]
  * [StopActionStringCollection]
  * [TargetActions]
* [Methods]
  * [LinkActiveCollisions()]
  * [LinkSourceActionToTargetAction()]
  * [LinkSourceContainerToPublishers()]
  * [OnDisable()]
  * [OnEnable()]
  * [SetPublisherTags()]
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
public Action ActiveAction { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractorActionPublisherFacade Facade { get; protected set; }
```

#### StartActionPublisher

The ActiveCollisionPublisher for checking valid start action.

##### Declaration

```
public ActiveCollisionPublisher StartActionPublisher { get; protected set; }
```

#### StartActionStringCollection

The StringObservableList for tagging the valid start action.

##### Declaration

```
public StringObservableList StartActionStringCollection { get; protected set; }
```

#### StopActionPublisher

The ActiveCollisionPublisher for checking valid stop action.

##### Declaration

```
public ActiveCollisionPublisher StopActionPublisher { get; protected set; }
```

#### StopActionStringCollection

The StringObservableList for tagging the valid stop action.

##### Declaration

```
public StringObservableList StopActionStringCollection { get; protected set; }
```

#### TargetActions

The ActionObservableList that containts the Action collection that can be linked to the InteractorActionFacade.SourceAction.

##### Declaration

```
public ActionObservableList TargetActions { get; protected set; }
```

### Methods

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

#### SetPublisherTags()

Sets the tags of the relevant publishers to the facade identifier.

##### Declaration

```
public virtual void SetPublisherTags()
```

#### UnlinkActiveCollisions()

Unlinks the start publisher from the InteractorActionFacade.SourceInteractor.

##### Declaration

```
public virtual void UnlinkActiveCollisions()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorActionPublisherFacade]: InteractorActionPublisherFacade.md
[TargetActions]: InteractorActionPublisherConfigurator.md#TargetActions
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ActiveAction]: #ActiveAction
[Facade]: #Facade
[StartActionPublisher]: #StartActionPublisher
[StartActionStringCollection]: #StartActionStringCollection
[StopActionPublisher]: #StopActionPublisher
[StopActionStringCollection]: #StopActionStringCollection
[TargetActions]: #TargetActions
[Methods]: #Methods
[LinkActiveCollisions()]: #LinkActiveCollisions
[LinkSourceActionToTargetAction()]: #LinkSourceActionToTargetAction
[LinkSourceContainerToPublishers()]: #LinkSourceContainerToPublishers
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[SetPublisherTags()]: #SetPublisherTags
[UnlinkActiveCollisions()]: #UnlinkActiveCollisions
