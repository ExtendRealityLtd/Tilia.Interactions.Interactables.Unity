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
  * [Colliders]
  * [Configuration]
  * [GrabbingInteractors]
  * [GrabEnabled]
  * [GrabProviderIndex]
  * [GrabType]
  * [InteractableRigidbody]
  * [IsGrabbed]
  * [IsGrabTypeToggle]
  * [IsTouched]
  * [MeshContainer]
  * [Meshes]
  * [PrimaryGrabEnabled]
  * [SecondaryGrabEnabled]
  * [TouchEnabled]
  * [TouchingInteractors]
  * [ValidInteractionTypes]
* [Methods]
  * [DisableGrab()]
  * [DisableGrabReceiver()]
  * [DisablePrimaryGrabAction()]
  * [DisableSecondaryGrabAction()]
  * [DisableTouch()]
  * [DoGrabAtEndOfFrame(InteractorFacade)]
  * [DoGrabIgnoreUngrabAtEndOfFrame(InteractorFacade)]
  * [DoUngrabAtEndOfFrame(Int32)]
  * [DoUngrabAtEndOfFrame(InteractorFacade)]
  * [EnableGrab()]
  * [EnableGrabReceiver()]
  * [EnablePrimaryGrabAction()]
  * [EnableSecondaryGrabAction()]
  * [EnableTouch()]
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
  * [OnAfterValidInteractionTypesChange()]
  * [OnEnable()]
  * [SetGrabType(Int32)]
  * [SetValidInteractionTypes()]
  * [SnapFollowOrientation()]
  * [Ungrab(GameObject)]
  * [Ungrab(Int32)]
  * [Ungrab(InteractorFacade)]
  * [UngrabAll()]
  * [UngrabAllAtEndOfFrame()]
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
[Obsolete("EndOfFrame methods are now obsolete.")]
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

#### Colliders

Returns a Collider collection of all the [MeshContainer] child colliders.

##### Declaration

```
public virtual Collider[] Colliders { get; }
```

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
public virtual IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

#### GrabEnabled

Whether the grab functionality is enabled.

##### Declaration

```
public virtual bool GrabEnabled { get; }
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

#### InteractableRigidbody

The Rigidbody attached to the Interactable.

##### Declaration

```
public virtual Rigidbody InteractableRigidbody { get; }
```

#### IsGrabbed

Whether the Interactable is currently being grabbed by any valid Interactor.

##### Declaration

```
public virtual bool IsGrabbed { get; }
```

#### IsGrabTypeToggle

Determines if the grab type is set to toggle.

##### Declaration

```
public virtual bool IsGrabTypeToggle { get; }
```

#### IsTouched

Whether the Interactable is currently being touched by any valid Interactor.

##### Declaration

```
public virtual bool IsTouched { get; }
```

#### MeshContainer

The mesh container.

##### Declaration

```
public virtual GameObject MeshContainer { get; }
```

#### Meshes

Returns a MeshRenderer collection of all the [MeshContainer] child meshes.

##### Declaration

```
public virtual MeshRenderer[] Meshes { get; }
```

#### PrimaryGrabEnabled

Whether the primary grab action functionality is enabled.

##### Declaration

```
public virtual bool PrimaryGrabEnabled { get; }
```

#### SecondaryGrabEnabled

Whether the secondary grab action functionality is enabled.

##### Declaration

```
public virtual bool SecondaryGrabEnabled { get; }
```

#### TouchEnabled

Whether the touch functionality is enabled.

##### Declaration

```
public virtual bool TouchEnabled { get; }
```

#### TouchingInteractors

A collection of Interactors that are currently touching the Interactable.

##### Declaration

```
public virtual IReadOnlyList<InteractorFacade> TouchingInteractors { get; }
```

#### ValidInteractionTypes

The types of interaction that are valid on the Interactable.

##### Declaration

```
public InteractableFacade.InteractionTypes ValidInteractionTypes { get; set; }
```

### Methods

#### DisableGrab()

Disables the grab logic.

##### Declaration

```
public virtual void DisableGrab()
```

#### DisableGrabReceiver()

Disables the grab receiver logic.

##### Declaration

```
public virtual void DisableGrabReceiver()
```

#### DisablePrimaryGrabAction()

Disables the primary grab action logic.

##### Declaration

```
public virtual void DisablePrimaryGrabAction()
```

#### DisableSecondaryGrabAction()

Disables the secondary grab action logic.

##### Declaration

```
public virtual void DisableSecondaryGrabAction()
```

#### DisableTouch()

Disables the touch logic.

##### Declaration

```
public virtual void DisableTouch()
```

#### DoGrabAtEndOfFrame(InteractorFacade)

Attempt to grab the Interactable to the given Interactor and ungrabs any existing grabbed Interactable at the end of the current frame.

##### Declaration

```
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Grab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.GrabIgnoreUngrab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Ungrab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Ungrab()` instead.")]
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

#### EnableGrab()

Enables the grab logic.

##### Declaration

```
public virtual void EnableGrab()
```

#### EnableGrabReceiver()

Enables the grab receiver logic.

##### Declaration

```
public virtual void EnableGrabReceiver()
```

#### EnablePrimaryGrabAction()

Enables the primary grab action logic.

##### Declaration

```
public virtual void EnablePrimaryGrabAction()
```

#### EnableSecondaryGrabAction()

Enables the secondary grab action logic.

##### Declaration

```
public virtual void EnableSecondaryGrabAction()
```

#### EnableTouch()

Enables the touch logic.

##### Declaration

```
public virtual void EnableTouch()
```

#### GetInteractorFromGameObject(GameObject)

Gets the [InteractorFacade] from the given GameObject or if not found searches for one on all descendants then ancestors.

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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Grab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Grab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.GrabIgnoreUngrab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.GrabIgnoreUngrab()` instead.")]
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

#### OnAfterValidInteractionTypesChange()

Called after [ValidInteractionTypes] has been changed.

##### Declaration

```
protected virtual void OnAfterValidInteractionTypesChange()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### SetGrabType(Int32)

Sets the [GrabType].

##### Declaration

```
public virtual void SetGrabType(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index of the [GrabInteractableReceiver.ActiveType]. |

#### SetValidInteractionTypes()

Activates or Deactivates the interaction types based on the selected [ValidInteractionTypes].

##### Declaration

```
protected virtual void SetValidInteractionTypes()
```

#### SnapFollowOrientation()

Snaps the follow on the primary and secondary action if they are GrabInteractableFollowAction type.

##### Declaration

```
public virtual void SnapFollowOrientation()
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

#### UngrabAll()

Attempts to ungrab the Interactable from all Interactors.

##### Declaration

```
public virtual void UngrabAll()
```

#### UngrabAllAtEndOfFrame()

Attempts to ungrab the Interactable from all Interactors at the end of the current frame.

##### Declaration

```
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.UngrabAll()` instead.")]
public virtual void UngrabAllAtEndOfFrame()
```

#### UngrabAtEndOfFrame(GameObject)

Attempt to ungrab the Interactable to the given GameObject that contains an Interactor at the end of the current frame.

##### Declaration

```
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Ungrab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Ungrab()` instead.")]
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
[Obsolete("Use `WaitForEndOfFrameYieldEmitter.Yielded() -> InteractableFacade.Ungrab()` instead.")]
public virtual void UngrabAtEndOfFrame(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to ungrab from. |

[Tilia.Interactions.Interactables.Interactables]: README.md
[InteractableFacade.UnityEvent]: InteractableFacade.UnityEvent.md
[MeshContainer]: InteractableFacade.md#MeshContainer
[InteractableConfigurator]: InteractableConfigurator.md
[InteractorFacade]: ../Interactors/InteractorFacade.md
[GrabInteractableReceiver.ActiveType]: Grab/Receiver/GrabInteractableReceiver.ActiveType.md
[MeshContainer]: InteractableFacade.md#MeshContainer
[InteractableFacade.InteractionTypes]: InteractableFacade.InteractionTypes.md
[GrabProviderIndex]: InteractableFacade.md#GrabProviderIndex
[GrabType]: InteractableFacade.md#GrabType
[ValidInteractionTypes]: InteractableFacade.md#ValidInteractionTypes
[GrabType]: InteractableFacade.md#GrabType
[ValidInteractionTypes]: InteractableFacade.md#ValidInteractionTypes
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
[Colliders]: #Colliders
[Configuration]: #Configuration
[GrabbingInteractors]: #GrabbingInteractors
[GrabEnabled]: #GrabEnabled
[GrabProviderIndex]: #GrabProviderIndex
[GrabType]: #GrabType
[InteractableRigidbody]: #InteractableRigidbody
[IsGrabbed]: #IsGrabbed
[IsGrabTypeToggle]: #IsGrabTypeToggle
[IsTouched]: #IsTouched
[MeshContainer]: #MeshContainer
[Meshes]: #Meshes
[PrimaryGrabEnabled]: #PrimaryGrabEnabled
[SecondaryGrabEnabled]: #SecondaryGrabEnabled
[TouchEnabled]: #TouchEnabled
[TouchingInteractors]: #TouchingInteractors
[ValidInteractionTypes]: #ValidInteractionTypes
[Methods]: #Methods
[DisableGrab()]: #DisableGrab
[DisableGrabReceiver()]: #DisableGrabReceiver
[DisablePrimaryGrabAction()]: #DisablePrimaryGrabAction
[DisableSecondaryGrabAction()]: #DisableSecondaryGrabAction
[DisableTouch()]: #DisableTouch
[DoGrabAtEndOfFrame(InteractorFacade)]: #DoGrabAtEndOfFrameInteractorFacade
[DoGrabIgnoreUngrabAtEndOfFrame(InteractorFacade)]: #DoGrabIgnoreUngrabAtEndOfFrameInteractorFacade
[DoUngrabAtEndOfFrame(Int32)]: #DoUngrabAtEndOfFrameInt32
[DoUngrabAtEndOfFrame(InteractorFacade)]: #DoUngrabAtEndOfFrameInteractorFacade
[EnableGrab()]: #EnableGrab
[EnableGrabReceiver()]: #EnableGrabReceiver
[EnablePrimaryGrabAction()]: #EnablePrimaryGrabAction
[EnableSecondaryGrabAction()]: #EnableSecondaryGrabAction
[EnableTouch()]: #EnableTouch
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
[OnAfterValidInteractionTypesChange()]: #OnAfterValidInteractionTypesChange
[OnEnable()]: #OnEnable
[SetGrabType(Int32)]: #SetGrabTypeInt32
[SetValidInteractionTypes()]: #SetValidInteractionTypes
[SnapFollowOrientation()]: #SnapFollowOrientation
[Ungrab(GameObject)]: #UngrabGameObject
[Ungrab(Int32)]: #UngrabInt32
[Ungrab(InteractorFacade)]: #UngrabInteractorFacade
[UngrabAll()]: #UngrabAll
[UngrabAllAtEndOfFrame()]: #UngrabAllAtEndOfFrame
[UngrabAtEndOfFrame(GameObject)]: #UngrabAtEndOfFrameGameObject
[UngrabAtEndOfFrame(Int32)]: #UngrabAtEndOfFrameInt32
[UngrabAtEndOfFrame(InteractorFacade)]: #UngrabAtEndOfFrameInteractorFacade
