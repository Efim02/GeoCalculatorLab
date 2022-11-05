namespace GCL.UI.Shop
{
    using System.Threading;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    /// <summary>
    /// Объект для анимирования интерфейса.
    /// </summary>
    public class RotateAnimation : VisualElement
    {
        /// <summary>
        /// Источник токена отмены анимации.
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        /// <inheritdoc cref="IsWork" />
        private bool _isWork;

        /// <summary>
        /// Установить состояние работы. TRUE - если работает.
        /// </summary>
        public bool IsWork
        {
            get => _isWork;
            set
            {
                if (value) 
                {
                    if (!_isWork)
                        StopRotate();

                    _cancellationTokenSource = new CancellationTokenSource();
                    StartRotate();
                }
                else
                {
                    if (_isWork)
                        StopRotate();
                }

                _isWork = value;
            }
        }

        /// <summary>
        /// Целевой объект анимации.
        /// </summary>
        public VisualElement Subject { get; set; }

        /// <inheritdoc />
        /// <remarks>
        /// Не уверен что так работает. Это попытка выключать и начинать анимацию когда элемент виден
        /// пользователю.
        /// </remarks>
        protected override void ChangeVisualState()
        {
            base.ChangeVisualState();
            IsWork = IsVisible;
        }

        /// <summary>
        /// Начать анимацию.
        /// </summary>
        private async void StartRotate()
        {
            while (true)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                    return;

                const int duration = 2000;
                if (Subject == null)
                {
                    await Task.Delay(duration);
                    continue;
                }

                await Subject.RotateTo(360, duration, Easing.SinInOut);
                Subject.Rotation = 0;
            }
        }

        /// <summary>
        /// Остановить анимацию.
        /// </summary>
        private void StopRotate()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        ~RotateAnimation()
        {
            StopRotate();
        }
    }
}