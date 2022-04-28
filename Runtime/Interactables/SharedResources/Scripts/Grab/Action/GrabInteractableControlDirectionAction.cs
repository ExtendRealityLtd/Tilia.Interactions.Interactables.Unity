namespace Tilia.Interactions.Interactables.Interactables.Grab.Action
{
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Tracking.Modification;

    /// <summary>
    /// Describes an action that allows the Interactable to point in the direction of a given Interactor.
    /// </summary>
    public class GrabInteractableControlDirectionAction : GrabInteractableAction
    {
        #region Interactable Settings
        [Header("Interactable Settings")]
        [Tooltip("A GameObject collection to enable/disabled as part of the direction control process.")]
        [SerializeField]
        private GameObjectObservableList linkedObjects;
        /// <summary>
        /// A <see cref="GameObject"/> collection to enable/disabled as part of the direction control process.
        /// </summary>
        public GameObjectObservableList LinkedObjects
        {
            get
            {
                return linkedObjects;
            }
            set
            {
                linkedObjects = value;
            }
        }
        [Tooltip("The Zinnia.Tracking.Modification.DirectionModifier to process the direction control.")]
        [SerializeField]
        [Restricted]
        private DirectionModifier directionModifier;
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Modification.DirectionModifier"/> to process the direction control.
        /// </summary>
        public DirectionModifier DirectionModifier
        {
            get
            {
                return directionModifier;
            }
            protected set
            {
                directionModifier = value;
            }
        }
        #endregion

        /// <summary>
        /// Enables the <see cref="GameObject"/> state of each of the items in the <see cref="LinkedObjects"/> collection.
        /// </summary>
        public virtual void EnableLinkedObjects()
        {
            ToggleLinkedObjectState(true);
        }

        /// <summary>
        /// Disables the <see cref="GameObject"/> state of each of the items in the <see cref="LinkedObjects"/> collection.
        /// </summary>
        public virtual void DisableLinkedObjects()
        {
            ToggleLinkedObjectState(false);
        }

        /// <summary>
        /// Sets up the <see cref="DirectionModifier.TargetOffset"/> based on the target offsets from any follow action.
        /// </summary>
        public virtual void SetupTargetOffset()
        {
            if (GrabSetup == null)
            {
                return;
            }

            if (GrabSetup.SecondaryAction == this)
            {
                LinkTargetOffsets(GrabSetup.PrimaryAction);
            }
            else if (GrabSetup.PrimaryAction == this)
            {
                LinkTargetOffsets(GrabSetup.SecondaryAction);
            }
        }

        /// <summary>
        /// Links the given action's target offset to the <see cref="DirectionModifier.TargetOffset"/> if the action is a Follow Action.
        /// </summary>
        /// <param name="action">The action to try and link from.</param>
        protected virtual void LinkTargetOffsets(GrabInteractableAction action)
        {
            if (!typeof(GrabInteractableFollowAction).IsAssignableFrom(action.GetType()))
            {
                return;
            }

            GrabInteractableFollowAction followAction = (GrabInteractableFollowAction)action;

            if (followAction == null || followAction.ObjectFollower == null || followAction.ObjectFollower.TargetOffsets == null)
            {
                return;
            }

            DirectionModifier.TargetOffset = followAction.ObjectFollower.TargetOffsets.NonSubscribableElements.Count > 0 ? followAction.ObjectFollower.TargetOffsets.NonSubscribableElements[0] : null;
            DirectionModifier.PivotOffset = DirectionModifier.TargetOffset != null && DirectionModifier.TargetOffset.transform.childCount > 0 ? DirectionModifier.TargetOffset.transform.GetChild(0).gameObject : null;
        }

        /// <summary>
        /// Toggles the <see cref="GameObject"/> state of each of the items in the <see cref="LinkedObjects"/> collection.
        /// </summary>
        /// <param name="state">The state to set the <see cref="GameObject"/> active state to.</param>
        protected virtual void ToggleLinkedObjectState(bool state)
        {
            if (LinkedObjects == null)
            {
                return;
            }

            foreach (GameObject linkedObject in LinkedObjects.NonSubscribableElements)
            {
                linkedObject.SetActive(state);
            }
        }

        /// <inheritdoc />
        protected override void OnAfterGrabSetupChange()
        {
            DirectionModifier.Target = GrabSetup.Facade.Configuration.ConsumerContainer;
        }
    }
}