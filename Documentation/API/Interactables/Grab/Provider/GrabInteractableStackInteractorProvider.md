# Class GrabInteractableStackInteractorProvider

Processes a received grab event into an Observable Stack to handle multiple output options for each grab type.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [AttemptSwapLogicContainer]
  * [EventStack]
  * [GrabbingInteractors]

## Details

##### Inheritance

* System.Object
* [GrabInteractableInteractorProvider]
* GrabInteractableStackInteractorProvider

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

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab.Provider]

##### Syntax

```
public class GrabInteractableStackInteractorProvider : GrabInteractableInteractorProvider
```

### Properties

#### AttemptSwapLogicContainer

The container that holds the logic for attempting to swap the stacks on force pop.

##### Declaration

```
public GameObject AttemptSwapLogicContainer { get; set; }
```

#### EventStack

The stack to get the current interactors from.

##### Declaration

```
public GameObjectObservableStack EventStack { get; set; }
```

#### GrabbingInteractors

Gets the available grabbing Interactors from the provider.

##### Declaration

```
public override IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | A collection of Interactors that are currently grabbing the Interactable. |

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
[InteractorFacade]: ../../../Interactors/InteractorFacade.md
[GrabInteractableInteractorProvider.GrabbingInteractors]: GrabInteractableInteractorProvider.md#Tilia_Interactions_Interactables_Interactables_Grab_Provider_GrabInteractableInteractorProvider_GrabbingInteractors
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[AttemptSwapLogicContainer]: #AttemptSwapLogicContainer
[EventStack]: #EventStack
[GrabbingInteractors]: #GrabbingInteractors
