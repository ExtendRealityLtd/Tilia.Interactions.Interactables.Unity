namespace Tilia.Interactions.Interactables.Interactables.Event.Proxy
{
    using System;
    using UnityEngine.Events;
    using Zinnia.Event.Proxy;

    /// <summary>
    /// Emits a UnityEvent with an <see cref="InteractableFacade"/> payload whenever the Receive method is called.
    /// </summary>
    public class InteractableFacadeEventProxyEmitter : RestrictableSingleEventProxyEmitter<InteractableFacade, InteractableFacadeEventProxyEmitter.UnityEvent>
    {
        /// <summary>
        /// Defines the event with the specified state.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractableFacade> { }

        /// <inheritdoc />
        protected override object GetTargetToCheck()
        {
            return Payload != null ? Payload.gameObject : null;
        }
    }
}