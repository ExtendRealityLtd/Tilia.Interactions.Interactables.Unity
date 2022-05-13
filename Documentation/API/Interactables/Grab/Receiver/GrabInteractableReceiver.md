# Class GrabInteractableReceiver

Handles the way in which a grab event from an Interactor is received and processed by the Interactable.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [GrabConsumer]
  * [GrabType]
  * [GrabValidity]
  * [OutputActiveCollisionConsumer]
  * [OutputGrabAction]
  * [OutputUngrabAction]
  * [OutputUngrabOnUntouchAction]
  * [StartStateGrab]
  * [StopStateGrab]
  * [ToggleGrab]
  * [ToggleList]
  * [UngrabConsumer]
* [Methods]
  * [ConfigureConsumerContainers(GameObject)]
  * [ConfigureGrabType()]
  * [OnAfterGrabTypeChange()]
  * [OnEnable()]
  * [SetGrabType(Int32)]

## Details

##### Inheritance

* System.Object
* GrabInteractableReceiver

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab.Receiver]

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

#### GrabType

The mechanism of how to keep the grab action active.

##### Declaration

```
public GrabInteractableReceiver.ActiveType GrabType { get; set; }
```

#### GrabValidity

The GameObjectEventProxyEmitter used to determine the grab validity.

##### Declaration

```
public GameObjectEventProxyEmitter GrabValidity { get; set; }
```

#### OutputActiveCollisionConsumer

The output ActiveCollisionConsumerEventProxyEmitter for the grab action.

##### Declaration

```
public ActiveCollisionConsumerEventProxyEmitter OutputActiveCollisionConsumer { get; protected set; }
```

#### OutputGrabAction

The output GameObjectEventProxyEmitter for the grab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputGrabAction { get; protected set; }
```

#### OutputUngrabAction

The output GameObjectEventProxyEmitter for the ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputUngrabAction { get; protected set; }
```

#### OutputUngrabOnUntouchAction

The output GameObjectEventProxyEmitter for the ungrab on untouch action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputUngrabOnUntouchAction { get; protected set; }
```

#### StartStateGrab

The GameObject containing the logic for starting HoldTillRelease grabbing.

##### Declaration

```
public GameObject StartStateGrab { get; protected set; }
```

#### StopStateGrab

The GameObject containing the logic for ending HoldTillRelease grabbing.

##### Declaration

```
public GameObject StopStateGrab { get; protected set; }
```

#### ToggleGrab

The GameObject containing the logic for starting and ending Toggle grabbing.

##### Declaration

```
public GameObject ToggleGrab { get; protected set; }
```

#### ToggleList

The GameObjectObservableSet containing the logic for starting and ending Toggle grabbing.

##### Declaration

```
public GameObjectObservableList ToggleList { get; protected set; }
```

#### UngrabConsumer

The ActiveCollisionConsumer that listens for the ungrab payload.

##### Declaration

```
public ActiveCollisionConsumer UngrabConsumer { get; protected set; }
```

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

[Tilia.Interactions.Interactables.Interactables.Grab.Receiver]: README.md
[GrabType]: GrabInteractableReceiver.md#GrabType
[GrabType]: GrabInteractableReceiver.md#GrabType
[GrabInteractableReceiver.ActiveType]: GrabInteractableReceiver.ActiveType.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[GrabConsumer]: #GrabConsumer
[GrabType]: #GrabType
[GrabValidity]: #GrabValidity
[OutputActiveCollisionConsumer]: #OutputActiveCollisionConsumer
[OutputGrabAction]: #OutputGrabAction
[OutputUngrabAction]: #OutputUngrabAction
[OutputUngrabOnUntouchAction]: #OutputUngrabOnUntouchAction
[StartStateGrab]: #StartStateGrab
[StopStateGrab]: #StopStateGrab
[ToggleGrab]: #ToggleGrab
[ToggleList]: #ToggleList
[UngrabConsumer]: #UngrabConsumer
[Methods]: #Methods
[ConfigureConsumerContainers(GameObject)]: #ConfigureConsumerContainersGameObject
[ConfigureGrabType()]: #ConfigureGrabType
[OnAfterGrabTypeChange()]: #OnAfterGrabTypeChange
[OnEnable()]: #OnEnable
[SetGrabType(Int32)]: #SetGrabTypeInt32
