# Class InteractableActionReceiverConfigurator

Sets up the Interactor Action Receiver Prefab action settings based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [defaultParent]
* [Properties]
  * [ActionRegistrar]
  * [Facade]
  * [ReceiveStartActionRule]
  * [ReceiveStopActionRule]
  * [StartActionConsumer]
  * [StopActionConsumer]
  * [TargetActions]
* [Methods]
  * [ActivateOutputAction(Type)]
  * [Awake()]
  * [ClearPublisherSetup()]
  * [DisableFirstTouchedOnActionRegistrar(InteractorFacade)]
  * [EnableFirstTouchedOnActionRegistrar(InteractorFacade)]
  * [IsValidPublisherElement(Object, Object, String)]
  * [LinkInteractableToConsumers()]
  * [NotifyActivated(GameObject)]
  * [NotifyDeactivated(GameObject)]
  * [OnDisable()]
  * [OnEnable()]
  * [ProcessPublisher(InteractorActionPublisherFacade, ref Type)]
  * [ProcessPublisherList()]
  * [RegisterInteractableEvents(InteractableFacade, InteractableActionReceiverFacade.InteractionState)]
  * [SetupPublisherLinks(InteractorActionPublisherFacade)]
  * [UnregisterInteractableEvents(InteractableFacade, InteractableActionReceiverFacade.InteractionState)]

## Details

##### Inheritance

* System.Object
* InteractableActionReceiverConfigurator

##### Namespace

* [Tilia.Interactions.Interactables.Interactables]

##### Syntax

```
public class InteractableActionReceiverConfigurator : MonoBehaviour
```

### Fields

#### defaultParent

The parent Transform to child the [InteractableActionReceiverFacade] by default.

##### Declaration

```
protected Transform defaultParent
```

### Properties

#### ActionRegistrar

The [ActionRegistrar] to create the appropriate action links.

##### Declaration

```
public ActionRegistrar ActionRegistrar { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractableActionReceiverFacade Facade { get; protected set; }
```

#### ReceiveStartActionRule

The ListContainsRule for the start action.

##### Declaration

```
public ListContainsRule ReceiveStartActionRule { get; protected set; }
```

#### ReceiveStopActionRule

The ListContainsRule for the stop action.

##### Declaration

```
public ListContainsRule ReceiveStopActionRule { get; protected set; }
```

#### StartActionConsumer

The ActiveCollisionConsumer for checking valid start action.

##### Declaration

```
public ActiveCollisionConsumer StartActionConsumer { get; protected set; }
```

#### StopActionConsumer

The ActiveCollisionConsumer for checking valid stop action.

##### Declaration

```
public ActiveCollisionConsumer StopActionConsumer { get; protected set; }
```

#### TargetActions

The ActionObservableList that containts the Zinnia.Action.Action collection that can be linked to the InteractorActionFacade.SourceAction.

##### Declaration

```
public ActionObservableList TargetActions { get; protected set; }
```

### Methods

#### ActivateOutputAction(Type)

Activates the correct output Zinnia.Action.Action based on the linked Zinnia.Action.Action from the publisher.

##### Declaration

```
protected virtual void ActivateOutputAction(Type actionType)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Type | actionType | The Zinnia.Action.Action type to activate. |

#### Awake()

##### Declaration

```
protected virtual void Awake()
```

#### ClearPublisherSetup()

Clears the publisher setup.

##### Declaration

```
protected virtual void ClearPublisherSetup()
```

#### DisableFirstTouchedOnActionRegistrar(InteractorFacade)

Disables the given [InteractorFacade] on the action registrar.

##### Declaration

```
protected virtual void DisableFirstTouchedOnActionRegistrar(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | interactor | The interactor to disable. |

#### EnableFirstTouchedOnActionRegistrar(InteractorFacade)

Enables the first touched [InteractorFacade] that is touching the [InteractableFacade] on the action registrar.

##### Declaration

```
protected virtual void EnableFirstTouchedOnActionRegistrar(InteractorFacade _)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorFacade] | \_ | Not used |

#### IsValidPublisherElement(Object, Object, String)

Determines if the given publisher element is valid.

##### Declaration

```
protected virtual bool IsValidPublisherElement(object cachedValue, object currentValue, string exceptionMessage)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Object | cachedValue | The cached value to check against. |
| System.Object | currentValue | The current value to check with. |
| System.String | exceptionMessage | The message to display in the exception if the element is not valid. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the given publisher element is valid. |

#### LinkInteractableToConsumers()

Links the InteractorActionFacade.SourceInteractor to the payload source containers on the start and stop publishers.

##### Declaration

```
public virtual void LinkInteractableToConsumers()
```

#### NotifyActivated(GameObject)

Notifies the Activated event on the [Facade].

##### Declaration

```
public virtual void NotifyActivated(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The source Interactor. |

#### NotifyDeactivated(GameObject)

Notifies the Deactivated event on the [Facade].

##### Declaration

```
public virtual void NotifyDeactivated(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The source Interactor. |

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### ProcessPublisher(InteractorActionPublisherFacade, ref Type)

Processes the given publisher data.

##### Declaration

```
protected virtual void ProcessPublisher(InteractorActionPublisherFacade publisher, ref Type previousActionType)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorActionPublisherFacade] | publisher | The publisher to process. |
| System.Type | previousActionType | The previous publisher's action type. |

#### ProcessPublisherList()

Processes the publishers linked in the Facade.SourcePublishers collection.

##### Declaration

```
public virtual void ProcessPublisherList()
```

#### RegisterInteractableEvents(InteractableFacade, InteractableActionReceiverFacade.InteractionState)

Registers the activation/deactivation events for the interactable on the appropraite interactionState.

##### Declaration

```
public virtual void RegisterInteractableEvents(InteractableFacade interactable, InteractableActionReceiverFacade.InteractionState interactionState)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The interactable to register the events on. |
| [InteractableActionReceiverFacade.InteractionState] | interactionState | The interaction state of the interactable to register the events on. |

#### SetupPublisherLinks(InteractorActionPublisherFacade)

Sets up the links from the publisher to the receiver.

##### Declaration

```
protected virtual void SetupPublisherLinks(InteractorActionPublisherFacade publisher)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractorActionPublisherFacade] | publisher | The publisher to link to. |

#### UnregisterInteractableEvents(InteractableFacade, InteractableActionReceiverFacade.InteractionState)

Unregisters the activation/deactivation events for the interactable from the appropraite interactionState.

##### Declaration

```
public virtual void UnregisterInteractableEvents(InteractableFacade interactable, InteractableActionReceiverFacade.InteractionState interactionState)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [InteractableFacade] | interactable | The interactable to unregister the events from. |
| [InteractableActionReceiverFacade.InteractionState] | interactionState | The interaction state of the interactable to unregister the events from. |

[Tilia.Interactions.Interactables.Interactables]: README.md
[ActionRegistrar]: InteractableActionReceiverConfigurator.md#ActionRegistrar
[InteractableActionReceiverFacade]: InteractableActionReceiverFacade.md
[InteractorFacade]: ../Interactors/InteractorFacade.md
[Facade]: InteractableActionReceiverConfigurator.md#Facade
[Facade]: InteractableActionReceiverConfigurator.md#Facade
[InteractorActionPublisherFacade]: ../Interactors/InteractorActionPublisherFacade.md
[InteractableFacade]: InteractableFacade.md
[InteractableActionReceiverFacade.InteractionState]: InteractableActionReceiverFacade.InteractionState.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[defaultParent]: #defaultParent
[Properties]: #Properties
[ActionRegistrar]: #ActionRegistrar
[Facade]: #Facade
[ReceiveStartActionRule]: #ReceiveStartActionRule
[ReceiveStopActionRule]: #ReceiveStopActionRule
[StartActionConsumer]: #StartActionConsumer
[StopActionConsumer]: #StopActionConsumer
[TargetActions]: #TargetActions
[Methods]: #Methods
[ActivateOutputAction(Type)]: #ActivateOutputActionType
[Awake()]: #Awake
[ClearPublisherSetup()]: #ClearPublisherSetup
[DisableFirstTouchedOnActionRegistrar(InteractorFacade)]: #DisableFirstTouchedOnActionRegistrarInteractorFacade
[EnableFirstTouchedOnActionRegistrar(InteractorFacade)]: #EnableFirstTouchedOnActionRegistrarInteractorFacade
[IsValidPublisherElement(Object, Object, String)]: #IsValidPublisherElementObject-Object-String
[LinkInteractableToConsumers()]: #LinkInteractableToConsumers
[NotifyActivated(GameObject)]: #NotifyActivatedGameObject
[NotifyDeactivated(GameObject)]: #NotifyDeactivatedGameObject
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[ProcessPublisher(InteractorActionPublisherFacade, ref Type)]: #ProcessPublisherInteractorActionPublisherFacade-ref Type
[ProcessPublisherList()]: #ProcessPublisherList
[RegisterInteractableEvents(InteractableFacade, InteractableActionReceiverFacade.InteractionState)]: #RegisterInteractableEventsInteractableFacade-InteractableActionReceiverFacade.InteractionState
[SetupPublisherLinks(InteractorActionPublisherFacade)]: #SetupPublisherLinksInteractorActionPublisherFacade
[UnregisterInteractableEvents(InteractableFacade, InteractableActionReceiverFacade.InteractionState)]: #UnregisterInteractableEventsInteractableFacade-InteractableActionReceiverFacade.InteractionState
