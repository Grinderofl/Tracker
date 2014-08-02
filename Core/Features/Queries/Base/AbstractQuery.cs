using System.Data.Entity;
using System.Linq;
using Core.Domain;

namespace Core.Features.Queries.Base
{
    public abstract class AbstractQuery<T>
    {
        public abstract T ExecuteCore(DbContext context);
    }
}