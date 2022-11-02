namespace GCL.UI.Commands
{
    using System;

    /// <summary>
    /// Типизированная команда.
    /// </summary>
    /// <typeparam name="T"> Тип параметра. </typeparam>
    public abstract class TypedBaseCommand<T> : BaseCommand
    {
        public sealed override bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter)
                return CanExecute(typedParameter);
            return false;
        }

        public sealed override void Execute(object parameter)
        {
            if (!(parameter is T typedParameter))
                throw new ArgumentException($"Не верный тип параметр {parameter.GetType().Name}.", nameof(parameter));
            Execute(typedParameter);
        }

        protected virtual bool CanExecute(T parameter)
        {
            return true;
        }

        protected abstract void Execute(T parameter);
    }
}