# Class InteractableGrabStateEmitter

Emits an appropriate event based on the state of whether an [InteractableFacade] is currently being grabbed or not.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [Grabbed]
  * [NotGrabbed]
* [Methods]
  * [DoIsGrabbed(GameObject)]
  * [DoIsGrabbed(InteractableFacade)]
  * [IsGrabbed(GameObject)]
  * [IsGrabbed(InteractableFacade)]

## Details

##### Inheritance

* System.Object
* InteractableGrabStateEmitter

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab]

##### Syntax

```
public class InteractableGrabStateEmitter : MonoBehaviour
```

### Fields

#### Grabbed

Emitted if the [InteractableFacade] is grabbed.

##### Declaration

```
public InteractableGrabStateEmitter.UnityEvent Grabbed
```

#### NotGrabbed

Emitted if the [InteractableFacade] is not grabbed.

##### Declaration

```
public InteractableGrabStateEmitter.UnityEvent NotGrabbed
```

### Methods

#### DoIsGrabbed(GameObject)

Determines if the given GameObject's [InteractableFacade] is currently grabbed by a valid Interactor.

##### Declaration

```
public virtual void DoIsGrabbed(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject to check. |

#### DoIsGrabbed(InteractableFacade)

Determines if the given Interactable is currently grabbed by a valid Interactor.

##### Declaration

```
public virtual void DoIsGrabbed(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to check. |

#### IsGrabbed(GameObject)

Determines if the given GameObject's [InteractableFacade] is currently grabbed by a valid Interactor.

##### Declaration

```
public virtual bool IsGrabbed(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject to check. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the Interactable is being grabbed. |

#### IsGrabbed(InteractableFacade)

Determines if the given Interactable is currently grabbed by a valid Interactor.

##### Declaration

```
public virtual bool IsGrabbed(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to check. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the Interactable is being grabbed. |

[InteractableFacade]: ../../Interactables/InteractableFacade.md
[Tilia.Interactions.Interactables.Interactables.Grab]: README.md
[InteractableGrabStateEmitter.UnityEvent]: InteractableGrabStateEmitter.UnityEvent.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[Grabbed]: #Grabbed
[NotGrabbed]: #NotGrabbed
[Methods]: #Methods
[DoIsGrabbed(GameObject)]: #DoIsGrabbedGameObject
[DoIsGrabbed(InteractableFacade)]: #DoIsGrabbedInteractableFacade
[IsGrabbed(GameObject)]: #IsGrabbedGameObject
[IsGrabbed(InteractableFacade)]: #IsGrabbedInteractableFacade
