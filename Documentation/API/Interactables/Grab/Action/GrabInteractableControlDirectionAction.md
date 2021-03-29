# Class GrabInteractableControlDirectionAction

Describes an action that allows the Interactable to point in the direction of a given Interactor.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [DirectionModifier]
  * [LinkedObjects]
* [Methods]
  * [DisableLinkedObjects()]
  * [EnableLinkedObjects()]
  * [LinkTargetOffsets(GrabInteractableAction)]
  * [OnAfterGrabSetupChange()]
  * [SetupTargetOffset()]
  * [ToggleLinkedObjectState(Boolean)]

## Details

##### Inheritance

* System.Object
* [GrabInteractableAction]
* GrabInteractableControlDirectionAction

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
public class GrabInteractableControlDirectionAction : GrabInteractableAction
```

### Properties

#### DirectionModifier

The Zinnia.Tracking.Modification.DirectionModifier to process the direction control.

##### Declaration

```
public DirectionModifier DirectionModifier { get; protected set; }
```

#### LinkedObjects

A GameObject collection to enable/disabled as part of the direction control process.

##### Declaration

```
public GameObjectObservableList LinkedObjects { get; set; }
```

### Methods

#### DisableLinkedObjects()

Disables the GameObject state of each of the items in the [LinkedObjects] collection.

##### Declaration

```
public virtual void DisableLinkedObjects()
```

#### EnableLinkedObjects()

Enables the GameObject state of each of the items in the [LinkedObjects] collection.

##### Declaration

```
public virtual void EnableLinkedObjects()
```

#### LinkTargetOffsets(GrabInteractableAction)

Links the given action's target offset to the DirectionModifier.TargetOffset if the action is a Follow Action.

##### Declaration

```
protected virtual void LinkTargetOffsets(GrabInteractableAction action)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [GrabInteractableAction] | action | The action to try and link from. |

#### OnAfterGrabSetupChange()

Called after [GrabSetup] has been changed.

##### Declaration

```
protected override void OnAfterGrabSetupChange()
```

##### Overrides

[GrabInteractableAction.OnAfterGrabSetupChange()]

#### SetupTargetOffset()

Sets up the DirectionModifier.TargetOffset based on the target offsets from any follow action.

##### Declaration

```
public virtual void SetupTargetOffset()
```

#### ToggleLinkedObjectState(Boolean)

Toggles the GameObject state of each of the items in the [LinkedObjects] collection.

##### Declaration

```
protected virtual void ToggleLinkedObjectState(bool state)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Boolean | state | The state to set the GameObject active state to. |

[GrabInteractableAction.InputActiveCollisionConsumer]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputActiveCollisionConsumer
[GrabInteractableAction.InputGrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabReceived
[GrabInteractableAction.InputUngrabReceived]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReceived
[GrabInteractableAction.InputGrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputGrabSetup
[GrabInteractableAction.InputUngrabReset]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_InputUngrabReset
[GrabInteractableAction.GrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_GrabSetup
[GrabInteractableAction.NotifyGrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyGrab_GameObject_
[GrabInteractableAction.NotifyUngrab(GameObject)]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_NotifyUngrab_GameObject_
[Tilia.Interactions.Interactables.Interactables.Grab.Action]: README.md
[LinkedObjects]: GrabInteractableControlDirectionAction.md#LinkedObjects
[LinkedObjects]: GrabInteractableControlDirectionAction.md#LinkedObjects
[GrabInteractableAction]: GrabInteractableAction.md
[GrabSetup]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_GrabSetup
[GrabInteractableAction.OnAfterGrabSetupChange()]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_OnAfterGrabSetupChange
[LinkedObjects]: GrabInteractableControlDirectionAction.md#LinkedObjects
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[DirectionModifier]: #DirectionModifier
[LinkedObjects]: #LinkedObjects
[Methods]: #Methods
[DisableLinkedObjects()]: #DisableLinkedObjects
[EnableLinkedObjects()]: #EnableLinkedObjects
[LinkTargetOffsets(GrabInteractableAction)]: #LinkTargetOffsetsGrabInteractableAction
[OnAfterGrabSetupChange()]: #OnAfterGrabSetupChange
[SetupTargetOffset()]: #SetupTargetOffset
[ToggleLinkedObjectState(Boolean)]: #ToggleLinkedObjectStateBoolean
