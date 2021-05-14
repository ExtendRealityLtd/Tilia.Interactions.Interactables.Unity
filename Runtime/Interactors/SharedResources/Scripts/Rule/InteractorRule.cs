namespace Tilia.Interactions.Interactables.Interactors.Rule
{
    using UnityEngine;
    using Zinnia.Rule;

    /// <summary>
    /// Simplifies implementing <see cref="IRule"/>s that only deals with an <see cref="InteractorRule"/> attached to a <see cref="GameObject"/>.
    /// </summary>
    public abstract class InteractorRule : GameObjectRule
    {
        /// <summary>
        /// A cache to store the given <see cref="GameObject"/> to prevent having to re execute the <see cref="GameObject.GetComponent{T}"/> method on the same given <see cref="GameObject"/>.
        /// </summary>
        protected GameObject cachedGameObject;
        /// <summary>
        /// The cached <see cref="InteractorFacade"/> to check the grabbed state on.
        /// </summary>
        protected InteractorFacade cachedInteractor;

        /// <summary>
        /// Determines whether a <see cref="InteractorFacade"/> is accepted.
        /// </summary>
        /// <param name="interactor">The <see cref="InteractorFacade"/> to check.</param>
        /// <returns><see langword="true"/> if <paramref name="targetInteractorFacade"/> is accepted, <see langword="false"/> otherwise.</returns>
        protected abstract bool Accepts(InteractorFacade targetInteractorFacade);

        /// <inheritdoc />
        protected override bool Accepts(GameObject targetGameObject)
        {
            if (cachedGameObject != targetGameObject || cachedInteractor == null)
            {
                cachedInteractor = targetGameObject.GetComponent<InteractorFacade>();
                if (cachedInteractor != null)
                {
                    cachedGameObject = targetGameObject;
                }
            }

            if (cachedInteractor == null)
            {
                return false;
            }

            return Accepts(cachedInteractor);
        }
    }
}