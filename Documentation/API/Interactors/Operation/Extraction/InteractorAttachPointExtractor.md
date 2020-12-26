# Class InteractorAttachPointExtractor

Extracts the grab attach point GameObject from an [InteractorFacade].

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [DoExtract(GameObject)]
  * [Extract(GameObject)]
  * [ExtractValue()]
  * [GetValue(InteractorFacade)]

## Details

##### Inheritance

* System.Object
* InteractorAttachPointExtractor
* [InteractorPrecisionPointExtractor]

##### Namespace

* [Tilia.Interactions.Interactables.Interactors.Operation.Extraction]

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

#### GetValue(InteractorFacade)

Gets the source to extract.

##### Declaration

```
protected virtual GameObject GetValue(InteractorFacade interactorSource)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorSource | The Interactor to extract from. |

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The grab attach point to return. |

[InteractorFacade]: ../../../Interactors/InteractorFacade.md
[InteractorPrecisionPointExtractor]: InteractorPrecisionPointExtractor.md
[Tilia.Interactions.Interactables.Interactors.Operation.Extraction]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[DoExtract(GameObject)]: #DoExtractGameObject
[Extract(GameObject)]: #ExtractGameObject
[ExtractValue()]: #ExtractValue
[GetValue(InteractorFacade)]: #GetValueInteractorFacade
