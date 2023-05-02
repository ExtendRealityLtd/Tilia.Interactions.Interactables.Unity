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
  * [DoEmbed(GameObject)]
  * [Embed(GameObject)]

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
public GameObject InteractableObject { get; set; }
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

#### DoEmbed(GameObject)

Embeds a created [InteractableFacade] into the given GameObject.

##### Declaration

```
public virtual void DoEmbed(GameObject embedObject)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | embedObject | The GameObject to embed the Interactable within. |

#### Embed(GameObject)

Embeds a created [InteractableFacade] into the given GameObject.

##### Declaration

```
public virtual InteractableFacade Embed(GameObject embedObject)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | embedObject | The GameObject to embed the Interactable within. |

##### Returns

| Type | Description |
| --- | --- |
| [InteractableFacade] | The created Interactable Facade. |

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
[DoEmbed(GameObject)]: #DoEmbedGameObject
[Embed(GameObject)]: #EmbedGameObject
