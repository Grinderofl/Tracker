using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Features.Queries.Base;

namespace Core.Features.Queries.Characters
{
    public class SelectActiveCharactersQuery : AbstractQuery<IQueryable<Character>>
    {
        public override IQueryable<Character> ExecuteCore(DbContext context)
        {
            return context.Set<Character>().Where(x => !x.Hidden);
        }
    }
}
