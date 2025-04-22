using DomainLayer.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected BaseSpecifications(Expression<Func<TEntity, bool>> _Criteria)
        {
            criteria = _Criteria;   
        }
        public Expression<Func<TEntity, bool>> criteria { get;private set; }

        #region Include
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludeExpressions.Add(includeExpression);
        }

        #endregion

        #region Order
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExepression)
        {
            OrderBy=OrderByExepression;
        }

        protected void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExpression)
        {
            OrderByDesc=OrderByDescExpression;
        }
        #endregion
    }
}
