using Archimind.Platform.Patterns;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archimind.Platform.BusinessEntities
{
    /// <summary>
    /// Base class for business entities.
    /// </summary>
    public abstract class BusinessEntityBase : BusinessObjectBase, IBusinessEntityBase
    {
        #region Construtors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessEntityBase"/> class.
        /// </summary>
        public BusinessEntityBase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessEntityBase"/> class.
        /// </summary>
        /// <param name="surrogateKey">The surrogate key.</param>
        public BusinessEntityBase(Guid surrogateKey)
            : this()
        {
            this.SurrogateKey = surrogateKey;
            this.ObjectState = ObjectState.New;
            this.Active = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessEntityBase"/> class.
        /// </summary>
        /// <param name="surrogateKey">The surrogate key.</param>
        /// <param name="naturalKey">The natural key.</param>
        /// <exception cref="System.ArgumentNullException">naturalKey</exception>
        public BusinessEntityBase(Guid surrogateKey, string naturalKey)
            : this(surrogateKey)
        {
            if (string.IsNullOrEmpty(naturalKey))
            {
                throw new ArgumentNullException("naturalKey");
            }

            this.NaturalKey = naturalKey;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the surrogate key.
        /// </summary>
        /// <value>
        /// The surrogate key.
        /// </value>
        [Key]
        [Column("Id")]
        public Guid SurrogateKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the natural key.
        /// </summary>
        /// <value>
        /// The natural key.
        /// </value>
        [Required]
        [StringLength(50)]
        public string NaturalKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IBusinessEntityBase" /> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the state of the object.
        /// </summary>
        /// <value>
        /// The state of the object.
        /// </value>
        [NotMapped]
        public ObjectState ObjectState
        {
            get;
            set;
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(IEntity<Guid, string> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != this.GetType())
                return false;
            return
                this.SurrogateKey.Equals(other.SurrogateKey);
        }

        #endregion

    }
}
