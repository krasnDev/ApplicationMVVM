using Shared.Enums;
using Shared.Models;

namespace ApplicationMVVM.Models
{
    /// <summary>
    /// Represents a task object.
    /// </summary>
    public class TaskObject : BaseObject
    {
        private State state;
        private const string type = "Задача";

        /// <summary>
        /// Creates a task instance.
        /// </summary>
        public TaskObject() : base(type, ObjectType.Task) { }

        /// <summary>
        /// Task state.
        /// </summary>
        public State State
        {
            get => state;
            set
            {
                state = value;
                RaiseBasePropertyChaged();
            }
        }
    }
}
