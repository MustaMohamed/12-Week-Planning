using System;
using System.Threading.Tasks;
using WeeksPlanning.DatabaseSpecific;
using WeeksPlanning.Linq;

namespace ORM
{
    public static class Query
    {
        public static async Task<T> GetAsync<T>(Func<LinqMetaData, Task<T>> query, DataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return await query(new LinqMetaData(transactionAdapter));

            using (var adapter = new DataAccessAdapter())
            {
                return await query(new LinqMetaData(adapter));
            }
        }
    }
}