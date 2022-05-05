namespace Tilia.Interactions.Interactables.Interactables.Grab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Extension;

    /// <summary>
    /// Registers listeners to the initial grab and final ungrab states of an <see cref="InteractableFacade"/> and emits the <see cref="InteractableFacade"/> as the event payload.
    /// </summary>
    public class InteractableGrabStateRegistrar : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the specified <see cref="InteractableFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractableFacade> { }
        /// <summary>
        /// Defines the event with the specified <see cref="Rigidbody"/>.
        /// </summary>
        [Serializable]
        public class RigidbodyUnityEvent : UnityEvent<Rigidbody> { }

        [Header("Subscription Settings")]
        [Tooltip("Determines whether to unsubscribe all registered listeners when the component is disabled.")]
        [SerializeField]
        private bool unsubscribeOnDisable = true;
        /// <summary>
        /// Determines whether to unsubscribe all registered listeners when the component is disabled.
        /// </summary>
        public bool UnsubscribeOnDisable
        {
            get
            {
                return unsubscribeOnDisable;
            }
            set
            {
                unsubscribeOnDisable = value;
            }
        }

        [Header("Interactable Events")]
        /// <summary>
        /// Emitted when the <see cref="InteractableFacade"/> is grabbed.
        /// </summary>
        public UnityEvent Grabbed = new UnityEvent();
        /// <summary>
        /// Emitted when the <see cref="InteractableFacade"/> is ungrabbed.
        /// </summary>
        public UnityEvent Ungrabbed = new UnityEvent();

        [Header("Advanced Events")]
        /// <summary>
        /// Emitted when the <see cref="InteractableFacade"/> is about to change the kinematic state of its <see cref="Rigidbody"/> when grabbed.
        /// </summary>
        public RigidbodyUnityEvent KinematicStateChangedOnGrabbed = new RigidbodyUnityEvent();
        /// <summary>
        /// Emitted when the <see cref="InteractableFacade"/> is about to change the kinematic state of its <see cref="Rigidbody"/> when ungrabbed.
        /// </summary>
        public RigidbodyUnityEvent KinematicStateChangedOnUngrabbed = new RigidbodyUnityEvent();

        /// <summary>
        /// Actions that unsubscribe the added grab event listeners.
        /// </summary>
        protected readonly Dictionary<InteractableFacade, System.Action> unsubscribeGrabActions = new Dictionary<InteractableFacade, System.Action>();
        /// <summary>
        /// Actions that unsubscribe the added ungrab event listeners.
        /// </summary>
        protected readonly Dictionary<InteractableFacade, System.Action> unsubscribeUngrabActions = new Dictionary<InteractableFacade, System.Action>();

        /// <summary>
        /// Registers a listener on the given <see cref="InteractableFacade"/> Ungrabbed event.
        /// </summary>
        /// <param name="ungrabbable">The interactable to register the ungrab event on.</param>
        public virtual void RegisterUngrabbed(InteractableFacade ungrabbable)
        {
            if (!this.IsValidState() || ungrabbable == null || unsubscribeUngrabActions.ContainsKey(ungrabbable))
            {
                return;
            }

            GrabInteractableConfigurator grabConfig = ungrabbable.Configuration.GrabConfiguration;

            void OnUngrabbed(InteractorFacade _) => InteractableUngrabbed(ungrabbable);
            void OnUngrabbedKinematicChange(Rigidbody _) => InteractableUngrabbedKinematicChange(ungrabbable);

            ungrabbable.LastUngrabbed.AddListener(OnUngrabbed);
            grabConfig.KinematicStateToChange.AddListener(OnUngrabbedKinematicChange);

            unsubscribeUngrabActions[ungrabbable] = () =>
            {
                ungrabbable.LastUngrabbed.RemoveListener(OnUngrabbed);
                grabConfig.KinematicStateToChange.RemoveListener(OnUngrabbedKinematicChange);
            };
        }

        /// <summary>
        /// Registers a listener on the given <see cref="GameObject"/>'s <see cref="InteractableFacade"/> Ungrabbed event.
        /// </summary>
        /// <param name="ungrabbable">The <see cref="GameObject"/> to get the <see cref="InteractableFacade"/> from to register the ungrab event on.</param>
        public virtual void RegisterUngrabbed(GameObject ungrabbable)
        {
            if (!this.IsValidState() || ungrabbable == null)
            {
                return;
            }

            RegisterUngrabbed(ungrabbable.GetComponent<InteractableFacade>());
        }

        /// <summary>
        /// Registers a listener on the given <see cref="InteractableFacade"/> Grabbed event.
        /// </summary>
        /// <param name="grabbable">The interactable to register the grab event on.</param>
        public virtual void RegisterGrabbed(InteractableFacade grabbable)
        {
            if (!this.IsValidState() || grabbable == null || unsubscribeGrabActions.ContainsKey(grabbable))
            {
                return;
            }

            GrabInteractableConfigurator grabConfig = grabbable.Configuration.GrabConfiguration;

            void OnGrabbed(InteractorFacade _) => InteractableGrabbed(grabbable);
            void OnGrabbedKinematicChange(Rigidbody _) => InteractableGrabbedKinematicChange(grabbable);

            grabbable.FirstGrabbed.AddListener(OnGrabbed);
            grabConfig.KinematicStateToChange.AddListener(OnGrabbedKinematicChange);
            unsubscribeGrabActions[grabbable] = () =>
            {
                grabbable.FirstGrabbed.RemoveListener(OnGrabbed);
                grabConfig.KinematicStateToChange.RemoveListener(OnGrabbedKinematicChange);
            };
        }

        /// <summary>
        /// Registers a listener on the given <see cref="GameObject"/>'s <see cref="InteractableFacade"/> Grabbed event.
        /// </summary>
        /// <param name="grabbable">The <see cref="GameObject"/> to get the <see cref="InteractableFacade"/> from to register the grab event on.</param>
        public virtual void RegisterGrabbed(GameObject grabbable)
        {
            if (!this.IsValidState() || grabbable == null)
            {
                return;
            }

            RegisterGrabbed(grabbable.GetComponent<InteractableFacade>());
        }

        /// <summary>
        /// Unregisters a listener from the given <see cref="InteractableFacade"/> Ungrabbed event.
        /// </summary>
        /// <param name="ungrabbable">The interactable to unregister the ungrab event from.</param>
        public virtual void UnregisterUngrabbed(InteractableFacade ungrabbable)
        {
            if (ungrabbable == null || !unsubscribeUngrabActions.TryGetValue(ungrabbable, out System.Action unsubscribeAction))
            {
                return;
            }

            unsubscribeAction();
            unsubscribeUngrabActions.Remove(ungrabbable);
        }

        /// <summary>
        /// Unregisters a listener from the given <see cref="GameObject"/>'s <see cref="InteractableFacade"/> Ungrabbed event.
        /// </summary>
        /// <param name="ungrabbable">The <see cref="GameObject"/> to get the <see cref="InteractableFacade"/> from to unregister the ungrab event from.</param>
        public virtual void UnregisterUngrabbed(GameObject ungrabbable)
        {
            if (ungrabbable == null)
            {
                return;
            }

            UnregisterUngrabbed(ungrabbable.GetComponent<InteractableFacade>());
        }

        /// <summary>
        /// Unregisters a listener from the given <see cref="InteractableFacade"/> Grabbed event.
        /// </summary>
        /// <param name="grabbable">The interactable to unregister the grab event from.</param>
        public virtual void UnregisterGrabbed(InteractableFacade grabbable)
        {
            if (grabbable == null || !unsubscribeGrabActions.TryGetValue(grabbable, out System.Action unsubscribeAction))
            {
                return;
            }

            unsubscribeAction();
            unsubscribeGrabActions.Remove(grabbable);
        }

        /// <summary>
        /// Unregisters a listener from the given <see cref="GameObject"/>'s <see cref="InteractableFacade"/> Grabbed event.
        /// </summary>
        /// <param name="grabbable">The <see cref="GameObject"/> to get the <see cref="InteractableFacade"/> from to unregister the grab event from.</param>
        public virtual void UnregisterGrabbed(GameObject grabbable)
        {
            if (grabbable == null)
            {
                return;
            }

            UnregisterGrabbed(grabbable.GetComponent<InteractableFacade>());
        }

        /// <summary>
        /// Unregisters all listeners for all ungrabbed events.
        /// </summary>
        public virtual void UnregisterAllUngrabbed()
        {
            foreach (InteractableFacade entry in unsubscribeUngrabActions.Keys.ToArray())
            {
                UnregisterUngrabbed(entry);
            }
            unsubscribeUngrabActions.Clear();
        }

        /// <summary>
        /// Unregisters all listeners for all grabbed events.
        /// </summary>
        public virtual void UnregisterAllGrabbed()
        {
            foreach (InteractableFacade entry in unsubscribeGrabActions.Keys.ToArray())
            {
                UnregisterGrabbed(entry);
            }
            unsubscribeGrabActions.Clear();
        }

        /// <summary>
        /// Unregisters all listeners for all events.
        /// </summary>
        public virtual void UnregisterAll()
        {
            UnregisterAllUngrabbed();
            UnregisterAllGrabbed();
        }

        protected virtual void OnDisable()
        {
            if (UnsubscribeOnDisable)
            {
                UnregisterAll();
            }
        }

        /// <summary>
        /// Processes the grabbed event on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to process the grab event for.</param>
        protected virtual void InteractableGrabbed(InteractableFacade interactable)
        {
            Grabbed?.Invoke(interactable);
        }

        /// <summary>
        /// Processes the ungrabbed event on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to process the ungrab event for.</param>
        protected virtual void InteractableUngrabbed(InteractableFacade interactable)
        {
            Ungrabbed?.Invoke(interactable);
        }

        /// <summary>
        /// Processes the kinematic state change on the grabbed event on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to process the grab event for.</param>
        protected virtual void InteractableGrabbedKinematicChange(InteractableFacade interactable)
        {
            KinematicStateChangedOnGrabbed?.Invoke(interactable.Configuration.ConsumerRigidbody);
        }

        /// <summary>
        /// Processes the kinematic state change on the ungrabbed event on the given Interactable.
        /// </summary>
        /// <param name="interactable">The Interactable to process the grab event for.</param>
        protected virtual void InteractableUngrabbedKinematicChange(InteractableFacade interactable)
        {
            KinematicStateChangedOnUngrabbed?.Invoke(interactable.Configuration.ConsumerRigidbody);
        }
    }
}