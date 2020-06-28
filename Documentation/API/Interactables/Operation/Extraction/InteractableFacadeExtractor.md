# Class InteractableFacadeExtractor

Extracts and emits the [InteractableFacade] found in relation to the Source.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [ExtractValue()]
  * [InvokeResult(InteractableFacade)]

## Details

##### Inheritance

* System.Object
* InteractableFacadeExtractor

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Operation.Extraction]

##### Syntax

```
public class InteractableFacadeExtractor : ComponentExtractor<InteractableFacade, InteractableFacadeExtractor.UnityEvent, InteractableFacade>
```

### Methods

#### ExtractValue()

##### Declaration

```
protected override InteractableFacade ExtractValue()
```

##### Returns

| Type | Description |
| --- | --- |
| [InteractableFacade] | n/a |

#### InvokeResult(InteractableFacade)

##### Declaration

```
protected override bool InvokeResult(InteractableFacade data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | data | n/a |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

[InteractableFacade]: ../../../Interactables/InteractableFacade.md
[Tilia.Interactions.Interactables.Interactables.Operation.Extraction]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[ExtractValue()]: #ExtractValue
[InvokeResult(InteractableFacade)]: #InvokeResultInteractableFacade
