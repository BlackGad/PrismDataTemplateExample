using System.ComponentModel.Composition;
using System.Windows;
using PrismDataTemplateExample.Models;
using PrismDataTemplateExample.Prism;

namespace PrismDataTemplateExample.Views
{
    [Export("ViewModel", typeof(DataGroupDetailedView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataGroupDetailedViewModel : DependencyObject,
                                              IPayloadContainer
    {
        #region Property definitions

        public static readonly DependencyProperty PayloadProperty =
            DependencyProperty.Register("Payload",
                                        typeof(DataGroup),
                                        typeof(DataGroupDetailedViewModel),
                                        new UIPropertyMetadata());

        #endregion

        #region Properties

        public DataGroup Payload
        {
            get { return (DataGroup)GetValue(PayloadProperty); }
            set { SetValue(PayloadProperty, value); }
        }

        #endregion

        #region IPayloadContainer Members

        object IPayloadContainer.Payload
        {
            get { return Payload; }
            set { Payload = value as DataGroup; }
        }

        #endregion
    }
}