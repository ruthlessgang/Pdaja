﻿using System;


namespace Lib.Data
{
    public class DataRepositoryStore
    {
        public static readonly string KEY_DATACONTEXT = "DataRepository";
        public static IDataRepositoryStore CurrentDataStore;
    }
}
