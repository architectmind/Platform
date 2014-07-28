using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Archimind.Platform.Core.Log
{
    /// <summary>
    /// Represents a log handler.
    /// </summary>
    public class LogHandler
    {
        #region Constants

        private const string CategoryEvents = "Events";
        private const string CategoryTraces = "Traces";
        private const string CategoryHandledExceptions = "ErrorsHandled";
        private const string CategoryUnhandledExceptions = "ErrorsUnhandled";

        private const int PriorityEvents = 3000;
        private const int PriorityTraces = 3000;
        private const int PriorityHandledExceptions = 2000;
        private const int PriorityUnhandledExceptions = 1000;

        private const int EventIdEvents = 3000;
        private const int EventIdTraces = 3000;
        private const int EventIdHandledExceptions = 2000;
        private const int EventIdUnhandledExceptions = 1000;

        private const string TitleEvents = "Event Log";
        private const string TitleTraces = "Trace Log";
        private const string TitleHandledExceptions = "Handled Errors Log";
        private const string TitleUnhandledExceptions = "Unhandled Errors Log";

        private const TraceEventType SeverityEvents = TraceEventType.Information;
        private const TraceEventType SeverityTraces = TraceEventType.Information;
        private const TraceEventType SeverityHandledExceptions = TraceEventType.Warning;
        private const TraceEventType SeverityUnhandledExceptions = TraceEventType.Error;

        #endregion

        #region Public Methods

        #region Events

        /// <summary>
        /// Logs a new event.
        /// </summary>
        /// <param name="message">Log message.</param>
        public static void Event(string message)
        {
            Event(message, PriorityEvents);
        }

        /// <summary>
        /// Logs a new event.
        /// </summary>
        /// <param name="message">Log message.</param>
        /// <param name="priority">Log entry priority.</param>
        public static void Event(string message, int priority)
        {
            Event(message, priority, EventIdEvents);
        }

        /// <summary>
        /// Logs a new event.
        /// </summary>
        /// <param name="message">Log message.</param>
        /// <param name="priority">Log entry priority.</param>
        /// <param name="eventId">Log entry event identifier.</param>
        public static void Event(string message, int priority, int eventId)
        {
            Event(message, priority, eventId, SeverityEvents);
        }

        /// <summary>
        /// Logs a new event.
        /// </summary>
        /// <param name="message">Log message.</param>
        /// <param name="priority">Log entry priority.</param>
        /// <param name="eventId">Log entry event identifier.</param>
        /// <param name="severity">Log entry severity.</param>
        public static void Event(string message, int priority, int eventId, TraceEventType severity)
        {
            WriteEntry(message, priority, eventId, severity, CategoryEvents, TitleEvents);
        }

        #endregion

        #region Trace

        /// <summary>
        /// Logs a new trace.
        /// </summary>
        /// <param name="message">Trace message.</param>
        public static void Trace(string message)
        {
            Trace(message, PriorityTraces);
        }

        /// <summary>
        /// Logs a new trace.
        /// </summary>
        /// <param name="message">Trace message.</param>
        /// <param name="priority">Trace entry priority.</param>
        public static void Trace(string message, int priority)
        {
            Trace(message, priority, EventIdTraces);
        }

        /// <summary>
        /// Logs a new trace.
        /// </summary>
        /// <param name="message">Trace message.</param>
        /// <param name="priority">Trace entry priority.</param>
        /// <param name="eventId">Trace entry event identifier.</param>
        public static void Trace(string message, int priority, int eventId)
        {
            Trace(message, priority, eventId, SeverityTraces);
        }

        /// <summary>
        /// Logs a new trace.
        /// </summary>
        /// <param name="message">Trace message.</param>
        /// <param name="priority">Trace entry priority.</param>
        /// <param name="eventId">Trace entry event identifier.</param>
        /// <param name="severity">Trace entry severity.</param>
        public static void Trace(string message, int priority, int eventId, TraceEventType severity)
        {
            WriteEntry(message, priority, eventId, severity, CategoryTraces, TitleTraces);
        }

        #endregion

        #region Handled Errors

        /// <summary>
        /// Logs an handled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        public static void HandledError(Exception ex)
        {
            HandledError(ex, PriorityHandledExceptions);
        }

        /// <summary>
        /// Logs an handled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        /// <param name="priority">Log entry priority.</param>
        public static void HandledError(Exception ex, int priority)
        {
            HandledError(ex, priority, EventIdHandledExceptions);
        }

        /// <summary>
        /// Logs an handled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        /// <param name="priority">Log entry priority.</param>
        /// <param name="eventId">Log entry event identifier.</param>
        public static void HandledError(Exception ex, int priority, int eventId)
        {
            HandledError(ex, priority, eventId, SeverityHandledExceptions);
        }

        /// <summary>
        /// Logs an handled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        /// <param name="priority">Log entry priority.</param>
        /// <param name="eventId">Log entry event identifier.</param>
        /// <param name="severity">Log entry severity.</param>
        public static void HandledError(Exception ex, int priority, int eventId, TraceEventType severity)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            WriteEntry(ex.ToString(), priority, eventId, severity, CategoryHandledExceptions, TitleHandledExceptions);
        }

        #endregion

        #region Unhandled Errors

        /// <summary>
        /// Logs an unhandled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        public static void UnhandledError(Exception ex)
        {
            UnhandledError(ex, PriorityUnhandledExceptions);
        }

        /// <summary>
        /// Logs an unhandled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        /// <param name="priority">Log entry priority.</param>
        public static void UnhandledError(Exception ex, int priority)
        {
            UnhandledError(ex, priority, EventIdUnhandledExceptions);
        }

        /// <summary>
        /// Logs an unhandled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        /// <param name="priority">Log entry priority.</param>
        /// <param name="eventId">Log entry event identifier.</param>
        public static void UnhandledError(Exception ex, int priority, int eventId)
        {
            UnhandledError(ex, priority, eventId, SeverityUnhandledExceptions);
        }

        /// <summary>
        /// Logs an unhandled exception.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        /// <param name="priority">Log entry priority.</param>
        /// <param name="eventId">Log entry event identifier.</param>
        /// <param name="severity">Log entry severity.</param>
        public static void UnhandledError(Exception ex, int priority, int eventId, TraceEventType severity)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            WriteEntry(ex.ToString(), priority, eventId, severity, CategoryUnhandledExceptions, TitleUnhandledExceptions);
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Writes the entry.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="category">The category.</param>
        /// <param name="title">The title.</param>
        private static void WriteEntry(string message, int priority, int eventId, TraceEventType severity, string category, string title)
        {
            try
            {
                LogEntry entry = new LogEntry();
                entry.Categories.Add(category);
                entry.TimeStamp = DateTime.Now;
                entry.EventId = eventId;
                entry.Message = message;
                entry.Priority = priority;
                entry.Severity = severity;
                entry.Title = title;
                Logger.Write(entry);
            }
            catch (Exception)
            {
                // Ignore errors because the log configuration may be missing
            }
        }

        #endregion
    }
}
