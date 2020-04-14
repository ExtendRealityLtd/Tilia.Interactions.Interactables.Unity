namespace Tilia.Interactions.Interactables.Interactors.Operation.Extraction
{
    using System;
    using UnityEngine;
    using Zinnia.Data.Operation.Extraction;

    /// <summary>
    /// Extracts a <see cref="GameObject"/> relevant to the extraction method from an <see cref="InteractorFacade"/>.
    /// </summary>
    public class InteractorExtractor : ComponentGameObjectExtractor
    {
        /// <summary>
        /// The cached Grab Attach Point if trying to Extract Attach Point;
        /// </summary>
        protected GameObject cachedGrabAttachPoint;

        /// <summary>
        /// Extracts the attach point associated with the grabbing functionality of the Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to extract from.</param>
        /// <returns>The attach point.</returns>
        [Obsolete("Use `InteractorAttachPointExtractor.Extract()` instead.")]
        public virtual GameObject ExtractAttachPoint(InteractorFacade interactor)
        {
            Debug.LogWarning("`InteractorExtractor.ExtractAttachPoint()` has been deprecated. Use `InteractorAttachPointExtractor.Extract()` instead.", gameObject);

            if (interactor == null || interactor.GrabConfiguration == null)
            {
                Result = null;
                return null;
            }

            cachedGrabAttachPoint = interactor.GrabAttachPoint;
            return base.Extract();
        }

        /// <summary>
        /// Extracts the attach point associated with the grabbing functionality of the Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to extract from.</param>
        [Obsolete("Use `InteractorAttachPointExtractor -> DoExtract` instead.")]
        public virtual void DoExtractAttachPoint(InteractorFacade interactor)
        {
            ExtractAttachPoint(interactor);
        }

        /// <summary>
        /// Extracts the attach point associated with the grabbing functionality of the Interactor.
        /// </summary>
        /// <param name="interactorContainer">The container that has an <see cref="InteractorFacade"/> component to extract from.</param>
        /// <returns>The attach point.</returns>
        [Obsolete("Use `InteractorAttachPointExtractor -> Extract` instead.")]
        public virtual GameObject ExtractAttachPoint(GameObject interactorContainer)
        {
            return ExtractAttachPoint(interactorContainer.GetComponent<InteractorFacade>());
        }

        /// <summary>
        /// Extracts the attach point associated with the grabbing functionality of the Interactor.
        /// </summary>
        /// <param name="interactorContainer">The container that has an <see cref="InteractorFacade"/> component to extract from.</param>
        [Obsolete("Use `InteractorAttachPointExtractor -> DoExtract` instead.")]
        public virtual void DoExtractAttachPoint(GameObject interactorContainer)
        {
            ExtractAttachPoint(interactorContainer);
        }

        /// <inheritdoc />
        protected override GameObject ExtractValue()
        {
            if (cachedGrabAttachPoint != null)
            {
                GameObject toReturn = cachedGrabAttachPoint;
                cachedGrabAttachPoint = null;
                return toReturn;
            }

            return Source.GetType() == typeof(InteractorFacade) ? base.ExtractValue() : null;
        }
    }
}