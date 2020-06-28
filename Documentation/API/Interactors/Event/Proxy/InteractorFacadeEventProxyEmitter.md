# Class InteractorFacadeEventProxyEmitter

Emits a UnityEvent with an [InteractorFacade] payload whenever SingleEventProxyEmitter.Receive is called.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [GetTargetToCheck()]

## Details

##### Inheritance

* System.Object
* InteractorFacadeEventProxyEmitter

##### Namespace

* [Tilia.Interactions.Interactables.Interactors.Event.Proxy]

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

[InteractorFacade]: ../../../Interactors/InteractorFacade.md
[Tilia.Interactions.Interactables.Interactors.Event.Proxy]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[GetTargetToCheck()]: #GetTargetToCheck
