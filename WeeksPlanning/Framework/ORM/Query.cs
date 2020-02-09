using System;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.ORMSupportClasses;
using WeeksPlanning.Entity.DatabaseSpecific;
using WeeksPlanning.Entity.Linq;

namespace ORM
{
    public static class Query
    {
        public static async Task<T> GetAsync<T>(Func<LinqMetaData, Task<T>> query, IDataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return await query(new LinqMetaData(transactionAdapter));

            DataAccessAdapter adapter = new DataAccessAdapter();
            return await query(new LinqMetaData(adapter));
        }
    }
}