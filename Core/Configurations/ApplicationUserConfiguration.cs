using System.Data.Entity.ModelConfiguration;
using Core.Domain;

namespace Core.Configurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            ToTable("Users");
        }
    }
}
