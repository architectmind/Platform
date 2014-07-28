using System;
using System.Data;

namespace Archimind.Platform.DataModel.Services
{
    /// <summary>
    /// Represents the interface of a database repository.
    /// </summary>
    public interface IRepository : IDataModelServiceBase
    {
        /// <summary>
        /// Creates the specified repository name.
        /// </summary>
        /// <param name="repositoryName">Name of the repository.</param>
        void Create(string repositoryName);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns>The data reader object.</returns>
        IDataReader ExecuteReader(string sqlStatement);

        /// <summary>
        /// Executes the updater.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns>Number of affected rows.</returns>
        int ExecuteUpdater(string sqlStatement);
    }
}
