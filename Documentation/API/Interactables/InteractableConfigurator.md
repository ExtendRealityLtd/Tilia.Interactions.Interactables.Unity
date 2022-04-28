# Class InteractableConfigurator

Sets up the Interactable Prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ActiveCollisions]
  * [CollisionNotifier]
  * [ConsumerContainer]
  * [ConsumerRigidbody]
  * [DisallowedGrabInteractors]
  * [DisallowedTouchInteractors]
  * [Facade]
  * [GrabConfiguration]
  * [MeshContainer]
  * [TouchConfiguration]
* [Methods]
  * [ClearConsumerContainer()]
  * [ClearConsumerRigidbody()]
  * [ClearDisallowedGrabInteractors()]
  * [ClearDisallowedTouchInteractors()]
  * [ConfigureContainer()]
  * [OnAfterConsumerContainerChange()]
  * [OnAfterConsumerRigidbodyChange()]
  * [OnAfterDisallowedGrabInteractorsChange()]
  * [OnAfterDisallowedTouchInteractorsChange()]

## Details

##### Inheritance

* System.Object
* InteractableConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactables]

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

#### CollisionNotifier

The linked [CollisionNotifier].

##### Declaration

```
public CollisionNotifier CollisionNotifier { get; protected set; }
```

#### ConsumerContainer

The overall container for the interactable consumers.

##### Declaration

```
public GameObject ConsumerContainer { get; set; }
```

#### ConsumerRigidbody

The Rigidbody for the overall collisions.

##### Declaration

```
public Rigidbody ConsumerRigidbody { get; set; }
```

#### DisallowedGrabInteractors

The rule to determine what is not allowed to grab this interactable.

##### Declaration

```
public RuleContainer DisallowedGrabInteractors { get; set; }
```

#### DisallowedTouchInteractors

The rule to determine what is not allowed to touch this interactable.

##### Declaration

```
public RuleContainer DisallowedTouchInteractors { get; set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractableFacade Facade { get; protected set; }
```

#### GrabConfiguration

The linked Grab Internal Setup.

##### Declaration

```
public GrabInteractableConfigurator GrabConfiguration { get; protected set; }
```

#### MeshContainer

The GameObject that contains the mesh for the Interactable.

##### Declaration

```
public GameObject MeshContainer { get; protected set; }
```

#### TouchConfiguration

The linked Touch Internal Setup.

##### Declaration

```
public TouchInteractableConfigurator TouchConfiguration { get; protected set; }
```

### Methods

#### ClearConsumerContainer()

Clears [ConsumerContainer].

##### Declaration

```
public virtual void ClearConsumerContainer()
```

#### ClearConsumerRigidbody()

Clears [ConsumerRigidbody].

##### Declaration

```
public virtual void ClearConsumerRigidbody()
```

#### ClearDisallowedGrabInteractors()

Clears [DisallowedGrabInteractors].

##### Declaration

```
public virtual void ClearDisallowedGrabInteractors()
```

#### ClearDisallowedTouchInteractors()

Clears [DisallowedTouchInteractors].

##### Declaration

```
public virtual void ClearDisallowedTouchInteractors()
```

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
[GrabInteractableConfigurator]: Grab/GrabInteractableConfigurator.md
[TouchInteractableConfigurator]: Touch/TouchInteractableConfigurator.md
[ConsumerContainer]: InteractableConfigurator.md#ConsumerContainer
[ConsumerRigidbody]: InteractableConfigurator.md#ConsumerRigidbody
[DisallowedGrabInteractors]: InteractableConfigurator.md#DisallowedGrabInteractors
[DisallowedTouchInteractors]: InteractableConfigurator.md#DisallowedTouchInteractors
[ConsumerContainer]: InteractableConfigurator.md#ConsumerContainer
[ConsumerRigidbody]: InteractableConfigurator.md#ConsumerRigidbody
[DisallowedGrabInteractors]: InteractableConfigurator.md#DisallowedGrabInteractors
[DisallowedTouchInteractors]: InteractableConfigurator.md#DisallowedTouchInteractors
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ActiveCollisions]: #ActiveCollisions
[CollisionNotifier]: #CollisionNotifier
[ConsumerContainer]: #ConsumerContainer
[ConsumerRigidbody]: #ConsumerRigidbody
[DisallowedGrabInteractors]: #DisallowedGrabInteractors
[DisallowedTouchInteractors]: #DisallowedTouchInteractors
[Facade]: #Facade
[GrabConfiguration]: #GrabConfiguration
[MeshContainer]: #MeshContainer
[TouchConfiguration]: #TouchConfiguration
[Methods]: #Methods
[ClearConsumerContainer()]: #ClearConsumerContainer
[ClearConsumerRigidbody()]: #ClearConsumerRigidbody
[ClearDisallowedGrabInteractors()]: #ClearDisallowedGrabInteractors
[ClearDisallowedTouchInteractors()]: #ClearDisallowedTouchInteractors
[ConfigureContainer()]: #ConfigureContainer
[OnAfterConsumerContainerChange()]: #OnAfterConsumerContainerChange
[OnAfterConsumerRigidbodyChange()]: #OnAfterConsumerRigidbodyChange
[OnAfterDisallowedGrabInteractorsChange()]: #OnAfterDisallowedGrabInteractorsChange
[OnAfterDisallowedTouchInteractorsChange()]: #OnAfterDisallowedTouchInteractorsChange
