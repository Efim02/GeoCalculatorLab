namespace GCL.UI.GitHub
{
    using System;
    using System.Windows.Input;

    using GCL.UI.Base;

    /// <summary>
    /// Вью-модель репозитория.
    /// </summary>
    public class RepVM : BaseVM
    {
        public RepVM()
        {
            OpenBrowseRepositoryCommand = new OpenBrowseRepositoryCommand();
        }

        /// <summary>
        /// ИД репозитория.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата обновления.
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Владелец.
        /// </summary>
        public OwnerVM OwnerVM { get; set; }

        /// <summary>
        /// Команда открыть в браузере.
        /// </summary>
        public ICommand OpenBrowseRepositoryCommand { get; }
    }
}