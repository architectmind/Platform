using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using Archimind.Platform.DataModel.Services;
using Archimind.Platform.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;
using System.Data.Linq;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks;
using Archimind.Platform.BusinessEntities.Services;

namespace Archimind.Platform.DataModel.Tests
{
    class Program
    {
        #region Members

        static Repository repository = null;
        static ExceptionManager exManager = null;
        static string connectionString = @"Data Source=FERNANDES01\SQLDEV01;Initial Catalog=Logging;Integrated Security=True;Pooling=False";
    
        #endregion

        static void Main(string[] args)
        {
            /*
            var eventListener = new ObservableEventListener();
            eventListener.EnableEvents(
                PlatformEventSource.Log,
                EventLevel.LogAlways,
                Keywords.All);
            */
            // Subscription with SQL Server Sink            
            /*
            SinkSubscription<SqlDatabaseSink> subscription =
              eventListener.LogToSqlDatabase(
                "Platform Event Source",
                connectionString);            
            */
           // var subscription = eventListener.LogToConsole();

            Console.WriteLine("Data Directory = " + AppDomain.CurrentDomain.GetData("DataDirectory"));

            VerifyEventSource();

            try
            {
                // Test repository.

                ReadUsers();

                //TestRepository();

                // Test Exception Handling

                // TestExceptionHandling();
                /*
                eventListener.DisableEvents(PlatformEventSource.Log);
                subscription.Sink.FlushAsync().Wait();              
                ShowContentsOfSqlDatabaseTable();
                eventListener.Dispose();
                 */
            }
            catch (Exception ex)
            {
                Console.WriteLine("Throw an error: {0}", ex.Message);
            }
            Console.ReadLine();
        }

        #region Public Methods

        public static void ReadUsers()
        {
            using (SecurityStoreRepository securityStore = new SecurityStoreRepository())
            {
                var users = from u in securityStore.GetUsers() select u;

                foreach (User user in users)
                {
                    Console.WriteLine(user.SurrogateKey.ToString());
                    Console.WriteLine(user.NaturalKey);
                    Console.WriteLine(user.Name);
                }
            }

        }

        public static void ReadSqlStatement()
        {
            using (IDataReader reader = repository.ExecuteReader("SELECT TOP 1 * FROM Products"))
            {
                DisplayRowValues(reader);
            }
        }

        public static void ReadStoredProcedure()
        {
            using (IDataReader reader = repository.ExecuteStoredProcedure("GetProductName", new object[] { "1" }))
            {
                DisplayRowValues(reader);
            }
        }

        public static void ReadSqlStatementWithCommand()
        {
            string sqlStatement = "SELECT TOP 1 * FROM Products WHERE ProductName LIKE @name";

            // Create the command.

            repository.CreateSqlCommand(sqlStatement);

            // Add the parameter.

            repository.AddInParameter("name", "Ikura");

            // Execute the command.

            using (IDataReader reader = repository.ExecuteReaderCommand())
            {
                DisplayRowValues(reader);
            }
        }

        public static void ReadStoredProcedureWithCommand()
        {
            string sqlStatement = "GetProductsByCategory";

            // Create the command.

            repository.CreateStoredProcedureCommand(sqlStatement);

            // Add the parameter.

            repository.AddInParameter("CategoryID", "2");

            // Execute the command.

            using (IDataReader reader = repository.ExecuteReaderCommand())
            {
                DisplayRowValues(reader);
            }
        }

        public static void AddProduct()
        {
            string sqlStatement = "HOLAddProduct";

            // Create the command

            repository.CreateStoredProcedureCommand(sqlStatement);

            // Add parameters.

            repository.AddInParameter("ProductName", "Patricio");
            repository.AddInParameter("CategoryID", 8);
            repository.AddInParameter("UnitPrice", 99.9);

            // Execute the updater command.

            repository.ExecuteUpdaterCommand();
        }

        public static void UpdateProductsWithTransactions()
        {
            // Open the connection.

            repository.OpenConnection();

            try
            {
                string sqlStatement = "UpdateProduct";

                // Create the command

                repository.CreateStoredProcedureCommand(sqlStatement);

                // Add parameters.

                repository.AddInParameter("ProductID", 79);
                repository.AddInParameter("ProductName", "Patricio2");
                repository.AddInParameter("LastUpdate", "2014-06-05 23:08:11.077");

                // Begin transaction

                repository.BeginTransaction();

                // Execute the updater command.

                repository.ExecuteUpdaterCommand();

                // Commit transaction

                repository.CommitTransaction();

                // Close connection.

                repository.CloseConnection();
            }
            catch (Exception ex)
            {
                if (repository.TransactionActive)
                {
                    // Rollback transaction.

                    repository.RollbackTransaction();
                }
            }

        }

        #endregion

        #region Private Methods

        private static void TestExceptionHandling()
        {
            // Create the default ExceptionManager object from the configuration settings.

            ExceptionPolicyFactory policyFactory = new ExceptionPolicyFactory();
            exManager = policyFactory.CreateManager();

            // Create an ExceptionPolicy to illustrate the static HandleException method
            ExceptionPolicy.SetExceptionManager(exManager);

            // Load log handler.

            //LogWriterFactory logWriterFactory = new LogWriterFactory();
            //LogWriter logWriter = logWriterFactory.Create();
            //Logger.SetLogWriter(logWriter);

            Console.WriteLine("Generating div by zero exception");

            try
            {
                var result = CalculateSalary("john", 0);
            }
            catch (Exception ex)
            {               
                Exception exceptionToThrow;
                if (ExceptionPolicy.HandleException(ex, "DataLayer", out exceptionToThrow))
                {
                    if (exceptionToThrow == null)
                        throw;
                    else
                    {
                        throw exceptionToThrow;
                    }
                }               
            }
        }

        private static double CalculateSalary(string user, double salary)
        {
            if (salary == 0)
                throw new ArgumentNullException("salary","Error calculating salary");

            return (1000 / salary);
        }

        private static void TestRepository()
        {
            Console.WriteLine("Creating the repository");

            repository = new Repository();

            Console.WriteLine("Creating the default database...");

            repository.Create();

            Console.WriteLine("Read Sql Statement");

            ReadSqlStatement();

            Console.WriteLine("Read Stored Procedure");

            ReadStoredProcedure();

            Console.WriteLine("Execute sql command with named params");

            ReadSqlStatementWithCommand();

            Console.WriteLine("Execute Stored Procedure with named params");

            ReadStoredProcedureWithCommand();

            Console.WriteLine("Add Product");

            AddProduct();

            Console.WriteLine("Update Product With Transaction");

            UpdateProductsWithTransactions();

            Console.ReadLine();
        }

        private static void DisplayRowValues(IDataReader reader)
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine("{0} = {1}", reader.GetName(i), reader[i].ToString());
                }
                Console.WriteLine();
            }
        }


        private static void VerifyEventSource()
        {
            try
            {
                EventSourceAnalyzer.InspectAll(PlatformEventSource.Log);
                Console.WriteLine("No incompatibilities found in MyCompanyEventSource");
            }
            catch (EventSourceAnalyzerException e)
            {
                Console.WriteLine("Incompatibilities found in MyCompanyEventSource");
                Console.WriteLine(e.Message);
            }

        }

        private static void ShowContentsOfSqlDatabaseTable()
        {

            Console.WriteLine("ID Timestamp                   Message");
            Console.WriteLine("== =========================== ========================");
            LogMessageDataContext db = new LogMessageDataContext(connectionString);
            Table<Trace> traces = db.GetTable<Trace>();
            foreach (var trace in traces)
            {
                Console.WriteLine("{0}  {1}  {2}", trace.EventId, trace.Timestamp, trace.FormattedMessage);
            }
        }
        #endregion
    }
}
