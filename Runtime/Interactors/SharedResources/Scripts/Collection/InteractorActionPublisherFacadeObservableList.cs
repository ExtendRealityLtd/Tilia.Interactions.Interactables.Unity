namespace Tilia.Interactions.Interactables.Interactors.Collection
{
    using System;
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine.Events;
    using Zinnia.Data.Collection.List;

    /// <summary>
    /// Allows observing changes to a <see cref="List{T}"/> of <see cref="InteractorActionPublisherFacade"/>s.
    /// </summary>
    public class InteractorActionPublisherFacadeObservableList : DefaultObservableList<InteractorActionPublisherFacade, InteractorActionPublisherFacadeObservableList.UnityEvent>
    {
        /// <summary>
        /// Defines the event with the <see cref="InteractorActionPublisherFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractorActionPublisherFacade>
        {
        }
    }
}
