# Class GrabInteractableScaleAction

Describes an action that allows the Interactable to be scaled in size between the points of two specified Interactors.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [PinchScaler]
* [Methods]
  * [OnAfterGrabSetupChange()]

## Details

##### Inheritance

* System.Object
* [GrabInteractableAction]
* GrabInteractableScaleAction

##### Inherited Members

[GrabInteractableAction.InputActiveCollisionConsumer]

[GrabInteractableAction.InputGrabReceived]

[GrabInteractableAction.InputUngrabReceived]

[GrabInteractableAction.InputGrabSetup]

[GrabInteractableAction.InputUngrabReset]

[GrabInteractableAction.GrabSetup]

[GrabInteractableAction.NotifyGrab(GameObject)]

[GrabInteractableAction.NotifyUngrab(GameObject)]

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab.Action]

##### Syntax

```
public class GrabInteractableScaleAction : GrabInteractableAction
```

### Properties

#### PinchScaler

The Zinnia.Tracking.Modification.PinchScaler to process the scale control.

##### Declaration

```
public PinchScaler PinchScaler { get; protected set; }
```

### Methods

#### OnAfterGrabSetupChange()

Called after [GrabSetup] has been changed.

##### Declaration

```
protected override void OnAfterGrabSetupChange()
```

##### Overrides

[GrabInteractableAction.OnAfterGrabSetupChange()]

[GrabInteractableAction]: GrabInteractableAction.md
[GrabInteractableAction.InputActiveCollisionConsumer]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputActiveCollisionConsumer
[GrabInteractableAction.InputGrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabReceived
[GrabInteractableAction.InputUngrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReceived
[GrabInteractableAction.InputGrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabSetup
[GrabInteractableAction.InputUngrabReset]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReset
[GrabInteractableAction.GrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_GrabSetup
[GrabInteractableAction.NotifyGrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyGrab_GameObject_
[GrabInteractableAction.NotifyUngrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyUngrab_GameObject_
[Tilia.Interactions.Interactables.Interactables.Grab.Action]: README.md
[GrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_GrabSetup
[GrabInteractableAction.OnAfterGrabSetupChange()]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_OnAfterGrabSetupChange
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[PinchScaler]: #PinchScaler
[Methods]: #Methods
[OnAfterGrabSetupChange()]: #OnAfterGrabSetupChange
