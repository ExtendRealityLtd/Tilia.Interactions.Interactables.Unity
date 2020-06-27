# Class GrabInteractableConfigurator

Sets up the Interactable Prefab grab settings based on the provided user settings.

##### Inheritance

* System.Object
* GrabInteractableConfigurator

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Grab]

##### Syntax

```
public class GrabInteractableConfigurator : MonoBehaviour
```

### Properties

#### ActionTypes

The GameObjectObservableList that contains the available grab action prefabs.

##### Declaration

```
public GameObjectObservableList ActionTypes { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### Facade

The public interface facade.

##### Declaration

```
public InteractableFacade Facade { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractableFacade] | n/a |

#### GrabbingInteractors

A collection of Interactors that are currently grabbing the Interactable.

##### Declaration

```
public IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | n/a |

#### GrabProvider

The Grab Provider setup.

##### Declaration

```
public GrabInteractableInteractorProvider GrabProvider { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableInteractorProvider] | n/a |

#### GrabProviderOptions

The potential options for the [GrabProvider].

##### Declaration

```
public GrabInteractableInteractorProvider[] GrabProviderOptions { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableInteractorProvider]\[\] | n/a |

#### GrabReceiver

The Grab Receiver setup.

##### Declaration

```
public GrabInteractableReceiver GrabReceiver { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableReceiver] | n/a |

#### IsGrabTypeToggle

Determines if the grab type is set to toggle.

##### Declaration

```
public bool IsGrabTypeToggle { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### PrimaryAction

The action to perform when grabbing the interactable for the first time.

##### Declaration

```
public GrabInteractableAction PrimaryAction { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | n/a |

#### SecondaryAction

The action to perform when grabbing the interactable for the second time.

##### Declaration

```
public GrabInteractableAction SecondaryAction { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | n/a |

### Methods

#### ConfigureActionContainer(GrabInteractableAction)

Configures the action containers.

##### Declaration

```
protected virtual void ConfigureActionContainer(GrabInteractableAction action)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [GrabInteractableAction] | action | The action to configure. |

#### ConfigureContainer()

Sets the consumer containers to the current active container.

##### Declaration

```
public virtual void ConfigureContainer()
```

#### Grab(InteractorFacade)

Attempt to grab the Interactable to the given Interactor.

##### Declaration

```
public virtual void Grab(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

#### LinkReceiverToProvider()

Links the Grab Receiver to the Grab Provider.

##### Declaration

```
protected virtual void LinkReceiverToProvider()
```

#### LinkToPrimaryAction()

Links the Grab Receiver and Grab Provider to the Primary Grab Action.

##### Declaration

```
protected virtual void LinkToPrimaryAction()
```

#### LinkToSecondaryAction()

Links the Grab Receiver and Grab Provider to the Secondary Grab Action.

##### Declaration

```
protected virtual void LinkToSecondaryAction()
```

#### NotifyGrab(GameObject)

Notifies that the Interactable is being grabbed.

##### Declaration

```
public virtual void NotifyGrab(GameObject data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | data | The grabbing object. |

#### NotifyUngrab(GameObject)

Notifies that the Interactable is no longer being grabbed.

##### Declaration

```
public virtual void NotifyUngrab(GameObject data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | data | The previous grabbing object. |

#### OnAfterPrimaryActionChange()

Called after [PrimaryAction] has been changed.

##### Declaration

```
protected virtual void OnAfterPrimaryActionChange()
```

#### OnAfterSecondaryActionChange()

Called after [SecondaryAction] has been changed.

##### Declaration

```
protected virtual void OnAfterSecondaryActionChange()
```

#### OnBeforePrimaryActionChange()

Called after [PrimaryAction] has been changed.

##### Declaration

```
protected virtual void OnBeforePrimaryActionChange()
```

#### OnBeforeSecondaryActionChange()

Called after [SecondaryAction] has been changed.

##### Declaration

```
protected virtual void OnBeforeSecondaryActionChange()
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

#### SetGrabProvider(Int32)

Sets the [GrabProvider] to the index of the [GrabProviderOptions] collection.

##### Declaration

```
public virtual void SetGrabProvider(int providerIndex)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | providerIndex | The index of the [GrabProviderOptions] to set the [GrabProvider] to. |

#### Ungrab(Int32)

Attempt to ungrab the Interactable.

##### Declaration

```
public virtual void Ungrab(int sequenceIndex = 0)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | sequenceIndex | The Interactor sequence index to ungrab from. |

#### Ungrab(InteractorFacade)

Attempts to ungrab the Interactable.

##### Declaration

```
public virtual void Ungrab(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to ungrab from. |

#### UnlinkReceiverToProvider()

Unlinks the Grab Receiver to the Grab Provider.

##### Declaration

```
protected virtual void UnlinkReceiverToProvider()
```

#### UnlinkToPrimaryAction()

Unlinks the Grab Receiver and Grab Provider to the Primary Grab Action.

##### Declaration

```
protected virtual void UnlinkToPrimaryAction()
```

#### UnlinkToSecondaryAction()

Unlinks the Grab Receiver and Grab Provider to the Secondary Grab Action.

##### Declaration

```
protected virtual void UnlinkToSecondaryAction()
```

[Tilia.Interactions.Interactables.Interactables.Grab]: README.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[GrabInteractableInteractorProvider]: Provider.GrabInteractableInteractorProvider.md
[GrabProvider]: GrabInteractableConfigurator.md#GrabProvider
[GrabInteractableInteractorProvider]: Provider.GrabInteractableInteractorProvider.md
[GrabInteractableReceiver]: Receiver.GrabInteractableReceiver.md
[GrabInteractableAction]: Action.GrabInteractableAction.md
[GrabInteractableAction]: Action.GrabInteractableAction.md
[GrabInteractableAction]: Action.GrabInteractableAction.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[PrimaryAction]: GrabInteractableConfigurator.md#PrimaryAction
[SecondaryAction]: GrabInteractableConfigurator.md#SecondaryAction
[PrimaryAction]: GrabInteractableConfigurator.md#PrimaryAction
[SecondaryAction]: GrabInteractableConfigurator.md#SecondaryAction
[GrabProvider]: GrabInteractableConfigurator.md#GrabProvider
[GrabProviderOptions]: GrabInteractableConfigurator.md#GrabProviderOptions
[GrabProviderOptions]: GrabInteractableConfigurator.md#GrabProviderOptions
[GrabProvider]: GrabInteractableConfigurator.md#GrabProvider
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md