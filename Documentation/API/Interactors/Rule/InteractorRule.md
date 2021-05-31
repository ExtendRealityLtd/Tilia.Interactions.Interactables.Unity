# Class InteractorRule

Simplifies implementing IRules that only deals with an [InteractorRule] attached to a GameObject.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedGameObject]
  * [cachedInteractor]
* [Methods]
  * [Accepts(GameObject)]
  * [Accepts(InteractorFacade)]

## Details

##### Inheritance

* System.Object
* InteractorRule
* [InteractorIsGrabbingRule]
* [InteractorIsTouchingRule]

##### Namespace

* [Tilia.Interactions.Interactables.Interactors.Rule]

##### Syntax

```
public abstract class InteractorRule : GameObjectRule
```

### Fields

#### cachedGameObject

A cache to store the given GameObject to prevent having to re execute the GameObject.GetComponent method on the same given GameObject.

##### Declaration

```
protected GameObject cachedGameObject
```

#### cachedInteractor

The cached [InteractorFacade] to check the grabbed state on.

##### Declaration

```
protected InteractorFacade cachedInteractor
```

### Methods

#### Accepts(GameObject)

##### Declaration

```
protected override bool Accepts(GameObject targetGameObject)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | targetGameObject | n/a |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### Accepts(InteractorFacade)

Determines whether a [InteractorFacade] is accepted.

##### Declaration

```
protected abstract bool Accepts(InteractorFacade targetInteractorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | targetInteractorFacade | n/a |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | true if `targetInteractorFacade` is accepted, false otherwise. |

[InteractorRule]: InteractorRule.md
[InteractorIsGrabbingRule]: InteractorIsGrabbingRule.md
[InteractorIsTouchingRule]: InteractorIsTouchingRule.md
[Tilia.Interactions.Interactables.Interactors.Rule]: README.md
[InteractorFacade]: ../../Interactors/InteractorFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedGameObject]: #cachedGameObject
[cachedInteractor]: #cachedInteractor
[Methods]: #Methods
[Accepts(GameObject)]: #AcceptsGameObject
[Accepts(InteractorFacade)]: #AcceptsInteractorFacade
