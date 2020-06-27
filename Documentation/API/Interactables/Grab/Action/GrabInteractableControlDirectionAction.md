# Class GrabInteractableControlDirectionAction

Describes an action that allows the Interactable to point in the direction of a given Interactor.

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

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Grab.Action]

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

##### Property Value

| Type | Description |
| --- | --- |
| DirectionModifier | n/a |

#### LinkedObjects

A GameObject collection to enable/disabled as part of the direction control process.

##### Declaration

```
public GameObjectObservableList LinkedObjects { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

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

#### OnAfterGrabSetupChange()

##### Declaration

```
protected override void OnAfterGrabSetupChange()
```

##### Overrides

[GrabInteractableAction.OnAfterGrabSetupChange()]

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
[LinkedObjects]: GrabInteractableControlDirectionAction.md#LinkedObjects
[LinkedObjects]: GrabInteractableControlDirectionAction.md#LinkedObjects
[GrabInteractableAction.OnAfterGrabSetupChange()]: GrabInteractableAction.md#Tilia_Interactions_Interactables_Interactables_Grab_Action_GrabInteractableAction_OnAfterGrabSetupChange
[LinkedObjects]: GrabInteractableControlDirectionAction.md#LinkedObjects