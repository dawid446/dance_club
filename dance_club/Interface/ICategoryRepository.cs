using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dance_club.Interface
{
    interface ICategoryRepository <TEnity> where TEnity : class
    {
        TEnity Get(int id);
        IEnumerable<TEnity> GetAll();
        IEnumerable<TEnity> Find(Expression<Func<TEnity, bool>>predicate);

        void Add(TEnity entity);

        void Remove(TEnity enity);
    }
}
