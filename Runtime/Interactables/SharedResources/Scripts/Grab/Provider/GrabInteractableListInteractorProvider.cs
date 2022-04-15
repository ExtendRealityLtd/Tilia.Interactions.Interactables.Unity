namespace Tilia.Interactions.Interactables.Interactables.Grab.Provider
{
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;

    /// <summary>
    /// Processes a received grab event into an Observable Set to handle a simplified grab process.
    /// </summary>
    public class GrabInteractableListInteractorProvider : GrabInteractableInteractorProvider
    {
        #region List Settings
        [Header("List Settings")]
        [Tooltip("The set to get the current interactors from.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList eventList;
        /// <summary>
        /// The set to get the current interactors from.
        /// </summary>
        public GameObjectObservableList EventList
        {
            get
            {
                return eventList;
            }
            protected set
            {
                eventList = value;
            }
        }
        #endregion

        /// <inheritdoc />
        public override IReadOnlyList<InteractorFacade> GrabbingInteractors => GetGrabbingInteractors(EventList.NonSubscribableElements);
    }
}