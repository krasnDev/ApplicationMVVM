using Shared.Models;
using System;

namespace ApplicationMVVM.Models
{
    /// <summary>
    /// Represent a document object.
    /// </summary>
    public class DocumentObject : BaseObject
    {
        private const string type = "Документ";
        private Guid? guid;
        private string body = string.Empty;

        /// <summary>
        /// Creates a document instance.
        /// </summary>
        public DocumentObject() : base(type, Shared.Enums.ObjectType.Document) { }

        /// <summary>
        /// Document text.
        /// </summary>
        public string Body
        {
            get => body;
            set
            {
                body = value;
                RaiseBasePropertyChaged();
            }
        }

        /// <summary>
        /// Digital signature.
        /// </summary>
        public Guid? Guid
        {
            get => guid; 
            set
            {
                guid = value;
                RaiseBasePropertyChaged();
            }
        }

        public void Subscribe()
        {
            Guid = System.Guid.NewGuid();
        }
    }
}
