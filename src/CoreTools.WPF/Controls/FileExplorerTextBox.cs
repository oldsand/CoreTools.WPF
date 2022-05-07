using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Ookii.Dialogs.Wpf;

namespace CoreTools.WPF.Controls
{
    public class FileExplorerTextBox: TextBox
    {
        static FileExplorerTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FileExplorerTextBox), 
                new FrameworkPropertyMetadata(typeof(FileExplorerTextBox)));
            
            CommandManager.RegisterClassCommandBinding(typeof(FileExplorerTextBox), new CommandBinding(
                ApplicationCommands.Open,
                (obj, e) => { e.Handled = true; ((FileExplorerTextBox)obj).ShowExplorerDialog(); },
                (_, e) => { e.CanExecute = true; }));
        }

        public string Filter
        {
            get => (string)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register(nameof(Filter), typeof(string), typeof(FileExplorerTextBox),
                new PropertyMetadata(default(string)));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(FileExplorerTextBox),
                new PropertyMetadata(default(string)));

        public bool SelectFolder
        {
            get => (bool)GetValue(SelectFolderProperty);
            set => SetValue(SelectFolderProperty, value);
        }

        public static readonly DependencyProperty SelectFolderProperty =
            DependencyProperty.Register(nameof(SelectFolder), typeof(bool), typeof(FileExplorerTextBox),
                new PropertyMetadata(default(bool)));

        private void ShowExplorerDialog()
        {
            if (SelectFolder)
                ShowOpenFolderDialog();
            else
                ShowOpenFileDialog();
        }

        private void ShowOpenFileDialog()
        {
            var dialog = new VistaOpenFileDialog
            {
                Title = Title,
                Filter = Filter
            };

            if (dialog.ShowDialog() == true)
            {
                Text = dialog.FileName;
            }
        }

        private void ShowOpenFolderDialog()
        {
            var dialog = new VistaFolderBrowserDialog
            {
                Description = Title,
                UseDescriptionForTitle = true
            };

            if (dialog.ShowDialog() == true)
            {
                Text = dialog.SelectedPath;
            }
        }
    }
}