using System;
using CoreTools.WPF.IO;

namespace CoreTools.WPF.Services
{
    public interface IFileService
    {
        public string SelectFile(Action<FileDialogOptions>? config = null);
        
        public string SelectDirectory(Action<FileDialogOptions>? config = null);
    }
}