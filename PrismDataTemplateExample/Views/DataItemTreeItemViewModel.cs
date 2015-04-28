using System.ComponentModel.Composition;
using System.Windows;
using PrismDataTemplateExample.Models;
using PrismDataTemplateExample.Prism;

namespace PrismDataTemplateExample.Views
{
    [Export("ViewModel", typeof(DataItemTreeItemView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataItemTreeItemViewModel : DependencyObject,
                                             IPayloadContainer
    {
        #region Property definitions

        public static readonly DependencyProperty PayloadProperty =
            DependencyProperty.Register("Payload",
                                        typeof(DataItem),
                                        typeof(DataItemTreeItemViewModel),
                                        new UIPropertyMetadata());

        #endregion

        #region Properties

        public DataItem Payload
        {
            get { return (DataItem)GetValue(PayloadProperty); }
            set { SetValue(PayloadProperty, value); }
        }

        #endregion

        #region IPayloadContainer Members

        object IPayloadContainer.Payload
        {
            get { return Payload; }
            set { Payload = value as DataItem; }
        }

        #endregion
    }
}