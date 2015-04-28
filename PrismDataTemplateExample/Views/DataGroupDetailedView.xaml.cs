using System.ComponentModel.Composition;

namespace PrismDataTemplateExample.Views
{
    [Export(typeof(DataGroupDetailedView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DataGroupDetailedView
    {
        #region Constructors

        public DataGroupDetailedView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        [Import("ViewModel", typeof(DataGroupDetailedView))]
        public DataGroupDetailedViewModel ViewModel
        {
            get { return DataContext as DataGroupDetailedViewModel; }
            set { DataContext = value; }
        }

        #endregion
    }
}