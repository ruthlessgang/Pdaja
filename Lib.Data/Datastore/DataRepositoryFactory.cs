using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using Lib.Data.GenericRepository;

namespace Lib.Data
{
    public static class DataRepositoryFactory
    {
        public static SALTEntities CurrentRepository
        {
            get
            {
                var repository = DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] as SALTEntities;
                if (repository == null)
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SALTEntities"].ConnectionString;
                    var decrypt = Encryptor.Decrypt(connectionString);
                    connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder(decrypt).ToString();

                    repository = new SALTEntities(connectionString);
                    DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] = repository;
                }

                return repository;

            }
        }

        public static void CloseCurrentRepository()
        {
            var repository = DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] as SALTEntities;
            if (repository != null)
            {
                repository.Dispose();
                DataRepositoryStore.CurrentDataStore[DataRepositoryStore.KEY_DATACONTEXT] = null;
            }
        }
    }
}
