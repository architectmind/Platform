using System;
using Archimind.Platform.BusinessEntities.Services;
using Archimind.Platform.BusinessModel.Services;
using Archimind.Platform.Core.Exceptions;
using Archimind.Platform.Core.Text;
using Archimind.Platform.Core.ServiceModel;
using Archimind.Platform.Core.Internal;
using Archimind.Platform.ServiceModel.Security.Contracts;
using Archimind.Platform.ServiceModel.Exceptions;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Archimind.Platform.ServiceModel.Security.Services
{
    /// <summary>
    /// Represents a security store service adapter.
    /// </summary>
    public sealed class SecurityStoreServiceAdapter : ServiceAdapterBase, ISecurityStoreService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityStoreServiceAdapter"/> class.
        /// </summary>
        public SecurityStoreServiceAdapter()
            : base()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The user data.
        /// </returns>
        public SecurityStoreGetUserByIdResponse GetUserById(SecurityStoreGetUserByIdRequest request)
        {
            // Verify request.

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                // Verify security token.

                if (Strings.IsNotNullOrEmpty(request.SecurityToken))
                {
                    if (string.Compare(request.SecurityToken, ServiceModelConstants.ServiceSecurityToken, false, Application.Culture) == 0)
                    {
                        // Get the security store business service.

                        SecurityStore securityStore = new SecurityStore();                        

                        // Get the user from the business layer.

                        User user = securityStore.ReadUser(new Guid(request.Id));

                        // Transform the business entity to a DTO.

                        ////@TODO: use objectmapper.
                        UserData userDto = new UserData
                        {
                            Id = user.SurrogateKey.ToString(),
                            Address = user.Address,
                            Email = user.Email,
                            Name = user.Name,
                            Phone = user.Phone
                        };

                        // return the DTO object.

                        return
                            new SecurityStoreGetUserByIdResponse(userDto);                        
                    }
                    else
                    {
                        throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
                    }

                }
                else
                {
                    throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
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
        /// Gets the users.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The get users response message.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        /// <exception cref="ServiceModelException">
        /// </exception>
        public SecurityStoreGetUsersResponse GetUsers(SecurityStoreGetUsersRequest request)
        {
            // Verify request.

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                // Verify security token.

                if (Strings.IsNotNullOrEmpty(request.SecurityToken))
                {
                    if (string.Compare(request.SecurityToken, ServiceModelConstants.ServiceSecurityToken, false, Application.Culture) == 0)
                    {
                        // Get the security store business service.

                        SecurityStore securityStore = new SecurityStore();

                        // Get the user from the business layer.

                        IEnumerable<User> users = securityStore.ReadUsers();

                        // Transform the business entity to a DTO.
                        ////@TODO: use objectmapper.

                        UserDataCollection userDTOs = new UserDataCollection();

                        foreach (User user in users)
                        {
                            UserData userDTO = new UserData
                            {
                                Id = user.SurrogateKey.ToString(),
                                Address = user.Address,
                                Email = user.Email,
                                Name = user.Name,
                                Phone = user.Phone
                            };

                            userDTOs.Add(userDTO);
                        }

                        // return the DTO object.

                        return
                            new SecurityStoreGetUsersResponse(userDTOs);
                    }
                    else
                    {
                        throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
                    }

                }
                else
                {
                    throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
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
        /// Gets the users with filters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The get users with filter response message.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        /// <exception cref="ServiceModelException">
        /// </exception>
        public SecurityStoreGetUsersWithFiltersResponse GetUsersWithFilters(SecurityStoreGetUsersWithFiltersRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                // Verify security token.

                if (Strings.IsNotNullOrEmpty(request.SecurityToken))
                {
                    if (string.Compare(request.SecurityToken, ServiceModelConstants.ServiceSecurityToken, false, Application.Culture) == 0)
                    {
                        // Get the security store business service.

                        SecurityStore securityStore = new SecurityStore();

                        // Convert the ExpressionNode to a Expression.

                        Expression<Func<User, bool>> filterExpression = null;

                        if (request.FilterExpressionNode != null)
                        {                            
                            filterExpression = request.FilterExpressionNode.ToExpression<Func<User, bool>>();
                        }

                        // Get the user from the business layer.

                        IEnumerable<User> users = securityStore.ReadUsersWithFilter(filterExpression);

                        // Transform the business entity to a DTO.
                        ////@TODO: use objectmapper.

                        UserDataCollection userDTOs = new UserDataCollection();

                        foreach (User user in users)
                        {
                            UserData userDTO = new UserData
                            {
                                Id = user.SurrogateKey.ToString(),
                                Address = user.Address,
                                Email = user.Email,
                                Name = user.Name,
                                Phone = user.Phone
                            };

                            userDTOs.Add(userDTO);
                        }

                        // return the DTO object.

                        return
                            new SecurityStoreGetUsersWithFiltersResponse(userDTOs);
                    }
                    else
                    {
                        throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
                    }

                }
                else
                {
                    throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
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
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The create user response message.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        /// <exception cref="ServiceModelException">
        /// </exception>
        public SecurityStoreCreateUserResponse CreateUser(SecurityStoreCreateUserRequest request)
        {
            // Verify request.

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                // Verify security token.

                if (Strings.IsNotNullOrEmpty(request.SecurityToken))
                {
                    if (string.Compare(request.SecurityToken, ServiceModelConstants.ServiceSecurityToken, false, Application.Culture) == 0)
                    {
                        // Get the security store business service.

                        SecurityStore securityStore = new SecurityStore();

                        // Get the user DTO from the request.

                        UserData userDto = request.User;

                        ////@TODO: use objectmapper.
                        User user = new User
                        {
                            SurrogateKey = Guid.NewGuid(),
                            NaturalKey = userDto.Name,
                            Name = userDto.Name,
                            Address = userDto.Address,
                            Email = userDto.Email,
                            Phone = userDto.Phone
                        };

                        // Create the user.

                        securityStore.CreateUser(user);                        

                        // return the response.

                        return
                            new SecurityStoreCreateUserResponse();
                    }
                    else
                    {
                        throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
                    }

                }
                else
                {
                    throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
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
        /// Updates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The update user response message.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        /// <exception cref="ServiceModelException">
        /// </exception>
        public SecurityStoreUpdateUserResponse UpdateUser(SecurityStoreUpdateUserRequest request)
        {
            // Verify request.

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                // Verify security token.

                if (Strings.IsNotNullOrEmpty(request.SecurityToken))
                {
                    if (string.Compare(request.SecurityToken, ServiceModelConstants.ServiceSecurityToken, false, Application.Culture) == 0)
                    {
                        // Get the security store business service.

                        SecurityStore securityStore = new SecurityStore();

                        // Get the user DTO from the request.

                        UserData userDto = request.User;

                        ////@TODO: use objectmapper.
                        User user = new User
                        {
                            SurrogateKey = new Guid(userDto.Id),
                            NaturalKey = userDto.Name,
                            Name = userDto.Name,
                            Address = userDto.Address,
                            Email = userDto.Email,
                            Phone = userDto.Phone
                        };

                        // Update the user.

                        securityStore.UpdateUser(user);

                        // return the response.

                        return
                            new SecurityStoreUpdateUserResponse();
                    }
                    else
                    {
                        throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
                    }

                }
                else
                {
                    throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
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
        /// Deletes the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The delete user response message.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        /// <exception cref="ServiceModelException">
        /// </exception>
        public SecurityStoreDeleteUserResponse DeleteUser(SecurityStoreDeleteUserRequest request)
        {
            // Verify request.

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                // Verify security token.

                if (Strings.IsNotNullOrEmpty(request.SecurityToken))
                {
                    if (string.Compare(request.SecurityToken, ServiceModelConstants.ServiceSecurityToken, false, Application.Culture) == 0)
                    {
                        // Get the security store business service.

                        SecurityStore securityStore = new SecurityStore();

                        // Delete the user from the business layer.

                        securityStore.DeleteUser(new Guid(request.Id));

                        return
                            new SecurityStoreDeleteUserResponse();
                    }
                    else
                    {
                        throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
                    }

                }
                else
                {
                    throw new ServiceModelException(Properties.Resources.RES_InvalidSecurityToken);
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

        #endregion        
    }
}
