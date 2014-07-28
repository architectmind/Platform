using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archimind.Platform.BusinessEntities.Services
{
    /// <summary>
    /// Represents a user entity in the business model.
    /// </summary>
    public class User : BusinessEntityBase
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="surrogateKey">The surrogate key.</param>
        public User(Guid surrogateKey)
            : base(surrogateKey)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="surrogateKey">The surrogate key.</param>
        /// <param name="naturalKey">The natural key.</param>
        public User(Guid surrogateKey, string naturalKey)
            : base(surrogateKey, naturalKey)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the user key.
        /// </summary>
        /// <value>
        /// The user key.
        /// </value>
        [Required]
        [Column("UserKey")]
        [StringLength(50)]
        public new string NaturalKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [StringLength(100)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        /// 
        [StringLength(250)]
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [Phone]
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// 
        [EmailAddress]
        public string Email
        {
            get;
            set;
        }

        #endregion
    }
}
