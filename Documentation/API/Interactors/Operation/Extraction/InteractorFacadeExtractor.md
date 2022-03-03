# Class InteractorFacadeExtractor

Extracts and emits the [InteractorFacade] found in relation to the Source.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [ExtractValue()]
  * [InvokeResult(InteractorFacade)]

## Details

##### Inheritance

* System.Object
* InteractorFacadeExtractor

##### Namespace

* [Tilia.Interactions.Interactables.Interactors.Operation.Extraction]

##### Syntax

```
public class InteractorFacadeExtractor : ComponentExtractor<InteractorFacade, InteractorFacadeExtractor.UnityEvent, InteractorFacade>
```

### Methods

#### ExtractValue()

##### Declaration

```
protected override InteractorFacade ExtractValue()
```

##### Returns

| Type | Description |
| --- | --- |
| [InteractorFacade] | n/a |

#### InvokeResult(InteractorFacade)

##### Declaration

```
protected override bool InvokeResult(InteractorFacade data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | data | n/a |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

[InteractorFacade]: ../../../Interactors/InteractorFacade.md
[Tilia.Interactions.Interactables.Interactors.Operation.Extraction]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[ExtractValue()]: #ExtractValue
[InvokeResult(InteractorFacade)]: #InvokeResultInteractorFacade
