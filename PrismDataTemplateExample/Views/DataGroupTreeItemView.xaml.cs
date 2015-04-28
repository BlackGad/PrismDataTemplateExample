using System.ComponentModel.Composition;

namespace PrismDataTemplateExample.Views
{
    [Export(typeof(DataGroupTreeItemView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DataGroupTreeItemView
    {
        #region Constructors

        public DataGroupTreeItemView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        [Import("ViewModel", typeof(DataGroupTreeItemView))]
        public DataGroupTreeItemViewModel ViewModel
        {
            get { return DataContext as DataGroupTreeItemViewModel; }
            set { DataContext = value; }
        }

        #endregion
    }
}