using System;
using System.Diagnostics.Tracing;

namespace Archimind.Platform.Instrumentation
{
    /// <summary>
    /// Represents a platform event source for the ETW infrastructure.
    /// </summary>
    [EventSource(
        Name = "Archimind-Platform",
        LocalizationResources = "Archimind.Platform.Instrumentation.Properties.Resources")]
    public partial class PlatformEventSource : EventSource
    {
        #region Members

        /// <summary>
        /// The singleton instance.
        /// </summary>
        private static readonly Lazy<PlatformEventSource> Instance =
            new Lazy<PlatformEventSource>(() => new PlatformEventSource());

        #endregion

        #region Constructor

        /// <summary>
        /// Prevents a default instance of the <see cref="PlatformEventSource"/> class from being created.
        /// </summary>
        private PlatformEventSource()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        public static PlatformEventSource Log
        {
            get { return Instance.Value; }
        }

        #endregion

        #region Repository

        /// <summary>
        /// Repository error event.
        /// </summary>
        /// <param name="message">The message.</param>
        [Event(1,
            Message = "General error message = {0}",
            Opcode = Opcodes.Error,
            Task = Tasks.General,
            Keywords = Keywords.DataLayer,
            Level = EventLevel.Error)]
        public void GeneralError(string message)
        {
            if (this.IsEnabled(EventLevel.Error, Keywords.DataLayer))
            {
                this.WriteEvent(1, message);
            }
        }

        /// <summary>
        /// Create repository event.
        /// </summary>
        /// <param name="repository">The repository.</param>
        [Event(2,
            Message = "Create repository name = {0}",
            Opcode = Opcodes.Create,
            Task = Tasks.Repository,
            Keywords = Keywords.DataLayer,
            Level = EventLevel.Informational)]
        public void RepositoryCreate(string repository)
        {
            if(this.IsEnabled(EventLevel.Informational, Keywords.DataLayer))
            {
                this.WriteEvent(2, repository);
            }
        }

        /// <summary>
        /// Created repository event.
        /// </summary>
        /// <param name="repository">The repository.</param>
        [Event(3,
            Message = "Created repository name = {0}",
            Opcode = Opcodes.Created,
            Task = Tasks.Repository,
            Keywords = Keywords.DataLayer,
            Level = EventLevel.Informational)]
        public void RepositoryCreated(string repository)
        {
            if (this.IsEnabled(EventLevel.Informational, Keywords.DataLayer))
            {
                this.WriteEvent(3, repository);
            }
        }

        /// <summary>
        /// Repository error event.
        /// </summary>
        /// <param name="message">The message.</param>
        [Event(4,
            Message = "Repository error message = {0}",
            Opcode = Opcodes.Error,
            Task = Tasks.Repository,
            Keywords = Keywords.DataLayer,
            Level = EventLevel.Error)]
        public void RepositoryError(string message)
        {
            if (this.IsEnabled(EventLevel.Error, Keywords.DataLayer))
            {
                this.WriteEvent(4, message);
            }
        }

        #endregion

        #region Keywords

        /// <summary>
        /// Represents the list of keywords accepted.
        /// </summary>
        public class Keywords
        {
            /// <summary>
            /// The data layer.
            /// </summary>
            public const EventKeywords DataLayer = (EventKeywords)1;

            /// <summary>
            /// The business layer.
            /// </summary>
            public const EventKeywords BusinessLayer = (EventKeywords)2;

            /// <summary>
            /// The service layer.
            /// </summary>
            public const EventKeywords ServiceLayer = (EventKeywords)4;

            /// <summary>
            /// The presentation layer.
            /// </summary>
            public const EventKeywords PresentationLayer = (EventKeywords)8;
        }

        #endregion

        #region Opcodes

        /// <summary>
        /// Represents the list of OPCODES accepted.
        /// </summary>
        public class Opcodes
        {
            /// <summary>
            /// The start event OPCODE.
            /// </summary>
            public const EventOpcode Start = (EventOpcode)20;

            /// <summary>
            /// The finish event OPCODE.
            /// </summary>
            public const EventOpcode Finish = (EventOpcode)21;

            /// <summary>
            /// The create event OPCODE.
            /// </summary>
            public const EventOpcode Create = (EventOpcode)22;

            /// <summary>
            /// The error event OPCODE.
            /// </summary>
            public const EventOpcode Error = (EventOpcode)23;

            /// <summary>
            /// The warning event OPCODE.
            /// </summary>
            public const EventOpcode Warning = (EventOpcode)24;

            /// <summary>
            /// The starting event OPCODE.
            /// </summary>
            public const EventOpcode Starting = (EventOpcode)25;

            /// <summary>
            /// The finishing event OPCODE.
            /// </summary>
            public const EventOpcode Finishing = (EventOpcode)26;

            /// <summary>
            /// The creating event OPCODE.
            /// </summary>
            public const EventOpcode Creating = (EventOpcode)27;

            /// <summary>
            /// The started event OPCODE.
            /// </summary>
            public const EventOpcode Started = (EventOpcode)28;

            /// <summary>
            /// The finished event OPCODE.
            /// </summary>
            public const EventOpcode Finished = (EventOpcode)29;

            /// <summary>
            /// The created event OPCODE.
            /// </summary>
            public const EventOpcode Created = (EventOpcode)30;
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Represents the list of tasks accepted.
        /// </summary>
        public class Tasks
        {
            /// <summary>
            /// The initialize event task.
            /// </summary>
            public const EventTask Initialize = (EventTask)1;

            /// <summary>
            /// The general event task.
            /// </summary>
            public const EventTask General = (EventTask)2;

            /// <summary>
            /// The repository create event task.
            /// </summary>
            public const EventTask Repository = (EventTask)4;
        }

        #endregion
    }
}
