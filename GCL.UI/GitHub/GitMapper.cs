namespace GCL.UI.GitHub
{
    using System;

    using GCL.BL.GitHub;

    /// <summary>
    /// Утилита для работы с GitHub-ом.
    /// </summary>
    public static class GitMapper
    {
        /// <summary>
        /// Преобразовать во вью-модель.
        /// </summary>
        /// <param name="rep"> Репозиторий. </param>
        /// <returns> Вью-модель. </returns>
        public static RepVM Map(Rep rep)
        {
            return new RepVM
            {
                Id = rep.Id,
                Name = rep.Name,
                Url = rep.Url,
                Description = rep.Description,
                UpdateDate = DateTime.Parse(rep.UpdateDate),
                OwnerVM = Map(rep.Owner)
            };
        }

        /// <summary>
        /// Преобразовать во вью-модель.
        /// </summary>
        /// <param name="owner"> Владелец репозитория. </param>
        /// <returns> Вью-модель. </returns>
        public static OwnerVM Map(Owner owner)
        {
            return new OwnerVM
            {
                Login = owner.Login,
                AvatarUrl = owner.AvatarUrl
            };
        }
    }
}