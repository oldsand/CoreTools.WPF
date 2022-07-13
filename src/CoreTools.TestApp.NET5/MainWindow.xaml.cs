using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreTools.TestApp.NET5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Folders = new ObservableCollection<Folder>(new List<Folder>
            {
                new()
                {
                    Name = "Root1",
                    Folders = new List<Folder>
                    {
                        new() { Name = "Child1" },
                        new() { Name = "Child2" },
                        new() { Name = "Child3" },
                        new() { Name = "Child4" }
                    }
                }
            });
        }

        public ObservableCollection<Folder> Folders { get; set; }
    }

    public class Folder
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<Folder> Folders { get; set; }
    }
}