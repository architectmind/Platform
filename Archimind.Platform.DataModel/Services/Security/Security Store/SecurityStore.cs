using System;
using System.Data;
using Archimind.Platform.BusinessEntities.Services;
using Archimind.Platform.Core;
using Archimind.Platform.Core.Exceptions;
using Archimind.Platform.Core.Text;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents a concrete security store.
    /// </summary>
    public class SecurityStore : DataModelServiceBase, ISecurityStore
    {
        #region Constants

        private string defaultSecurityStoreName = "SecurityStore";

        #endregion

        #region Members

        private Repository securityRepository;
        private ISecurityStoreRepository securityStoreRepository;
        private bool disposed = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStore"/> class.
        /// </summary>
        public SecurityStore()
        {
            this.securityRepository = new Repository();
            this.securityStoreRepository = new SecurityStoreRepository(
                    new SecurityContext()
                );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStore"/> class.
        /// </summary>
        /// <param name="securityRepository">The security repository.</param>
        /// <exception cref="System.ArgumentNullException">The securityRepository.</exception>
        public SecurityStore(IRepository securityRepository)
        {
            // Verify arguments.

            if (securityRepository == null)
            {
                throw new ArgumentNullException("securityRepository");
            }

            ////@TODO: design a new interface for repository.

            this.securityRepository = securityRepository as Repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new data model service.
        /// </summary>
        public void Create()
        {
            // Create the security repository.

            try
            {
                this.securityRepository.Create(this.defaultSecurityStoreName);
            }
            catch (Exception ex)
            {
                Exception exceptionToThrow;
                if (this.HandleException(ex, out exceptionToThrow))
                {
                    if (exceptionToThrow == null)
                    {
                        throw;
                    }
                    else
                    {
                        throw exceptionToThrow;
                    }
                }
            }
        }

        /// <summary>
        /// Creates the specified security store.
        /// </summary>
        /// <param name="securityStore">The security store.</param>
        /// <exception cref="System.ArgumentNullException">The securityStore.</exception>
        public void Create(string securityStore)
        {
            // Verify arguments.

            if (Strings.IsNullOrEmpty(securityStore))
            {
                throw new ArgumentNullException("securityStore");
            }

            // Create the security repository.

            try
            {
                this.securityRepository.Create(securityStore);
            }
            catch (Exception ex)
            {
                Exception exceptionToThrow;
                if (this.HandleException(ex, out exceptionToThrow))
                {
                    if (exceptionToThrow == null)
                    {
                        throw;
                    }
                    else
                    {
                        throw exceptionToThrow;
                    }
                }
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.securityStoreRepository.CreateUser(user);
            this.securityStoreRepository.Save();
        }

        /// <summary>
        /// Reads the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user object.
        /// </returns>
        public User ReadUser(Guid id)
        {
            return
                this.securityStoreRepository.GetUserById(id);

            /*
            User user = null;

            string sqlStatement = "SELECT TOP 1 * FROM Users WHERE Id = @id";

            try
            {
                // Create the command.

                this.securityRepository.CreateSqlCommand(sqlStatement);

                // Add the parameter.

                this.securityRepository.AddInParameter("id", id);

                // Execute the command.

                using (IDataReader reader = this.securityRepository.ExecuteReaderCommand())
                {
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = (Guid)reader["Id"],
                            Email = (string)reader["Email"],
                            Phone = (string)reader["Phone"],
                            Address = (string)reader["Address"],
                            Name = (string)reader["Name"],
                            Active = (bool)reader["Active"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Exception exceptionToThrow;
                if (this.HandleException(ex, out exceptionToThrow))
                {
                    if (exceptionToThrow == null)
                    {
                        throw;
                    }
                    else
                    {
                        throw exceptionToThrow;
                    }
                }
            }

            return user;            
             * */
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.securityStoreRepository.UpdateUser(user);
            this.securityStoreRepository.Save();
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUser(Guid id)
        {
            this.securityStoreRepository.DeleteUser(id);
            this.securityStoreRepository.Save();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.securityStoreRepository.Dispose();
                    this.securityRepository.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
