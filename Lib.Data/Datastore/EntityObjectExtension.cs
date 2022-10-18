using System;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Linq;
using Lib.Data;

public static class EntityObjectExtension
{
    public static IEntityWithKey Save(this IEntityWithKey entity)
    {
        object originalItem;

        if (DataRepositoryFactory.CurrentRepository.TryGetObjectByKey(entity.EntityKey, out originalItem))
        {
            //DataRepositoryFactory.CurrentRepository.ApplyPropertyChanges(entity.EntityKey.EntitySetName, entity);
            DataRepositoryFactory.CurrentRepository.ApplyCurrentValues(entity.EntityKey.EntitySetName, entity);
        }
        else
        {
            DataRepositoryFactory.CurrentRepository.AddObject(entity.EntityKey.EntitySetName, entity);
        }
        DataRepositoryFactory.CurrentRepository.SaveChanges();
        return entity;
    }

    /// <summary>
    ///Saves the specified object to the current Context
    /// </summary>
    /// <param name="obj">The obj.</param>
    public static void Save<T>(this EntityObject obj) where T : class, new()
    {
        var isNewRecord = IsNewRecord(obj.EntityKey);
        if (isNewRecord)
        {
            var objectSet = DataRepositoryFactory.CurrentRepository.CreateObjectSet<T>();
            DataRepositoryFactory.CurrentRepository.AddObject(objectSet.EntitySet.Name, obj);
        }
        var objectState = isNewRecord ? EntityState.Added :  EntityState.Modified;
        DataRepositoryFactory.CurrentRepository.ObjectStateManager.ChangeObjectState(obj, objectState);
        DataRepositoryFactory.CurrentRepository.SaveChanges();
    }

    /// <summary>
    /// Inserts the specified obj.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The obj.</param>
    public static void InsertSave<T>(this EntityObject obj) where T : class, new()
    {
        var isNewRecord = IsNewRecord(obj.EntityKey);
        if (isNewRecord)
        {
            var objectSet = DataRepositoryFactory.CurrentRepository.CreateObjectSet<T>();
            DataRepositoryFactory.CurrentRepository.AddObject(objectSet.EntitySet.Name, obj);
        }
        DataRepositoryFactory.CurrentRepository.ObjectStateManager.ChangeObjectState(obj, EntityState.Added);
        DataRepositoryFactory.CurrentRepository.SaveChanges();
    }

    /// <summary>
    /// Updates the save.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The obj.</param>
    public static void UpdateSave<T>(this EntityObject obj) where T : class, new()
    {
        var isNewRecord = IsNewRecord(obj.EntityKey);
        if (isNewRecord)
        {
            var objectSet = DataRepositoryFactory.CurrentRepository.CreateObjectSet<T>();
            DataRepositoryFactory.CurrentRepository.AddObject(objectSet.EntitySet.Name, obj);
        }
        DataRepositoryFactory.CurrentRepository.ObjectStateManager.ChangeObjectState(obj, EntityState.Modified);
        DataRepositoryFactory.CurrentRepository.SaveChanges();
    }

    /// <summary>
    /// Deletes the specified EntityObject.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The obj.</param>
    public static void Delete<T>(this EntityObject obj) where T : class, new()
    {
        var isNewRecord = IsNewRecord(obj.EntityKey);
        if (isNewRecord)
        {
            var objectSet = DataRepositoryFactory.CurrentRepository.CreateObjectSet<T>();
            DataRepositoryFactory.CurrentRepository.AddObject(objectSet.EntitySet.Name, obj);
        }
        DataRepositoryFactory.CurrentRepository.ObjectStateManager.ChangeObjectState(obj, EntityState.Deleted);
        DataRepositoryFactory.CurrentRepository.SaveChanges();
    }

    /// <summary>
    /// Determines whether current object is new. 
    /// </summary>
    /// <param name="entityKey">The current EntityObject.</param>
    private static bool IsNewRecord(EntityKey entityKey)
    {
        if (entityKey == null)
        {
            return true;
        }
        int temp = 0;
        var keyMembers = entityKey.EntityKeyValues;
        return keyMembers.Where(x => string.IsNullOrWhiteSpace(x.Value.ToString()) || (Int32.TryParse(x.Value.ToString(), out temp) && Convert.ToInt32(x.Value.ToString()) == 0)).Any();
    }

    /// <summary>
    /// Determines whether current object is new. 
    /// </summary>
    /// <param name="obj">The current EntityObject.</param>
    public static bool IsNewRecord(this EntityObject obj)
    {
        if (obj == null)
        {
            return true;
        }
        return IsNewRecord(obj.EntityKey);
    }
}

