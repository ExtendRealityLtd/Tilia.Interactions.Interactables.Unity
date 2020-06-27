# Class InteractorFacadeSettingsModifier

Allows the modification of the settings on a specified [InteractorFacade] found in a collection.

##### Inheritance

* System.Object
* InteractorFacadeSettingsModifier

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors]

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

##### Property Value

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### Elements

The [InteractorFacadeSettingsModifier.InteractorElement] collection of settings to modify per [InteractorFacade].

##### Declaration

```
public List<InteractorFacadeSettingsModifier.InteractorElement> Elements { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Collections.Generic.List<[InteractorFacadeSettingsModifier.InteractorElement]\> | n/a |

### Methods

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

[InteractorFacade]: InteractorFacade.md
[Tilia.Interactions.Interactables.Interactors]: README.md
[InteractorFacadeSettingsModifier.InteractorElement]: InteractorFacadeSettingsModifier.InteractorElement.md
[InteractorFacade]: InteractorFacade.md
[InteractorFacadeSettingsModifier.InteractorElement]: InteractorFacadeSettingsModifier.InteractorElement.md
[InteractorFacade]: InteractorFacade.md
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[TargetGrabAction]: InteractorFacadeSettingsModifier.InteractorElement.md#InteractorElement_TargetGrabAction
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[TargetGrabPrecognition]: InteractorFacadeSettingsModifier.InteractorElement.md#InteractorElement_TargetGrabPrecognition
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[Elements]: InteractorFacadeSettingsModifier.md#Elements
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker
[TargetVelocityTracker]: InteractorFacadeSettingsModifier.InteractorElement.md#InteractorElement_TargetVelocityTracker
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md