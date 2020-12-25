# Class InteractorPrecisionPointExtractor

Extracts the precision grab attach point GameObject from an [InteractorFacade].

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [GetValue(InteractorFacade)]

## Details

##### Inheritance

* System.Object
* [InteractorAttachPointExtractor]
* InteractorPrecisionPointExtractor

##### Inherited Members

[InteractorAttachPointExtractor.Extract(GameObject)]

[InteractorAttachPointExtractor.DoExtract(GameObject)]

[InteractorAttachPointExtractor.ExtractValue()]

##### Namespace

* [Tilia.Interactions.Interactables.Interactors.Operation.Extraction]

##### Syntax

```
public class InteractorPrecisionPointExtractor : InteractorAttachPointExtractor
```

### Methods

#### GetValue(InteractorFacade)

Gets the source to extract.

##### Declaration

```
protected override GameObject GetValue(InteractorFacade interactorSource)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorSource | The Interactor to extract from. |

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The grab attach point to return. |

##### Overrides

[InteractorAttachPointExtractor.GetValue(InteractorFacade)]

[InteractorFacade]: ../../../Interactors/InteractorFacade.md
[InteractorAttachPointExtractor]: InteractorAttachPointExtractor.md
[InteractorAttachPointExtractor.Extract(GameObject)]: InteractorAttachPointExtractor.md#Tilia_Interactions_Interactables_Interactors_Operation_Extraction_InteractorAttachPointExtractor_Extract_GameObject_
[InteractorAttachPointExtractor.DoExtract(GameObject)]: InteractorAttachPointExtractor.md#Tilia_Interactions_Interactables_Interactors_Operation_Extraction_InteractorAttachPointExtractor_DoExtract_GameObject_
[InteractorAttachPointExtractor.ExtractValue()]: InteractorAttachPointExtractor.md#Tilia_Interactions_Interactables_Interactors_Operation_Extraction_InteractorAttachPointExtractor_ExtractValue
[Tilia.Interactions.Interactables.Interactors.Operation.Extraction]: README.md
[InteractorAttachPointExtractor.GetValue(InteractorFacade)]: InteractorAttachPointExtractor.md#Tilia_Interactions_Interactables_Interactors_Operation_Extraction_InteractorAttachPointExtractor_GetValue_Tilia_Interactions_Interactables_Interactors_InteractorFacade_
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[GetValue(InteractorFacade)]: #GetValueInteractorFacade
