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
            protected set
            {
                eventStack = value;
            }
        }
        #endregion

        /// <inheritdoc />
        public override IReadOnlyList<InteractorFacade> GrabbingInteractors => GetGrabbingInteractors(EventStack.Stack);
    }
}