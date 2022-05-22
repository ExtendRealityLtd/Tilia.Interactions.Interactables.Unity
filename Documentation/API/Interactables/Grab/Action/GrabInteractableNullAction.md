# Class GrabInteractableNullAction

Describes an action that performs no action.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ForceEmitEvents]
  * [GrabEventContainer]
  * [UngrabEventContainer]
* [Methods]
  * [OnEnable()]
  * [OnForceEmitEventsChange()]

## Details

##### Inheritance

* System.Object
* [GrabInteractableAction]
* GrabInteractableNullAction

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
public class GrabInteractableNullAction : GrabInteractableAction
```

### Properties

#### ForceEmitEvents

Determines whether to force the grabbed/ungrabbed events even though no grab is occurring.

##### Declaration

```
public bool ForceEmitEvents { get; set; }
```

#### GrabEventContainer

The container of the grab event logic.

##### Declaration

```
public GameObject GrabEventContainer { get; protected set; }
```

#### UngrabEventContainer

The container of the ungrab event logic.

##### Declaration

```
public GameObject UngrabEventContainer { get; protected set; }
```

### Methods

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### OnForceEmitEventsChange()

Called after [ForceEmitEvents] has been changed.

##### Declaration

```
protected virtual void OnForceEmitEventsChange()
```

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
[ForceEmitEvents]: GrabInteractableNullAction.md#ForceEmitEvents
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ForceEmitEvents]: #ForceEmitEvents
[GrabEventContainer]: #GrabEventContainer
[UngrabEventContainer]: #UngrabEventContainer
[Methods]: #Methods
[OnEnable()]: #OnEnable
[OnForceEmitEventsChange()]: #OnForceEmitEventsChange
