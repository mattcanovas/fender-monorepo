using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Fender.App.ViewModels.Handler;

public class CommandHandler : ICommand
{
    private readonly Action<object> _action;
    private readonly Func<object, bool> _canExecute;
    public CommandHandler(Action<object> action, Func<object, bool> canExecute)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        _action = action;
        _canExecute = canExecute ?? (x => true);
    }
    public CommandHandler(Action<object> action) : this(action, null)
    {
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        _action(parameter);
    }
    public static void Refresh()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}

public class RelayCommandAsync(Func<Task> execute, Predicate<object> canExecute) : ICommand
{
    private readonly Func<Task> _execute = execute;
    private readonly Predicate<object> _canExecute = canExecute;
    private bool isExecuting;

    public RelayCommandAsync(Func<Task> execute) : this(execute, null) { }

    public bool CanExecute(object parameter)
    {
        if (!isExecuting && _canExecute == null) return true;
        return (!isExecuting && _canExecute(parameter));
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public async void Execute(object parameter)
    {
        isExecuting = true;
        try { await _execute(); }
        finally { isExecuting = false; }
    }
}