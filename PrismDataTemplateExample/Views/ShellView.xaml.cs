using System.ComponentModel.Composition;
using System.Windows;

namespace PrismDataTemplateExample.Views
{
    [Export(typeof(ShellView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ShellView
    {
        #region Constructors

        public ShellView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        [Import("ViewModel", typeof(ShellView))]
        public ShellViewModel ViewModel
        {
            get { return DataContext as ShellViewModel; }
            set { DataContext = value; }
        }

        #endregion

        #region Event handlers

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var model = ViewModel;
            if (model != null) model.SelectedItem = e.NewValue;
        }

        #endregion
    }
}