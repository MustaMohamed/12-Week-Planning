using System;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.ORMSupportClasses;
using WeeksPlanning.Entity.DatabaseSpecific;
using WeeksPlanning.Entity.Linq;

namespace ORM
{
    public static class OrmOperationFactory
    {
        public static async Task<T> GetQueryAsync<T>(Func<LinqMetaData, Task<T>> query, IDataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return await query(new LinqMetaData(transactionAdapter));

            using DataAccessAdapter adapter = new DataAccessAdapter();
            return await query(new LinqMetaData(adapter));
        }

        public static T GetQuery<T>(Func<LinqMetaData, T> query, IDataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return query(new LinqMetaData(transactionAdapter));

            // using DataAccessAdapter adapter = new DataAccessAdapter();
            DataAccessAdapter adapter = new DataAccessAdapter();
            return query(new LinqMetaData(adapter));
        }

        public static async Task<T> DoCommandAsync<T>(Func<DataAccessAdapter, Task<T>> cmd, DataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return await cmd(transactionAdapter);

            using DataAccessAdapter adapter = new DataAccessAdapter();
            return await cmd(adapter);
        }

        public static async Task<T> DoCommandAsync<T>(Func<DataAccessAdapter, LinqMetaData, Task<T>> cmd, DataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return await cmd(transactionAdapter, new LinqMetaData(transactionAdapter));

            using DataAccessAdapter adapter = new DataAccessAdapter();
            return await cmd(adapter, new LinqMetaData(adapter));
        }

        public static T DoCommand<T>(Func<DataAccessAdapter, T> cmd, DataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return cmd(transactionAdapter);

            // using DataAccessAdapter adapter = new DataAccessAdapter();
            DataAccessAdapter adapter = new DataAccessAdapter();
            return cmd(adapter);
        }
        
        public static T DoCommand<T>(Func<DataAccessAdapter, LinqMetaData, T> cmd, DataAccessAdapter transactionAdapter = null)
        {
            if (transactionAdapter != null)
                return  cmd(transactionAdapter, new LinqMetaData(transactionAdapter));

            using DataAccessAdapter adapter = new DataAccessAdapter();
            return  cmd(adapter, new LinqMetaData(adapter));
        }
    }
}