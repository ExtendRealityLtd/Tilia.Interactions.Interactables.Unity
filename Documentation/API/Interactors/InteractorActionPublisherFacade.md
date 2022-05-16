# Class InteractorActionPublisherFacade

The public interface into the Interactor Action Publisher Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ActiveAction]
  * [Configuration]
  * [SourceAction]
  * [SourceInteractor]
* [Methods]
  * [ClearSourceAction()]
  * [ClearSourceInteractor()]
  * [OnAfterSourceActionChange()]
  * [OnAfterSourceInteractorChange()]
  * [OnBeforeSourceInteractorChange()]

## Details

##### Inheritance

* System.Object
* InteractorActionPublisherFacade

##### Namespace

* [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class InteractorActionPublisherFacade : MonoBehaviour
```

### Properties

#### ActiveAction

The current active Action.

##### Declaration

```
public virtual Action ActiveAction { get; }
```

#### Configuration

The Action that will be linked to the [SourceAction].

##### Declaration

```
public InteractorActionPublisherConfigurator Configuration { get; protected set; }
```

#### SourceAction

The Action to be monitored to control the interaction.

##### Declaration

```
public Action SourceAction { get; set; }
```

#### SourceInteractor

The source [InteractorFacade] that the action will be processed through.

##### Declaration

```
public InteractorFacade SourceInteractor { get; set; }
```

### Methods

#### ClearSourceAction()

Clears [SourceAction].

##### Declaration

```
public virtual void ClearSourceAction()
```

#### ClearSourceInteractor()

Clears [SourceInteractor].

##### Declaration

```
public virtual void ClearSourceInteractor()
```

#### OnAfterSourceActionChange()

Called after [SourceAction] has been changed.

##### Declaration

```
protected virtual void OnAfterSourceActionChange()
```

#### OnAfterSourceInteractorChange()

Called after [SourceInteractor] has been changed.

##### Declaration

```
protected virtual void OnAfterSourceInteractorChange()
```

#### OnBeforeSourceInteractorChange()

Called before [SourceInteractor] has been changed.

##### Declaration

```
protected virtual void OnBeforeSourceInteractorChange()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[SourceAction]: InteractorActionPublisherFacade.md#SourceAction
[InteractorActionPublisherConfigurator]: InteractorActionPublisherConfigurator.md
[InteractorFacade]: InteractorFacade.md
[SourceAction]: InteractorActionPublisherFacade.md#SourceAction
[SourceInteractor]: InteractorActionPublisherFacade.md#SourceInteractor
[SourceAction]: InteractorActionPublisherFacade.md#SourceAction
[SourceInteractor]: InteractorActionPublisherFacade.md#SourceInteractor
[SourceInteractor]: InteractorActionPublisherFacade.md#SourceInteractor
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ActiveAction]: #ActiveAction
[Configuration]: #Configuration
[SourceAction]: #SourceAction
[SourceInteractor]: #SourceInteractor
[Methods]: #Methods
[ClearSourceAction()]: #ClearSourceAction
[ClearSourceInteractor()]: #ClearSourceInteractor
[OnAfterSourceActionChange()]: #OnAfterSourceActionChange
[OnAfterSourceInteractorChange()]: #OnAfterSourceInteractorChange
[OnBeforeSourceInteractorChange()]: #OnBeforeSourceInteractorChange
