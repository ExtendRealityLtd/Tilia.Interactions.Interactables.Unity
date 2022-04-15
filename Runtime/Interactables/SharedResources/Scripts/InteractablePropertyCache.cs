namespace Tilia.Interactions.Interactables.Interactables
{
    using UnityEngine;
    using Zinnia.Extension;

    /// <summary>
    /// Caches common properties for an <see cref="InteractableFacade"/> to be restored at a later point in time.
    /// </summary>
    public class InteractablePropertyCache : MonoBehaviour
    {
        [Tooltip("The source to cache properties for.")]
        [SerializeField]
        private InteractableFacade source;
        /// <summary>
        /// The source to cache properties for.
        /// </summary>
        public InteractableFacade Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }

        /// <summary>
        /// The cached local position of the <see cref="Source"/>
        /// </summary>
        protected Vector3? cachedLocalPosition;
        /// <summary>
        /// The cached local rotation of the <see cref="Source"/>
        /// </summary>
        protected Quaternion cachedLocalRotation;
        /// <summary>
        /// The cached local scale of the <see cref="Source"/>
        /// </summary>
        protected Vector3 cachedLocalScale;
        /// <summary>
        /// The cached kinematic state of the the <see cref="Source"/>
        /// </summary>
        protected bool cachedRigidbodyKinematicState;

        /// <summary>
        /// Clears <see cref="Source"/>.
        /// </summary>
        public virtual void ClearSource()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Source = default;
        }

        /// <summary>
        /// Sets the <see cref="Source"/> property from a given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="source">The source to set to.</param>
        public virtual void SetSource(GameObject source)
        {
            if (!this.IsValidState() || source == null)
            {
                return;
            }

            Source = source.GetComponent<InteractableFacade>();
        }

        /// <summary>
        /// Caches the position.
        /// </summary>
        public virtual void CachePosition()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            cachedLocalPosition = Source.transform.localPosition;
        }

        /// <summary>
        /// Caches the rotation.
        /// </summary>
        public virtual void CacheRotation()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            cachedLocalRotation = Source.transform.localRotation;
        }

        /// <summary>
        /// Caches the scale.
        /// </summary>
        public virtual void CacheScale()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            cachedLocalScale = Source.transform.localScale;
        }

        /// <summary>
        /// Caches the rigidbody kinematic state..
        /// </summary>
        public virtual void CacheRigidbodyKinematicState()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            cachedRigidbodyKinematicState = Source.Configuration.ConsumerRigidbody != null ? Source.Configuration.ConsumerRigidbody.isKinematic : false;
        }

        /// <summary>
        /// Caches all of the properties.
        /// </summary>
        public virtual void CacheAll()
        {
            if (!this.IsValidState())
            {
                return;
            }

            CachePosition();
            CacheRotation();
            CacheScale();
            CacheRigidbodyKinematicState();
        }

        /// <summary>
        /// Restores the cached position.
        /// </summary>
        public virtual void RestorePosition()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            Source.transform.localPosition = (Vector3)cachedLocalPosition;
        }

        /// <summary>
        /// Restores the cached rotation.
        /// </summary>
        public virtual void RestoreRotation()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            Source.transform.localRotation = cachedLocalRotation;
        }

        /// <summary>
        /// Restores the cached scale.
        /// </summary>
        public virtual void RestoreScale()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            Source.transform.localScale = cachedLocalScale;
        }

        /// <summary>
        /// Restores the cached rigidbody kinematic state.
        /// </summary>
        public virtual void RestoreRigidbodyKinematicState()
        {
            if (!this.IsValidState() || Source == null)
            {
                return;
            }

            Source.Configuration.ConsumerRigidbody.isKinematic = cachedRigidbodyKinematicState;
        }

        /// <summary>
        /// Restores the all of cached properties.
        /// </summary>
        public virtual void RestoreAll()
        {
            if (!this.IsValidState())
            {
                return;
            }

            RestorePosition();
            RestoreRotation();
            RestoreScale();
            RestoreRigidbodyKinematicState();
        }
    }
}