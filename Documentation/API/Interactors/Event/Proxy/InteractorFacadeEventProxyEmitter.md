# Class InteractorFacadeEventProxyEmitter

Emits a UnityEvent with an [InteractorFacade] payload whenever SingleEventProxyEmitter.Receive is called.

##### Inheritance

* System.Object
* InteractorFacadeEventProxyEmitter

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors.Event.Proxy]

##### Syntax

```
public class InteractorFacadeEventProxyEmitter : RestrictableSingleEventProxyEmitter<InteractorFacade, InteractorFacadeEventProxyEmitter.UnityEvent>
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

[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[Tilia.Interactions.Interactables.Interactors.Event.Proxy]: README.md