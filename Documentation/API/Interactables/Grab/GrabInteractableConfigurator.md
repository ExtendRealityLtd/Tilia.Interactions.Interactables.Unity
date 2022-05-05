# Class GrabInteractableConfigurator

Sets up the Interactable Prefab grab settings based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [KinematicStateToChange]
* [Properties]
  * [ActionTypes]
  * [Facade]
  * [GrabbingInteractors]
  * [GrabProvider]
  * [GrabProviderOptions]
  * [GrabReceiver]
  * [IsGrabTypeToggle]
  * [PrimaryAction]
  * [SecondaryAction]
* [Methods]
  * [ClearActionTypes()]
  * [ClearPrimaryAction()]
  * [ClearSecondaryAction()]
  * [ConfigureActionContainer(GrabInteractableAction)]
  * [ConfigureContainer()]
  * [DisableSecondaryInputActiveCollisionConsumer(GameObject)]
  * [EnableSecondaryInputActiveCollisionConsumer(GameObject)]
  * [Grab(InteractorFacade)]
  * [GrabIgnoreUngrab(InteractorFacade)]
  * [LinkReceiverToProvider()]
  * [LinkToPrimaryAction()]
  * [LinkToSecondaryAction()]
  * [NotifyGrab(GameObject)]
  * [NotifyUngrab(GameObject)]
  * [OnAfterPrimaryActionChange()]
  * [OnAfterSecondaryActionChange()]
  * [OnBeforePrimaryActionChange()]
  * [OnBeforeSecondaryActionChange()]
  * [OnDisable()]
  * [OnEnable()]
  * [PrimaryGrabIsNone(Int32)]
  * [SetGrabProvider(Int32)]
  * [SnapFollowOrientation()]
  * [Ungrab(Int32)]
  * [Ungrab(InteractorFacade)]
  * [UnlinkReceiverToProvider()]
  * [UnlinkToPrimaryAction()]
  * [UnlinkToSecondaryAction()]

## Details

##### Inheritance

* System.Object
* GrabInteractableConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab]

##### Syntax

```
public class GrabInteractableConfigurator : MonoBehaviour
```

### Fields

#### KinematicStateToChange

##### Declaration

```
public GrabInteractableConfigurator.UnityEvent KinematicStateToChange
```

### Properties

#### ActionTypes

The GameObjectObservableList that contains the available grab action prefabs.

##### Declaration

```
public GameObjectObservableList ActionTypes { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractableFacade Facade { get; protected set; }
```

#### GrabbingInteractors

A collection of Interactors that are currently grabbing the Interactable.

##### Declaration

```
public virtual IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

#### GrabProvider

The Grab Provider setup.

##### Declaration

```
public GrabInteractableInteractorProvider GrabProvider { get; protected set; }
```

#### GrabProviderOptions

The potential options for the [GrabProvider].

##### Declaration

```
public GrabInteractableInteractorProvider[] GrabProviderOptions { get; protected set; }
```

#### GrabReceiver

The Grab Receiver setup.

##### Declaration

```
public GrabInteractableReceiver GrabReceiver { get; protected set; }
```

#### IsGrabTypeToggle

Determines if the grab type is set to toggle.

##### Declaration

```
public virtual bool IsGrabTypeToggle { get; }
```

#### PrimaryAction

The action to perform when grabbing the interactable for the first time.

##### Declaration

```
public GrabInteractableAction PrimaryAction { get; set; }
```

#### SecondaryAction

The action to perform when grabbing the interactable for the second time.

##### Declaration

```
public GrabInteractableAction SecondaryAction { get; set; }
```

### Methods

#### ClearActionTypes()

Clears [ActionTypes].

##### Declaration

```
public virtual void ClearActionTypes()
```

#### ClearPrimaryAction()

Clears [PrimaryAction].

##### Declaration

```
public virtual void ClearPrimaryAction()
```

#### ClearSecondaryAction()

Clears [SecondaryAction].

##### Declaration

```
public virtual void ClearSecondaryAction()
```

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

#### DisableSecondaryInputActiveCollisionConsumer(GameObject)

Disables the Secondary Input Active Collision Consumer component.

##### Declaration

```
protected virtual void DisableSecondaryInputActiveCollisionConsumer(GameObject _)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | \_ | unused |

#### EnableSecondaryInputActiveCollisionConsumer(GameObject)

Enables the Secondary Input Active Collision Consumer component.

##### Declaration

```
protected virtual void EnableSecondaryInputActiveCollisionConsumer(GameObject _)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | \_ | unused |

#### Grab(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and ungrabs any existing grab.

##### Declaration

```
public virtual void Grab(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

#### GrabIgnoreUngrab(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grab.

##### Declaration

```
public virtual void GrabIgnoreUngrab(InteractorFacade interactor)
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

#### PrimaryGrabIsNone(Int32)

Determines whether the primary grab action is of type [GrabInteractableNullAction].

##### Declaration

```
protected virtual bool PrimaryGrabIsNone(int interactorCount)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | interactorCount | The amount of grabbing Interactors. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the primary grab is of type [GrabInteractableNullAction]. |

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

#### SnapFollowOrientation()

Snaps the follow on the primary and secondary action if they are [GrabInteractableFollowAction] type.

##### Declaration

```
public virtual void SnapFollowOrientation()
```

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
[GrabInteractableConfigurator.UnityEvent]: GrabInteractableConfigurator.UnityEvent.md
[InteractableFacade]: ../../Interactables/InteractableFacade.md
[InteractorFacade]: ../../Interactors/InteractorFacade.md
[GrabInteractableInteractorProvider]: Provider/GrabInteractableInteractorProvider.md
[GrabProvider]: GrabInteractableConfigurator.md#GrabProvider
[GrabInteractableReceiver]: Receiver/GrabInteractableReceiver.md
[GrabInteractableAction]: Action/GrabInteractableAction.md
[ActionTypes]: GrabInteractableConfigurator.md#ActionTypes
[PrimaryAction]: GrabInteractableConfigurator.md#PrimaryAction
[SecondaryAction]: GrabInteractableConfigurator.md#SecondaryAction
[PrimaryAction]: GrabInteractableConfigurator.md#PrimaryAction
[SecondaryAction]: GrabInteractableConfigurator.md#SecondaryAction
[PrimaryAction]: GrabInteractableConfigurator.md#PrimaryAction
[SecondaryAction]: GrabInteractableConfigurator.md#SecondaryAction
[GrabInteractableNullAction]: Action/GrabInteractableNullAction.md
[GrabProvider]: GrabInteractableConfigurator.md#GrabProvider
[GrabProviderOptions]: GrabInteractableConfigurator.md#GrabProviderOptions
[GrabProviderOptions]: GrabInteractableConfigurator.md#GrabProviderOptions
[GrabProvider]: GrabInteractableConfigurator.md#GrabProvider
[GrabInteractableFollowAction]: Action/GrabInteractableFollowAction.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[KinematicStateToChange]: #KinematicStateToChange
[Properties]: #Properties
[ActionTypes]: #ActionTypes
[Facade]: #Facade
[GrabbingInteractors]: #GrabbingInteractors
[GrabProvider]: #GrabProvider
[GrabProviderOptions]: #GrabProviderOptions
[GrabReceiver]: #GrabReceiver
[IsGrabTypeToggle]: #IsGrabTypeToggle
[PrimaryAction]: #PrimaryAction
[SecondaryAction]: #SecondaryAction
[Methods]: #Methods
[ClearActionTypes()]: #ClearActionTypes
[ClearPrimaryAction()]: #ClearPrimaryAction
[ClearSecondaryAction()]: #ClearSecondaryAction
[ConfigureActionContainer(GrabInteractableAction)]: #ConfigureActionContainerGrabInteractableAction
[ConfigureContainer()]: #ConfigureContainer
[DisableSecondaryInputActiveCollisionConsumer(GameObject)]: #DisableSecondaryInputActiveCollisionConsumerGameObject
[EnableSecondaryInputActiveCollisionConsumer(GameObject)]: #EnableSecondaryInputActiveCollisionConsumerGameObject
[Grab(InteractorFacade)]: #GrabInteractorFacade
[GrabIgnoreUngrab(InteractorFacade)]: #GrabIgnoreUngrabInteractorFacade
[LinkReceiverToProvider()]: #LinkReceiverToProvider
[LinkToPrimaryAction()]: #LinkToPrimaryAction
[LinkToSecondaryAction()]: #LinkToSecondaryAction
[NotifyGrab(GameObject)]: #NotifyGrabGameObject
[NotifyUngrab(GameObject)]: #NotifyUngrabGameObject
[OnAfterPrimaryActionChange()]: #OnAfterPrimaryActionChange
[OnAfterSecondaryActionChange()]: #OnAfterSecondaryActionChange
[OnBeforePrimaryActionChange()]: #OnBeforePrimaryActionChange
[OnBeforeSecondaryActionChange()]: #OnBeforeSecondaryActionChange
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[PrimaryGrabIsNone(Int32)]: #PrimaryGrabIsNoneInt32
[SetGrabProvider(Int32)]: #SetGrabProviderInt32
[SnapFollowOrientation()]: #SnapFollowOrientation
[Ungrab(Int32)]: #UngrabInt32
[Ungrab(InteractorFacade)]: #UngrabInteractorFacade
[UnlinkReceiverToProvider()]: #UnlinkReceiverToProvider
[UnlinkToPrimaryAction()]: #UnlinkToPrimaryAction
[UnlinkToSecondaryAction()]: #UnlinkToSecondaryAction
