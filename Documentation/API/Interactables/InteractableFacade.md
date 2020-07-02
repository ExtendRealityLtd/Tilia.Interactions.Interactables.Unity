# Class InteractableFacade

The public interface into the Interactable Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [FirstGrabbed]
  * [FirstTouched]
  * [Grabbed]
  * [LastUngrabbed]
  * [LastUntouched]
  * [Touched]
  * [Ungrabbed]
  * [Untouched]
* [Properties]
  * [Configuration]
  * [GrabbingInteractors]
  * [GrabProviderIndex]
  * [GrabType]
  * [IsGrabbed]
  * [IsGrabTypeToggle]
  * [IsTouched]
  * [TouchingInteractors]
* [Methods]
  * [Grab(GameObject)]
  * [Grab(InteractorFacade)]
  * [OnAfterGrabProviderIndexChange()]
  * [OnAfterGrabTypeChange()]
  * [Ungrab(GameObject)]
  * [Ungrab(Int32)]
  * [Ungrab(InteractorFacade)]

## Details

##### Inheritance

* System.Object
* InteractableFacade

##### Namespace

* [Tilia.Interactions.Interactables.Interactables]

##### Syntax

```
public class InteractableFacade : MonoBehaviour
```

### Fields

#### FirstGrabbed

Emitted when the Interactable is grabbed for the first time by an Interactor.

##### Declaration

```
public InteractableFacade.UnityEvent FirstGrabbed
```

#### FirstTouched

Emitted when the Interactable is touched for the first time by an Interactor.

##### Declaration

```
public InteractableFacade.UnityEvent FirstTouched
```

#### Grabbed

Emitted when an Interactor grabs the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Grabbed
```

#### LastUngrabbed

Emitted when the Interactable is ungrabbed for the last time by an Interactor.

##### Declaration

```
public InteractableFacade.UnityEvent LastUngrabbed
```

#### LastUntouched

Emitted when the Interactable is untouched for the last time by an Interactor.

##### Declaration

```
public InteractableFacade.UnityEvent LastUntouched
```

#### Touched

Emitted when an Interactor touches the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Touched
```

#### Ungrabbed

Emitted when an Interactor ungrabs the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Ungrabbed
```

#### Untouched

Emitted when an Interactor stops touching the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Untouched
```

### Properties

#### Configuration

The linked [InteractableConfigurator].

##### Declaration

```
public InteractableConfigurator Configuration { get; protected set; }
```

#### GrabbingInteractors

A collection of Interactors that are currently grabbing the Interactable.

##### Declaration

```
public IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

#### GrabProviderIndex

The GrabInteractableInteractorProvider to use.

##### Declaration

```
public int GrabProviderIndex { get; set; }
```

#### GrabType

The linked [GrabInteractableReceiver.ActiveType].

##### Declaration

```
public GrabInteractableReceiver.ActiveType GrabType { get; set; }
```

#### IsGrabbed

Whether the Interactable is currently being grabbed by any valid Interactor.

##### Declaration

```
public bool IsGrabbed { get; }
```

#### IsGrabTypeToggle

Determines if the grab type is set to toggle.

##### Declaration

```
public bool IsGrabTypeToggle { get; }
```

#### IsTouched

Whether the Interactable is currently being touched by any valid Interactor.

##### Declaration

```
public bool IsTouched { get; }
```

#### TouchingInteractors

A collection of Interactors that are currently touching the Interactable.

##### Declaration

```
public IReadOnlyList<InteractorFacade> TouchingInteractors { get; }
```

### Methods

#### Grab(GameObject)

Attempt to grab the Interactable to the given GameObject that contains an Interactor.

##### Declaration

```
public virtual void Grab(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The GameObject that the Interactor is on. |

#### Grab(InteractorFacade)

Attempt to grab the Interactable to the given Interactor.

##### Declaration

```
public virtual void Grab(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

#### OnAfterGrabProviderIndexChange()

Called after [GrabProviderIndex] has been changed.

##### Declaration

```
protected virtual void OnAfterGrabProviderIndexChange()
```

#### OnAfterGrabTypeChange()

Called after [GrabType] has been changed.

##### Declaration

```
protected virtual void OnAfterGrabTypeChange()
```

#### Ungrab(GameObject)

Attempt to ungrab the Interactable to the given GameObject that contains an Interactor.

##### Declaration

```
public virtual void Ungrab(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The GameObject that the Interactor is on. |

#### Ungrab(Int32)

Attempt to ungrab the Interactable at a specific grabbing index.

##### Declaration

```
public virtual void Ungrab(int sequenceIndex = 0)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | sequenceIndex | The Interactor sequence index to ungrab from. |

#### Ungrab(InteractorFacade)

Attempt to ungrab the Interactable.

##### Declaration

```
public virtual void Ungrab(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to ungrab from. |

[Tilia.Interactions.Interactables.Interactables]: README.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableConfigurator]: InteractableConfigurator.md
[InteractorFacade]: ../Interactors/InteractorFacade.md
[GrabInteractableReceiver.ActiveType]: Grab/Receiver/GrabInteractableReceiver.ActiveType.md
[GrabProviderIndex]: InteractableFacade.md#GrabProviderIndex
[GrabType]: InteractableFacade.md#GrabType
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[FirstGrabbed]: #FirstGrabbed
[FirstTouched]: #FirstTouched
[Grabbed]: #Grabbed
[LastUngrabbed]: #LastUngrabbed
[LastUntouched]: #LastUntouched
[Touched]: #Touched
[Ungrabbed]: #Ungrabbed
[Untouched]: #Untouched
[Properties]: #Properties
[Configuration]: #Configuration
[GrabbingInteractors]: #GrabbingInteractors
[GrabProviderIndex]: #GrabProviderIndex
[GrabType]: #GrabType
[IsGrabbed]: #IsGrabbed
[IsGrabTypeToggle]: #IsGrabTypeToggle
[IsTouched]: #IsTouched
[TouchingInteractors]: #TouchingInteractors
[Methods]: #Methods
[Grab(GameObject)]: #GrabGameObject
[Grab(InteractorFacade)]: #GrabInteractorFacade
[OnAfterGrabProviderIndexChange()]: #OnAfterGrabProviderIndexChange
[OnAfterGrabTypeChange()]: #OnAfterGrabTypeChange
[Ungrab(GameObject)]: #UngrabGameObject
[Ungrab(Int32)]: #UngrabInt32
[Ungrab(InteractorFacade)]: #UngrabInteractorFacade
