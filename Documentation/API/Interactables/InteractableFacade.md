# Class InteractableFacade

The public interface into the Interactable Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [delayInstruction]
  * [FirstGrabbed]
  * [FirstTouched]
  * [Grabbed]
  * [grabRoutine]
  * [LastUngrabbed]
  * [LastUntouched]
  * [Touched]
  * [Ungrabbed]
  * [ungrabRoutine]
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
  * [DoGrabAtEndOfFrame(InteractorFacade)]
  * [DoGrabIgnoreUngrabAtEndOfFrame(InteractorFacade)]
  * [DoUngrabAtEndOfFrame(Int32)]
  * [DoUngrabAtEndOfFrame(InteractorFacade)]
  * [GetInteractorFromGameObject(GameObject)]
  * [Grab(GameObject)]
  * [Grab(InteractorFacade)]
  * [GrabAtEndOfFrame(GameObject)]
  * [GrabAtEndOfFrame(InteractorFacade)]
  * [GrabIgnoreUngrab(GameObject)]
  * [GrabIgnoreUngrab(InteractorFacade)]
  * [GrabIgnoreUngrabAtEndOfFrame(GameObject)]
  * [GrabIgnoreUngrabAtEndOfFrame(InteractorFacade)]
  * [OnAfterGrabProviderIndexChange()]
  * [OnAfterGrabTypeChange()]
  * [Ungrab(GameObject)]
  * [Ungrab(Int32)]
  * [Ungrab(InteractorFacade)]
  * [UngrabAtEndOfFrame(GameObject)]
  * [UngrabAtEndOfFrame(Int32)]
  * [UngrabAtEndOfFrame(InteractorFacade)]

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

#### delayInstruction

A reusable instance of WaitForEndOfFrame.

##### Declaration

```
protected WaitForEndOfFrame delayInstruction
```

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

#### grabRoutine

The routine for grabbing after a certain instruction.

##### Declaration

```
protected Coroutine grabRoutine
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

#### ungrabRoutine

The routine for ungrabbing after a certain instruction.

##### Declaration

```
protected Coroutine ungrabRoutine
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

#### DoGrabAtEndOfFrame(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and ungrabs any existing grabbed Interactable at the end of the current frame.

##### Declaration

```
protected virtual IEnumerator DoGrabAtEndOfFrame(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | An Enumerator to manage the running of the Coroutine. |

#### DoGrabIgnoreUngrabAtEndOfFrame(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grabbed Interactable at the end of the current frame.

##### Declaration

```
protected virtual IEnumerator DoGrabIgnoreUngrabAtEndOfFrame(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | An Enumerator to manage the running of the Coroutine. |

#### DoUngrabAtEndOfFrame(Int32)

Attempt to ungrab the Interactable at a specific grabbing index at the end of the current frame.

##### Declaration

```
protected virtual IEnumerator DoUngrabAtEndOfFrame(int sequenceIndex = 0)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | sequenceIndex | The Interactor sequence index to ungrab from. |

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | An Enumerator to manage the running of the Coroutine. |

#### DoUngrabAtEndOfFrame(InteractorFacade)

Attempt to ungrab the Interactable at the end of the current frame.

##### Declaration

```
protected virtual IEnumerator DoUngrabAtEndOfFrame(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to ungrab from. |

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | An Enumerator to manage the running of the Coroutine. |

#### GetInteractorFromGameObject(GameObject)

Gets the [InteractorFacade] from the given GameObject or if not found searches for one on all desdendants then ancestors.

##### Declaration

```
protected virtual InteractorFacade GetInteractorFromGameObject(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The source to search on. |

##### Returns

| Type | Description |
| --- | --- |
| [InteractorFacade] | The found component if exists. |

#### Grab(GameObject)

Attempt to grab the Interactable to the given GameObject that contains an Interactor and ungrabs any existing grabbed Interactable.

##### Declaration

```
public virtual void Grab(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The GameObject that the Interactor is on. |

#### Grab(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and ungrabs any existing grabbed Interactable.

##### Declaration

```
public virtual void Grab(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

#### GrabAtEndOfFrame(GameObject)

Attempt to grab the Interactable to the given GameObject that contains an Interactor and ungrabs any existing grabbed Interactable at the end of the current frame.

##### Declaration

```
public virtual void GrabAtEndOfFrame(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The GameObject that the Interactor is on. |

#### GrabAtEndOfFrame(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and ungrabs any existing grabbed Interactable at the end of the current frame.

##### Declaration

```
public virtual void GrabAtEndOfFrame(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

#### GrabIgnoreUngrab(GameObject)

Attempt to grab the Interactable to the given GameObject that contains an Interactor and does not ungrab any existing grabbed Interactable.

##### Declaration

```
public virtual void GrabIgnoreUngrab(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The GameObject that the Interactor is on. |

#### GrabIgnoreUngrab(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grabbed Interactable.

##### Declaration

```
public virtual void GrabIgnoreUngrab(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to attach the Interactable to. |

#### GrabIgnoreUngrabAtEndOfFrame(GameObject)

Attempt to grab the Interactable to the given GameObject that contains an Interactor and does not ungrab any existing grabbed Interactable at the end of the current frame.

##### Declaration

```
public virtual void GrabIgnoreUngrabAtEndOfFrame(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The GameObject that the Interactor is on. |

#### GrabIgnoreUngrabAtEndOfFrame(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and does not ungrab any existing grabbed Interactable at the end of the current frame.

##### Declaration

```
public virtual void GrabIgnoreUngrabAtEndOfFrame(InteractorFacade interactor)
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

#### UngrabAtEndOfFrame(GameObject)

Attempt to ungrab the Interactable to the given GameObject that contains an Interactor at the end of the current frame.

##### Declaration

```
public virtual void UngrabAtEndOfFrame(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The GameObject that the Interactor is on. |

#### UngrabAtEndOfFrame(Int32)

Attempt to ungrab the Interactable at a specific grabbing index at the end of the current frame.

##### Declaration

```
public virtual void UngrabAtEndOfFrame(int sequenceIndex = 0)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | sequenceIndex | The Interactor sequence index to ungrab from. |

#### UngrabAtEndOfFrame(InteractorFacade)

Attempt to ungrab the Interactable at the end of the current frame.

##### Declaration

```
public virtual void UngrabAtEndOfFrame(InteractorFacade interactor)
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
[delayInstruction]: #delayInstruction
[FirstGrabbed]: #FirstGrabbed
[FirstTouched]: #FirstTouched
[Grabbed]: #Grabbed
[grabRoutine]: #grabRoutine
[LastUngrabbed]: #LastUngrabbed
[LastUntouched]: #LastUntouched
[Touched]: #Touched
[Ungrabbed]: #Ungrabbed
[ungrabRoutine]: #ungrabRoutine
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
[DoGrabAtEndOfFrame(InteractorFacade)]: #DoGrabAtEndOfFrameInteractorFacade
[DoGrabIgnoreUngrabAtEndOfFrame(InteractorFacade)]: #DoGrabIgnoreUngrabAtEndOfFrameInteractorFacade
[DoUngrabAtEndOfFrame(Int32)]: #DoUngrabAtEndOfFrameInt32
[DoUngrabAtEndOfFrame(InteractorFacade)]: #DoUngrabAtEndOfFrameInteractorFacade
[GetInteractorFromGameObject(GameObject)]: #GetInteractorFromGameObjectGameObject
[Grab(GameObject)]: #GrabGameObject
[Grab(InteractorFacade)]: #GrabInteractorFacade
[GrabAtEndOfFrame(GameObject)]: #GrabAtEndOfFrameGameObject
[GrabAtEndOfFrame(InteractorFacade)]: #GrabAtEndOfFrameInteractorFacade
[GrabIgnoreUngrab(GameObject)]: #GrabIgnoreUngrabGameObject
[GrabIgnoreUngrab(InteractorFacade)]: #GrabIgnoreUngrabInteractorFacade
[GrabIgnoreUngrabAtEndOfFrame(GameObject)]: #GrabIgnoreUngrabAtEndOfFrameGameObject
[GrabIgnoreUngrabAtEndOfFrame(InteractorFacade)]: #GrabIgnoreUngrabAtEndOfFrameInteractorFacade
[OnAfterGrabProviderIndexChange()]: #OnAfterGrabProviderIndexChange
[OnAfterGrabTypeChange()]: #OnAfterGrabTypeChange
[Ungrab(GameObject)]: #UngrabGameObject
[Ungrab(Int32)]: #UngrabInt32
[Ungrab(InteractorFacade)]: #UngrabInteractorFacade
[UngrabAtEndOfFrame(GameObject)]: #UngrabAtEndOfFrameGameObject
[UngrabAtEndOfFrame(Int32)]: #UngrabAtEndOfFrameInt32
[UngrabAtEndOfFrame(InteractorFacade)]: #UngrabAtEndOfFrameInteractorFacade