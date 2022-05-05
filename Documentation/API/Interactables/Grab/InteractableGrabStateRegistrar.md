# Class InteractableGrabStateRegistrar

Registers listeners to the initial grab and final ungrab states of an [InteractableFacade] and emits the [InteractableFacade] as the event payload.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [Grabbed]
  * [KinematicStateChangedOnGrabbed]
  * [KinematicStateChangedOnUngrabbed]
  * [Ungrabbed]
  * [unsubscribeGrabActions]
  * [unsubscribeUngrabActions]
* [Properties]
  * [UnsubscribeOnDisable]
* [Methods]
  * [InteractableGrabbed(InteractableFacade)]
  * [InteractableGrabbedKinematicChange(InteractableFacade)]
  * [InteractableUngrabbed(InteractableFacade)]
  * [InteractableUngrabbedKinematicChange(InteractableFacade)]
  * [OnDisable()]
  * [RegisterGrabbed(GameObject)]
  * [RegisterGrabbed(InteractableFacade)]
  * [RegisterUngrabbed(GameObject)]
  * [RegisterUngrabbed(InteractableFacade)]
  * [UnregisterAll()]
  * [UnregisterAllGrabbed()]
  * [UnregisterAllUngrabbed()]
  * [UnregisterGrabbed(GameObject)]
  * [UnregisterGrabbed(InteractableFacade)]
  * [UnregisterUngrabbed(GameObject)]
  * [UnregisterUngrabbed(InteractableFacade)]

## Details

##### Inheritance

* System.Object
* InteractableGrabStateRegistrar

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab]

##### Syntax

```
public class InteractableGrabStateRegistrar : MonoBehaviour
```

### Fields

#### Grabbed

##### Declaration

```
public InteractableGrabStateRegistrar.UnityEvent Grabbed
```

#### KinematicStateChangedOnGrabbed

##### Declaration

```
public InteractableGrabStateRegistrar.RigidbodyUnityEvent KinematicStateChangedOnGrabbed
```

#### KinematicStateChangedOnUngrabbed

Emitted when the [InteractableFacade] is about to change the kinematic state of its Rigidbody when ungrabbed.

##### Declaration

```
public InteractableGrabStateRegistrar.RigidbodyUnityEvent KinematicStateChangedOnUngrabbed
```

#### Ungrabbed

Emitted when the [InteractableFacade] is ungrabbed.

##### Declaration

```
public InteractableGrabStateRegistrar.UnityEvent Ungrabbed
```

#### unsubscribeGrabActions

Actions that unsubscribe the added grab event listeners.

##### Declaration

```
protected readonly Dictionary<InteractableFacade, Action> unsubscribeGrabActions
```

#### unsubscribeUngrabActions

Actions that unsubscribe the added ungrab event listeners.

##### Declaration

```
protected readonly Dictionary<InteractableFacade, Action> unsubscribeUngrabActions
```

### Properties

#### UnsubscribeOnDisable

Determines whether to unsubscribe all registered listeners when the component is disabled.

##### Declaration

```
public bool UnsubscribeOnDisable { get; set; }
```

### Methods

#### InteractableGrabbed(InteractableFacade)

Processes the grabbed event on the given Interactable.

##### Declaration

```
protected virtual void InteractableGrabbed(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to process the grab event for. |

#### InteractableGrabbedKinematicChange(InteractableFacade)

Processes the kinematic state change on the grabbed event on the given Interactable.

##### Declaration

```
protected virtual void InteractableGrabbedKinematicChange(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to process the grab event for. |

#### InteractableUngrabbed(InteractableFacade)

Processes the ungrabbed event on the given Interactable.

##### Declaration

```
protected virtual void InteractableUngrabbed(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to process the ungrab event for. |

#### InteractableUngrabbedKinematicChange(InteractableFacade)

Processes the kinematic state change on the ungrabbed event on the given Interactable.

##### Declaration

```
protected virtual void InteractableUngrabbedKinematicChange(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The Interactable to process the grab event for. |

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### RegisterGrabbed(GameObject)

Registers a listener on the given GameObject's [InteractableFacade] Grabbed event.

##### Declaration

```
public virtual void RegisterGrabbed(GameObject grabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | grabbable | The GameObject to get the [InteractableFacade] from to register the grab event on. |

#### RegisterGrabbed(InteractableFacade)

Registers a listener on the given [InteractableFacade] Grabbed event.

##### Declaration

```
public virtual void RegisterGrabbed(InteractableFacade grabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | grabbable | The interactable to register the grab event on. |

#### RegisterUngrabbed(GameObject)

Registers a listener on the given GameObject's [InteractableFacade] Ungrabbed event.

##### Declaration

```
public virtual void RegisterUngrabbed(GameObject ungrabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | ungrabbable | The GameObject to get the [InteractableFacade] from to register the ungrab event on. |

#### RegisterUngrabbed(InteractableFacade)

Registers a listener on the given [InteractableFacade] Ungrabbed event.

##### Declaration

```
public virtual void RegisterUngrabbed(InteractableFacade ungrabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | ungrabbable | The interactable to register the ungrab event on. |

#### UnregisterAll()

Unregisters all listeners for all events.

##### Declaration

```
public virtual void UnregisterAll()
```

#### UnregisterAllGrabbed()

Unregisters all listeners for all grabbed events.

##### Declaration

```
public virtual void UnregisterAllGrabbed()
```

#### UnregisterAllUngrabbed()

Unregisters all listeners for all ungrabbed events.

##### Declaration

```
public virtual void UnregisterAllUngrabbed()
```

#### UnregisterGrabbed(GameObject)

Unregisters a listener from the given GameObject's [InteractableFacade] Grabbed event.

##### Declaration

```
public virtual void UnregisterGrabbed(GameObject grabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | grabbable | The GameObject to get the [InteractableFacade] from to unregister the grab event from. |

#### UnregisterGrabbed(InteractableFacade)

Unregisters a listener from the given [InteractableFacade] Grabbed event.

##### Declaration

```
public virtual void UnregisterGrabbed(InteractableFacade grabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | grabbable | The interactable to unregister the grab event from. |

#### UnregisterUngrabbed(GameObject)

Unregisters a listener from the given GameObject's [InteractableFacade] Ungrabbed event.

##### Declaration

```
public virtual void UnregisterUngrabbed(GameObject ungrabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | ungrabbable | The GameObject to get the [InteractableFacade] from to unregister the ungrab event from. |

#### UnregisterUngrabbed(InteractableFacade)

Unregisters a listener from the given [InteractableFacade] Ungrabbed event.

##### Declaration

```
public virtual void UnregisterUngrabbed(InteractableFacade ungrabbable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | ungrabbable | The interactable to unregister the ungrab event from. |

[InteractableFacade]: ../../Interactables/InteractableFacade.md
[Tilia.Interactions.Interactables.Interactables.Grab]: README.md
[InteractableGrabStateRegistrar.RigidbodyUnityEvent]: InteractableGrabStateRegistrar.RigidbodyUnityEvent.md
[InteractableGrabStateRegistrar.UnityEvent]: InteractableGrabStateRegistrar.UnityEvent.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[Grabbed]: #Grabbed
[KinematicStateChangedOnGrabbed]: #KinematicStateChangedOnGrabbed
[KinematicStateChangedOnUngrabbed]: #KinematicStateChangedOnUngrabbed
[Ungrabbed]: #Ungrabbed
[unsubscribeGrabActions]: #unsubscribeGrabActions
[unsubscribeUngrabActions]: #unsubscribeUngrabActions
[Properties]: #Properties
[UnsubscribeOnDisable]: #UnsubscribeOnDisable
[Methods]: #Methods
[InteractableGrabbed(InteractableFacade)]: #InteractableGrabbedInteractableFacade
[InteractableGrabbedKinematicChange(InteractableFacade)]: #InteractableGrabbedKinematicChangeInteractableFacade
[InteractableUngrabbed(InteractableFacade)]: #InteractableUngrabbedInteractableFacade
[InteractableUngrabbedKinematicChange(InteractableFacade)]: #InteractableUngrabbedKinematicChangeInteractableFacade
[OnDisable()]: #OnDisable
[RegisterGrabbed(GameObject)]: #RegisterGrabbedGameObject
[RegisterGrabbed(InteractableFacade)]: #RegisterGrabbedInteractableFacade
[RegisterUngrabbed(GameObject)]: #RegisterUngrabbedGameObject
[RegisterUngrabbed(InteractableFacade)]: #RegisterUngrabbedInteractableFacade
[UnregisterAll()]: #UnregisterAll
[UnregisterAllGrabbed()]: #UnregisterAllGrabbed
[UnregisterAllUngrabbed()]: #UnregisterAllUngrabbed
[UnregisterGrabbed(GameObject)]: #UnregisterGrabbedGameObject
[UnregisterGrabbed(InteractableFacade)]: #UnregisterGrabbedInteractableFacade
[UnregisterUngrabbed(GameObject)]: #UnregisterUngrabbedGameObject
[UnregisterUngrabbed(InteractableFacade)]: #UnregisterUngrabbedInteractableFacade
