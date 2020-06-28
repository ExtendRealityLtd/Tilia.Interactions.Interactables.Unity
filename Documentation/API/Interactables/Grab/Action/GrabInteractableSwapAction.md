# Class GrabInteractableSwapAction

Describes the action of swapping a an action from being the secondary action to the primary action.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [ClearStack()]
  * [EmitActiveCollisionConsumerPayload()]
  * [PushToStack(GameObject)]
  * [ResetToggle(GameObject)]
  * [ToStackInteractorProvider(GrabInteractableInteractorProvider)]

## Details

##### Inheritance

* System.Object
* [GrabInteractableAction]
* GrabInteractableSwapAction

##### Inherited Members

[GrabInteractableAction.InputActiveCollisionConsumer]

[GrabInteractableAction.InputGrabReceived]

[GrabInteractableAction.InputUngrabReceived]

[GrabInteractableAction.InputGrabSetup]

[GrabInteractableAction.InputUngrabReset]

[GrabInteractableAction.GrabSetup]

[GrabInteractableAction.NotifyGrab(GameObject)]

[GrabInteractableAction.NotifyUngrab(GameObject)]

[GrabInteractableAction.OnAfterGrabSetupChange()]

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab.Action]

##### Syntax

```
public class GrabInteractableSwapAction : GrabInteractableAction
```

##### **Remarks**

Can only be used in conjunction with [GrabInteractableStackInteractorProvider].

### Methods

#### ClearStack()

Clears the stack.

##### Declaration

```
public virtual void ClearStack()
```

#### EmitActiveCollisionConsumerPayload()

Emits the active collision payload.

##### Declaration

```
public virtual void EmitActiveCollisionConsumerPayload()
```

#### PushToStack(GameObject)

Pushes the given Interactor to the stack.

##### Declaration

```
public virtual void PushToStack(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to push to the stack. |

#### ResetToggle(GameObject)

Resets the toggle state on the Grab Receiver.

##### Declaration

```
public virtual void ResetToggle(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to remove from the toggle state. |

#### ToStackInteractorProvider(GrabInteractableInteractorProvider)

Casts a given [GrabInteractableInteractorProvider] to the required [GrabInteractableStackInteractorProvider] type.

##### Declaration

```
protected virtual GrabInteractableStackInteractorProvider ToStackInteractorProvider(GrabInteractableInteractorProvider provider)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [GrabInteractableInteractorProvider] | provider | The base provider to cast. |

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableStackInteractorProvider] | The casted provider. |

[GrabInteractableAction]: GrabInteractableAction.md
[GrabInteractableAction.InputActiveCollisionConsumer]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputActiveCollisionConsumer
[GrabInteractableAction.InputGrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabReceived
[GrabInteractableAction.InputUngrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReceived
[GrabInteractableAction.InputGrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabSetup
[GrabInteractableAction.InputUngrabReset]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReset
[GrabInteractableAction.GrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_GrabSetup
[GrabInteractableAction.NotifyGrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyGrab_GameObject_
[GrabInteractableAction.NotifyUngrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyUngrab_GameObject_
[GrabInteractableAction.OnAfterGrabSetupChange()]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_OnAfterGrabSetupChange
[Tilia.Interactions.Interactables.Interactables.Grab.Action]: README.md
[GrabInteractableStackInteractorProvider]: ../../../Interactables/Grab/Provider/GrabInteractableStackInteractorProvider.md
[GrabInteractableInteractorProvider]: ../../../Interactables/Grab/Provider/GrabInteractableInteractorProvider.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[ClearStack()]: #ClearStack
[EmitActiveCollisionConsumerPayload()]: #EmitActiveCollisionConsumerPayload
[PushToStack(GameObject)]: #PushToStackGameObject
[ResetToggle(GameObject)]: #ResetToggleGameObject
[ToStackInteractorProvider(GrabInteractableInteractorProvider)]: #ToStackInteractorProviderGrabInteractableInteractorProvider
