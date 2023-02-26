# Class InteractableFactory

A factory for creating an Interactable Object.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [CanConvert(GameObject)]
  * [Create(GameObject, GameObject)]

## Details

##### Inheritance

* System.Object
* InteractableFactory

##### Inherited Members

System.Object.ToString()

System.Object.Equals(System.Object)

System.Object.Equals(System.Object, System.Object)

System.Object.ReferenceEquals(System.Object, System.Object)

System.Object.GetHashCode()

System.Object.GetType()

System.Object.MemberwiseClone()

##### Namespace

* [Tilia.Interactions.Interactables.Interactables.Utility]

##### Syntax

```
public class InteractableFactory
```

### Methods

#### CanConvert(GameObject)

Whether the given GameObject can be converted to an Interactable Object.

##### Declaration

```
public virtual bool CanConvert(GameObject objectToConvert)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | objectToConvert | The object to convert. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether it can be converted. |

#### Create(GameObject, GameObject)

Creates a new Interactable Object in the scene.

##### Declaration

```
public virtual GameObject Create(GameObject interactablePrefab, GameObject objectToConvert)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactablePrefab | The Interactable Object prefab to create from. |
| GameObject | objectToConvert | The Object to convert into the new Interactable Object. |

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The created Interactable Object. |

[Tilia.Interactions.Interactables.Interactables.Utility]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[CanConvert(GameObject)]: #CanConvertGameObject
[Create(GameObject, GameObject)]: #CreateGameObject-GameObject
