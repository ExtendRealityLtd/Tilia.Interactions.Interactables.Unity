# Class InteractableActionReceiverFacade

The public interface into the Interactor Action Receiver Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ActivationState]
  * [Configuration]
  * [SourcePublishers]
  * [TargetInteractable]
* [Methods]
  * [DisableActionRegistrar(GameObject)]
  * [DisableActionRegistrar(InteractorFacade)]
  * [EnableActionRegistrar(GameObject)]
  * [EnableActionRegistrar(InteractorFacade)]
  * [OnAfterActivationStateChange()]
  * [OnAfterTargetInteractableChange()]
  * [OnBeforeActivationStateChange()]
  * [OnBeforeTargetInteractableChange()]

## Details

##### Inheritance

* System.Object
* InteractableActionReceiverFacade

##### Namespace

* [Tilia.Interactions.Interactables.Interactables]

##### Syntax

```
public class InteractableActionReceiverFacade : MonoBehaviour
```

### Properties

#### ActivationState

The [InteractableActionReceiverFacade.InteractionState] that determies when to activate the action receiver.

##### Declaration

```
public InteractableActionReceiverFacade.InteractionState ActivationState { get; set; }
```

#### Configuration

The Action that will be linked to the SourceAction.

##### Declaration

```
public InteractableActionReceiverConfigurator Configuration { get; protected set; }
```

#### SourcePublishers

The [InteractorActionPublisherFacade] collection of the publishers to receive data from.

##### Declaration

```
public InteractorActionPublisherFacadeObservableList SourcePublishers { get; set; }
```

#### TargetInteractable

The [InteractableFacade] that the action receiver will target.

##### Declaration

```
public InteractableFacade TargetInteractable { get; set; }
```

### Methods

#### DisableActionRegistrar(GameObject)

Disables the given source GameObject on the ActionRegistrar.

##### Declaration

```
public virtual void DisableActionRegistrar(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The source to disable. |

#### DisableActionRegistrar(InteractorFacade)

Disables the given source [InteractorFacade] on the ActionRegistrar.

##### Declaration

```
public virtual void DisableActionRegistrar(InteractorFacade source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | source | The source to disable. |

#### EnableActionRegistrar(GameObject)

Enables the given source GameObject on the ActionRegistrar.

##### Declaration

```
public virtual void EnableActionRegistrar(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The source to enable. |

#### EnableActionRegistrar(InteractorFacade)

Enables the given source [InteractorFacade] on the ActionRegistrar.

##### Declaration

```
public virtual void EnableActionRegistrar(InteractorFacade source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | source | The source to enable. |

#### OnAfterActivationStateChange()

Called after [ActivationState] has been changed.

##### Declaration

```
protected virtual void OnAfterActivationStateChange()
```

#### OnAfterTargetInteractableChange()

Called after [TargetInteractable] has been changed.

##### Declaration

```
protected virtual void OnAfterTargetInteractableChange()
```

#### OnBeforeActivationStateChange()

Called before [ActivationState] has been changed.

##### Declaration

```
protected virtual void OnBeforeActivationStateChange()
```

#### OnBeforeTargetInteractableChange()

Called before [TargetInteractable] has been changed.

##### Declaration

```
protected virtual void OnBeforeTargetInteractableChange()
```

[Tilia.Interactions.Interactables.Interactables]: README.md
[InteractableActionReceiverFacade.InteractionState]: InteractableActionReceiverFacade.InteractionState.md
[InteractableActionReceiverConfigurator]: InteractableActionReceiverConfigurator.md
[InteractorActionPublisherFacade]: ../Interactors/InteractorActionPublisherFacade.md
[InteractorActionPublisherFacadeObservableList]: ../Interactors/Collection/InteractorActionPublisherFacadeObservableList.md
[InteractableFacade]: InteractableFacade.md
[InteractorFacade]: ../Interactors/InteractorFacade.md
[ActivationState]: InteractableActionReceiverFacade.md#ActivationState
[TargetInteractable]: InteractableActionReceiverFacade.md#TargetInteractable
[ActivationState]: InteractableActionReceiverFacade.md#ActivationState
[TargetInteractable]: InteractableActionReceiverFacade.md#TargetInteractable
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ActivationState]: #ActivationState
[Configuration]: #Configuration
[SourcePublishers]: #SourcePublishers
[TargetInteractable]: #TargetInteractable
[Methods]: #Methods
[DisableActionRegistrar(GameObject)]: #DisableActionRegistrarGameObject
[DisableActionRegistrar(InteractorFacade)]: #DisableActionRegistrarInteractorFacade
[EnableActionRegistrar(GameObject)]: #EnableActionRegistrarGameObject
[EnableActionRegistrar(InteractorFacade)]: #EnableActionRegistrarInteractorFacade
[OnAfterActivationStateChange()]: #OnAfterActivationStateChange
[OnAfterTargetInteractableChange()]: #OnAfterTargetInteractableChange
[OnBeforeActivationStateChange()]: #OnBeforeActivationStateChange
[OnBeforeTargetInteractableChange()]: #OnBeforeTargetInteractableChange
