# Class InteractableConfigurator

##### Inheritance

* System.Object
* InteractableConfigurator

###### **Namespace**: [Tilia.Interactions.Interactables.Interactables]

##### Syntax

```
public class InteractableConfigurator : MonoBehaviour
```

### Properties

#### ActiveCollisions

The linked GameObjectObservableList.

##### Declaration

```
public GameObjectObservableList ActiveCollisions { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObjectObservableList | n/a |

#### CollisionNotifier

The linked [CollisionNotifier].

##### Declaration

```
public CollisionNotifier CollisionNotifier { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| CollisionNotifier | n/a |

#### ConsumerContainer

The overall container for the interactable consumers.

##### Declaration

```
public GameObject ConsumerContainer { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### ConsumerRigidbody

##### Declaration

```
public Rigidbody ConsumerRigidbody { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| Rigidbody | n/a |

#### DisallowedGrabInteractors

The rule to determine what is not allowed to grab this interactable.

##### Declaration

```
public RuleContainer DisallowedGrabInteractors { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| RuleContainer | n/a |

#### DisallowedTouchInteractors

The rule to determine what is not allowed to touch this interactable.

##### Declaration

```
public RuleContainer DisallowedTouchInteractors { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| RuleContainer | n/a |

#### Facade

The public interface facade.

##### Declaration

```
public InteractableFacade Facade { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractableFacade] | n/a |

#### GrabConfiguration

The linked Grab Internal Setup.

##### Declaration

```
public GrabInteractableConfigurator GrabConfiguration { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [GrabInteractableConfigurator] | n/a |

#### MeshContainer

The GameObject that contains the mesh for the Interactable.

##### Declaration

```
public GameObject MeshContainer { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| GameObject | n/a |

#### TouchConfiguration

The linked Touch Internal Setup.

##### Declaration

```
public TouchInteractableConfigurator TouchConfiguration { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [TouchInteractableConfigurator] | n/a |

### Methods

#### ConfigureContainer()

Configures any container data to the sub setup components.

##### Declaration

```
protected virtual void ConfigureContainer()
```

#### OnAfterConsumerContainerChange()

Called after [ConsumerContainer] has been changed.

##### Declaration

```
protected virtual void OnAfterConsumerContainerChange()
```

#### OnAfterConsumerRigidbodyChange()

Called after [ConsumerRigidbody] has been changed.

##### Declaration

```
protected virtual void OnAfterConsumerRigidbodyChange()
```

#### OnAfterDisallowedGrabInteractorsChange()

Called after [DisallowedGrabInteractors] has been changed.

##### Declaration

```
protected virtual void OnAfterDisallowedGrabInteractorsChange()
```

#### OnAfterDisallowedTouchInteractorsChange()

Called after [DisallowedTouchInteractors] has been changed.

##### Declaration

```
protected virtual void OnAfterDisallowedTouchInteractorsChange()
```

[Tilia.Interactions.Interactables.Interactables]: README.md
[CollisionNotifier]: InteractableConfigurator.md#CollisionNotifier
[InteractableFacade]: InteractableFacade.md
[GrabInteractableConfigurator]: Grab.GrabInteractableConfigurator.md
[TouchInteractableConfigurator]: Touch.TouchInteractableConfigurator.md
[ConsumerContainer]: InteractableConfigurator.md#ConsumerContainer
[ConsumerRigidbody]: InteractableConfigurator.md#ConsumerRigidbody
[DisallowedGrabInteractors]: InteractableConfigurator.md#DisallowedGrabInteractors
[DisallowedTouchInteractors]: InteractableConfigurator.md#DisallowedTouchInteractors