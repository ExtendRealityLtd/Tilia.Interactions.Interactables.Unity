namespace Tilia.Interactions.Interactables.Interactables.Operation.Extraction
{
    using System;
    using UnityEngine.Events;
    using Zinnia.Data.Operation.Extraction;
    using Zinnia.Extension;

    /// <summary>
    /// Extracts and emits the <see cref="InteractableFacade"/> found in relation to the <see cref="Source"/>.
    /// </summary>
    public class InteractableFacadeExtractor : ComponentExtractor<InteractableFacade, InteractableFacadeExtractor.UnityEvent, InteractableFacade>
    {
        /// <summary>
        /// Defines the event with the specified <see cref="InteractableFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractableFacade> { }

        /// <inheritdoc />
        protected override InteractableFacade ExtractValue()
        {
            return Source != null
                ? Source.gameObject.TryGetComponent<InteractableFacade>(
                    (SearchAlsoOn & SearchCriteria.IncludeDescendants) != 0,
                    (SearchAlsoOn & SearchCriteria.IncludeAncestors) != 0)
                : null;
        }

        /// <inheritdoc/>
        protected override bool InvokeResult(InteractableFacade data)
        {
            return InvokeEvent(data);
        }
    }
}