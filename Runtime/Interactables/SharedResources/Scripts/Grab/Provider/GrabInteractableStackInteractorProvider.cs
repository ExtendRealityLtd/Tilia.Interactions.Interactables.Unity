namespace Tilia.Interactions.Interactables.Interactables.Grab.Provider
{
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.Stack;

    /// <summary>
    /// Processes a received grab event into an Observable Stack to handle multiple output options for each grab type.
    /// </summary>
    public class GrabInteractableStackInteractorProvider : GrabInteractableInteractorProvider
    {
        #region Stack Settings
        [Header("Stack Settings")]
        [Tooltip("The stack to get the current interactors from.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableStack eventStack;
        /// <summary>
        /// The stack to get the current interactors from.
        /// </summary>
        public GameObjectObservableStack EventStack
        {
            get
            {
                return eventStack;
            }
            set
            {
                eventStack = value;
            }
        }
        [Tooltip("The container that holds the logic for attempting to swap the stacks on force pop.")]
        [SerializeField]
        [Restricted]
        private GameObject attemptSwapLogicContainer;
        /// <summary>
        /// The container that holds the logic for attempting to swap the stacks on force pop.
        /// </summary>
        public GameObject AttemptSwapLogicContainer
        {
            get
            {
                return attemptSwapLogicContainer;
            }
            set
            {
                attemptSwapLogicContainer = value;
            }
        }
        #endregion

        /// <inheritdoc />
        public override IReadOnlyList<InteractorFacade> GrabbingInteractors => GetGrabbingInteractors(EventStack.Stack);
    }
}