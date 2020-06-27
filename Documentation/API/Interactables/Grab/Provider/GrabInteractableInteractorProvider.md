# Class GrabInteractableInteractorProvider

Processes a received grab event and passes it over to the appropriate grab actions.

##### Inheritance

* System.Object
* GrabInteractableInteractorProvider
* [GrabInteractableListInteractorProvider]
* [GrabInteractableStackInteractorProvider]

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables.Grab.Provider]

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

##### Field Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.List<[InteractorFacade]\> | n/a |

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

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### InputUngrabReceived

The input GameObjectEventProxyEmitter for the ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter InputUngrabReceived { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputPrimaryGrabAction

The output GameObjectEventProxyEmitter for the primary grab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryGrabAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputPrimaryGrabSetupOnSecondaryAction

The output GameObjectEventProxyEmitter for the primary grab setup on secondary action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryGrabSetupOnSecondaryAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputPrimaryUngrabAction

The output GameObjectEventProxyEmitter for the primary ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryUngrabAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputPrimaryUngrabResetOnSecondaryAction

The output GameObjectEventProxyEmitter for the primary ungrab reset on secondary action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputPrimaryUngrabResetOnSecondaryAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputSecondaryGrabAction

The output GameObjectEventProxyEmitter for the secondary grab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputSecondaryGrabAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

#### OutputSecondaryUngrabAction

The output GameObjectEventProxyEmitter for the Secondary ungrab action.

##### Declaration

```
public GameObjectEventProxyEmitter OutputSecondaryUngrabAction { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectEventProxyEmitter | n/a |

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
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md