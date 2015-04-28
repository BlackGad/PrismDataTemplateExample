using System.ComponentModel.Composition;

namespace PrismDataTemplateExample.Views
{
    [Export(typeof(DataItemDetailedView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DataItemDetailedView
    {
        #region Constructors

        public DataItemDetailedView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        [Import("ViewModel", typeof(DataItemDetailedView))]
        public DataItemDetailedViewModel ViewModel
        {
            get { return DataContext as DataItemDetailedViewModel; }
            set { DataContext = value; }
        }

        #endregion
    }
}