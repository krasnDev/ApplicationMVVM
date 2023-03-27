using ApplicationMVVM.Implementations;
using ApplicationMVVM.Models;
using Shared.Extensions;
using Shared.Handlers;
using Shared.Interfaces;
using Shared.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace ApplicationMVVM.ViewModels
{
    /// <summary>
    /// Main application view model.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IWindowService windowService = new WindowService();
        private readonly ObjectCollectionModel collectionModel = new();
        private BaseObject selectedObject;

        public MainWindowViewModel()
        {
            AddDocumentCommand = new CommandHandler(() => windowService?.ShowWindow(new DocInteractionViewModel(collectionModel)));
            AddTaskCommand = new CommandHandler(() => windowService?.ShowWindow(new TaskInteractionViewModel(collectionModel)));
            EditCommand = new CommandHandler(() => windowService?.ShowWindow(GetViewModelForSelected()), () => SelectedObject != null);
        }

        public ICommand AddDocumentCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand EditCommand { get; }

        public BaseObject SelectedObject
        {
            get => selectedObject;
            set
            {
                selectedObject = value;
                PropertyChanged?.Raise(this);
            }
        }

        public ObservableCollection<BaseObject> Objects => collectionModel.Objects;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Get a specified view model for current object type.
        /// </summary>
        /// <returns>Specified view model or exception.</returns>
        /// <exception cref="NotImplementedException"></exception>
        private object GetViewModelForSelected()
        {
            object viewModel = null;
            if (SelectedObject != null)
            {
                viewModel = SelectedObject.Type switch
                {
                    Shared.Enums.ObjectType.Document => new DocInteractionViewModel(collectionModel, (DocumentObject?)SelectedObject),
                    Shared.Enums.ObjectType.Task => new TaskInteractionViewModel(collectionModel, (TaskObject?)SelectedObject),
                    _ => throw new NotImplementedException(),
                };
            }
            return viewModel;
        }

    }
}
