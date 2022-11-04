namespace GCL.BL.Main
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Используется для внедрения зависимостей в архитектуру приложения.
    /// </summary>
    public static class Injector
    {
        private const string GET_ERROR = "Абстракция не зарегистрирована.";

        private const string REGISTER_ERROR = "Реализация для указанной абстракции уже существует.";

        /// <summary>
        /// Блокировщик обращений к Injector-у из потоков.
        /// </summary>
        private static readonly object Locker;

        /// <summary>
        /// Контейнер сущностей.
        /// </summary>
        private static readonly Dictionary<Type, Type> Registers;

        /// <summary>
        /// Контейнер сущностей, синглтонов.
        /// </summary>
        private static readonly Dictionary<Type, object> Singletons;

        static Injector()
        {
            Registers = new Dictionary<Type, Type>();
            Singletons = new Dictionary<Type, object>();
            Locker = new object();
        }

        /// <summary>
        /// Получить реализацию.
        /// </summary>
        /// <typeparam name="TInterface"> Абстракция реализации. </typeparam>
        /// <returns> Реализация. </returns>
        public static TInterface Get<TInterface>() where TInterface : class
        {
            lock (Locker)
            {
                var interfaceType = typeof(TInterface);
                if (Registers.TryGetValue(interfaceType, out var implType))
                    return (TInterface)Activator.CreateInstance(implType);

                if (Singletons.TryGetValue(interfaceType, out var singleton))
                    return (TInterface)singleton;

                throw new Exception(GET_ERROR);
            }
        }

        /// <summary>
        /// Регистрация сущности; создается для каждого вызова.
        /// </summary>
        /// <typeparam name="TInterface"> Тип интерфейса. </typeparam>
        /// <typeparam name="TImpl"> Тип реализации. </typeparam>
        public static void Register<TInterface, TImpl>() where TInterface : class where TImpl : class, new()
        {
            lock (Locker)
            {
                var interfaceType = typeof(TInterface);
                if (Registers.ContainsKey(interfaceType))
                    throw new Exception(REGISTER_ERROR);

                Registers[interfaceType] = typeof(TImpl);
            }
        }

        /// <summary>
        /// Регистрация сущности; создается для каждого вызова.
        /// </summary>
        /// <typeparam name="TInterface"> Тип интерфейса. </typeparam>
        /// <param name="impl"> Реализация. </param>
        public static void RegisterSingleton<TInterface>(TInterface impl) where TInterface : class
        {
            lock (Locker)
            {
                var interfaceType = typeof(TInterface);
                if (Singletons.ContainsKey(interfaceType))
                    throw new Exception(REGISTER_ERROR);

                Singletons[interfaceType] = impl;
            }
        }
    }
}