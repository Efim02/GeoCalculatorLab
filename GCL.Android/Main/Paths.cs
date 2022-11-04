namespace GCL.Droid.Main
{
    using System;
    using System.IO;

    using GCL.BL.Interface;
    using GCL.BL.Main;

    /// <summary>
    /// Реализация класса путей.
    /// </summary>
    public class Paths : IPaths
    {
        /// <inheritdoc />
        public string GetDbPath()
        {
            var applicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(applicationData, PathConstants.DATABASE);
        }
    }
}