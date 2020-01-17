namespace Tilia.Interactions.Interactables.Interactors
{
    using Malimbe.BehaviourStateRequirementMethod;
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Zinnia.Action;
    using Zinnia.Tracking.Velocity;

    /// <summary>
    /// Allows the modification of the settings on a specified <see cref="InteractorFacade"/> found in a collection.
    /// </summary>
    public class InteractorFacadeSettingsModifier : MonoBehaviour
    {
        [Serializable]
        public class InteractorElement
        {
            /// <summary>
            /// The <see cref="InteractorFacade"/> to modify the settings on.
            /// </summary>
            [Serialized, Cleared]
            [field: DocumentedByXml]
            public InteractorFacade TargetFacade { get; set; }
            /// <summary>
            /// The <see cref="BooleanAction"/> to update the <see cref="InteractorFacade.GrabAction"/> to.
            /// </summary>
            [Serialized, Cleared]
            [field: DocumentedByXml]
            public BooleanAction TargetGrabAction { get; set; }
            /// <summary>
            /// The <see cref="VelocityTrackerProcessor"/> to update the <see cref="InteractorFacade.VelocityTracker"/> to.
            /// </summary>
            [Serialized, Cleared]
            [field: DocumentedByXml]
            public VelocityTrackerProcessor TargetVelocityTracker { get; set; }
            /// <summary>
            /// The updated value to set the <see cref="InteractorFacade.GrabPrecognition"/> to.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml]
            public float TargetGrabPrecognition { get; set; }

            /// <summary>
            /// The original <see cref="BooleanAction"/> on the <see cref="TargetFacade"/> to revert back to.
            /// </summary>
            protected BooleanAction cachedGrabAction;
            /// <summary>
            /// The original <see cref="VelocityTrackerProcessor"/> on the <see cref="TargetFacade"/> to revert back to.
            /// </summary>
            protected VelocityTrackerProcessor cachedVelocityTracker;
            /// <summary>
            /// The original <see cref="GrabPrecognition"/> on the <see cref="TargetFacade"/> to revert back to.
            /// </summary>
            protected float cachedGrabPrecognition;

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
            [CalledAfterChangeOf(nameof(TargetFacade))]
            protected virtual void OnAfterFacadeChange()
            {
                cachedGrabAction = TargetFacade.GrabAction;
                cachedVelocityTracker = TargetFacade.VelocityTracker;
                cachedGrabPrecognition = TargetFacade.GrabPrecognition;
            }
        }

        /// <summary>
        /// The <see cref="InteractorElement"/> collection of settings to modify per <see cref="InteractorFacade"/>.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public List<InteractorElement> Elements { get; set; }
        /// <summary>
        /// Determines whether to cache the element settings when attempting to set them.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public bool CacheElementSettings { get; set; } = true;

        /// <summary>
        /// Matches the given <see cref="InteractorFacade"/> in the <see cref="Elements"/> and updates the <see cref="InteractorFacade.GrabAction"/> with the relevant <see cref="InteractorElement.TargetGrabAction"/>.
        /// </summary>
        /// <param name="interactorFacade">The <see cref="InteractorFacade"/> to update.</param>
        [RequiresBehaviourState]
        public virtual void SetTargetGrabActionFor(InteractorFacade interactorFacade)
        {
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
        [RequiresBehaviourState]
        public virtual void SetTargetVelocityTracker(InteractorFacade interactorFacade)
        {
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
        [RequiresBehaviourState]
        public virtual void SetTargetGrabPrecognition(InteractorFacade interactorFacade)
        {
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