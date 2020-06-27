# Class GrabInteractorConfigurator

Sets up the Interactor Prefab grab settings based on the provided user settings.

##### Inheritance

* System.Object
* GrabInteractorConfigurator

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors]

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

##### Field Value

| Type | Description |
| --- | --- |
| ActiveCollisionsContainer.EventData | n/a |

### Properties

#### Facade

The public interface facade.

##### Declaration

```
public InteractorFacade Facade { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractorFacade] | n/a |

#### GrabAction

The BooleanAction that will initiate the Interactor grab mechanism.

##### Declaration

```
public BooleanAction GrabAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| BooleanAction | n/a |

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

#### GrabbedObjectsCollection

The GameObjectObservableSet containing the currently grabbed objects.

##### Declaration

```
public GameObjectObservableList GrabbedObjectsCollection { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### InstantGrabProcessor

The processor for initiating an instant grab.

##### Declaration

```
public GameObject InstantGrabProcessor { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### MinPrecognitionTimer

The minimum timer value for the grab precognition CountdownTimer.

##### Declaration

```
public float MinPrecognitionTimer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Single | n/a |

#### PrecognitionGrabProcessor

The processor for initiating a precognitive grab.

##### Declaration

```
public GameObject PrecognitionGrabProcessor { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### PrecognitionTimer

The CountdownTimer to determine grab precognition.

##### Declaration

```
public CountdownTimer PrecognitionTimer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| CountdownTimer | n/a |

#### StartGrabbingPublisher

The ActiveCollisionPublisher for checking valid start grabbing action.

##### Declaration

```
public ActiveCollisionPublisher StartGrabbingPublisher { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionPublisher | n/a |

#### StopGrabbingPublisher

The ActiveCollisionPublisher for checking valid stop grabbing action.

##### Declaration

```
public ActiveCollisionPublisher StopGrabbingPublisher { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionPublisher | n/a |

#### VelocityTracker

The VelocityTrackerProcessor to measure the interactors current velocity for throwing on release.

##### Declaration

```
public VelocityTrackerProcessor VelocityTracker { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| VelocityTrackerProcessor | n/a |

### Methods

#### ChooseGrabProcessor()

Chooses which grab processing to perform on the grab action.

##### Declaration

```
protected virtual void ChooseGrabProcessor()
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

Attempt to grab an Interactable to the current Interactor utilizing custom collision data.

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

#### OnAfterVelocityTrackerChange()

Called after [VelocityTracker] has been changed.

##### Declaration

```
protected virtual void OnAfterVelocityTrackerChange()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
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

#### Ungrab()

Attempt to ungrab currently grabbed Interactables to the current Interactor.

##### Declaration

```
public virtual void Ungrab()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorFacade]: InteractorFacade.md
[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[VelocityTracker]: GrabInteractorConfigurator.md#VelocityTracker