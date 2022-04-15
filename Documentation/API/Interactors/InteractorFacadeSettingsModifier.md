# Class InteractorFacadeSettingsModifier

Allows the modification of the settings on a specified [InteractorFacade] found in a collection.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [CacheElementSettings]
  * [Elements]
* [Methods]
  * [ClearElements()]
  * [RestoreCachedGrabAction(InteractorFacade)]
  * [RestoreCachedGrabPrecognition(InteractorFacade)]
  * [RestoreCachedVelocityTracker(InteractorFacade)]
  * [SetTargetGrabActionFor(InteractorFacade)]
  * [SetTargetGrabPrecognition(InteractorFacade)]
  * [SetTargetVelocityTracker(InteractorFacade)]

## Details

##### Inheritance

* System.Object
* InteractorFacadeSettingsModifier

##### Namespace

* [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
public class InteractorFacadeSettingsModifier : MonoBehaviour
```

### Properties

#### CacheElementSettings

Determines whether to cache the element settings when attempting to set them.

##### Declaration

```
public bool CacheElementSettings { get; set; }
```

#### Elements

The [InteractorFacadeSettingsModifier.InteractorElement] collection of settings to modify per [InteractorFacade].

##### Declaration

```
public List<InteractorFacadeSettingsModifier.InteractorElement> Elements { get; set; }
```

### Methods

#### ClearElements()

Clears [Elements].

##### Declaration

```
public virtual void ClearElements()
```

#### RestoreCachedGrabAction(InteractorFacade)

Matches the given [InteractorFacade] in the [Elements] and restores the cached [GrabAction].

##### Declaration

```
public virtual void RestoreCachedGrabAction(InteractorFacade interactorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorFacade | The [InteractorFacade] to update. |

#### RestoreCachedGrabPrecognition(InteractorFacade)

Matches the given [InteractorFacade] in the [Elements] and restores the cached [GrabPrecognition].

##### Declaration

```
public virtual void RestoreCachedGrabPrecognition(InteractorFacade interactorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorFacade | The [InteractorFacade] to update. |

#### RestoreCachedVelocityTracker(InteractorFacade)

Matches the given [InteractorFacade] in the [Elements] and restores the cached [VelocityTracker].

##### Declaration

```
public virtual void RestoreCachedVelocityTracker(InteractorFacade interactorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorFacade | The [InteractorFacade] to update. |

#### SetTargetGrabActionFor(InteractorFacade)

Matches the given [InteractorFacade] in the [Elements] and updates the [GrabAction] with the relevant [TargetGrabAction].

##### Declaration

```
public virtual void SetTargetGrabActionFor(InteractorFacade interactorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorFacade | The [InteractorFacade] to update. |

#### SetTargetGrabPrecognition(InteractorFacade)

Matches the given [InteractorFacade] in the [Elements] and updates the [GrabPrecognition] with the relevant [TargetGrabPrecognition].

##### Declaration

```
public virtual void SetTargetGrabPrecognition(InteractorFacade interactorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorFacade | The [InteractorFacade] to update. |

#### SetTargetVelocityTracker(InteractorFacade)

Matches the given [InteractorFacade] in the [Elements] and updates the [VelocityTracker] with the relevant [TargetVelocityTracker].

##### Declaration

```
public virtual void SetTargetVelocityTracker(InteractorFacade interactorFacade)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactorFacade | The [InteractorFacade] to update. |

[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorFacadeSettingsModifier.InteractorElement]: InteractorFacadeSettingsModifier.InteractorElement.md
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[TargetGrabAction]: InteractorFacadeSettingsModifier.InteractorElement.md#InteractorElement_TargetGrabAction
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[TargetGrabPrecognition]: InteractorFacadeSettingsModifier.InteractorElement.md#InteractorElement_TargetGrabPrecognition
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker
[TargetVelocityTracker]: InteractorFacadeSettingsModifier.InteractorElement.md#InteractorElement_TargetVelocityTracker
[InteractorFacade]: InteractorFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[CacheElementSettings]: #CacheElementSettings
[Elements]: #Elements
[Methods]: #Methods
[ClearElements()]: #ClearElements
[RestoreCachedGrabAction(InteractorFacade)]: #RestoreCachedGrabActionInteractorFacade
[RestoreCachedGrabPrecognition(InteractorFacade)]: #RestoreCachedGrabPrecognitionInteractorFacade
[RestoreCachedVelocityTracker(InteractorFacade)]: #RestoreCachedVelocityTrackerInteractorFacade
[SetTargetGrabActionFor(InteractorFacade)]: #SetTargetGrabActionForInteractorFacade
[SetTargetGrabPrecognition(InteractorFacade)]: #SetTargetGrabPrecognitionInteractorFacade
[SetTargetVelocityTracker(InteractorFacade)]: #SetTargetVelocityTrackerInteractorFacade
