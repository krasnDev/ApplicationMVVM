using Shared.Models;
using System.Collections.ObjectModel;

namespace ApplicationMVVM.Models
{
    /// <summary>
    /// Represent a collection model.
    /// </summary>
    public class ObjectCollectionModel
    {
        private static int id = 1;

        public ObjectCollectionModel() 
        {
            Objects = new ObservableCollection<BaseObject>();
        }

        /// <summary>
        /// Collection of objects.
        /// </summary>
        public readonly ObservableCollection<BaseObject> Objects;

        /// <summary>
        /// Adds object to the collection.
        /// </summary>
        /// <param name="obj">Object to add.</param>
        public void Add(BaseObject obj)
        {
            if (!Objects.Contains(obj)) 
            {
                SetId(obj);
                Objects.Add(obj);
            }
        }

        /// <summary>
        /// Sets Id to the object. 
        /// </summary>
        /// <param name="obj">Object to set id.</param>
        private void SetId(BaseObject obj)
        {
            obj.Id = id;
            id++;
        }
    }
}
