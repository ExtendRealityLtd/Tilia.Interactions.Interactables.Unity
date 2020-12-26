namespace Tilia.Interactions.Interactables.Interactors.Operation.Extraction
{
    using UnityEngine;
    using Zinnia.Data.Operation.Extraction;

    /// <summary>
    /// Extracts the grab attach point <see cref="GameObject"/> from an <see cref="InteractorFacade"/>.
    /// </summary>
    public class InteractorAttachPointExtractor : ComponentGameObjectExtractor
    {
        /// <summary>
        /// Extracts the attach point associated with the grabbing functionality of the Interactor.
        /// </summary>
        /// <param name="interactorContainer">The container that has an <see cref="InteractorFacade"/> component to extract from.</param>
        /// <returns>The attach point.</returns>
        public virtual GameObject Extract(GameObject interactorContainer)
        {
            return Extract(interactorContainer.GetComponent<InteractorFacade>());
        }

        /// <summary>
        /// Extracts the attach point associated with the grabbing functionality of the Interactor.
        /// </summary>
        /// <param name="interactorContainer">The container that has an <see cref="InteractorFacade"/> component to extract from.</param>
        public virtual void DoExtract(GameObject interactorContainer)
        {
            Extract(interactorContainer);
        }

        /// <inheritdoc />
        protected override GameObject ExtractValue()
        {
            if (Source.GetType() != typeof(InteractorFacade))
            {
                return null;
            }

            InteractorFacade interactorSource = (InteractorFacade)Source;
            return interactorSource != null && interactorSource.GrabConfiguration != null
                ? GetValue(interactorSource)
                : null;
        }

        /// <summary>
        /// Gets the source to extract.
        /// </summary>
        /// <param name="interactorSource">The Interactor to extract from.</param>
        /// <returns>The grab attach point to return.</returns>
        protected virtual GameObject GetValue(InteractorFacade interactorSource)
        {
            return interactorSource.GrabAttachPoint;
        }
    }
}