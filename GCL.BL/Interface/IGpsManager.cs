namespace GCL.BL.Interface
{
    /// <summary>
    /// GPS менеджер.
    /// </summary>
    public interface IGpsManager
    {
        /// <summary>
        /// Включен ли GPS на устройстве.
        /// </summary>
        /// <returns> TRUE - если включен. </returns>
        bool IsEnabled();
    }
}