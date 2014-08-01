using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Configurations
{
    public class EntryConfiguration : EntityTypeConfiguration<Entry>
    {
        public EntryConfiguration()
        {
            
        }
    }
}
