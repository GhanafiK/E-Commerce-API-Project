using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> InputQuery,ISpecifications<TEntity,TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var Query=InputQuery;

            if(specifications.criteria is not null)
                Query=Query.Where(specifications.criteria); 

            if(specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count() > 0)
            {
                //foreach (var expression in specifications.IncludeExpressions)
                //    Query = Query.Include(expression);
                Query = specifications.IncludeExpressions.Aggregate(Query, (CurrentQuery, expression) => CurrentQuery.Include(expression));
            }

            return Query;
        }
    }
}
