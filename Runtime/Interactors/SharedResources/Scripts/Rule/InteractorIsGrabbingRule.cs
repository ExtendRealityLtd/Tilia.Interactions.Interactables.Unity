namespace Tilia.Interactions.Interactables.Interactors.Rule
{
    /// <summary>
    /// Determines whether the Interactor is currently grabbing something.
    /// </summary>
    public class InteractorIsGrabbingRule : InteractorRule
    {
        /// <inheritdoc />
        protected override bool Accepts(InteractorFacade targetInteractorFacade)
        {
            return targetInteractorFacade.GrabbedObjects.Count > 0;
        }
    }
}