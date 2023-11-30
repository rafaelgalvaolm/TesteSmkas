using Smkas.Core.Settings;

namespace Smkas.Data
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(AppSettings appSettings) : base(appSettings, "Application")
        {

        }
    }
}