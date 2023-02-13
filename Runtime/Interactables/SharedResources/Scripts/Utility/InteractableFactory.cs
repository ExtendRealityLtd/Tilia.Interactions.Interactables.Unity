namespace Tilia.Interactions.Interactables.Interactables.Utility
{
    using UnityEngine;

    /// <summary>
    /// A factory for creating an Interactable Object.
    /// </summary>
    public class InteractableFactory
    {
        /// <summary>
        /// The grab action type to be applied to the primary or secondary action.
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// No action is performed.
            /// </summary>
            None,
            /// <summary>
            /// The Interactable will follow the Interactor.
            /// </summary>
            Follow,
            /// <summary>
            /// The Interactable will swap the primary action to the secondary Interactor.
            /// </summary>
            Swap,
            /// <summary>
            /// The Interactable will attempt to rotate into the direction of the Interactor.
            /// </summary>
            ControlDirection,
            /// <summary>
            /// The Interactable will scale in size based on the point difference between the given Interactors.
            /// </summary>
            Scale
        }

        /// <summary>
        /// Whether the given <see cref="GameObject"/> can be converted to an Interactable Object.
        /// </summary>
        /// <param name="objectToConvert">The object to convert.</param>
        /// <returns>Whether it can be converted.</returns>
        public virtual bool CanConvert(GameObject objectToConvert)
        {
            return objectToConvert.GetComponentInParent<InteractableFacade>() == null;
        }

        /// <summary>
        /// Creates a new Interactable Object in the scene.
        /// </summary>
        /// <param name="interactablePrefab">The Interactable Object prefab to create from.</param>
        /// <param name="objectToConvert">The Object to convert into the new Interactable Object.</param>
        /// <returns>The created Interactable Object.</returns>
        public virtual GameObject Create(GameObject interactablePrefab, GameObject objectToConvert)
        {
            if (!CanConvert(objectToConvert))
            {
                return null;
            }

            int siblingIndex = objectToConvert.transform.GetSiblingIndex();
            interactablePrefab.name += "_" + objectToConvert.name;
            interactablePrefab.name = interactablePrefab.name.Replace("(Clone)", "");
            InteractableFacade facade = interactablePrefab.GetComponent<InteractableFacade>();

            interactablePrefab.transform.SetParent(objectToConvert.transform.parent);
            interactablePrefab.transform.localPosition = objectToConvert.transform.localPosition;
            interactablePrefab.transform.localRotation = objectToConvert.transform.localRotation;
            interactablePrefab.transform.localScale = objectToConvert.transform.localScale;

            foreach (MeshRenderer defaultMeshes in facade.Configuration.MeshContainer.GetComponentsInChildren<MeshRenderer>())
            {
                defaultMeshes.gameObject.SetActive(false);
            }

            objectToConvert.transform.SetParent(facade.Configuration.MeshContainer.transform);
            objectToConvert.transform.localPosition = Vector3.zero;
            objectToConvert.transform.localRotation = Quaternion.identity;
            objectToConvert.transform.localScale = Vector3.one;

            interactablePrefab.transform.SetSiblingIndex(siblingIndex);

            return interactablePrefab;
        }
    }
}