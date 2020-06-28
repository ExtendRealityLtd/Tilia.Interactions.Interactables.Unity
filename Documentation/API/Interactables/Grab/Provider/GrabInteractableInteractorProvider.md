# Class GrabInteractableInteractorProvider

Processes a received grab event and passes it over to the appropriate grab actions.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [grabbingInteractors]
* [Properties]
  * [GrabbingInteractors]
  * [InputGrabReceived]
  * [InputUngrabReceived]
  * [OutputPrimaryGrabAction]
  * [OutputPrimaryGrabSetupOnSecondaryAction]
  * [OutputPrimaryUngrabAction]
  * [OutputPrimaryUngrabResetOnSecondaryAction]
  * [OutputSecondaryGrabAction]
  * [OutputSecondaryUngrabAction]
* [Methods]
  * [GetGrabbingInteractors(IEnumerable<GameObject>)]

## Details

##### Inheritance

* System.Object
* GrabInteractableInteractorProvider
* [GrabInteractableListInteractorProvider]
* [GrabInteractableStackInteractorProvider]

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Grab.Provider]

##### Syntax

```
public abstract class GrabInteractableInteractorProvider : MonoBehaviour
```

### Fields

#### grabbingInteractors

A reusable collection to hold the returned grabbing interactors.

##### Declaration

```
protected readonly List<InteractorFacade> grabbingInteractors
```

### Properties

#### GrabbingInteractors

Gets the available grabbing Interactors from the provider.

##### Declaration

```
public abstract IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | A collection of Interactors that are currently grabbing the Interactable. |

#### InputGrabReceived

The input GameObjectEventProxyEmitter for the grab action.

##### Declaration

```
public GameObjectEventProxyEmitter InputGrabReceived { get; protected set; }
```

#### InputUngrabReceived

The input GameObjectEventProxyEmitter for the ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter InputUngrabReceived { get; protected set; }
```

#### OutputPrimaryGrabAction

The output GameObjectEventProxyEmitter for the primary grab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryGrabAction { get; protected set; }
```

#### OutputPrimaryGrabSetupOnSecondaryAction

The output GameObjectEventProxyEmitter for the primary grab setup on secondary action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryGrabSetupOnSecondaryAction { get; protected set; }
```

#### OutputPrimaryUngrabAction

The output GameObjectEventProxyEmitter for the primary ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryUngrabAction { get; protected set; }
```

#### OutputPrimaryUngrabResetOnSecondaryAction

The output GameObjectEventProxyEmitter for the primary ungrab reset on secondary action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryUngrabResetOnSecondaryAction { get; protected set; }
```

#### OutputSecondaryGrabAction

The output GameObjectEventProxyEmitter for the secondary grab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputSecondaryGrabAction { get; protected set; }
```

#### OutputSecondaryUngrabAction

The output GameObjectEventProxyEmitter for the Secondary ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputSecondaryUngrabAction { get; protected set; }
```

### Methods

#### GetGrabbingInteractors(IEnumerable<GameObject>)

Gets the Grabbing Interactors stored in the given collection.

##### Declaration

```
protected virtual IReadOnlyList<InteractorFacade> GetGrabbingInteractors(IEnumerable<GameObject> elements)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Collections.Generic.IEnumerable<GameObject\> | elements | The collection to retrieve the Grabbing Interactors from. |

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.Generic.IReadOnlyList<[InteractorFacade]\> | A collection of Grabbing Interactors. |

[GrabInteractableListInteractorProvider]: GrabInteractableListInteractorProvider.md
[GrabInteractableStackInteractorProvider]: GrabInteractableStackInteractorProvider.md
[Tilia.Interactions.Interactables.Interactables.Grab.Provider]: README.md
[InteractorFacade]: ../../../Interactors/InteractorFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[grabbingInteractors]: #grabbingInteractors
[Properties]: #Properties
[GrabbingInteractors]: #GrabbingInteractors
[InputGrabReceived]: #InputGrabReceived
[InputUngrabReceived]: #InputUngrabReceived
[OutputPrimaryGrabAction]: #OutputPrimaryGrabAction
[OutputPrimaryGrabSetupOnSecondaryAction]: #OutputPrimaryGrabSetupOnSecondaryAction
[OutputPrimaryUngrabAction]: #OutputPrimaryUngrabAction
[OutputPrimaryUngrabResetOnSecondaryAction]: #OutputPrimaryUngrabResetOnSecondaryAction
[OutputSecondaryGrabAction]: #OutputSecondaryGrabAction
[OutputSecondaryUngrabAction]: #OutputSecondaryUngrabAction
[Methods]: #Methods
[GetGrabbingInteractors(IEnumerable<GameObject>)]: #GetGrabbingInteractorsIEnumerable<GameObject>
