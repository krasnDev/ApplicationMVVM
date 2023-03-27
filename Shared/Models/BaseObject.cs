using Shared.Enums;
using Shared.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared.Models
{
    /// <summary>
    /// Represents a base object.
    /// </summary>
    public class BaseObject : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private int id;

        /// <summary>
        /// Creates an instance of the base object with specified type.
        /// </summary>
        /// <param name="type">Russian language type name.</param>
        /// <param name="objectType">Type name enum.</param>
        public BaseObject(string type, ObjectType objectType)
        {
            DisplayType = type;
            Type = objectType;
        }

        /// <summary>
        /// Uniquie identifier.
        /// </summary>
        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Raise(this);
            }
        }

        /// <summary>
        /// Russian type name.
        /// </summary>
        public string DisplayType { get; internal set; } = string.Empty;

        /// <summary>
        /// Enum type name.
        /// </summary>
        public ObjectType Type { get; internal set; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Raise(this);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void RaiseBasePropertyChaged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Raise(this, propertyName);
        }

    }
}
