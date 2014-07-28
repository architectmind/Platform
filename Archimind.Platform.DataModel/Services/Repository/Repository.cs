using System;
using System.Data;
using System.Data.Common;
using System.Xml;
using Archimind.Platform.Core;
using Archimind.Platform.Core.Internal;
using Archimind.Platform.Core.Text;
using Archimind.Platform.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents a database repository.
    /// </summary>
    public class Repository : DataModelServiceBase, IRepository
    {
        #region Members

        private string name;
        private Database database;
        private DbCommand command;
        private DbConnection connection;
        private DbTransaction transaction;
        private bool repositoryOpen;
        private bool commandActive;
        private bool connectionOpen;
        private bool transactionActive;

        #endregion

        #region Construtors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        public Repository()
        {
            this.repositoryOpen = false;
            this.commandActive = false;
            this.connectionOpen = false;
            this.transactionActive = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the repository name.
        /// </summary>
        /// <value>
        /// The repository name.
        /// </value>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets a value indicating whether [transaction active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [transaction active]; otherwise, <c>false</c>.
        /// </value>
        public bool TransactionActive
        {
            get { return this.transactionActive; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the default database.
        /// </summary>
        public void Create()
        {
            // Log create event.

            PlatformEventSource.Log.RepositoryCreate("default");

            // Create the database factory.

            DatabaseProviderFactory databaseFactory = 
                new DatabaseProviderFactory();

            // Create the default database.

            this.database = 
                databaseFactory.CreateDefault();

            // Set properties.

            this.repositoryOpen = true;

            // Log created event.

            PlatformEventSource.Log.RepositoryCreated("default");
        }

        /// <summary>
        /// Creates the database with the specified name.
        /// </summary>
        /// <param name="repositoryName">The repository name.</param>
        public void Create(string repositoryName)
        {
            // Log create event.

            PlatformEventSource.Log.RepositoryCreate(repositoryName);

            // Verify parameter.

            if (Strings.IsNullOrEmpty(repositoryName))
            {
                throw new ArgumentNullException("repositoryName");
            }

            // Create the database factory.

            DatabaseProviderFactory databaseFactory =
                new DatabaseProviderFactory();

            // Create the named database.

            this.database =
                databaseFactory.Create(repositoryName);

            // Set properties.

            this.name = repositoryName;
            this.repositoryOpen = true;

            // Log created event.

            PlatformEventSource.Log.RepositoryCreated(repositoryName);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns>A IDataReader object.</returns>
        public IDataReader ExecuteReader(string sqlStatement)
        {
            // Verify the parameter.

            if (Strings.IsNullOrEmpty(sqlStatement))
            {
                throw new ArgumentNullException("name");
            }

            // Return the reader.

            if (this.repositoryOpen)
            {
                return
                    this.database.ExecuteReader(
                        CommandType.Text,
                        sqlStatement);
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="storedProcedure">Name of the stored procedure.</param>
        /// <param name="parameters">The stored procedure parameters.</param>
        /// <returns>A IDataReader object.</returns>
        public IDataReader ExecuteStoredProcedure(string storedProcedure, object[] parameters)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(storedProcedure))
            {
                throw new ArgumentNullException("storedProcedure");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            // Return the reader.

            if (this.repositoryOpen)
            {
                return
                    this.database.ExecuteReader(
                        storedProcedure,
                        parameters);
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Creates the SQL statement command.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        public void CreateSqlCommand(string sqlStatement)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(sqlStatement))
            {
                throw new ArgumentNullException("sqlStatement");
            }

            // Initialize the command.

            if (this.repositoryOpen)
            {
                this.command =
                    this.database.GetSqlStringCommand(sqlStatement);
                this.command.CommandTimeout = 0;
                this.commandActive = true;
            }
            else
            {
                this.commandActive = false;

                // Throw error.

                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Creates the stored procedure command.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        public void CreateStoredProcedureCommand(string storedProcedure)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(storedProcedure))
            {
                throw new ArgumentNullException("storedProcedure");
            }

            // Initialize the command.

            if (this.repositoryOpen)
            {
                this.command =
                    this.database.GetStoredProcCommand(storedProcedure);
                this.command.CommandTimeout = 0;
                this.commandActive = true;
            }
            else
            {
                this.commandActive = false;

                // Throw error.

                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a string parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The string value.</param>
        public void AddInParameter(string parameterName, string value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            if (Strings.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            // Add the string parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.String,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a GUID parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The value.</param>
        public void AddInParameter(string parameterName, Guid value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // Add the guid parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.Guid,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a BOOL parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The boolean value.</param>
        public void AddInParameter(string parameterName, bool value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            // Add the bool parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.Boolean,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a INT32 parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The value.</param>
        public void AddInParameter(string parameterName, int value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            // Add the int32 parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.Int32,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a DATETIME parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The value.</param>
        public void AddInParameter(string parameterName, DateTime value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // Add the date parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.DateTime,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a binary parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The value.</param>
        public void AddInParameter(string parameterName, byte[] value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // Add the byte array parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.Binary,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a xml parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The value.</param>
        public void AddInParameter(string parameterName, XmlDocument value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // Add the byte array parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.Xml,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Adds a DOUBLE parameter.
        /// </summary>
        /// <param name="parameterName">The name.</param>
        /// <param name="value">The value.</param>
        public void AddInParameter(string parameterName, double value)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentNullException("parameterName");
            }

            // Add the double parameter to the command.

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    this.database.AddInParameter(
                        this.command,
                        parameterName,
                        DbType.Double,
                        value);
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Executes the reader command.
        /// </summary>
        /// <returns>A IDataReader object.</returns>
        public IDataReader ExecuteReaderCommand()
        {
            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    // Return the reader.

                    using (this.command)
                    {
                        this.commandActive = false;

                        return
                            this.database.ExecuteReader(this.command);
                    }
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Executes the updater command.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        public int ExecuteUpdaterCommand()
        {
            int numberOfRowsAffected = 0;

            if (this.repositoryOpen)
            {
                if (this.commandActive)
                {
                    // Return the number of affected rows.

                    using (this.command)
                    {
                        if (this.transactionActive)
                        {
                            numberOfRowsAffected =
                                this.database.ExecuteNonQuery(
                                    this.command,
                                    this.transaction);
                        }
                        else
                        {
                            numberOfRowsAffected =
                                this.database.ExecuteNonQuery(this.command);
                        }
                    }

                    this.commandActive = false;

                    // Return.

                    return numberOfRowsAffected;
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryCommandNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Executes the SQL updater statement.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns>The number of rows affected.</returns>
        public int ExecuteUpdater(string sqlStatement)
        {
            // Verify parameters.

            if (Strings.IsNullOrEmpty(sqlStatement))
            {
                throw new ArgumentNullException("sqlStatement");
            }

            // Return the number of rows affected.

            if (this.repositoryOpen)
            {
                return
                    this.database.ExecuteNonQuery(
                        CommandType.Text,
                        sqlStatement);
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        public void OpenConnection()
        {
            if (this.repositoryOpen)
            {
                // Create the connection.

                this.connection =
                    this.database.CreateConnection();

                // Open the connection.

                this.connection.Open();
                this.connectionOpen = true;
            }
            else
            {
                this.connectionOpen = false;

                // Throw error.

                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void CloseConnection()
        {
            if (this.connectionOpen)
            {
                // Close the active connection.

                this.connection.Close();
                this.connectionOpen = false;
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryConnectionNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public void BeginTransaction()
        {
            if (this.connectionOpen)
            {
                // We don't allow nested transactions.

                if (!this.transactionActive)
                {
                    this.transaction =
                        this.connection.BeginTransaction();
                    this.transactionActive = true;
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryConnectionNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public void CommitTransaction()
        {
            if (this.connectionOpen)
            {
                if (this.transactionActive)
                {
                    this.transaction.Commit();
                    this.transactionActive = false;
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryTransactionNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryConnectionNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public void RollbackTransaction()
        {
            if (this.connectionOpen)
            {
                if (this.transactionActive)
                {
                    this.transaction.Rollback();
                    this.transactionActive = false;
                }
                else
                {
                    string error = string.Format(
                        Application.Culture,
                        Properties.Resources.RES_RepositoryTransactionNotInitialized);
                    throw new RepositoryException(error);
                }
            }
            else
            {
                string error = string.Format(
                    Application.Culture,
                    Properties.Resources.RES_RepositoryConnectionNotInitialized);
                throw new RepositoryException(error);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
