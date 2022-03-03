# Class InteractableGrabDropRestrictor

Restricts the ability to drop a grabbed [InteractableFacade].

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [DisableDrop(GameObject)]
  * [DisableDrop(InteractableFacade)]
  * [DoDisableDrop(GameObject)]
  * [DoDisableDrop(InteractableFacade)]
  * [DoEnableDrop(GameObject)]
  * [DoEnableDrop(InteractableFacade)]
  * [EnableDrop(GameObject)]
  * [EnableDrop(InteractableFacade)]

## Details

##### Inheritance

* System.Object
* InteractableGrabDropRestrictor

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab]

##### Syntax

```
public class InteractableGrabDropRestrictor : MonoBehaviour
```

### Methods

#### DisableDrop(GameObject)

Disables the drop on the given Interactable.

##### Declaration

```
public static bool DisableDrop(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The Interactable to disable on. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the drop was disabled. |

#### DisableDrop(InteractableFacade)

Disables the drop on the given Interactable.

##### Declaration

```
public static bool DisableDrop(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to disable on. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the drop was disabled. |

#### DoDisableDrop(GameObject)

Disables the drop on the given Interactable.

##### Declaration

```
public virtual void DoDisableDrop(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The Interactable to disable on. |

#### DoDisableDrop(InteractableFacade)

Disables the drop on the given Interactable.

##### Declaration

```
public virtual void DoDisableDrop(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to disable on. |

#### DoEnableDrop(GameObject)

Enables the drop on the given Interactable.

##### Declaration

```
public virtual void DoEnableDrop(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The Interactable to enable on. |

#### DoEnableDrop(InteractableFacade)

Enables the drop on the given Interactable.

##### Declaration

```
public virtual void DoEnableDrop(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to enable on. |

#### EnableDrop(GameObject)

Enables the drop on the given Interactable.

##### Declaration

```
public static bool EnableDrop(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The Interactable to enable on. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the drop was enabled. |

#### EnableDrop(InteractableFacade)

Enables the drop on the given Interactable.

##### Declaration

```
public static bool EnableDrop(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to enable on. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the drop was enabled. |

[InteractableFacade]: ../../Interactables/InteractableFacade.md
[Tilia.Interactions.Interactables.Interactables.Grab]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[DisableDrop(GameObject)]: #DisableDropGameObject
[DisableDrop(InteractableFacade)]: #DisableDropInteractableFacade
[DoDisableDrop(GameObject)]: #DoDisableDropGameObject
[DoDisableDrop(InteractableFacade)]: #DoDisableDropInteractableFacade
[DoEnableDrop(GameObject)]: #DoEnableDropGameObject
[DoEnableDrop(InteractableFacade)]: #DoEnableDropInteractableFacade
[EnableDrop(GameObject)]: #EnableDropGameObject
[EnableDrop(InteractableFacade)]: #EnableDropInteractableFacade
