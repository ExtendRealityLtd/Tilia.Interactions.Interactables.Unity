# Class InteractorIsGrabbingRule

Determines whether the Interactor is currently grabbing something.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [Accepts(InteractorFacade)]

## Details

##### Inheritance

* System.Object
* [InteractorRule]
* InteractorIsGrabbingRule

##### Inherited Members

[InteractorRule.cachedGameObject]

[InteractorRule.cachedInteractor]

[InteractorRule.Accepts(GameObject)]

##### Namespace

* [Tilia.Interactions.Interactables.Interactors.Rule]

##### Syntax

```
public class InteractorIsGrabbingRule : InteractorRule
```

### Methods

#### Accepts(InteractorFacade)

Determines whether a [InteractorFacade] is accepted.

##### Declaration

```
protected override bool Accepts(InteractorFacade targetInteractorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | targetInteractorFacade | n/a |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | true if `targetInteractorFacade` is accepted, false otherwise. |

##### Overrides

[InteractorRule.Accepts(InteractorFacade)]

[InteractorRule]: InteractorRule.md
[InteractorRule.cachedGameObject]: InteractorRule.md#Tilia_Interactions_Interactables_Interactors_Rule_InteractorRule_cachedGameObject
[InteractorRule.cachedInteractor]: InteractorRule.md#Tilia_Interactions_Interactables_Interactors_Rule_InteractorRule_cachedInteractor
[InteractorRule.Accepts(GameObject)]: InteractorRule.md#Tilia_Interactions_Interactables_Interactors_Rule_InteractorRule_Accepts_GameObject_
[Tilia.Interactions.Interactables.Interactors.Rule]: README.md
[InteractorFacade]: ../../Interactors/InteractorFacade.md
[InteractorRule.Accepts(InteractorFacade)]: InteractorRule.md#Tilia_Interactions_Interactables_Interactors_Rule_InteractorRule_Accepts_Tilia_Interactions_Interactables_Interactors_InteractorFacade_
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[Accepts(InteractorFacade)]: #AcceptsInteractorFacade
