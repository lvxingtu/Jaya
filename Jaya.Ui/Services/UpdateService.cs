﻿using Jaya.Shared.Services;
using System;
using System.Composition;

namespace Jaya.Ui.Services
{
    [Shared]
    [Export(nameof(UpdateService), typeof(IService))]
    public sealed class UpdateService: IService
    {
        public Version Version => Constants.VERSION;

        public string VersionString => string.Format("{0}.{1}.{2}.{3}", Version.Major, Version.Minor, Version.Build, Version.Revision);

        public byte Bitness => Environment.Is64BitOperatingSystem ? (byte)64 : (byte)32;
    }
}