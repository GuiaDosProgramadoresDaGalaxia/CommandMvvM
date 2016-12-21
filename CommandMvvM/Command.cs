using System;
using System.Windows.Input;

namespace CommandMvvM
{
    public class Command : ICommand
    {
        public Action Action { get; set; }
        public string DisplayName { get; set; }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Command(Action action)
        {
            Action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public void Execute(object parameter)
        {
            Action?.Invoke();
        }
    }

    public class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<T> Action { get; set; }
        public string DisplayName { get; set; }
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public Command(Action<T> action)
        {
            Action = action;
        }
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }
        public void Execute(object parameter)
        {
            if (Action != null && parameter is T)
                Action((T)parameter);
        }
    }
}
