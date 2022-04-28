# Class InteractorFacade

The public interface into the Interactor Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [ClearGrabStateRoutine]
  * [delayInstruction]
  * [Grabbed]
  * [Touched]
  * [Ungrabbed]
  * [Untouched]
* [Properties]
  * [ActiveTouchedObject]
  * [AvatarContainer]
  * [GrabAction]
  * [GrabAttachPoint]
  * [GrabbedObjects]
  * [GrabConfiguration]
  * [GrabPrecognition]
  * [PrecisionAttachPoint]
  * [TouchConfiguration]
  * [TouchedObjects]
  * [VelocityTracker]
* [Methods]
  * [ClearGrabAction()]
  * [ClearGrabAttachPoint()]
  * [ClearGrabState(InteractableFacade)]
  * [ClearGrabStateAtEndOfFrame(InteractableFacade)]
  * [ClearVelocityTracker()]
  * [CreateCollisionPayload(GameObject)]
  * [Grab(GameObject)]
  * [Grab(GameObject, Boolean)]
  * [Grab(SurfaceData)]
  * [Grab(SurfaceData, Boolean)]
  * [Grab(InteractableFacade)]
  * [Grab(InteractableFacade, Collision, Collider)]
  * [Grab(InteractableFacade, Collision, Collider, Boolean)]
  * [Grab(InteractableFacade, Boolean)]
  * [GrabIgnoreUngrab(GameObject)]
  * [GrabIgnoreUngrab(SurfaceData)]
  * [GrabIgnoreUngrab(InteractableFacade)]
  * [GrabIgnoreUngrab(InteractableFacade, Collision, Collider)]
  * [NotifyOfGrab(InteractableFacade)]
  * [NotifyOfTouch(InteractableFacade)]
  * [NotifyOfUngrab(InteractableFacade)]
  * [NotifyOfUntouch(InteractableFacade)]
  * [OnAfterGrabActionChange()]
  * [OnAfterGrabPrecognitionChange()]
  * [OnAfterVelocityTrackerChange()]
  * [SimulateTouch(GameObject)]
  * [SimulateTouch(InteractableFacade)]
  * [SimulateUntouch(GameObject)]
  * [SimulateUntouch(InteractableFacade)]
  * [SnapAllGrabbedInteractableOrientations()]
  * [SnapGrabbedInteractableOrientation(Int32)]
  * [Ungrab()]

## Details

##### Inheritance

* System.Object
* InteractorFacade

##### Namespace

* [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class InteractorFacade : MonoBehaviour
```

### Fields

#### ClearGrabStateRoutine

The routine for clearing grab state.

##### Declaration

```
protected Coroutine ClearGrabStateRoutine
```

#### delayInstruction

A reusable instance of WaitForEndOfFrame.

##### Declaration

```
protected WaitForEndOfFrame delayInstruction
```

#### Grabbed

Emitted when the Interactor starts grabbing a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Grabbed
```

#### Touched

Emitted when the Interactor starts touching a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Touched
```

#### Ungrabbed

Emitted when the Interactor stops grabbing a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Ungrabbed
```

#### Untouched

Emitted when the Interactor stops touching a valid Interactable.

##### Declaration

```
public InteractorFacade.UnityEvent Untouched
```

### Properties

#### ActiveTouchedObject

The currently active touched GameObject.

##### Declaration

```
public virtual GameObject ActiveTouchedObject { get; }
```

#### AvatarContainer

The container of the Interactor avatar components.

##### Declaration

```
public GameObject AvatarContainer { get; protected set; }
```

#### GrabAction

The BooleanAction that will initiate the Interactor grab mechanism.

##### Declaration

```
public BooleanAction GrabAction { get; set; }
```

#### GrabAttachPoint

The point at which the grabbed Interactable will be attached to the Interactor.

##### Declaration

```
public GameObject GrabAttachPoint { get; set; }
```

#### GrabbedObjects

A collection of currently grabbed GameObjects.

##### Declaration

```
public virtual IReadOnlyList<GameObject> GrabbedObjects { get; }
```

#### GrabConfiguration

The linked Grab Internal Setup.

##### Declaration

```
public GrabInteractorConfigurator GrabConfiguration { get; protected set; }
```

#### GrabPrecognition

The time between initiating the [GrabAction] and touching an Interactable to be considered a valid grab.

##### Declaration

```
public float GrabPrecognition { get; set; }
```

#### PrecisionAttachPoint

The point at which the grabbed Interactable will be attached to the Interactor via precision grabbing.

##### Declaration

```
public GameObject PrecisionAttachPoint { get; protected set; }
```

#### TouchConfiguration

The linked Touch Internal Setup.

##### Declaration

```
public TouchInteractorConfigurator TouchConfiguration { get; protected set; }
```

#### TouchedObjects

A collection of currently touched GameObjects.

##### Declaration

```
public virtual IReadOnlyList<GameObject> TouchedObjects { get; }
```

#### VelocityTracker

The [VelocityTracker] to measure the interactors current velocity.

##### Declaration

```
public VelocityTracker VelocityTracker { get; set; }
```

### Methods

#### ClearGrabAction()

Clears [GrabAction].

##### Declaration

```
public virtual void ClearGrabAction()
```

#### ClearGrabAttachPoint()

Clears [GrabAttachPoint].

##### Declaration

```
public virtual void ClearGrabAttachPoint()
```

#### ClearGrabState(InteractableFacade)

Clears the grab state for the given [InteractableFacade].

##### Declaration

```
protected virtual void ClearGrabState(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to clear grab state on. |

#### ClearGrabStateAtEndOfFrame(InteractableFacade)

Clears the grab state at the end of the frame.

##### Declaration

```
protected virtual IEnumerator ClearGrabStateAtEndOfFrame(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | n/a |

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | An Enumerator to manage the running of the Coroutine. |

#### ClearVelocityTracker()

Clears [VelocityTracker].

##### Declaration

```
public virtual void ClearVelocityTracker()
```

#### CreateCollisionPayload(GameObject)

Creates a collision payload for a given Interactable GameObject

##### Declaration

```
protected virtual CollisionNotifier.EventData CreateCollisionPayload(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject that the Interactable is on. |

##### Returns

| Type | Description |
| --- | --- |
| CollisionNotifier.EventData | A collision payload. |

#### Grab(GameObject)

Attempt to attach a GameObject that contains an [InteractableFacade] to this [InteractorFacade] and ungrabs any existing grab.

##### Declaration

```
public virtual void Grab(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject that the Interactable is on. |

#### Grab(GameObject, Boolean)

Attempt to attach a GameObject that contains an [InteractableFacade] to this [InteractorFacade].

##### Declaration

```
public virtual void Grab(GameObject interactable, bool ungrabExistingGrab)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject that the Interactable is on. |
| System.Boolean | ungrabExistingGrab | Whether to ungrab any existing grab. |

#### Grab(SurfaceData)

Attempt to attach an [InteractableFacade] found in the given SurfaceData to this [InteractorFacade] and ungrabs any existing grab.

##### Declaration

```
public virtual void Grab(SurfaceData data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| SurfaceData | data | The collision data containing a valid Interactable. |

#### Grab(SurfaceData, Boolean)

Attempt to attach an [InteractableFacade] found in the given SurfaceData to this [InteractorFacade].

##### Declaration

```
public virtual void Grab(SurfaceData data, bool ungrabExistingGrab)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| SurfaceData | data | The collision data containing a valid Interactable. |
| System.Boolean | ungrabExistingGrab | Whether to ungrab any existing grab. |

#### Grab(InteractableFacade)

Attempt to attach an [InteractableFacade] to this [InteractorFacade] and ungrabs any existing grab.

##### Declaration

```
public virtual void Grab(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to attempt to grab. |

#### Grab(InteractableFacade, Collision, Collider)

Attempt to attach an [InteractableFacade] to this [InteractorFacade] utilizing custom collision data and ungrabs any existing grab.

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

#### Grab(InteractableFacade, Collision, Collider, Boolean)

Attempt to attach an [InteractableFacade] to this [InteractorFacade] utilizing custom collision data.

##### Declaration

```
public virtual void Grab(InteractableFacade interactable, Collision collision, Collider collider, bool ungrabExistingGrab)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to attempt to grab. |
| Collision | collision | Custom collision data. |
| Collider | collider | Custom collider data. |
| System.Boolean | ungrabExistingGrab | Whether to ungrab any existing grab. |

#### Grab(InteractableFacade, Boolean)

Attempt to attach an [InteractableFacade] to this [InteractorFacade].

##### Declaration

```
public virtual void Grab(InteractableFacade interactable, bool ungrabExistingGrab)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to attempt to grab. |
| System.Boolean | ungrabExistingGrab | Whether to ungrab any existing grab. |

#### GrabIgnoreUngrab(GameObject)

Attempt to attach a GameObject that contains an [InteractableFacade] to this [InteractorFacade] and does not ungrab any existing grab.

##### Declaration

```
public virtual void GrabIgnoreUngrab(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject that the Interactable is on. |

#### GrabIgnoreUngrab(SurfaceData)

Attempt to attach an [InteractableFacade] found in the given SurfaceData to this [InteractorFacade] and does not ungrab any existing grab.

##### Declaration

```
public virtual void GrabIgnoreUngrab(SurfaceData data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| SurfaceData | data | The collision data containing a valid Interactable. |

#### GrabIgnoreUngrab(InteractableFacade)

Attempt to attach an [InteractableFacade] to this [InteractorFacade] and does not ungrab any existing grab.

##### Declaration

```
public virtual void GrabIgnoreUngrab(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to attempt to grab. |

#### GrabIgnoreUngrab(InteractableFacade, Collision, Collider)

Attempt to attach an [InteractableFacade] to this [InteractorFacade] utilizing custom collision data and does not ungrab any existing grab.

##### Declaration

```
public virtual void GrabIgnoreUngrab(InteractableFacade interactable, Collision collision, Collider collider)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to attempt to grab. |
| Collision | collision | Custom collision data. |
| Collider | collider | Custom collider data. |

#### NotifyOfGrab(InteractableFacade)

Notifies the Interactor that it is grabbing an Interactable.

##### Declaration

```
public virtual void NotifyOfGrab(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable being grabbed. |

#### NotifyOfTouch(InteractableFacade)

Notifies the Interactor that it is touching an Interactable.

##### Declaration

```
public virtual void NotifyOfTouch(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable being touched. |

#### NotifyOfUngrab(InteractableFacade)

Notifies the Interactor that it is no longer grabbing an Interactable.

##### Declaration

```
public virtual void NotifyOfUngrab(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable being ungrabbed. |

#### NotifyOfUntouch(InteractableFacade)

Notifies the Interactor that it is no longer touching an Interactable.

##### Declaration

```
public virtual void NotifyOfUntouch(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable being untouched. |

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

#### SimulateTouch(GameObject)

Simulates this Interactor touching a given Interactable.

##### Declaration

```
public virtual void SimulateTouch(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject containing the Interactable. |

#### SimulateTouch(InteractableFacade)

Simulates this Interactor touching a given Interactable.

##### Declaration

```
public virtual void SimulateTouch(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable. |

#### SimulateUntouch(GameObject)

Simulates this Interactor untouching a given Interactable.

##### Declaration

```
public virtual void SimulateUntouch(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The GameObject containing the Interactable. |

#### SimulateUntouch(InteractableFacade)

Simulates this Interactor untouching a given Interactable.

##### Declaration

```
public virtual void SimulateUntouch(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable. |

#### SnapAllGrabbedInteractableOrientations()

Snaps the orientation of all grabbed Interactables to this Interactor.

##### Declaration

```
public virtual void SnapAllGrabbedInteractableOrientations()
```

#### SnapGrabbedInteractableOrientation(Int32)

Snaps the orientation of the grabbed Interactable at the given index to this Interactor.

##### Declaration

```
public virtual void SnapGrabbedInteractableOrientation(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index of the grabbed Interactable. |

#### Ungrab()

Attempt to ungrab currently grabbed Interactables to the current Interactor.

##### Declaration

```
public virtual void Ungrab()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorFacade.UnityEvent]: InteractorFacade.UnityEvent.md
[GrabInteractorConfigurator]: GrabInteractorConfigurator.md
[GrabAction]: InteractorFacade.md#GrabAction
[TouchInteractorConfigurator]: TouchInteractorConfigurator.md
[VelocityTracker]: InteractorFacade.md#VelocityTracker
[GrabAction]: InteractorFacade.md#GrabAction
[GrabAttachPoint]: InteractorFacade.md#GrabAttachPoint
[InteractableFacade]: ../Interactables/InteractableFacade.md
[VelocityTracker]: InteractorFacade.md#VelocityTracker
[InteractorFacade]: InteractorFacade.md
[GrabAction]: InteractorFacade.md#GrabAction
[GrabPrecognition]: InteractorFacade.md#GrabPrecognition
[VelocityTracker]: InteractorFacade.md#VelocityTracker
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[ClearGrabStateRoutine]: #ClearGrabStateRoutine
[delayInstruction]: #delayInstruction
[Grabbed]: #Grabbed
[Touched]: #Touched
[Ungrabbed]: #Ungrabbed
[Untouched]: #Untouched
[Properties]: #Properties
[ActiveTouchedObject]: #ActiveTouchedObject
[AvatarContainer]: #AvatarContainer
[GrabAction]: #GrabAction
[GrabAttachPoint]: #GrabAttachPoint
[GrabbedObjects]: #GrabbedObjects
[GrabConfiguration]: #GrabConfiguration
[GrabPrecognition]: #GrabPrecognition
[PrecisionAttachPoint]: #PrecisionAttachPoint
[TouchConfiguration]: #TouchConfiguration
[TouchedObjects]: #TouchedObjects
[VelocityTracker]: #VelocityTracker
[Methods]: #Methods
[ClearGrabAction()]: #ClearGrabAction
[ClearGrabAttachPoint()]: #ClearGrabAttachPoint
[ClearGrabState(InteractableFacade)]: #ClearGrabStateInteractableFacade
[ClearGrabStateAtEndOfFrame(InteractableFacade)]: #ClearGrabStateAtEndOfFrameInteractableFacade
[ClearVelocityTracker()]: #ClearVelocityTracker
[CreateCollisionPayload(GameObject)]: #CreateCollisionPayloadGameObject
[Grab(GameObject)]: #GrabGameObject
[Grab(GameObject, Boolean)]: #GrabGameObject-Boolean
[Grab(SurfaceData)]: #GrabSurfaceData
[Grab(SurfaceData, Boolean)]: #GrabSurfaceData-Boolean
[Grab(InteractableFacade)]: #GrabInteractableFacade
[Grab(InteractableFacade, Collision, Collider)]: #GrabInteractableFacade-Collision-Collider
[Grab(InteractableFacade, Collision, Collider, Boolean)]: #GrabInteractableFacade-Collision-Collider-Boolean
[Grab(InteractableFacade, Boolean)]: #GrabInteractableFacade-Boolean
[GrabIgnoreUngrab(GameObject)]: #GrabIgnoreUngrabGameObject
[GrabIgnoreUngrab(SurfaceData)]: #GrabIgnoreUngrabSurfaceData
[GrabIgnoreUngrab(InteractableFacade)]: #GrabIgnoreUngrabInteractableFacade
[GrabIgnoreUngrab(InteractableFacade, Collision, Collider)]: #GrabIgnoreUngrabInteractableFacade-Collision-Collider
[NotifyOfGrab(InteractableFacade)]: #NotifyOfGrabInteractableFacade
[NotifyOfTouch(InteractableFacade)]: #NotifyOfTouchInteractableFacade
[NotifyOfUngrab(InteractableFacade)]: #NotifyOfUngrabInteractableFacade
[NotifyOfUntouch(InteractableFacade)]: #NotifyOfUntouchInteractableFacade
[OnAfterGrabActionChange()]: #OnAfterGrabActionChange
[OnAfterGrabPrecognitionChange()]: #OnAfterGrabPrecognitionChange
[OnAfterVelocityTrackerChange()]: #OnAfterVelocityTrackerChange
[SimulateTouch(GameObject)]: #SimulateTouchGameObject
[SimulateTouch(InteractableFacade)]: #SimulateTouchInteractableFacade
[SimulateUntouch(GameObject)]: #SimulateUntouchGameObject
[SimulateUntouch(InteractableFacade)]: #SimulateUntouchInteractableFacade
[SnapAllGrabbedInteractableOrientations()]: #SnapAllGrabbedInteractableOrientations
[SnapGrabbedInteractableOrientation(Int32)]: #SnapGrabbedInteractableOrientationInt32
[Ungrab()]: #Ungrab
