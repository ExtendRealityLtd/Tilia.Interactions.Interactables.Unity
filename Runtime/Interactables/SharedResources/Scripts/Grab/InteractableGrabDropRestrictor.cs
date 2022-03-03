namespace Tilia.Interactions.Interactables.Interactables.Grab
{
    using UnityEngine;

    /// <summary>
    /// Restricts the ability to drop a grabbed <see cref="InteractableFacade"/>.
    /// </summary>
    public class InteractableGrabDropRestrictor : MonoBehaviour
    {
        /// <summary>
        /// Disables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to disable on.</param>
        public virtual void DoDisableDrop(GameObject interactable)
        {
            DisableDrop(interactable);
        }

        /// <summary>
        /// Enables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to enable on.</param>
        public virtual void DoEnableDrop(GameObject interactable)
        {
            EnableDrop(interactable);
        }

        /// <summary>
        /// Disables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to disable on.</param>
        public virtual void DoDisableDrop(InteractableFacade interactable)
        {
            DisableDrop(interactable);
        }

        /// <summary>
        /// Enables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to enable on.</param>
        public virtual void DoEnableDrop(InteractableFacade interactable)
        {
            DoEnableDrop(interactable);
        }

        /// <summary>
        /// Disables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to disable on.</param>
        /// <returns>Whether the drop was disabled.</returns>
        public static bool DisableDrop(GameObject interactable)
        {
            if (interactable == null)
            {
                return false;
            }

            return DisableDrop(interactable.GetComponent<InteractableFacade>());
        }

        /// <summary>
        /// Enables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to enable on.</param>
        /// <returns>Whether the drop was enabled.</returns>
        public static bool EnableDrop(GameObject interactable)
        {
            if (interactable == null)
            {
                return false;
            }

            return EnableDrop(interactable.GetComponent<InteractableFacade>());
        }

        /// <summary>
        /// Disables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to disable on.</param>
        /// <returns>Whether the drop was disabled.</returns>
        public static bool DisableDrop(InteractableFacade interactable)
        {
            if (interactable == null || interactable.GrabbingInteractors.Count == 0)
            {
                return false;
            }

            interactable.DisableGrabReceiver();
            return true;
        }

        /// <summary>
        /// Enables the drop on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to enable on.</param>
        /// <returns>Whether the drop was enabled.</returns>
        public static bool EnableDrop(InteractableFacade interactable)
        {
            if (interactable == null)
            {
                return false;
            }

            interactable.EnableGrabReceiver();
            return true;
        }
    }
}