# Class InteractorActionPublisherFacade

The public interface into the Interactor Action Publisher Prefab.

##### Inheritance

* System.Object
* InteractorActionPublisherFacade

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class InteractorActionPublisherFacade : MonoBehaviour
```

### Properties

#### ActiveAction

The current active Action.

##### Declaration

```
public Action ActiveAction { get; }
```

##### Property Value

| Type | Description |
| --- | --- |
| Action | n/a |

#### Configuration

The Action that will be linked to the [SourceAction].

##### Declaration

```
public InteractorActionPublisherConfigurator Configuration { get; protected set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractorActionPublisherConfigurator] | n/a |

#### PublisherIdentifier

An indentifier for the publisher that is used by the Action Receiver to create the link between publisher and receiver.

##### Declaration

```
public string PublisherIdentifier { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.String | n/a |

#### SourceAction

The Action to be monitored to control the interaction.

##### Declaration

```
public Action SourceAction { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| Action | n/a |

#### SourceInteractor

The source [InteractorFacade] that the action will be processed through.

##### Declaration

```
public InteractorFacade SourceInteractor { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractorFacade] | n/a |

### Methods

#### OnAfterPublisherIdentifierChange()

Called after [PublisherIdentifier] has been changed.

##### Declaration

```
protected virtual void OnAfterPublisherIdentifierChange()
```

#### OnAfterSourceActionChange()

Called after [SourceAction] has been changed.

##### Declaration

```
protected virtual void OnAfterSourceActionChange()
```

#### OnAfterSourceInteractorChange()

Called after [SourceInteractor] has been changed.

##### Declaration

```
protected virtual void OnAfterSourceInteractorChange()
```

#### OnBeforeSourceInteractorChange()

Called before [SourceInteractor] has been changed.

##### Declaration

```
protected virtual void OnBeforeSourceInteractorChange()
```

[Tilia.Interactions.Interactables.Interactors]: README.md
[SourceAction]: InteractorActionPublisherFacade.md#SourceAction
[InteractorActionPublisherConfigurator]: InteractorActionPublisherConfigurator.md
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[PublisherIdentifier]: InteractorActionPublisherFacade.md#PublisherIdentifier
[SourceAction]: InteractorActionPublisherFacade.md#SourceAction
[SourceInteractor]: InteractorActionPublisherFacade.md#SourceInteractor
[SourceInteractor]: InteractorActionPublisherFacade.md#SourceInteractor