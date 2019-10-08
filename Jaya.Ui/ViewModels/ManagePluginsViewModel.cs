﻿using Jaya.Ui.Base;
using Jaya.Ui.Services;
using System;
using System.Collections.Generic;

namespace Jaya.Ui.ViewModels
{
    public class ManagePluginsViewModel: ViewModelBase
    {
        public IEnumerable<ProviderServiceBase> Plugins => GetService<ProviderService>().Services;

        public ProviderServiceBase SelectedPlugin
        {
            get => Get<ProviderServiceBase>();
            set
            {
                if (Set(value))
                {
                    if (value == null || value.ConfigurationEditorType == null)
                        ConfigurationEditor = null;
                    else
                        ConfigurationEditor = Activator.CreateInstance(value.ConfigurationEditorType);

                    RaisePropertyChanged(nameof(IsHavingConfigurationEditor));
                }
            }
        }

        public bool IsHavingConfigurationEditor => ConfigurationEditor != null;

        public object ConfigurationEditor
        {
            get => Get<object>();
            private set => Set(value);
        }
    }
}