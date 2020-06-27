# Class InteractableFacade

The public interface into the Interactable Prefab.

##### Inheritance

* System.Object
* InteractableFacade

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables]

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

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

#### FirstTouched

Emitted when the Interactable is touched for the first time by an Interactor.

##### Declaration

```
public InteractableFacade.UnityEvent FirstTouched
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

#### Grabbed

Emitted when an Interactor grabs the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Grabbed
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

#### LastUngrabbed

Emitted when the Interactable is ungrabbed for the last time by an Interactor.

##### Declaration

```
public InteractableFacade.UnityEvent LastUngrabbed
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

#### LastUntouched

Emitted when the Interactable is untouched for the last time by an Interactor.

##### Declaration

```
public InteractableFacade.UnityEvent LastUntouched
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

#### Touched

Emitted when an Interactor touches the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Touched
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

#### Ungrabbed

Emitted when an Interactor ungrabs the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Ungrabbed
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

#### Untouched

Emitted when an Interactor stops touching the Interactable.

##### Declaration

```
public InteractableFacade.UnityEvent Untouched
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractableFacade.UnityEvent] | n/a |

### Properties

#### Configuration

The linked [InteractableConfigurator].

##### Declaration

```
public InteractableConfigurator Configuration { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractableConfigurator] | n/a |

#### GrabbingInteractors

A collection of Interactors that are currently grabbing the Interactable.

##### Declaration

```
public IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | n/a |

#### GrabProviderIndex

The GrabInteractableInteractorProvider to use.

##### Declaration

```
public int GrabProviderIndex { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Int32 | n/a |

#### GrabType

The linked [GrabInteractableReceiver.ActiveType].

##### Declaration

```
public GrabInteractableReceiver.ActiveType GrabType { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableReceiver.ActiveType] | n/a |

#### IsGrabbed

Whether the Interactable is currently being grabbed by any valid Interactor.

##### Declaration

```
public bool IsGrabbed { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### IsGrabTypeToggle

Determines if the grab type is set to toggle.

##### Declaration

```
public bool IsGrabTypeToggle { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### IsTouched

Whether the Interactable is currently being touched by any valid Interactor.

##### Declaration

```
public bool IsTouched { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### TouchingInteractors

A collection of Interactors that are currently touching the Interactable.

##### Declaration

```
public IReadOnlyList<InteractorFacade> TouchingInteractors { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | n/a |

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
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[InteractableConfigurator]: InteractableConfigurator.md
[InteractableConfigurator]: InteractableConfigurator.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[GrabInteractableReceiver.ActiveType]: Grab.Receiver.GrabInteractableReceiver.ActiveType.md
[GrabInteractableReceiver.ActiveType]: Grab.Receiver.GrabInteractableReceiver.ActiveType.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[GrabProviderIndex]: InteractableFacade.md#GrabProviderIndex
[GrabType]: InteractableFacade.md#GrabType
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md