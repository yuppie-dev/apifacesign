using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Facesign.Services.Infra.Data.Data.Extensions
{
    static class Extensions
    {
        public static async Task<List<T>> ToListWithNoLockAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
        {
            List<T>? result = default;
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                    new TransactionOptions()
                                    {
                                        IsolationLevel = IsolationLevel.ReadUncommitted
                                    },
                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await query.ToListAsync(cancellationToken);
                scope.Complete();
            }
            return result;
        }

        public static async Task<T> FirstOrDefaultWithNoLockAsync<T>(this IQueryable<T> query, CancellationToken cancellationToken = default)
        {
            T? result = default;
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                        new TransactionOptions()
                        {
                            IsolationLevel = IsolationLevel.ReadUncommitted
                        },
                        TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await query.FirstOrDefaultAsync(cancellationToken);
                scope.Complete();
            }
            return result;
        }
    }
}
