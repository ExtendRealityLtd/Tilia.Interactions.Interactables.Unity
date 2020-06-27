# Class InteractorFacadeSettingsModifier.InteractorElement

##### Inheritance

* System.Object
* InteractorFacadeSettingsModifier.InteractorElement

##### Inherited Members

System.Object.ToString()

System.Object.Equals(System.Object)

System.Object.Equals(System.Object, System.Object)

System.Object.ReferenceEquals(System.Object, System.Object)

System.Object.GetHashCode()

System.Object.GetType()

System.Object.MemberwiseClone()

###### **Namespace**: [Tilia.Interactions.Interactables.Interactors]

##### Syntax

```
[Serializable]
public class InteractorElement
```

### Fields

#### cachedGrabAction

The original BooleanAction on the [TargetFacade] to revert back to.

##### Declaration

```
protected BooleanAction cachedGrabAction
```

##### Field Value

| Type | Description |
| --- | --- |
| BooleanAction | n/a |

#### cachedGrabPrecognition

The original GrabPrecognition on the [TargetFacade] to revert back to.

##### Declaration

```
protected float cachedGrabPrecognition
```

##### Field Value

| Type | Description |
| --- | --- |
| System.Single | n/a |

#### cachedVelocityTracker

The original VelocityTrackerProcessor on the [TargetFacade] to revert back to.

##### Declaration

```
protected VelocityTrackerProcessor cachedVelocityTracker
```

##### Field Value

| Type | Description |
| --- | --- |
| VelocityTrackerProcessor | n/a |

### Properties

#### TargetFacade

The [InteractorFacade] to modify the settings on.

##### Declaration

```
public InteractorFacade TargetFacade { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| [InteractorFacade] | n/a |

#### TargetGrabAction

The BooleanAction to update the [GrabAction] to.

##### Declaration

```
public BooleanAction TargetGrabAction { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| BooleanAction | n/a |

#### TargetGrabPrecognition

The updated value to set the [GrabPrecognition] to.

##### Declaration

```
public float TargetGrabPrecognition { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| System.Single | n/a |

#### TargetVelocityTracker

The VelocityTrackerProcessor to update the [VelocityTracker] to.

##### Declaration

```
public VelocityTrackerProcessor TargetVelocityTracker { get; set; }
```

##### Property Value

| Type | Description |
| --- | --- |
| VelocityTrackerProcessor | n/a |

### Methods

#### OnAfterFacadeChange()

Called after [TargetFacade] has been changed.

##### Declaration

```
protected virtual void OnAfterFacadeChange()
```

#### RestoreCachedGrabAction()

Restores the cached [GrabAction].

##### Declaration

```
public virtual void RestoreCachedGrabAction()
```

#### RestoreCachedGrabPrecognition()

Restores the cached [GrabPrecognition].

##### Declaration

```
public virtual void RestoreCachedGrabPrecognition()
```

#### RestoreCachedVelocityTracker()

Restores the cached [VelocityTracker].

##### Declaration

```
public virtual void RestoreCachedVelocityTracker()
```

#### SetTargetGrabAction(Boolean)

Sets the [GrabAction] to the value of [TargetGrabAction].

##### Declaration

```
public virtual void SetTargetGrabAction(bool cacheCurrentGrabAction)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Boolean | cacheCurrentGrabAction | Caches the current [GrabAction] value to be restored later. |

#### SetTargetGrabPrecognition(Boolean)

Sets the [GrabPrecognition] to the value of [TargetGrabPrecognition].

##### Declaration

```
public virtual void SetTargetGrabPrecognition(bool cacheCurrentGrabPrecognition)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Boolean | cacheCurrentGrabPrecognition | Caches the current [GrabPrecognition] value to be restored later. |

#### SetTargetVelocityTracker(Boolean)

Sets the [VelocityTracker] to the value of [TargetVelocityTracker].

##### Declaration

```
public virtual void SetTargetVelocityTracker(bool cacheCurrentVelocityTracker)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Boolean | cacheCurrentVelocityTracker | Caches the current [VelocityTracker] value to be restored later. |

[Tilia.Interactions.Interactables.Interactors]: README.md
[TargetFacade]: InteractorFacadeSettingsModifier.InteractorElement.md#TargetFacade
[TargetFacade]: InteractorFacadeSettingsModifier.InteractorElement.md#TargetFacade
[TargetFacade]: InteractorFacadeSettingsModifier.InteractorElement.md#TargetFacade
[InteractorFacade]: InteractorFacade.md
[InteractorFacade]: InteractorFacade.md
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker
[TargetFacade]: InteractorFacadeSettingsModifier.InteractorElement.md#TargetFacade
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[TargetGrabAction]: InteractorFacadeSettingsModifier.InteractorElement.md#TargetGrabAction
[GrabAction]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabAction
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[TargetGrabPrecognition]: InteractorFacadeSettingsModifier.InteractorElement.md#TargetGrabPrecognition
[GrabPrecognition]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_GrabPrecognition
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker
[TargetVelocityTracker]: InteractorFacadeSettingsModifier.InteractorElement.md#TargetVelocityTracker
[VelocityTracker]: InteractorFacade.md#Tilia_Interactions_Interactables_Interactors_InteractorFacade_VelocityTracker