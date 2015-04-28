using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismDataTemplateExample.Models
{
    public class DataGroup : DataBase
    {
        private int _priority;

        private IList<DataBase> _items;
        private string _title;

        #region Properties

        public int Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChangedAuto();
            }
        }

        public IList<DataBase> Items
        {
            get { return _items ?? (_items = new ObservableCollection<DataBase>()); }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChangedAuto();
            }
        }

        #endregion
    }
}