using System.Windows;
using System.Windows.Input;

namespace Notify
{
    public class WorkWindowViewModel
    {
        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand<Window>()
                {
                    CanExecuteFunc = (window) => window != null,
                    CommandAction = (window) => window.Close()
                };
            }
        }

        public string SelectedText { get; set; }
    }
}
