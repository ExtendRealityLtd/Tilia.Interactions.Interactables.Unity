# Class InteractorAttachPointExtractor

Extracts the attach point GameObject from an [InteractorFacade].

##### Inheritance

* System.Object
* InteractorAttachPointExtractor

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors.Operation.Extraction]

##### Syntax

```
public class InteractorAttachPointExtractor : ComponentGameObjectExtractor
```

### Methods

#### DoExtract(GameObject)

Extracts the attach point associated with the grabbing functionality of the Interactor.

##### Declaration

```
public virtual void DoExtract(GameObject interactorContainer)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactorContainer | The container that has an [InteractorFacade] component to extract from. |

#### Extract(GameObject)

Extracts the attach point associated with the grabbing functionality of the Interactor.

##### Declaration

```
public virtual GameObject Extract(GameObject interactorContainer)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactorContainer | The container that has an [InteractorFacade] component to extract from. |

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The attach point. |

#### ExtractValue()

##### Declaration

```
protected override GameObject ExtractValue()
```

##### Returns

| Type | Description |
| --- | --- |
| GameObject | n/a |

[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[Tilia.Interactions.Interactables.Interactors.Operation.Extraction]: README.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md
[InteractorFacade]: Tilia.Interactions.Interactables.Interactors.InteractorFacade.md