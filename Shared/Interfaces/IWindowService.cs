namespace Shared.Interfaces
{
    /// <summary>
    /// Base interface for open windows.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Opens a window for this datacontext.
        /// </summary>
        /// <param name="dataContext">Datacontext for the window.</param>
        void ShowWindow(object dataContext);
    }
}
