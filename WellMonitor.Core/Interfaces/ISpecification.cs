using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace WellMonitor.Core.Interfaces
{
       public interface ISpecification<T>
        {
            Expression<Func<T, bool>> Criteria { get; }

            List<Expression<Func<T, object>>> Includes { get; }

            Expression<Func<T, object>> OrderBy { get; }

            Expression<Func<T, object>> OrderByDescending { get; }
    }
}
