namespace Tilia.Interactions.Interactables.Interactors.Operation.Extraction
{
    using UnityEngine;

    /// <summary>
    /// Extracts the precision grab attach point <see cref="GameObject"/> from an <see cref="InteractorFacade"/>.
    /// </summary>
    public class InteractorPrecisionPointExtractor : InteractorAttachPointExtractor
    {
        /// <inheritdoc />
        protected override GameObject GetValue(InteractorFacade interactorSource)
        {
            return interactorSource.PrecisionAttachPoint;
        }
    }
}