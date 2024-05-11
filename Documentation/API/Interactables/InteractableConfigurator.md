# Class InteractableConfigurator

Sets up the Interactable Prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedGrabAllowanceState]
  * [cachedKinematicState]
  * [controlDirectionCachedAction]
  * [followCachedAction]
  * [meshColliderTriggerStates]
  * [meshRendererEnabledStates]
* [Properties]
  * [ActiveCollisions]
  * [AddCollisionExtractor]
  * [CollisionNotifier]
  * [ConsumerContainer]
  * [ConsumerRigidbody]
  * [DisallowedGrabInteractors]
  * [DisallowedTouchInteractors]
  * [Facade]
  * [GrabActionTypesCount]
  * [GrabConfiguration]
  * [InteractableVisibilityStatusTagContainer]
  * [IsVisible]
  * [MeshContainer]
  * [RemoveCollisionExtractor]
  * [TouchConfiguration]
* [Methods]
  * [CacheAndDisableGrabState()]
  * [CacheAndSetConsumerRigidbodyKinematicState()]
  * [ClearConsumerContainer()]
  * [ClearConsumerRigidbody()]
  * [ClearDisallowedGrabInteractors()]
  * [ClearDisallowedTouchInteractors()]
  * [ConfigureContainer()]
  * [CreateGrabAction(GrabInteractableAction, Int32, Int32)]
  * [DisableCollidersAndRenderers()]
  * [GetGrabActionTypeObject(Int32)]
  * [GetGrabActionTypeObject(InteractableFactory.ActionType)]
  * [GetPrimaryAction()]
  * [GetSecondaryAction()]
  * [HandleHiddenLastUngrab(InteractorFacade)]
  * [IsGrabConfigurationSet()]
  * [OnAfterConsumerContainerChange()]
  * [OnAfterConsumerRigidbodyChange()]
  * [OnAfterDisallowedGrabInteractorsChange()]
  * [OnAfterDisallowedTouchInteractorsChange()]
  * [OnEnable()]
  * [RestoreCollidersAndRenderers()]
  * [RestoreConsumerRigidbodyKinematicStateFromCache()]
  * [RestoreGrabStateFromCache()]
  * [SetFollowAndControlDirectionPair()]
  * [SetFollowPrecisionPointToDirectionModifierPivot(GameObject)]
  * [SetRigidbodyMaxAngularVelocity(Single)]
  * [UnsetFollowPrecisionPointToDirectionModifierPivot(GameObject)]
  * [UpdatePrimaryAction(Int32)]
  * [UpdatePrimaryAction(InteractableFactory.ActionType)]
  * [UpdateSecondaryAction(Int32)]
  * [UpdateSecondaryAction(InteractableFactory.ActionType)]

## Details

##### Inheritance

* System.Object
* InteractableConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactables]

##### Syntax

```
public class InteractableConfigurator : MonoBehaviour
```

### Fields

#### cachedGrabAllowanceState

The cached active state of the GrabConfiguration.gameObject when changing the visibility state.

##### Declaration

```
protected bool cachedGrabAllowanceState
```

#### cachedKinematicState

The cached kinematic state of the Rigidbody when changing the visibility state.

##### Declaration

```
protected bool cachedKinematicState
```

#### controlDirectionCachedAction

The cached [GrabInteractableControlDirectionAction] for when the follow/control direction pairing is required to be set up.

##### Declaration

```
protected GrabInteractableControlDirectionAction controlDirectionCachedAction
```

#### followCachedAction

The cached [GrabInteractableFollowAction] for when the follow/control direction pairing is required to be set up.

##### Declaration

```
protected GrabInteractableFollowAction followCachedAction
```

#### meshColliderTriggerStates

A collection of trigger states for the colliders held within the [MeshContainer].

##### Declaration

```
protected Dictionary<Collider, bool> meshColliderTriggerStates
```

#### meshRendererEnabledStates

A collection of enabled states for the renderers held within the [MeshContainer].

##### Declaration

```
protected Dictionary<Renderer, bool> meshRendererEnabledStates
```

### Properties

#### ActiveCollisions

The linked GameObjectObservableList.

##### Declaration

```
public GameObjectObservableList ActiveCollisions { get; set; }
```

#### AddCollisionExtractor

The linked NotifierContainerExtractor for adding collisions.

##### Declaration

```
public NotifierContainerExtractor AddCollisionExtractor { get; set; }
```

#### CollisionNotifier

The linked [CollisionNotifier].

##### Declaration

```
public CollisionNotifier CollisionNotifier { get; set; }
```

#### ConsumerContainer

The overall container for the interactable consumers.

##### Declaration

```
public GameObject ConsumerContainer { get; set; }
```

#### ConsumerRigidbody

The Rigidbody for the overall collisions.

##### Declaration

```
public Rigidbody ConsumerRigidbody { get; set; }
```

#### DisallowedGrabInteractors

The rule to determine what is not allowed to grab this interactable.

##### Declaration

```
public RuleContainer DisallowedGrabInteractors { get; set; }
```

#### DisallowedTouchInteractors

The rule to determine what is not allowed to touch this interactable.

##### Declaration

```
public RuleContainer DisallowedTouchInteractors { get; set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractableFacade Facade { get; set; }
```

#### GrabActionTypesCount

The total number of available grab action types.

##### Declaration

```
public virtual int GrabActionTypesCount { get; }
```

#### GrabConfiguration

The linked Grab Internal Setup.

##### Declaration

```
public GrabInteractableConfigurator GrabConfiguration { get; set; }
```

#### InteractableVisibilityStatusTagContainer

The linked Interactable Visibility Status Tag.

##### Declaration

```
public InteractableVisibilityStatusTag InteractableVisibilityStatusTagContainer { get; set; }
```

#### IsVisible

Whether the Interactable is visible or not.

##### Declaration

```
public virtual bool IsVisible { get; set; }
```

#### MeshContainer

The GameObject that contains the mesh for the Interactable.

##### Declaration

```
public GameObject MeshContainer { get; set; }
```

#### RemoveCollisionExtractor

The linked NotifierContainerExtractor for removing collisions.

##### Declaration

```
public NotifierContainerExtractor RemoveCollisionExtractor { get; set; }
```

#### TouchConfiguration

The linked Touch Internal Setup.

##### Declaration

```
public TouchInteractableConfigurator TouchConfiguration { get; set; }
```

### Methods

#### CacheAndDisableGrabState()

Caches the existing grab state of the [GrabConfiguration] and hides the GameObject to prevent grab logic.

##### Declaration

```
protected virtual void CacheAndDisableGrabState()
```

#### CacheAndSetConsumerRigidbodyKinematicState()

Caches the existing Tilia.Interactions.Interactables.Interactables.InteractableConfigurator.consumerRigidbody kinematic state and sets it to kinematic.

##### Declaration

```
protected virtual void CacheAndSetConsumerRigidbodyKinematicState()
```

#### ClearConsumerContainer()

Clears [ConsumerContainer].

##### Declaration

```
public virtual void ClearConsumerContainer()
```

#### ClearConsumerRigidbody()

Clears [ConsumerRigidbody].

##### Declaration

```
public virtual void ClearConsumerRigidbody()
```

#### ClearDisallowedGrabInteractors()

Clears [DisallowedGrabInteractors].

##### Declaration

```
public virtual void ClearDisallowedGrabInteractors()
```

#### ClearDisallowedTouchInteractors()

Clears [DisallowedTouchInteractors].

##### Declaration

```
public virtual void ClearDisallowedTouchInteractors()
```

#### ConfigureContainer()

Configures any container data to the sub setup components.

##### Declaration

```
protected virtual void ConfigureContainer()
```

#### CreateGrabAction(GrabInteractableAction, Int32, Int32)

Creates a grab action for the given type.

##### Declaration

```
protected virtual GrabInteractableAction CreateGrabAction(GrabInteractableAction currentAction, int newActionType, int siblingPosition)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [GrabInteractableAction] | currentAction | The current action. |
| System.Int32 | newActionType | The new action type to create. |
| System.Int32 | siblingPosition | The position the action should take in the hierarcy. |

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | The created Grab Action. |

#### DisableCollidersAndRenderers()

Hides all of the found Collider and Renderer components in the [MeshContainer] and saves their current state for later restore.

##### Declaration

```
protected virtual void DisableCollidersAndRenderers()
```

#### GetGrabActionTypeObject(Int32)

Gets the GameObject for the given Grab Action Type index.

##### Declaration

```
public virtual GameObject GetGrabActionTypeObject(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index to attempt to get. |

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The found GameObject for the given index type. |

#### GetGrabActionTypeObject(InteractableFactory.ActionType)

Gets the GameObject for the given Grab [InteractableFactory.ActionType].

##### Declaration

```
public virtual GameObject GetGrabActionTypeObject(InteractableFactory.ActionType type)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFactory.ActionType] | type | The action type to attempt to get. |

##### Returns

| Type | Description |
| --- | --- |
| GameObject | The GameObject for the given action type. |

#### GetPrimaryAction()

Gets the current grab configuration primary action.

##### Declaration

```
public virtual GrabInteractableAction GetPrimaryAction()
```

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | The current primary action. |

#### GetSecondaryAction()

Gets the current grab configuration secondary action.

##### Declaration

```
public virtual GrabInteractableAction GetSecondaryAction()
```

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | The current secondary action. |

#### HandleHiddenLastUngrab(InteractorFacade)

Deals with when a hidden object is last ungrabbed to ensure the kinematic state is correct.

##### Declaration

```
protected virtual void HandleHiddenLastUngrab(InteractorFacade _)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | \_ | unused. |

#### IsGrabConfigurationSet()

Determines whether the grab configuration is set.

##### Declaration

```
public virtual bool IsGrabConfigurationSet()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the grab configuration is set. |

#### OnAfterConsumerContainerChange()

Called after [ConsumerContainer] has been changed.

##### Declaration

```
protected virtual void OnAfterConsumerContainerChange()
```

#### OnAfterConsumerRigidbodyChange()

Called after [ConsumerRigidbody] has been changed.

##### Declaration

```
protected virtual void OnAfterConsumerRigidbodyChange()
```

#### OnAfterDisallowedGrabInteractorsChange()

Called after [DisallowedGrabInteractors] has been changed.

##### Declaration

```
protected virtual void OnAfterDisallowedGrabInteractorsChange()
```

#### OnAfterDisallowedTouchInteractorsChange()

Called after [DisallowedTouchInteractors] has been changed.

##### Declaration

```
protected virtual void OnAfterDisallowedTouchInteractorsChange()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### RestoreCollidersAndRenderers()

Restores all of the current saved states for the found Collider and Renderer components found in the [MeshContainer].

##### Declaration

```
protected virtual void RestoreCollidersAndRenderers()
```

#### RestoreConsumerRigidbodyKinematicStateFromCache()

Restores the kinematic state of the Tilia.Interactions.Interactables.Interactables.InteractableConfigurator.consumerRigidbody to the cached state.

##### Declaration

```
protected virtual void RestoreConsumerRigidbodyKinematicStateFromCache()
```

#### RestoreGrabStateFromCache()

Restores the grab state of the [GrabConfiguration] and applies the active state to the GameObject from the cached state.

##### Declaration

```
protected virtual void RestoreGrabStateFromCache()
```

#### SetFollowAndControlDirectionPair()

Sets up the relevant linkages if the follow and control direction actions are selected in a pairing.

##### Declaration

```
protected virtual void SetFollowAndControlDirectionPair()
```

#### SetFollowPrecisionPointToDirectionModifierPivot(GameObject)

Sets up the link between the primary [GrabInteractableFollowAction] and the secondary [GrabInteractableControlDirectionAction] to mirror the follow precision point to the control direction pivot.

##### Declaration

```
protected virtual void SetFollowPrecisionPointToDirectionModifierPivot(GameObject precisionPointContainer)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | precisionPointContainer | The precision point container. |

#### SetRigidbodyMaxAngularVelocity(Single)

Sets the Maximum Angular Velocity of the Rigidbody in radians per seconds.

##### Declaration

```
public virtual void SetRigidbodyMaxAngularVelocity(float angularVelocity)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | angularVelocity | The maximum angular velocity in radians per seconds. |

#### UnsetFollowPrecisionPointToDirectionModifierPivot(GameObject)

Unsets the set up done in the [SetFollowPrecisionPointToDirectionModifierPivot(GameObject)] method.

##### Declaration

```
protected virtual void UnsetFollowPrecisionPointToDirectionModifierPivot(GameObject precisionPointContainer)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | precisionPointContainer | The precision point container. |

#### UpdatePrimaryAction(Int32)

Updates the primary grab action to the given type index.

##### Declaration

```
public virtual GrabInteractableAction UpdatePrimaryAction(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The grab action type index. |

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | The new grab action. |

#### UpdatePrimaryAction(InteractableFactory.ActionType)

Updates the primary grab action to the given type.

##### Declaration

```
public virtual GrabInteractableAction UpdatePrimaryAction(InteractableFactory.ActionType type)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFactory.ActionType] | type | The grab action type. |

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | The new grab action. |

#### UpdateSecondaryAction(Int32)

Updates the secondary grab action to the given type index.

##### Declaration

```
public virtual GrabInteractableAction UpdateSecondaryAction(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The grab action type index. |

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | The new grab action. |

#### UpdateSecondaryAction(InteractableFactory.ActionType)

Updates the secondary grab action to the given type.

##### Declaration

```
public virtual GrabInteractableAction UpdateSecondaryAction(InteractableFactory.ActionType type)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFactory.ActionType] | type | The grab action type. |

##### Returns

| Type | Description |
| --- | --- |
| [GrabInteractableAction] | The new grab action. |

[Tilia.Interactions.Interactables.Interactables]: README.md
[GrabInteractableControlDirectionAction]: Grab/Action/GrabInteractableControlDirectionAction.md
[GrabInteractableFollowAction]: Grab/Action/GrabInteractableFollowAction.md
[MeshContainer]: InteractableConfigurator.md#MeshContainer
[MeshContainer]: InteractableConfigurator.md#MeshContainer
[CollisionNotifier]: InteractableConfigurator.md#CollisionNotifier
[InteractableFacade]: InteractableFacade.md
[GrabInteractableConfigurator]: Grab/GrabInteractableConfigurator.md
[InteractableVisibilityStatusTag]: ComponentTags/InteractableVisibilityStatusTag.md
[TouchInteractableConfigurator]: Touch/TouchInteractableConfigurator.md
[GrabConfiguration]: InteractableConfigurator.md#GrabConfiguration
[ConsumerContainer]: InteractableConfigurator.md#ConsumerContainer
[ConsumerRigidbody]: InteractableConfigurator.md#ConsumerRigidbody
[DisallowedGrabInteractors]: InteractableConfigurator.md#DisallowedGrabInteractors
[DisallowedTouchInteractors]: InteractableConfigurator.md#DisallowedTouchInteractors
[GrabInteractableAction]: Grab/Action/GrabInteractableAction.md
[MeshContainer]: InteractableConfigurator.md#MeshContainer
[InteractableFactory.ActionType]: Utility/InteractableFactory.ActionType.md
[InteractorFacade]: ../Interactors/InteractorFacade.md
[ConsumerContainer]: InteractableConfigurator.md#ConsumerContainer
[ConsumerRigidbody]: InteractableConfigurator.md#ConsumerRigidbody
[DisallowedGrabInteractors]: InteractableConfigurator.md#DisallowedGrabInteractors
[DisallowedTouchInteractors]: InteractableConfigurator.md#DisallowedTouchInteractors
[MeshContainer]: InteractableConfigurator.md#MeshContainer
[GrabConfiguration]: InteractableConfigurator.md#GrabConfiguration
[SetFollowPrecisionPointToDirectionModifierPivot(GameObject)]: InteractableConfigurator.md#SetFollowPrecisionPointToDirectionModifierPivot_GameObject_
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedGrabAllowanceState]: #cachedGrabAllowanceState
[cachedKinematicState]: #cachedKinematicState
[controlDirectionCachedAction]: #controlDirectionCachedAction
[followCachedAction]: #followCachedAction
[meshColliderTriggerStates]: #meshColliderTriggerStates
[meshRendererEnabledStates]: #meshRendererEnabledStates
[Properties]: #Properties
[ActiveCollisions]: #ActiveCollisions
[AddCollisionExtractor]: #AddCollisionExtractor
[CollisionNotifier]: #CollisionNotifier
[ConsumerContainer]: #ConsumerContainer
[ConsumerRigidbody]: #ConsumerRigidbody
[DisallowedGrabInteractors]: #DisallowedGrabInteractors
[DisallowedTouchInteractors]: #DisallowedTouchInteractors
[Facade]: #Facade
[GrabActionTypesCount]: #GrabActionTypesCount
[GrabConfiguration]: #GrabConfiguration
[InteractableVisibilityStatusTagContainer]: #InteractableVisibilityStatusTagContainer
[IsVisible]: #IsVisible
[MeshContainer]: #MeshContainer
[RemoveCollisionExtractor]: #RemoveCollisionExtractor
[TouchConfiguration]: #TouchConfiguration
[Methods]: #Methods
[CacheAndDisableGrabState()]: #CacheAndDisableGrabState
[CacheAndSetConsumerRigidbodyKinematicState()]: #CacheAndSetConsumerRigidbodyKinematicState
[ClearConsumerContainer()]: #ClearConsumerContainer
[ClearConsumerRigidbody()]: #ClearConsumerRigidbody
[ClearDisallowedGrabInteractors()]: #ClearDisallowedGrabInteractors
[ClearDisallowedTouchInteractors()]: #ClearDisallowedTouchInteractors
[ConfigureContainer()]: #ConfigureContainer
[CreateGrabAction(GrabInteractableAction, Int32, Int32)]: #CreateGrabActionGrabInteractableAction-Int32-Int32
[DisableCollidersAndRenderers()]: #DisableCollidersAndRenderers
[GetGrabActionTypeObject(Int32)]: #GetGrabActionTypeObjectInt32
[GetGrabActionTypeObject(InteractableFactory.ActionType)]: #GetGrabActionTypeObjectInteractableFactory.ActionType
[GetPrimaryAction()]: #GetPrimaryAction
[GetSecondaryAction()]: #GetSecondaryAction
[HandleHiddenLastUngrab(InteractorFacade)]: #HandleHiddenLastUngrabInteractorFacade
[IsGrabConfigurationSet()]: #IsGrabConfigurationSet
[OnAfterConsumerContainerChange()]: #OnAfterConsumerContainerChange
[OnAfterConsumerRigidbodyChange()]: #OnAfterConsumerRigidbodyChange
[OnAfterDisallowedGrabInteractorsChange()]: #OnAfterDisallowedGrabInteractorsChange
[OnAfterDisallowedTouchInteractorsChange()]: #OnAfterDisallowedTouchInteractorsChange
[OnEnable()]: #OnEnable
[RestoreCollidersAndRenderers()]: #RestoreCollidersAndRenderers
[RestoreConsumerRigidbodyKinematicStateFromCache()]: #RestoreConsumerRigidbodyKinematicStateFromCache
[RestoreGrabStateFromCache()]: #RestoreGrabStateFromCache
[SetFollowAndControlDirectionPair()]: #SetFollowAndControlDirectionPair
[SetFollowPrecisionPointToDirectionModifierPivot(GameObject)]: #SetFollowPrecisionPointToDirectionModifierPivotGameObject
[SetRigidbodyMaxAngularVelocity(Single)]: #SetRigidbodyMaxAngularVelocitySingle
[UnsetFollowPrecisionPointToDirectionModifierPivot(GameObject)]: #UnsetFollowPrecisionPointToDirectionModifierPivotGameObject
[UpdatePrimaryAction(Int32)]: #UpdatePrimaryActionInt32
[UpdatePrimaryAction(InteractableFactory.ActionType)]: #UpdatePrimaryActionInteractableFactory.ActionType
[UpdateSecondaryAction(Int32)]: #UpdateSecondaryActionInt32
[UpdateSecondaryAction(InteractableFactory.ActionType)]: #UpdateSecondaryActionInteractableFactory.ActionType
