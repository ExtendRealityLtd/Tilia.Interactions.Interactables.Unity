namespace Tilia.Interactions.Interactables.Interactors.Event.Proxy
{
    using System;
    using UnityEngine.Events;
    using Zinnia.Event.Proxy;

    /// <summary>
    /// Emits a UnityEvent with an <see cref="InteractorFacade"/> payload whenever <see cref="SingleEventProxyEmitter{TValue,TEvent}.Receive"/> is called.
    /// </summary>
    public class InteractorFacadeEventProxyEmitter : RestrictableSingleEventProxyEmitter<InteractorFacade, InteractorFacadeEventProxyEmitter.UnityEvent>
    {
        /// <summary>
        /// Defines the event with the specified state.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractorFacade>
        {
        }

        /// <inheritdoc />
        protected override object GetTargetToCheck()
        {
            return Payload != null ? Payload.gameObject : null;
        }
    }
}