using ApplicationMVVM.Views;
using Shared.Interfaces;

namespace ApplicationMVVM.Implementations
{
    internal class WindowService : IWindowService
    {
        public void ShowWindow(object viewModel)
        {
            CommonWindow win = new()
            {
                DataContext = viewModel,
                Owner = App.Current.MainWindow,
            };

            win.ShowDialog();

        }
    }
}
