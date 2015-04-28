using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Practices.ServiceLocation;
using PrismDataTemplateExample.Extensions;

namespace PrismDataTemplateExample.Prism
{
    public class PrismFrameworkElementFactory : FrameworkElementFactory
    {
        #region Static members

        public static void SetViewDataContext(FrameworkElement view, object context)
        {
            if (view == null) return;
            if (view.DataContext == DependencyProperty.UnsetValue) view.DataContext = context;
            else
            {
                var payloadViewModel = view.DataContext as IPayloadContainer;
                if (payloadViewModel != null) payloadViewModel.Payload = context;
            }
        }

        #endregion

        private readonly IPrismDataTemplate _prismDataTemplate;

        #region Constructors

        public PrismFrameworkElementFactory(IPrismDataTemplate prismDataTemplate)
            : base(typeof(Control))
        {
            if (prismDataTemplate == null) throw new ArgumentNullException("prismDataTemplate");
            _prismDataTemplate = prismDataTemplate;

            OverrideDefaultFactory();
        }

        #endregion

        #region Event handlers

        private void container_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var container = sender as ContentPresenter;
            if (container == null || VisualTreeHelper.GetChildrenCount(container) == 0) return;

            var view = VisualTreeHelper.GetChild(container, 0) as FrameworkElement;
            SetViewDataContext(view, container.DataContext);
        }

        #endregion

        #region Members

        internal void OverrideDefaultFactory()
        {
            var field = typeof(FrameworkElementFactory).GetField("_knownTypeFactory", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null) throw new NotSupportedException();
            field.SetValue(this, new Func<object>(CreatePrismInstance));
        }

        private object CreatePrismInstance()
        {
            if (this.IsInDesignMode())
            {
                var designTimeBlankContainer = new Grid
                {
                    Background = new SolidColorBrush(Color.FromArgb(50, 120, 120, 120)),
                };
                if (_prismDataTemplate.DesignWidth.HasValue) designTimeBlankContainer.Width = _prismDataTemplate.DesignWidth.Value;
                if (_prismDataTemplate.DesignHeight.HasValue) designTimeBlankContainer.Height = _prismDataTemplate.DesignHeight.Value;

                var formatText = string.Format("Prism template: {0}", _prismDataTemplate.ServiceType.Name);
                if (!string.IsNullOrEmpty(_prismDataTemplate.Key)) formatText += string.Format(", {0}", _prismDataTemplate.Key);
                designTimeBlankContainer.Children.Add(new TextBlock
                {
                    Text = formatText,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                });

                return designTimeBlankContainer;
            }

            var view = ServiceLocator.Current.GetInstance(_prismDataTemplate.ServiceType, _prismDataTemplate.Key) as FrameworkElement;
            if (view == null)
            {
                var error = string.Format("Service type {0} with {1} key object must be inherited from FrameworkElement",
                                          _prismDataTemplate.ServiceType,
                                          _prismDataTemplate.Key);
                throw new ArgumentException(error);
            }
            var container = new ContentPresenter
            {
                Content = view
            };
            container.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(LoadedRoutedEventHandler));
            container.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(UnloadedRoutedEventHandler));

            return container;
        }

        private void LoadedRoutedEventHandler(object sender, RoutedEventArgs e)
        {
            var container = (FrameworkElement)sender;
            container.DataContextChanged += container_DataContextChanged;

            if (VisualTreeHelper.GetChildrenCount(container) == 0) return;

            var view = VisualTreeHelper.GetChild(container, 0) as FrameworkElement;
            SetViewDataContext(view, container.DataContext);
        }

        private void UnloadedRoutedEventHandler(object sender, RoutedEventArgs e)
        {
            var container = (FrameworkElement)sender;
            container.DataContextChanged -= container_DataContextChanged;
        }

        #endregion
    }
}