namespace Tilia.Interactions.Interactables.Interactables.Operation.Extraction
{
    using UnityEngine;
    using Zinnia.Data.Operation.Extraction;

    /// <summary>
    /// Extracts the <see cref="GameObject"/> of the <see cref="InteractableFacade.ConsumerRigidbody"/>.
    /// </summary>
    public class InteractableConsumerRigidbodyExtractor : ComponentGameObjectExtractor
    {
        /// <inheritdoc />
        protected override GameObject ExtractValue()
        {
            if (Source.GetType() != typeof(InteractableFacade))
            {
                return null;
            }

            InteractableFacade interactableSource = (InteractableFacade)Source;
            return interactableSource != null && interactableSource.Configuration != null && interactableSource.Configuration.ConsumerRigidbody != null
                ? interactableSource.Configuration.ConsumerRigidbody.gameObject
                : null;
        }
    }
}