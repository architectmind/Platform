using System;
using System.Collections.Generic;
using System.Linq;
using Archimind.Platform.BusinessEntities.Services;
using System.Data.Entity;
using Archimind.Platform.DataModel.Orm.EntityFramework.Repositories;
using Archimind.Platform.DataModel.Orm.EntityFramework.UnitOfWork;
using System.Linq.Expressions;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents a concrete security store repository.
    /// </summary>
    public class SecurityStoreRepository : DataModelServiceBase, ISecurityStoreRepository
    {
        #region Members

        private SecurityContext securityContext;
        private EntitiesUnitOfWork securityStoreUnitOfWork;
        private bool disposed = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreRepository"/> class.
        /// </summary>
        public SecurityStoreRepository()
            : base()
        {
            this.securityContext = new SecurityContext();

            // Initialize unit of work.

            this.securityStoreUnitOfWork = new EntitiesUnitOfWork(
                this.securityContext,
                new RepositoryRegistry(new RepositoryFactories()));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreRepository"/> class.
        /// </summary>
        /// <param name="securityContext">The security context.</param>
        /// <exception cref="System.ArgumentNullException">securityContext</exception>
        public SecurityStoreRepository(SecurityContext securityContext)
            : base()
        {
            if (securityContext == null)
            {
                throw new ArgumentNullException("securityContext");
            }

            this.securityContext = securityContext;

            // Initialize unit of work.

            this.securityStoreUnitOfWork = new EntitiesUnitOfWork(
                this.securityContext,
                new RepositoryRegistry(new RepositoryFactories()));
        }

        #endregion

        #region Finalizer

        /// <summary>
        /// Finalizes an instance of the <see cref="SecurityStoreRepository"/> class.
        /// </summary>
        ~SecurityStoreRepository()
        {
            Dispose(false);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>
        /// The users.
        /// </returns>
        public IEnumerable<User> GetUsers()
        {
            try
            {
                return
                    this.securityStoreUnitOfWork.GetRepository<User>().GetBy();
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

            return null;
        }

        /// <summary>
        /// Gets the users with filter.
        /// </summary>
        /// <param name="filterExpression">The filter.</param>
        /// <returns>
        /// The users.
        /// </returns>
        public IEnumerable<User> GetUsersWithFilter(Expression<Func<User, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                {
                    return
                        this.GetUsers();
                }
                else
                {
                    return
                        this.securityStoreUnitOfWork.GetRepository<User>().GetBy(
                            filter: filterExpression);
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

            return null;
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user.
        /// </returns>
        public User GetUserById(Guid id)
        {
            try
            {
                Repository<User> repository = 
                    this.securityStoreUnitOfWork.GetRepository<User>();

                return
                    //this.repository.FindBySurrogateKey(id);
                    //this.securityContext.Users.Find(id);
                    repository.FindBySurrogateKey(id);
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

            return null;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            try
            {
                Repository<User> repository = 
                    this.securityStoreUnitOfWork.GetRepository<User>();
                //this.securityContext.Users.Add(user);
                repository.Add(user);
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

            try
            {
                Repository<User> repository = 
                    this.securityStoreUnitOfWork.GetRepository<User>();
                //this.securityContext.Entry(user).State = EntityState.Modified;
                repository.Update(user);
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
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUser(Guid id)
        {
            try
            {
                Repository<User> repository = 
                    this.securityStoreUnitOfWork.GetRepository<User>();
                //User userToDelete = this.securityContext.Users.Find(id);
                //this.securityContext.Users.Remove(userToDelete);
                User userToDelete = repository.FindBySurrogateKey(id);
                repository.Delete(userToDelete);
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
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            try
            {
                //this.securityContext.SaveChanges();
                this.securityStoreUnitOfWork.SaveChanges();
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
                    this.securityContext.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
