# Class GrabInteractableReceiver

Handles the way in which a grab event from an Interactor is received and processed by the Interactable.

##### Inheritance

* System.Object
* GrabInteractableReceiver

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Grab.Receiver]

##### Syntax

```
public class GrabInteractableReceiver : MonoBehaviour
```

### Properties

#### GrabConsumer

The ActiveCollisionConsumer that listens for the grab payload.

##### Declaration

```
public ActiveCollisionConsumer GrabConsumer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionConsumer | n/a |

#### GrabType

The mechanism of how to keep the grab action active.

##### Declaration

```
public GrabInteractableReceiver.ActiveType GrabType { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableReceiver.ActiveType] | n/a |

#### GrabValidity

The GameObjectEventProxyEmitter used to determine the grab validity.

##### Declaration

```
public GameObjectEventProxyEmitter GrabValidity { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputActiveCollisionConsumer

The output ActiveCollisionConsumerEventProxyEmitter for the grab action.

##### Declaration

```
public ActiveCollisionConsumerEventProxyEmitter OutputActiveCollisionConsumer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionConsumerEventProxyEmitter | n/a |

#### OutputGrabAction

The output GameObjectEventProxyEmitter for the grab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputGrabAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputUngrabAction

The output GameObjectEventProxyEmitter for the ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputUngrabAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputUngrabOnUntouchAction

The output GameObjectEventProxyEmitter for the ungrab on untouch action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputUngrabOnUntouchAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### StartStateGrab

The GameObject containing the logic for starting HoldTillRelease grabbing.

##### Declaration

```
public GameObject StartStateGrab { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### StopStateGrab

The GameObject containing the logic for ending HoldTillRelease grabbing.

##### Declaration

```
public GameObject StopStateGrab { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### ToggleGrab

The GameObject containing the logic for starting and ending Toggle grabbing.

##### Declaration

```
public GameObject ToggleGrab { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### ToggleList

The GameObjectObservableSet containing the logic for starting and ending Toggle grabbing.

##### Declaration

```
public GameObjectObservableList ToggleList { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### UngrabConsumer

The ActiveCollisionConsumer that listens for the ungrab payload.

##### Declaration

```
public ActiveCollisionConsumer UngrabConsumer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionConsumer | n/a |

### Methods

#### ConfigureConsumerContainers(GameObject)

Sets the consumer containers to the current active container.

##### Declaration

```
public virtual void ConfigureConsumerContainers(GameObject container)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | container | The container for the consumer. |

#### ConfigureGrabType()

Configures the Grab Type to be used.

##### Declaration

```
public virtual void ConfigureGrabType()
```

#### OnAfterGrabTypeChange()

Called after [GrabType] has been changed.

##### Declaration

```
protected virtual void OnAfterGrabTypeChange()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

[Tilia.Interactions.Interactables.Interactables.Grab.Receiver]: README.md
[GrabInteractableReceiver.ActiveType]: GrabInteractableReceiver.ActiveType.md
[GrabType]: GrabInteractableReceiver.md#GrabType