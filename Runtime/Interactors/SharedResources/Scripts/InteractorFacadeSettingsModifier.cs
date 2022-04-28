namespace Tilia.Interactions.Interactables.Interactors
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Extension;
    using Zinnia.Tracking.Velocity;

    /// <summary>
    /// Allows the modification of the settings on a specified <see cref="InteractorFacade"/> found in a collection.
    /// </summary>
    public class InteractorFacadeSettingsModifier : MonoBehaviour
    {
        [Serializable]
        public class InteractorElement
        {
            [Tooltip("The InteractorFacade to modify the settings on.")]
            [SerializeField]
            private InteractorFacade targetFacade;
            /// <summary>
            /// The <see cref="InteractorFacade"/> to modify the settings on.
            /// </summary>
            public InteractorFacade TargetFacade
            {
                get
                {
                    return targetFacade;
                }
                set
                {
                    targetFacade = value;
                    OnAfterTargetFacadeChange();
                }
            }
            [Tooltip("The BooleanAction to update the InteractorFacade.GrabAction to.")]
            [SerializeField]
            private BooleanAction targetGrabAction;
            /// <summary>
            /// The <see cref="BooleanAction"/> to update the <see cref="InteractorFacade.GrabAction"/> to.
            /// </summary>
            public BooleanAction TargetGrabAction
            {
                get
                {
                    return targetGrabAction;
                }
                set
                {
                    targetGrabAction = value;
                }
            }
            [Tooltip("The VelocityTracker to update the InteractorFacade.VelocityTracker to.")]
            [SerializeField]
            private VelocityTracker targetVelocityTracker;
            /// <summary>
            /// The <see cref="VelocityTracker"/> to update the <see cref="InteractorFacade.VelocityTracker"/> to.
            /// </summary>
            public VelocityTracker TargetVelocityTracker
            {
                get
                {
                    return targetVelocityTracker;
                }
                set
                {
                    targetVelocityTracker = value;
                }
            }
            [Tooltip("The updated value to set the InteractorFacade.GrabPrecognition to.")]
            [SerializeField]
            private float targetGrabPrecognition;
            /// <summary>
            /// The updated value to set the <see cref="InteractorFacade.GrabPrecognition"/> to.
            /// </summary>
            public float TargetGrabPrecognition
            {
                get
                {
                    return targetGrabPrecognition;
                }
                set
                {
                    targetGrabPrecognition = value;
                }
            }

            /// <summary>
            /// The original <see cref="BooleanAction"/> on the <see cref="TargetFacade"/> to revert back to.
            /// </summary>
            protected BooleanAction cachedGrabAction;
            /// <summary>
            /// The original <see cref="VelocityTracker"/> on the <see cref="TargetFacade"/> to revert back to.
            /// </summary>
            protected VelocityTracker cachedVelocityTracker;
            /// <summary>
            /// The original <see cref="GrabPrecognition"/> on the <see cref="TargetFacade"/> to revert back to.
            /// </summary>
            protected float cachedGrabPrecognition;

            /// <summary>
            /// Clears <see cref="TargetFacade"/>.
            /// </summary>
            public virtual void ClearTargetFacade()
            {
                TargetFacade = default;
            }

            /// <summary>
            /// Clears <see cref="TargetGrabAction"/>.
            /// </summary>
            public virtual void ClearTargetGrabAction()
            {
                TargetGrabAction = default;
            }

            /// <summary>
            /// Clears <see cref="TargetVelocityTracker"/>.
            /// </summary>
            public virtual void ClearTargetVelocityTracker()
            {
                TargetVelocityTracker = default;
            }

            /// <summary>
            /// Sets the <see cref="InteractorFacade.GrabAction"/> to the value of <see cref="TargetGrabAction"/>.
            /// </summary>
            /// <param name="cacheCurrentGrabAction">Caches the current <see cref="InteractorFacade.GrabAction"/> value to be restored later.</param>
            public virtual void SetTargetGrabAction(bool cacheCurrentGrabAction)
            {
                if (cacheCurrentGrabAction)
                {
                    cachedGrabAction = TargetFacade.GrabAction;
                }

                TargetFacade.GrabAction = TargetGrabAction;
            }

            /// <summary>
            /// Restores the cached <see cref="InteractorFacade.GrabAction"/>.
            /// </summary>
            public virtual void RestoreCachedGrabAction()
            {
                TargetFacade.GrabAction = cachedGrabAction;
            }

            /// <summary>
            /// Sets the <see cref="InteractorFacade.VelocityTracker"/> to the value of <see cref="TargetVelocityTracker"/>.
            /// </summary>
            /// <param name="cacheCurrentVelocityTracker">Caches the current <see cref="InteractorFacade.VelocityTracker"/> value to be restored later.</param>
            public virtual void SetTargetVelocityTracker(bool cacheCurrentVelocityTracker)
            {
                if (cacheCurrentVelocityTracker)
                {
                    cachedVelocityTracker = TargetFacade.VelocityTracker;
                }

                TargetFacade.VelocityTracker = TargetVelocityTracker;
            }

            /// <summary>
            /// Restores the cached <see cref="InteractorFacade.VelocityTracker"/>.
            /// </summary>
            public virtual void RestoreCachedVelocityTracker()
            {
                TargetFacade.VelocityTracker = cachedVelocityTracker;
            }

            /// <summary>
            /// Sets the <see cref="InteractorFacade.GrabPrecognition"/> to the value of <see cref="TargetGrabPrecognition"/>.
            /// </summary>
            /// <param name="cacheCurrentGrabPrecognition">Caches the current <see cref="InteractorFacade.GrabPrecognition"/> value to be restored later.</param>
            public virtual void SetTargetGrabPrecognition(bool cacheCurrentGrabPrecognition)
            {
                if (cacheCurrentGrabPrecognition)
                {
                    cachedGrabPrecognition = TargetFacade.GrabPrecognition;
                }

                TargetFacade.GrabPrecognition = TargetGrabPrecognition;
            }

            /// <summary>
            /// Restores the cached <see cref="InteractorFacade.GrabPrecognition"/>.
            /// </summary>
            public virtual void RestoreCachedGrabPrecognition()
            {
                TargetFacade.GrabPrecognition = cachedGrabPrecognition;
            }

            /// <summary>
            /// Called after <see cref="TargetFacade"/> has been changed.
            /// </summary>
            protected virtual void OnAfterTargetFacadeChange()
            {
                cachedGrabAction = TargetFacade.GrabAction;
                cachedVelocityTracker = TargetFacade.VelocityTracker;
                cachedGrabPrecognition = TargetFacade.GrabPrecognition;
            }

            [Obsolete("Use `OnAfterTargetFacadeChange` instead.")]
            protected virtual void OnAfterFacadeChange()
            {
                OnAfterTargetFacadeChange();
            }
        }

        [Tooltip("The InteractorElement collection of settings to modify per InteractorFacade.")]
        [SerializeField]
        private List<InteractorElement> elements = new List<InteractorElement>();
        /// <summary>
        /// The <see cref="InteractorElement"/> collection of settings to modify per <see cref="InteractorFacade"/>.
        /// </summary>
        public List<InteractorElement> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                elements = value;
            }
        }
        [Tooltip("Determines whether to cache the element settings when attempting to set them.")]
        [SerializeField]
        private bool cacheElementSettings = true;
        /// <summary>
        /// Determines whether to cache the element settings when attempting to set them.
        /// </summary>
        public bool CacheElementSettings
        {
            get
            {
                return cacheElementSettings;
            }
            set
            {
                cacheElementSettings = value;
            }
        }

        /// <summary>
        /// Clears <see cref="Elements"/>.
        /// </summary>
        public virtual void ClearElements()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Elements.Clear();
        }

        /// <summary>
        /// Matches the given <see cref="InteractorFacade"/> in the <see cref="Elements"/> and updates the <see cref="InteractorFacade.GrabAction"/> with the relevant <see cref="InteractorElement.TargetGrabAction"/>.
        /// </summary>
        /// <param name="interactorFacade">The <see cref="InteractorFacade"/> to update.</param>
        public virtual void SetTargetGrabActionFor(InteractorFacade interactorFacade)
        {
            if (!this.IsValidState())
            {
                return;
            }

            InteractorElement interactor = Elements.Find(x => x.TargetFacade.Equals(interactorFacade));
            if (interactor != null)
            {
                interactor.SetTargetGrabAction(CacheElementSettings);
            }
        }

        /// <summary>
        /// Matches the given <see cref="InteractorFacade"/> in the <see cref="Elements"/> and restores the cached <see cref="InteractorFacade.GrabAction"/>.
        /// </summary>
        /// <param name="interactorFacade">The <see cref="InteractorFacade"/> to update.</param>
        public virtual void RestoreCachedGrabAction(InteractorFacade interactorFacade)
        {
            InteractorElement interactor = Elements.Find(interactorElement => interactorElement.TargetFacade.Equals(interactorFacade));
            if (interactor != null)
            {
                interactor.RestoreCachedGrabAction();
            }
        }

        /// <summary>
        /// Matches the given <see cref="InteractorFacade"/> in the <see cref="Elements"/> and updates the <see cref="InteractorFacade.VelocityTracker"/> with the relevant <see cref="InteractorElement.TargetVelocityTracker"/>.
        /// </summary>
        /// <param name="interactorFacade">The <see cref="InteractorFacade"/> to update.</param>
        public virtual void SetTargetVelocityTracker(InteractorFacade interactorFacade)
        {
            if (!this.IsValidState())
            {
                return;
            }

            InteractorElement interactor = Elements.Find(x => x.TargetFacade.Equals(interactorFacade));
            if (interactor != null)
            {
                interactor.SetTargetVelocityTracker(CacheElementSettings);
            }
        }

        /// <summary>
        /// Matches the given <see cref="InteractorFacade"/> in the <see cref="Elements"/> and restores the cached <see cref="InteractorFacade.VelocityTracker"/>.
        /// </summary>
        /// <param name="interactorFacade">The <see cref="InteractorFacade"/> to update.</param>
        public virtual void RestoreCachedVelocityTracker(InteractorFacade interactorFacade)
        {
            InteractorElement interactor = Elements.Find(interactorElement => interactorElement.TargetFacade.Equals(interactorFacade));
            if (interactor != null)
            {
                interactor.RestoreCachedVelocityTracker();
            }
        }

        /// <summary>
        /// Matches the given <see cref="InteractorFacade"/> in the <see cref="Elements"/> and updates the <see cref="InteractorFacade.GrabPrecognition"/> with the relevant <see cref="InteractorElement.TargetGrabPrecognition"/>.
        /// </summary>
        /// <param name="interactorFacade">The <see cref="InteractorFacade"/> to update.</param>
        public virtual void SetTargetGrabPrecognition(InteractorFacade interactorFacade)
        {
            if (!this.IsValidState())
            {
                return;
            }

            InteractorElement interactor = Elements.Find(x => x.TargetFacade.Equals(interactorFacade));
            if (interactor != null)
            {
                interactor.SetTargetGrabPrecognition(CacheElementSettings);
            }
        }

        /// <summary>
        /// Matches the given <see cref="InteractorFacade"/> in the <see cref="Elements"/> and restores the cached <see cref="InteractorFacade.GrabPrecognition"/>.
        /// </summary>
        /// <param name="interactorFacade">The <see cref="InteractorFacade"/> to update.</param>
        public virtual void RestoreCachedGrabPrecognition(InteractorFacade interactorFacade)
        {
            InteractorElement interactor = Elements.Find(interactorElement => interactorElement.TargetFacade.Equals(interactorFacade));
            if (interactor != null)
            {
                interactor.RestoreCachedGrabPrecognition();
            }
        }
    }
}