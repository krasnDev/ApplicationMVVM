using ApplicationMVVM.Models;
using Shared.Extensions;
using Shared.Handlers;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace ApplicationMVVM.ViewModels
{
    /// <summary>
    /// Document interaction view model. Used for creation, editing and displaying document properties.
    /// </summary>
    public class DocInteractionViewModel : INotifyPropertyChanged
    {
        private readonly ObjectCollectionModel objectCollectionModel;
        private DocumentObject document;

        public DocInteractionViewModel(ObjectCollectionModel collectionModel, DocumentObject? document = null)
        {
            objectCollectionModel = collectionModel;
            Document = document ?? new();
            SubscribeCommand = new CommandHandler(() => SubcribeDocument(), () => !IsReadOnly);
            AddCommand = new CommandHandler(() => objectCollectionModel.Add(Document), () => IsCreation);
        }

        public ICommand SubscribeCommand { get; }
        public ICommand AddCommand { get; }

        /// <summary>
        /// Title of the parent window.
        /// </summary>
        public string Title => "Document interaction window";

        public DocumentObject Document
        {
            get => document;
            set
            {
                document = value;
                PropertyChanged?.Raise(this);
            }
        }

        public bool IsReadOnly => Document?.Guid.GetValueOrDefault() != Guid.Empty;

        /// <summary>
        /// Disables Id and 'add to list' button.
        /// </summary>
        public bool IsCreation => !objectCollectionModel.Objects.Contains(Document);

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Handler for subscribe action.
        /// </summary>
        private void SubcribeDocument()
        {
            Document.Subscribe();
            PropertyChanged?.Raise(this, nameof(IsReadOnly));
        }

    }
}
