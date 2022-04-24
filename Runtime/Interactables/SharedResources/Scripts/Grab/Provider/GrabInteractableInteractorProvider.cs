﻿namespace Tilia.Interactions.Interactables.Interactables.Grab.Provider
{
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Event.Proxy;
    using Zinnia.Extension;

    /// <summary>
    /// Processes a received grab event and passes it over to the appropriate grab actions.
    /// </summary>
    public abstract class GrabInteractableInteractorProvider : MonoBehaviour
    {
        #region Input Settings
        [Header("Input Settings")]
        [Tooltip("The input GameObjectEventProxyEmitter for the grab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter inputGrabReceived;
        /// <summary>
        /// The input <see cref="GameObjectEventProxyEmitter"/> for the grab action.
        /// </summary>
        public GameObjectEventProxyEmitter InputGrabReceived
        {
            get
            {
                return inputGrabReceived;
            }
            protected set
            {
                inputGrabReceived = value;
            }
        }
        [Tooltip("The input GameObjectEventProxyEmitter for the ungrab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter inputUngrabReceived;
        /// <summary>
        /// The input <see cref="GameObjectEventProxyEmitter"/> for the ungrab action.
        /// </summary>
        public GameObjectEventProxyEmitter InputUngrabReceived
        {
            get
            {
                return inputUngrabReceived;
            }
            protected set
            {
                inputUngrabReceived = value;
            }
        }
        #endregion

        #region Primary Output Settings
        [Header("Primary Output Settings")]
        [Tooltip("The output GameObjectEventProxyEmitter for the primary grab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputPrimaryGrabAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the primary grab action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputPrimaryGrabAction
        {
            get
            {
                return outputPrimaryGrabAction;
            }
            protected set
            {
                outputPrimaryGrabAction = value;
            }
        }
        [Tooltip("The output GameObjectEventProxyEmitter for the primary grab setup on secondary action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputPrimaryGrabSetupOnSecondaryAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the primary grab setup on secondary action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputPrimaryGrabSetupOnSecondaryAction
        {
            get
            {
                return outputPrimaryGrabSetupOnSecondaryAction;
            }
            protected set
            {
                outputPrimaryGrabSetupOnSecondaryAction = value;
            }
        }
        [Tooltip("The output GameObjectEventProxyEmitter for the primary ungrab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputPrimaryUngrabAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the primary ungrab action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputPrimaryUngrabAction
        {
            get
            {
                return outputPrimaryUngrabAction;
            }
            protected set
            {
                outputPrimaryUngrabAction = value;
            }
        }
        [Tooltip("The output GameObjectEventProxyEmitter for the primary ungrab reset on secondary action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputPrimaryUngrabResetOnSecondaryAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the primary ungrab reset on secondary action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputPrimaryUngrabResetOnSecondaryAction
        {
            get
            {
                return outputPrimaryUngrabResetOnSecondaryAction;
            }
            protected set
            {
                outputPrimaryUngrabResetOnSecondaryAction = value;
            }
        }
        #endregion

        #region Secondary Output Settings
        [Header("Secondary Output Settings")]
        [Tooltip("The output GameObjectEventProxyEmitter for the secondary grab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputSecondaryGrabAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the secondary grab action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputSecondaryGrabAction
        {
            get
            {
                return outputSecondaryGrabAction;
            }
            protected set
            {
                outputSecondaryGrabAction = value;
            }
        }
        [Tooltip("The output GameObjectEventProxyEmitter for the Secondary ungrab action.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter outputSecondaryUngrabAction;
        /// <summary>
        /// The output <see cref="GameObjectEventProxyEmitter"/> for the Secondary ungrab action.
        /// </summary>
        public GameObjectEventProxyEmitter OutputSecondaryUngrabAction
        {
            get
            {
                return outputSecondaryUngrabAction;
            }
            protected set
            {
                outputSecondaryUngrabAction = value;
            }
        }
        #endregion

        /// <summary>
        /// Gets the available grabbing Interactors from the provider.
        /// </summary>
        /// <returns>A collection of Interactors that are currently grabbing the Interactable.</returns>
        public abstract IReadOnlyList<InteractorFacade> GrabbingInteractors { get; }

        /// <summary>
        /// A reusable collection to hold the returned grabbing interactors.
        /// </summary>
        protected readonly List<InteractorFacade> grabbingInteractors = new List<InteractorFacade>();

        /// <summary>
        /// Gets the Grabbing Interactors stored in the given collection.
        /// </summary>
        /// <param name="elements">The collection to retrieve the Grabbing Interactors from.</param>
        /// <returns>A collection of Grabbing Interactors.</returns>
        protected virtual IReadOnlyList<InteractorFacade> GetGrabbingInteractors(IEnumerable<GameObject> elements)
        {
            grabbingInteractors.Clear();

            if (elements == null)
            {
                return grabbingInteractors;
            }

            foreach (GameObject element in elements)
            {
                InteractorFacade interactor = element.TryGetComponent<InteractorFacade>(true, true);
                if (interactor != null)
                {
                    grabbingInteractors.Add(interactor);
                }
            }

            return grabbingInteractors;
        }
    }
}