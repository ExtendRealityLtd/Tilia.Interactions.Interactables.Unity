namespace Tilia.Interactions.Interactables.Interactors.Collection
{
    using System;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine.Events;
    using Zinnia.Data.Collection.List;

    /// <summary>
    /// Allows observing changes to a <see cref="List{T}"/> of <see cref="InteractorFacade"/>s.
    /// </summary>
    public class InteractorFacadeObservableList : DefaultObservableList<InteractorFacade, InteractorFacadeObservableList.UnityEvent>
    {
        /// <summary>
        /// Defines the event with the <see cref="InteractorFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractorFacade>
        {
        }
    }
}
