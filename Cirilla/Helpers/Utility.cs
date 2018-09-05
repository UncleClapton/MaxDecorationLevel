﻿using Cirilla.Core.Models;
using Cirilla.ViewModels;
using System;
using System.Collections.Generic;

namespace Cirilla.Helpers
{
    public static class Utility
    {
        // Here we map a Core.Models type to a ViewModel
        private static readonly Dictionary<Type, Type> _handlerTypeToViewModelTypeMap = new Dictionary<Type, Type>
            {
                { typeof(GMD), typeof(GMDViewModel) }
            };

        // Maps a MHFileType to a FileTypeTabItemViewModelBase
        public static FileTypeTabItemViewModelBase GetViewModelForFile(string path)
        {
            MHFileType reg = Core.Helpers.Utility.GetFileType(path);

            if (_handlerTypeToViewModelTypeMap.TryGetValue(reg.Handler, out Type vmType))
                return (FileTypeTabItemViewModelBase)Activator.CreateInstance(vmType, path);
            else
                throw new Exception("This type of files are currently not supported.");
        }
    }
}