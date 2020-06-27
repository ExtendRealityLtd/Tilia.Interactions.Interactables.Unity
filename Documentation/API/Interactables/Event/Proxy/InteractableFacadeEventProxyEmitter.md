# Class InteractableFacadeEventProxyEmitter

Emits a UnityEvent with an [InteractableFacade] payload whenever the Receive method is called.

##### Inheritance

* System.Object
* InteractableFacadeEventProxyEmitter

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Event.Proxy]

##### Syntax

```
public class InteractableFacadeEventProxyEmitter : RestrictableSingleEventProxyEmitter<InteractableFacade, InteractableFacadeEventProxyEmitter.UnityEvent>
```

### Methods

#### GetTargetToCheck()

##### Declaration

```
protected override object GetTargetToCheck()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Object | n/a |

[InteractableFacade]: Tilia.Interactions.Interactables.Interactables.InteractableFacade.md
[Tilia.Interactions.Interactables.Interactables.Event.Proxy]: README.md