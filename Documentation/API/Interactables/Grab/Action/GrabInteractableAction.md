# Class GrabInteractableAction

Describes an action to perform when a Grab Process is executed.

##### Inheritance

* System.Object
* GrabInteractableAction
* [GrabInteractableControlDirectionAction]
* [GrabInteractableFollowAction]
* [GrabInteractableScaleAction]
* [GrabInteractableSwapAction]

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Grab.Action]

##### Syntax

```
public class GrabInteractableAction : MonoBehaviour
```

### Properties

#### GrabSetup

The internal setup for the grab action.

##### Declaration

```
public GrabInteractableConfigurator GrabSetup { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableConfigurator] | n/a |

#### InputActiveCollisionConsumer

The input ActiveCollisionConsumerEventProxyEmitter for the grab action.

##### Declaration

```
public ActiveCollisionConsumerEventProxyEmitter InputActiveCollisionConsumer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| ActiveCollisionConsumerEventProxyEmitter | n/a |

#### InputGrabReceived

The input GameObjectEventProxyEmitter for the grab action.

##### Declaration

```
public GameObjectEventProxyEmitter InputGrabReceived { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### InputGrabSetup

The input GameObjectEventProxyEmitter for any pre setup on grab.

##### Declaration

```
public GameObjectEventProxyEmitter InputGrabSetup { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### InputUngrabReceived

The input GameObjectEventProxyEmitter for the grab action.

##### Declaration

```
public GameObjectEventProxyEmitter InputUngrabReceived { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### InputUngrabReset

The input GameObjectEventProxyEmitter for any post reset on ungrab.

##### Declaration

```
public GameObjectEventProxyEmitter InputUngrabReset { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

### Methods

#### NotifyGrab(GameObject)

Notifies that the Interactable is being grabbed.

##### Declaration

```
public virtual void NotifyGrab(GameObject data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | data | The grabbing object. |

#### NotifyUngrab(GameObject)

Notifies that the Interactable is no longer being grabbed.

##### Declaration

```
public virtual void NotifyUngrab(GameObject data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | data | The previous grabbing object. |

#### OnAfterGrabSetupChange()

Called after [GrabSetup] has been changed.

##### Declaration

```
protected virtual void OnAfterGrabSetupChange()
```

[GrabInteractableControlDirectionAction]: GrabInteractableControlDirectionAction.md
[GrabInteractableFollowAction]: GrabInteractableFollowAction.md
[GrabInteractableScaleAction]: GrabInteractableScaleAction.md
[GrabInteractableSwapAction]: GrabInteractableSwapAction.md
[Tilia.Interactions.Interactables.Interactables.Grab.Action]: README.md
[GrabInteractableConfigurator]: Tilia.Interactions.Interactables.Interactables.Grab.GrabInteractableConfigurator.md
[GrabSetup]: GrabInteractableAction.md#GrabSetup