using System;
using System.Windows;
using System.Windows.Markup;
using PrismDataTemplateExample.Extensions;

namespace PrismDataTemplateExample.Prism
{
    [ContentProperty]
    public class PrismHierarchicalDataTemplate : HierarchicalDataTemplate,
                                                 IPrismDataTemplate
    {
        #region Constructors

        public PrismHierarchicalDataTemplate()
        {
            VisualTree = new PrismFrameworkElementFactory(this);
            VisualTree.InternalMethodCall("Seal", this);
        }

        #endregion

        #region IPrismDataTemplate Members

        public double? DesignHeight { get; set; }
        public double? DesignWidth { get; set; }
        public string Key { get; set; }
        public Type ServiceType { get; set; }

        #endregion
    }
}