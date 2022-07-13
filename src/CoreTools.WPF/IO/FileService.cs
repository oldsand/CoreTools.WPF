using System;
using CoreTools.WPF.Services;
using Ookii.Dialogs.Wpf;

namespace CoreTools.WPF.IO
{
    public class FileService : IFileService
    {
        public string SelectFile(Action<FileDialogOptions>? config = null)
        {
            var options = new FileDialogOptions();
            config?.Invoke(options);
            var dialog = ConfigureDialog(options);
            return dialog.ShowDialog() == true ? dialog.FileName : string.Empty;
        }

        public string SelectDirectory(Action<FileDialogOptions>? config = null)
        {
            throw new NotImplementedException();
        }

        private static VistaOpenFileDialog ConfigureDialog(FileDialogOptions options)
        {
            var dialog = new VistaOpenFileDialog
            {
                Title = options.Title,
                Filter = options.Filter,
                DefaultExt = options.DefaultExt,
                AddExtension = options.AddExtension,
                Multiselect = options.Multiselect,
                CheckFileExists = options.CheckFileExists,
                ShowReadOnly = options.ShowReadOnly,
                ReadOnlyChecked = options.ReadOnlyChecked,
                CheckPathExists = options.CheckPathExists,
                ValidateNames = options.ValidateNames,
                RestoreDirectory = options.RestoreDirectory
            };

            return dialog;
        }
    }
}