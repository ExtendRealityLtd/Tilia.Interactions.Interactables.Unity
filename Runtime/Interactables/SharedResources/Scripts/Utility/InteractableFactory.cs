namespace Tilia.Interactions.Interactables.Interactables.Utility
{
    using Tilia.Interactions.Interactables.Interactors.ComponentTags;
    using UnityEngine;
    using Zinnia.Tracking.Collision;
    using Zinnia.Utility;

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

            HideMeshes(facade.Configuration.MeshContainer);

            objectToConvert.transform.SetParent(facade.Configuration.MeshContainer.transform);
            objectToConvert.transform.localPosition = Vector3.zero;
            objectToConvert.transform.localRotation = Quaternion.identity;
            objectToConvert.transform.localScale = Vector3.one;

            interactablePrefab.transform.SetSiblingIndex(siblingIndex);

            return interactablePrefab;
        }

        /// <summary>
        /// Embeds an Interactable Object as a child of the existing scene GameObject.
        /// </summary>
        /// <param name="interactablePrefab">The Interactable Object prefab to create from and embed.</param>
        /// <param name="objectToConvert">The Object to embed the new Interactable Object into.</param>
        /// <returns>The existing scene GameObject with the embedded newly created Interactable Object.</returns>
        public virtual GameObject Embed(GameObject interactablePrefab, GameObject embedInto)
        {
            if (!CanConvert(embedInto))
            {
                return null;
            }

            interactablePrefab.transform.SetParent(embedInto.transform);
            interactablePrefab.transform.localPosition = Vector3.zero;
            interactablePrefab.transform.localRotation = Quaternion.identity;
            interactablePrefab.transform.localScale = Vector3.one;

            InteractableFacade facade = interactablePrefab.GetComponent<InteractableFacade>();
            Object.DestroyImmediate(facade.GetComponent<AllowInteractorCollisionTag>());
            Object.DestroyImmediate(facade.GetComponent<Rigidbody>());
            Object.DestroyImmediate(facade.GetComponent<BaseGameObjectSelector>());
            Object.DestroyImmediate(facade.GetComponent<CollisionNotifier>());

            embedInto.AddComponent<AllowInteractorCollisionTag>();
            embedInto.AddComponent<BaseGameObjectSelector>();
            facade.Configuration.CollisionNotifier = embedInto.AddComponent<CollisionNotifier>();
            Rigidbody baseRigidbody = embedInto.GetComponent<Rigidbody>();

            facade.Configuration.CollisionNotifier.CollisionStarted.AddListener(facade.Configuration.AddCollisionExtractor.DoExtract);
            facade.Configuration.CollisionNotifier.CollisionStopped.AddListener(facade.Configuration.RemoveCollisionExtractor.DoExtract);

            facade.Configuration.ConsumerContainer = embedInto;
            facade.Configuration.ConsumerRigidbody = baseRigidbody;

            HideMeshes(facade.Configuration.MeshContainer);
            facade.Configuration.MeshContainer = embedInto;

            return embedInto;
        }

        /// <summary>
        /// Hides all of the meshes found in the given <see cref="GameObject"/> child hierarchy.
        /// </summary>
        /// <param name="container">The container to find the meshes in.</param>
        protected virtual void HideMeshes(GameObject container)
        {
            foreach (Renderer currentMesh in container.GetComponentsInChildren<Renderer>())
            {
                currentMesh.gameObject.SetActive(false);
            }
        }
    }
}