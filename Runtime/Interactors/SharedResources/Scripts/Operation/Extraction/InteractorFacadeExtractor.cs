namespace Tilia.Interactions.Interactables.Interactors.Operation.Extraction
{
    using System;
    using UnityEngine.Events;
    using Zinnia.Data.Operation.Extraction;
    using Zinnia.Extension;

    /// <summary>
    /// Extracts and emits the <see cref="InteractorFacade"/> found in relation to the <see cref="Source"/>.
    /// </summary>
    public class InteractorFacadeExtractor : ComponentExtractor<InteractorFacade, InteractorFacadeExtractor.UnityEvent, InteractorFacade>
    {
        /// <summary>
        /// Defines the event with the specified <see cref="InteractorFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractorFacade>
        {
        }

        /// <inheritdoc />
        protected override InteractorFacade ExtractValue()
        {
            return Source != null
                ? Source.gameObject.TryGetComponent<InteractorFacade>(
                    (SearchAlsoOn & SearchCriteria.IncludeDescendants) != 0,
                    (SearchAlsoOn & SearchCriteria.IncludeAncestors) != 0)
                : null;
        }

        /// <inheritdoc/>
        protected override bool InvokeResult(InteractorFacade data)
        {
            return InvokeEvent(data);
        }
    }
}