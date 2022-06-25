# Class GrabInteractorConfigurator

Sets up the Interactor Prefab grab settings based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [activeCollisionsEventData]
  * [simulateTouchResetRoutine]
* [Properties]
  * [Facade]
  * [GrabAction]
  * [GrabbedObjects]
  * [GrabbedObjectsCollection]
  * [InstantGrabProcessor]
  * [IsGrabbingAction]
  * [MinPrecognitionTimer]
  * [PrecognitionGrabProcessor]
  * [PrecognitionTimer]
  * [StartGrabbingPublisher]
  * [StopGrabbingPublisher]
  * [TouchBeforeForceGrab]
  * [VelocityTracker]
* [Methods]
  * [CancelSimulateTouchResetRoutine()]
  * [ChooseGrabProcessor()]
  * [ClearVelocityTracker()]
  * [ConfigureGrabAction()]
  * [ConfigureGrabPrecognition()]
  * [ConfigureVelocityTrackers()]
  * [CreateActiveCollisionsEventData(GameObject, Collision, Collider)]
  * [Grab(InteractableFacade, Collision, Collider)]
  * [Grab(InteractableFacade, Collision, Collider, Boolean)]
  * [GrabIgnoreUngrab(InteractableFacade, Collision, Collider)]
  * [OnAfterVelocityTrackerChange()]
  * [OnDisable()]
  * [OnEnable()]
  * [PrecognitionGrabForRegisteredConsumers()]
  * [ProcessGrabAction(ActiveCollisionPublisher, Boolean)]
  * [ResetSimulateTouchState(InteractableFacade, Boolean, Boolean)]
  * [Ungrab()]

## Details

##### Inheritance

* System.Object
* GrabInteractorConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class GrabInteractorConfigurator : MonoBehaviour
```

### Fields

#### activeCollisionsEventData

A reusable instance of event data.

##### Declaration

```
protected readonly ActiveCollisionsContainer.EventData activeCollisionsEventData
```

#### simulateTouchResetRoutine

Manages the reset simulate touch logic.

##### Declaration

```
protected Coroutine simulateTouchResetRoutine
```

### Properties

#### Facade

The public interface facade.

##### Declaration

```
public InteractorFacade Facade { get; protected set; }
```

#### GrabAction

The BooleanAction that will initiate the Interactor grab mechanism.

##### Declaration

```
public BooleanAction GrabAction { get; protected set; }
```

#### GrabbedObjects

A collection of currently grabbed GameObjects.

##### Declaration

```
public virtual IReadOnlyList<GameObject> GrabbedObjects { get; }
```

#### GrabbedObjectsCollection

The GameObjectObservableSet containing the currently grabbed objects.

##### Declaration

```
public GameObjectObservableList GrabbedObjectsCollection { get; protected set; }
```

#### InstantGrabProcessor

The processor for initiating an instant grab.

##### Declaration

```
public GameObject InstantGrabProcessor { get; protected set; }
```

#### IsGrabbingAction

A BooleanAction for holding the state of whether the Interactor is grabbing something.

##### Declaration

```
public BooleanAction IsGrabbingAction { get; protected set; }
```

#### MinPrecognitionTimer

The minimum timer value for the grab precognition CountdownTimer.

##### Declaration

```
public float MinPrecognitionTimer { get; protected set; }
```

#### PrecognitionGrabProcessor

The processor for initiating a precognitive grab.

##### Declaration

```
public GameObject PrecognitionGrabProcessor { get; protected set; }
```

#### PrecognitionTimer

The CountdownTimer to determine grab precognition.

##### Declaration

```
public CountdownTimer PrecognitionTimer { get; protected set; }
```

#### StartGrabbingPublisher

The ActiveCollisionPublisher for checking valid start grabbing action.

##### Declaration

```
public ActiveCollisionPublisher StartGrabbingPublisher { get; protected set; }
```

#### StopGrabbingPublisher

The ActiveCollisionPublisher for checking valid stop grabbing action.

##### Declaration

```
public ActiveCollisionPublisher StopGrabbingPublisher { get; protected set; }
```

#### TouchBeforeForceGrab

Whether to simulate a touch before force grabbing.

##### Declaration

```
public bool TouchBeforeForceGrab { get; set; }
```

#### VelocityTracker

The VelocityTrackerProcessor to measure the interactors current velocity for throwing on release.

##### Declaration

```
public VelocityTrackerProcessor VelocityTracker { get; protected set; }
```

### Methods

#### CancelSimulateTouchResetRoutine()

Cancels the [simulateTouchResetRoutine] coroutine.

##### Declaration

```
protected virtual void CancelSimulateTouchResetRoutine()
```

#### ChooseGrabProcessor()

Chooses which grab processing to perform on the grab action.

##### Declaration

```
protected virtual void ChooseGrabProcessor()
```

#### ClearVelocityTracker()

Clears [VelocityTracker].

##### Declaration

```
public virtual void ClearVelocityTracker()
```

#### ConfigureGrabAction()

Configures the action used to control grabbing.

##### Declaration

```
public virtual void ConfigureGrabAction()
```

#### ConfigureGrabPrecognition()

Configures the CountdownTimer components for grab precognition.

##### Declaration

```
public virtual void ConfigureGrabPrecognition()
```

#### ConfigureVelocityTrackers()

Configures the velocity tracker used for grabbing.

##### Declaration

```
public virtual void ConfigureVelocityTrackers()
```

#### CreateActiveCollisionsEventData(GameObject, Collision, Collider)

Creates Active Collision data based on the given parameters.

##### Declaration

```
protected virtual ActiveCollisionsContainer.EventData CreateActiveCollisionsEventData(GameObject forwardSource, Collision collision = null, Collider collider = null)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | forwardSource | The source of the GameObject forwarding the collision data. |
| Collision | collision | The data on the point of the collision for precision grabbing. |
| Collider | collider | The collider that has been collided with. |

##### Returns

| Type | Description |
| --- | --- |
| ActiveCollisionsContainer.EventData | n/a |

#### Grab(InteractableFacade, Collision, Collider)

Attempt to grab an Interactable to the current Interactor utilizing custom collision data and ungrabs any existing grab.

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

Attempt to grab an Interactable to the current Interactor utilizing custom collision data.

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

#### GrabIgnoreUngrab(InteractableFacade, Collision, Collider)

Attempt to grab an Interactable to the current Interactor utilizing custom collision data and does not ungrab any existing grab..

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

#### OnAfterVelocityTrackerChange()

Called after [VelocityTracker] has been changed.

##### Declaration

```
protected virtual void OnAfterVelocityTrackerChange()
```

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### PrecognitionGrabForRegisteredConsumers()

Attempts to automatically emit precognition grab if there are registered consumers.

##### Declaration

```
public virtual void PrecognitionGrabForRegisteredConsumers()
```

#### ProcessGrabAction(ActiveCollisionPublisher, Boolean)

Processes the given collision data into a grab action based on the given state.

##### Declaration

```
protected virtual void ProcessGrabAction(ActiveCollisionPublisher publisher, bool actionState)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| ActiveCollisionPublisher | publisher | The collision data to process. |
| System.Boolean | actionState | The grab state to check against. |

#### ResetSimulateTouchState(InteractableFacade, Boolean, Boolean)

Resets the state set by the simulate touch logic.

##### Declaration

```
protected virtual IEnumerator ResetSimulateTouchState(InteractableFacade interactable, bool collisionNotifierEnabled, bool processCollisionsWhenDisabled)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The interactable to reset on. |
| System.Boolean | collisionNotifierEnabled | The value to set the CollisionNotifier.enabled value to. |
| System.Boolean | processCollisionsWhenDisabled | The value to set the CollisionNotifier.ProcessCollisionsWhenDisabled value to. |

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | An enumerator for controlling the coroutine. |

#### Ungrab()

Attempt to ungrab currently grabbed Interactables to the current Interactor.

##### Declaration

```
public virtual void Ungrab()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorFacade]: InteractorFacade.md
[simulateTouchResetRoutine]: GrabInteractorConfigurator.md#simulateTouchResetRoutine
[VelocityTracker]: GrabInteractorConfigurator.md#VelocityTracker
[InteractableFacade]: ../Interactables/InteractableFacade.md
[VelocityTracker]: GrabInteractorConfigurator.md#VelocityTracker
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[activeCollisionsEventData]: #activeCollisionsEventData
[simulateTouchResetRoutine]: #simulateTouchResetRoutine
[Properties]: #Properties
[Facade]: #Facade
[GrabAction]: #GrabAction
[GrabbedObjects]: #GrabbedObjects
[GrabbedObjectsCollection]: #GrabbedObjectsCollection
[InstantGrabProcessor]: #InstantGrabProcessor
[IsGrabbingAction]: #IsGrabbingAction
[MinPrecognitionTimer]: #MinPrecognitionTimer
[PrecognitionGrabProcessor]: #PrecognitionGrabProcessor
[PrecognitionTimer]: #PrecognitionTimer
[StartGrabbingPublisher]: #StartGrabbingPublisher
[StopGrabbingPublisher]: #StopGrabbingPublisher
[TouchBeforeForceGrab]: #TouchBeforeForceGrab
[VelocityTracker]: #VelocityTracker
[Methods]: #Methods
[CancelSimulateTouchResetRoutine()]: #CancelSimulateTouchResetRoutine
[ChooseGrabProcessor()]: #ChooseGrabProcessor
[ClearVelocityTracker()]: #ClearVelocityTracker
[ConfigureGrabAction()]: #ConfigureGrabAction
[ConfigureGrabPrecognition()]: #ConfigureGrabPrecognition
[ConfigureVelocityTrackers()]: #ConfigureVelocityTrackers
[CreateActiveCollisionsEventData(GameObject, Collision, Collider)]: #CreateActiveCollisionsEventDataGameObject-Collision-Collider
[Grab(InteractableFacade, Collision, Collider)]: #GrabInteractableFacade-Collision-Collider
[Grab(InteractableFacade, Collision, Collider, Boolean)]: #GrabInteractableFacade-Collision-Collider-Boolean
[GrabIgnoreUngrab(InteractableFacade, Collision, Collider)]: #GrabIgnoreUngrabInteractableFacade-Collision-Collider
[OnAfterVelocityTrackerChange()]: #OnAfterVelocityTrackerChange
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[PrecognitionGrabForRegisteredConsumers()]: #PrecognitionGrabForRegisteredConsumers
[ProcessGrabAction(ActiveCollisionPublisher, Boolean)]: #ProcessGrabActionActiveCollisionPublisher-Boolean
[ResetSimulateTouchState(InteractableFacade, Boolean, Boolean)]: #ResetSimulateTouchStateInteractableFacade-Boolean-Boolean
[Ungrab()]: #Ungrab
