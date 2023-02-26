# Class InteractableCreator

A helper class to easily create an Interactable Object via script.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [interactableFactory]
* [Properties]
  * [InteractableObject]
* [Methods]
  * [Convert(GameObject)]
  * [DoConvert(GameObject)]

## Details

##### Inheritance

* System.Object
* InteractableCreator

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Utility]

##### Syntax

```
public class InteractableCreator : MonoBehaviour
```

### Fields

#### interactableFactory

The factory for creating new Interactable Obejcts.

##### Declaration

```
protected InteractableFactory interactableFactory
```

### Properties

#### InteractableObject

The interactable prefab.

##### Declaration

```
public GameObject InteractableObject { get; protected set; }
```

### Methods

#### Convert(GameObject)

Converts a given GameObject and wraps it into an [InteractableFacade].

##### Declaration

```
public virtual InteractableFacade Convert(GameObject objectToConvert)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | objectToConvert | The GameObject to convert. |

##### Returns

| Type | Description |
| --- | --- |
| [InteractableFacade] | The created Interactable Facade. |

#### DoConvert(GameObject)

Converts a given GameObject and wraps it into an [InteractableFacade].

##### Declaration

```
public virtual void DoConvert(GameObject objectToConvert)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | objectToConvert | The GameObject to convert. |

[Tilia.Interactions.Interactables.Interactables.Utility]: README.md
[InteractableFactory]: InteractableFactory.md
[InteractableFacade]: ../../Interactables/InteractableFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[interactableFactory]: #interactableFactory
[Properties]: #Properties
[InteractableObject]: #InteractableObject
[Methods]: #Methods
[Convert(GameObject)]: #ConvertGameObject
[DoConvert(GameObject)]: #DoConvertGameObject
