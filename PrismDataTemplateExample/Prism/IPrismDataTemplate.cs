using System;

namespace PrismDataTemplateExample.Prism
{
    public interface IPrismDataTemplate
    {
        #region Properties

        double? DesignHeight { get; }
        double? DesignWidth { get; }
        string Key { get; }
        Type ServiceType { get; }

        #endregion
    }
}