using ApplicationMVVM.Models;
using Shared.Enums;
using Shared.Extensions;
using Shared.Handlers;
using System.ComponentModel;
using System.Windows.Input;

namespace ApplicationMVVM.ViewModels
{
    /// <summary>
    /// Task interaction view model. Used for creation, editing and displaying task properties.
    /// </summary>
    public class TaskInteractionViewModel : INotifyPropertyChanged
    {
        private readonly ObjectCollectionModel objectCollectionModel;
        private TaskObject task;

        public TaskInteractionViewModel(ObjectCollectionModel collectionModel, TaskObject? task = null)
        {
            objectCollectionModel = collectionModel;
            Task = task ?? new();
            States = new State[] { State.InProcess, State.Complete };
            AddCommand = new CommandHandler(() => objectCollectionModel.Add(Task), () => !IsCreation);
        }

        public ICommand SubscribeCommand { get; }
        public ICommand AddCommand { get; }

        /// <summary>
        /// Title of the parent window.
        /// </summary>
        public string Title => "Task interaction window";

        /// <summary>
        /// Collection of state enums.
        /// </summary>
        public State[] States { get; }

        public TaskObject Task
        {
            get => task;
            set
            {
                task = value;
                PropertyChanged?.Raise(this);
            }
        }

        /// <summary>
        /// Disables Id and 'add to list' button.
        /// </summary>
        public bool IsCreation => objectCollectionModel.Objects.Contains(Task);


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
