namespace GCL.UI.GitHub
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using GCL.UI.Base;

    /// <summary>
    /// Вью-модель для Viewer-а по гитхабу.
    /// </summary>
    public class GitHubVM : BaseVM
    {
        private string _search;
        private RepVM _selectedRepVM;

        public GitHubVM()
        {
            Search = string.Empty;
            SearchRepositoryCommand = new SearchRepositoryCommand(this);
            CompleteLoadRepositoryCommand = new CompleteLoadRepositoryCommand();
            RepVms = new ObservableCollection<RepVM>();
        }

        /// <summary>
        /// Номер страницы, которую запросили последний раз.
        /// </summary>
        public int LastNumberGitPage { get; set; }

        /// <summary>
        /// Репозитории.
        /// </summary>
        public ObservableCollection<RepVM> RepVms { get; set; }

        /// <summary>
        /// Строка поиска.
        /// </summary>
        public string Search
        {
            get => _search;
            set
            {
                if (value == _search)
                    return;
                _search = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда поиска.
        /// </summary>
        public ICommand SearchRepositoryCommand { get; }

        /// <summary>
        /// Выбранный репозиторий.
        /// </summary>
        public RepVM SelectedRepVM
        {
            get => _selectedRepVM;
            set
            {
                if (Equals(value, _selectedRepVM))
                    return;

                _selectedRepVM = value;
                OnPropertyChanged();

                CompleteLoadRepositoryCommand.Execute(_selectedRepVM);
            }
        }

        /// <summary>
        /// Команда догрузить информацию по репозиторию.
        /// </summary>
        private ICommand CompleteLoadRepositoryCommand { get; }
    }
}