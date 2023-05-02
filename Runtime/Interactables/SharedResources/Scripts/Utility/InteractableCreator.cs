namespace Tilia.Interactions.Interactables.Interactables.Utility
{
    using UnityEngine;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// A helper class to easily create an Interactable Object via script.
    /// </summary>
    public class InteractableCreator : MonoBehaviour
    {
        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The interactable prefab.")]
        [SerializeField]
        [Restricted]
        private GameObject interactableObject;
        /// <summary>
        /// The interactable prefab.
        /// </summary>
        public GameObject InteractableObject
        {
            get
            {
                return interactableObject;
            }
            set
            {
                interactableObject = value;
            }
        }
        #endregion

        /// <summary>
        /// The factory for creating new Interactable Obejcts.
        /// </summary>
        protected InteractableFactory interactableFactory = new InteractableFactory();

        /// <summary>
        /// Converts a given <see cref="GameObject"/> and wraps it into an <see cref="InteractableFacade"/>.
        /// </summary>
        /// <param name="objectToConvert">The GameObject to convert.</param>
        /// <returns>The created Interactable Facade.</returns>
        public virtual InteractableFacade Convert(GameObject objectToConvert)
        {
            if (InteractableObject == null || !interactableFactory.CanConvert(objectToConvert))
            {
                return null;
            }

            bool prefabState = interactableObject.activeSelf;
            interactableObject.SetActive(false);
            GameObject newInteractable = Instantiate(interactableObject);
            GameObject createdInteractable = interactableFactory.Create(newInteractable, objectToConvert);
            InteractableFacade interactableFacade = createdInteractable.GetComponent<InteractableFacade>();
            interactableFacade.Configuration.UpdatePrimaryAction(InteractableFactory.ActionType.None);
            interactableFacade.Configuration.UpdateSecondaryAction(InteractableFactory.ActionType.None);
            createdInteractable.SetActive(true);
            interactableObject.SetActive(prefabState);

            return interactableFacade;
        }

        /// <summary>
        /// Converts a given <see cref="GameObject"/> and wraps it into an <see cref="InteractableFacade"/>.
        /// </summary>
        /// <param name="objectToConvert">The GameObject to convert.</param>
        public virtual void DoConvert(GameObject objectToConvert)
        {
            Convert(objectToConvert);
        }

        /// <summary>
        /// Embeds a created <see cref="InteractableFacade"/> into the given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="embedObject">The GameObject to embed the Interactable within.</param>
        /// <returns>The created Interactable Facade.</returns>
        public virtual InteractableFacade Embed(GameObject embedObject)
        {
            if (InteractableObject == null || !interactableFactory.CanConvert(embedObject))
            {
                return null;
            }

            bool prefabState = interactableObject.activeSelf;
            interactableObject.SetActive(false);
            GameObject newInteractable = Instantiate(interactableObject);
            GameObject createdInteractable = interactableFactory.Embed(newInteractable, embedObject);
            InteractableFacade interactableFacade = createdInteractable.GetComponentInChildren<InteractableFacade>();
            interactableFacade.Configuration.UpdatePrimaryAction(InteractableFactory.ActionType.None);
            interactableFacade.Configuration.UpdateSecondaryAction(InteractableFactory.ActionType.None);
            createdInteractable.SetActive(true);
            interactableObject.SetActive(prefabState);

            return interactableFacade;
        }

        /// <summary>
        /// Embeds a created <see cref="InteractableFacade"/> into the given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="embedObject">The GameObject to embed the Interactable within.</param>
        public virtual void DoEmbed(GameObject embedObject)
        {
            Embed(embedObject);
        }
    }
}