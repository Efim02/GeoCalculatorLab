namespace GCL.UI.Base
{
    using System;

    using Xamarin.Forms.Internals;

    /// <summary>
    /// Типизированная команда.
    /// </summary>
    /// <typeparam name="T"> Тип параметра. </typeparam>
    public abstract class TypedBaseCommand<T> : BaseCommand
    {
        private const string EXCEPTION = "ИСКЛЮЧЕНИЕ: ";

        public sealed override bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter)
                return CanExecute(typedParameter);
            return false;
        }

        public sealed override void Execute(object parameter)
        {
            try
            {
                if (!(parameter is T typedParameter))
                {
                    throw new ArgumentException($"Не верный тип параметр {parameter.GetType().Name}.",
                        nameof(parameter));
                }

                Execute(typedParameter);
            }
            catch (Exception exception)
            {
                var message = $"{exception.Message}\n{exception.StackTrace}";
                Log.Warning(EXCEPTION, message);
            }
        }

        protected virtual bool CanExecute(T parameter)
        {
            return true;
        }

        protected abstract void Execute(T parameter);
    }
}