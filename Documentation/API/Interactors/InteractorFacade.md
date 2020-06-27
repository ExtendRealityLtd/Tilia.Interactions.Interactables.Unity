# Class InteractorFacade

The public interface into the Interactor Prefab.

##### Inheritance

* System.Object
* InteractorFacade

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class InteractorFacade : MonoBehaviour
```

### Fields

#### Grabbed

Emitted when the Interactor starts grabbing a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Grabbed
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractorFacade.UnityEvent] | n/a |

#### Touched

Emitted when the Interactor starts touching a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Touched
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractorFacade.UnityEvent] | n/a |

#### Ungrabbed

Emitted when the Interactor stops grabbing a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Ungrabbed
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractorFacade.UnityEvent] | n/a |

#### Untouched

Emitted when the Interactor stops touching a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Untouched
```

##### Field Value

| Type | Description |
| --- | --- |
| [InteractorFacade.UnityEvent] | n/a |

### Properties

#### ActiveTouchedObject

The currently active touched GameObject.

##### Declaration

```
public GameObject ActiveTouchedObject { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### AvatarContainer

The container of the Interactor avatar components.

##### Declaration

```
public GameObject AvatarContainer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### GrabAction

The BooleanAction that will initiate the Interactor grab mechanism.

##### Declaration

```
public BooleanAction GrabAction { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| BooleanAction | n/a |

#### GrabAttachPoint

The point at which the grabbed Interactable will be attached to the Interactor.

##### Declaration

```
public GameObject GrabAttachPoint { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### GrabbedObjects

A collection of currently grabbed GameObjects.

##### Declaration

```
public IReadOnlyList<GameObject> GrabbedObjects { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<GameObject\> | n/a |

#### GrabConfiguration

The linked Grab Internal Setup.

##### Declaration

```
public GrabInteractorConfigurator GrabConfiguration { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractorConfigurator] | n/a |

#### GrabPrecognition

The time between initiating the [GrabAction] and touching an Interactable to be considered a valid grab.

##### Declaration

```
public float GrabPrecognition { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Single | n/a |

#### TouchConfiguration

The linked Touch Internal Setup.

##### Declaration

```
public TouchInteractorConfigurator TouchConfiguration { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [TouchInteractorConfigurator] | n/a |

#### TouchedObjects

A collection of currently touched GameObjects.

##### Declaration

```
public IReadOnlyList<GameObject> TouchedObjects { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<GameObject\> | n/a |

#### VelocityTracker

The VelocityTrackerProcessor to measure the interactors current velocity.

##### Declaration

```
public VelocityTrackerProcessor VelocityTracker { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| VelocityTrackerProcessor | n/a |

### Methods

#### Grab(GameObject)

Attempt to attach a GameObject that contains an [InteractableFacade] to this [InteractorFacade].

##### Declaration

```
public virtual void Grab(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject that the Interactable is on. |

#### Grab(SurfaceData)

Attempt to attach an [InteractableFacade] found in the given SurfaceData to this [InteractorFacade].

##### Declaration

```
public virtual void Grab(SurfaceData data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| SurfaceData | data | The collision data containing a valid Interactable. |

#### Grab(InteractableFacade)

Attempt to attach an [InteractableFacade] to this [InteractorFacade].

##### Declaration

```
public virtual void Grab(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to attempt to grab. |

#### Grab(InteractableFacade, Collision, Collider)

Attempt to attach an [InteractableFacade] to this [InteractorFacade] utilizing custom collision data.

##### Declaration

```
public virtual void Grab(InteractableFacade interactable, Collision collision, Collider collider)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to attempt to grab. |
| Collision | collision | Custom collision data. |
| Collider | collider | Custom collider data. |

#### NotifyOfGrab(InteractableFacade)

Notifies the interactor that it is grabbing an interactable.

##### Declaration

```
public virtual void NotifyOfGrab(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The interactable being grabbed. |

#### NotifyOfTouch(InteractableFacade)

Notifies the interactor that it is touching an interactable.

##### Declaration

```
public virtual void NotifyOfTouch(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The interactable being touched. |

#### NotifyOfUngrab(InteractableFacade)

Notifies the interactor that it is no longer grabbing an interactable.

##### Declaration

```
public virtual void NotifyOfUngrab(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The interactable being ungrabbed. |

#### NotifyOfUntouch(InteractableFacade)

Notifies the interactor that it is no longer touching an interactable.

##### Declaration

```
public virtual void NotifyOfUntouch(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The interactable being untouched. |

#### OnAfterGrabActionChange()

Called after [GrabAction] has been changed.

##### Declaration

```
protected virtual void OnAfterGrabActionChange()
```

#### OnAfterGrabPrecognitionChange()

Called after [GrabPrecognition] has been changed.

##### Declaration

```
protected virtual void OnAfterGrabPrecognitionChange()
```

#### OnAfterVelocityTrackerChange()

Called after [VelocityTracker] has been changed.

##### Declaration

```
protected virtual void OnAfterVelocityTrackerChange()
```

#### Ungrab()

Attempt to ungrab currently grabbed Interactables to the current Interactor.

##### Declaration

```
public virtual void Ungrab()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorFacade.UnityEvent]: InteractorFacade.UnityEvent.md
[InteractorFacade.UnityEvent]: InteractorFacade.UnityEvent.md
[InteractorFacade.UnityEvent]: InteractorFacade.UnityEvent.md
[InteractorFacade.UnityEvent]: InteractorFacade.UnityEvent.md
[GrabInteractorConfigurator]: GrabInteractorConfigurator.md
[GrabAction]: InteractorFacade.md#GrabAction
[TouchInteractorConfigurator]: TouchInteractorConfigurator.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[GrabAction]: InteractorFacade.md#GrabAction
[GrabPrecognition]: InteractorFacade.md#GrabPrecognition
[VelocityTracker]: InteractorFacade.md#VelocityTracker