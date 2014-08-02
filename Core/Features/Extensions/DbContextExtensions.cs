using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Features.Queries.Base;

namespace Core.Features.Extensions
{
    public static class DbContextExtensions
    {
        public static T Query<T>(this DbContext context, AbstractQuery<T> query)
        {
            return query.ExecuteCore(context);
        }
    }
}
