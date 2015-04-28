using System.ComponentModel.Composition;

namespace PrismDataTemplateExample.Views
{
    [Export(typeof(DataItemTreeItemView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DataItemTreeItemView
    {
        #region Constructors

        public DataItemTreeItemView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        [Import("ViewModel", typeof(DataItemTreeItemView))]
        public DataItemTreeItemViewModel ViewModel
        {
            get { return DataContext as DataItemTreeItemViewModel; }
            set { DataContext = value; }
        }

        #endregion
    }
}