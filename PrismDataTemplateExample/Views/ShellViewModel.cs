using System.ComponentModel.Composition;
using System.Windows;
using PrismDataTemplateExample.Models;

namespace PrismDataTemplateExample.Views
{
    [Export("ViewModel", typeof(ShellView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellViewModel : DependencyObject
    {
        #region Property definitions

        public static readonly DependencyProperty DataProviderProperty =
            DependencyProperty.Register("DataProvider",
                                        typeof(DataProvider),
                                        typeof(ShellViewModel),
                                        new UIPropertyMetadata());

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem",
                                        typeof(object),
                                        typeof(ShellViewModel),
                                        new UIPropertyMetadata());

        #endregion

        #region Properties

        [Import]
        public DataProvider DataProvider
        {
            get { return (DataProvider)GetValue(DataProviderProperty); }
            set { SetValue(DataProviderProperty, value); }
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        #endregion
    }
}