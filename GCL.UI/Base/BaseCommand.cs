namespace GCL.UI.Base
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Базовый класс команд.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Доступна ли команда.
        /// </summary>
        /// <param name="parameter"> DataContext для команды. </param>
        /// <returns> True - доступна. </returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Событие выполнения.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="parameter"> DataContext для команды. </param>
        public abstract void Execute(object parameter);
    }
}