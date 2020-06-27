# Class GrabInteractableListInteractorProvider

Processes a received grab event into an Observable Set to handle a simplified grab process.

##### Inheritance

* System.Object
* [GrabInteractableInteractorProvider]
* GrabInteractableListInteractorProvider

##### Inherited Members

[GrabInteractableInteractorProvider.InputGrabReceived]

[GrabInteractableInteractorProvider.InputUngrabReceived]

[GrabInteractableInteractorProvider.OutputPrimaryGrabAction]

[GrabInteractableInteractorProvider.OutputPrimaryGrabSetupOnSecondaryAction]

[GrabInteractableInteractorProvider.OutputPrimaryUngrabAction]

[GrabInteractableInteractorProvider.OutputPrimaryUngrabResetOnSecondaryAction]

[GrabInteractableInteractorProvider.OutputSecondaryGrabAction]

[GrabInteractableInteractorProvider.OutputSecondaryUngrabAction]

[GrabInteractableInteractorProvider.grabbingInteractors]

[GrabInteractableInteractorProvider.GetGrabbingInteractors(IEnumerable<GameObject>)]

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Grab.Provider]

##### Syntax

```
public class GrabInteractableListInteractorProvider : GrabInteractableInteractorProvider
```

### Properties

#### EventList

The set to get the current interactors from.

##### Declaration

```
public GameObjectObservableList EventList { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### GrabbingInteractors

##### Declaration

```
public override IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | n/a |

##### Overrides

[GrabInteractableInteractorProvider.GrabbingInteractors]

[GrabInteractableInteractorProvider]: GrabInteractableInteractorProvider.md
[GrabInteractableInteractorProvider.InputGrabReceived]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_InputGrabReceived
[GrabInteractableInteractorProvider.InputUngrabReceived]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_InputUngrabReceived
[GrabInteractableInteractorProvider.OutputPrimaryGrabAction]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_OutputPrimaryGrabAction
[GrabInteractableInteractorProvider.OutputPrimaryGrabSetupOnSecondaryAction]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_OutputPrimaryGrabSetupOnSecondaryAction
[GrabInteractableInteractorProvider.OutputPrimaryUngrabAction]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_OutputPrimaryUngrabAction
[GrabInteractableInteractorProvider.OutputPrimaryUngrabResetOnSecondaryAction]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_OutputPrimaryUngrabResetOnSecondaryAction
[GrabInteractableInteractorProvider.OutputSecondaryGrabAction]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_OutputSecondaryGrabAction
[GrabInteractableInteractorProvider.OutputSecondaryUngrabAction]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_OutputSecondaryUngrabAction
[GrabInteractableInteractorProvider.grabbingInteractors]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_grabbingInteractors
[GrabInteractableInteractorProvider.GetGrabbingInteractors(IEnumerable<GameObject>)]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_GetGrabbingInteractors_System_Collections_Generic_IEnumerable_GameObject__
[Tilia.Interactions.Interactables.Interactables.Grab.Provider]: README.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[GrabInteractableInteractorProvider.GrabbingInteractors]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_GrabbingInteractors