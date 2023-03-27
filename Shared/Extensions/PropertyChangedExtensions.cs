using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared.Extensions
{
    public static class PropertyChangedExtensions
    {
        /// <summary>
        /// Invoke PropertyChanged event.
        /// </summary>
        /// <param name="handler">Event.</param>
        /// <param name="sender">Owner.</param>
        /// <param name="propertyName">Property name.</param>
        public static void Raise(this PropertyChangedEventHandler handler, INotifyPropertyChanged sender, [CallerMemberName] string? propertyName = null)
        {
            handler?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
