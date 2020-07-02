# Class InteractorExtractor

Extracts a GameObject relevant to the extraction method from an [InteractorFacade].

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedGrabAttachPoint]
* [Methods]
  * [DoExtractAttachPoint(GameObject)]
  * [DoExtractAttachPoint(InteractorFacade)]
  * [ExtractAttachPoint(GameObject)]
  * [ExtractAttachPoint(InteractorFacade)]
  * [ExtractValue()]

## Details

##### Inheritance

* System.Object
* InteractorExtractor

##### Namespace

* [Tilia.Interactions.Interactables.Interactors.Operation.Extraction]

##### Syntax

```
public class InteractorExtractor : ComponentGameObjectExtractor
```

### Fields

#### cachedGrabAttachPoint

The cached Grab Attach Point if trying to Extract Attach Point;

##### Declaration

```
protected GameObject cachedGrabAttachPoint
```

### Methods

#### DoExtractAttachPoint(GameObject)

Extracts the attach point associated with the grabbing functionality of the Interactor.

##### Declaration

```
[Obsolete("Use `InteractorAttachPointExtractor -> DoExtract` instead.")]
public virtual void DoExtractAttachPoint(GameObject interactorContainer)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactorContainer | The container that has an [InteractorFacade] component to extract from. |

#### DoExtractAttachPoint(InteractorFacade)

Extracts the attach point associated with the grabbing functionality of the Interactor.

##### Declaration

```
[Obsolete("Use `InteractorAttachPointExtractor -> DoExtract` instead.")]
public virtual void DoExtractAttachPoint(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to extract from. |

#### ExtractAttachPoint(GameObject)

Extracts the attach point associated with the grabbing functionality of the Interactor.

##### Declaration

```
[Obsolete("Use `InteractorAttachPointExtractor -> Extract` instead.")]
public virtual GameObject ExtractAttachPoint(GameObject interactorContainer)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactorContainer | The container that has an [InteractorFacade] component to extract from. |

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The attach point. |

#### ExtractAttachPoint(InteractorFacade)

Extracts the attach point associated with the grabbing functionality of the Interactor.

##### Declaration

```
[Obsolete("Use `InteractorAttachPointExtractor.Extract()` instead.")]
public virtual GameObject ExtractAttachPoint(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The Interactor to extract from. |

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

[InteractorFacade]: ../../../Interactors/InteractorFacade.md
[Tilia.Interactions.Interactables.Interactors.Operation.Extraction]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedGrabAttachPoint]: #cachedGrabAttachPoint
[Methods]: #Methods
[DoExtractAttachPoint(GameObject)]: #DoExtractAttachPointGameObject
[DoExtractAttachPoint(InteractorFacade)]: #DoExtractAttachPointInteractorFacade
[ExtractAttachPoint(GameObject)]: #ExtractAttachPointGameObject
[ExtractAttachPoint(InteractorFacade)]: #ExtractAttachPointInteractorFacade
[ExtractValue()]: #ExtractValue
