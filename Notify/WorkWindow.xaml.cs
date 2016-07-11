using System.Windows;

namespace Notify
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();
            SelectedTextBox.Focus();
        }
    }
}
