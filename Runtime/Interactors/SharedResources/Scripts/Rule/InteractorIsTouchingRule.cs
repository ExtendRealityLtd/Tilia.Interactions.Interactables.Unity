namespace Tilia.Interactions.Interactables.Interactors.Rule
{
    /// <summary>
    /// Determines whether the Interactor is currently touching something.
    /// </summary>
    public class InteractorIsTouchingRule : InteractorRule
    {
        /// <inheritdoc />
        protected override bool Accepts(InteractorFacade targetInteractorFacade)
        {
            return targetInteractorFacade.TouchedObjects.Count > 0;
        }
    }
}