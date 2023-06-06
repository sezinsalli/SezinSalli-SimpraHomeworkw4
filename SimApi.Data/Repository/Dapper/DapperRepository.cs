using Dapper;
using Microsoft.AspNetCore.Mvc.Filters;
using SimApi.Base.Model;
using SimApi.Data.Context;
using SimApi.Data.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;

public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : BaseModel
{
    private readonly IDbConnection connection;

    public DapperRepository(SimDapperDbContext dbContext)
    {
        this.connection = dbContext.CreateConnection();
    }

    public List<TEntity> GetAll()
    {
        var tableName = GetTableName();
        var query = $"SELECT * FROM {tableName}";
        return connection.Query<TEntity>(query).ToList();
    }

    public List<TEntity> Filter(string sql)
    {
        return connection.Query<TEntity>(sql).ToList();
    }

    public TEntity GetById(int id)
    {
        var tableName = GetTableName();
        var query = $"SELECT * FROM {tableName} WHERE Id = @Id";
        return connection.QueryFirstOrDefault<TEntity>(query, new { Id = id });
    }

    public void Insert(TEntity entity)
    {
        var tableName = GetTableName();
        var columns = GetColumns(entity);
        var values = GetValues(entity);
        var query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
        connection.Execute(query, entity);
    }

    public void Update(TEntity entity)
    {
        var tableName = GetTableName();
        var updateValues = GetUpdateValues(entity);
        var query = $"UPDATE {tableName} SET {updateValues} WHERE Id = @Id";
        connection.Execute(query, entity);
    }

    public void DeleteById(int id)
    {
        var tableName = GetTableName();
        var query = $"DELETE FROM {tableName} WHERE Id = @Id";
        connection.Execute(query, new { Id = id });
    }

    private string GetTableName()
    {
        var entityType = typeof(TEntity);
        var tableAttribute = entityType.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
        if (tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Schema))
        {
            return $"{tableAttribute.Schema}.{tableAttribute.Name}";
        }
        else if (tableAttribute != null)
        {
            return tableAttribute.Name;
        }
        else
        {
            return entityType.Name;
        }
    }

    private string GetColumns(TEntity entity)
    {
        var properties = entity.GetType().GetProperties();
        return string.Join(", ", properties.Select(p => p.Name));
    }

    private string GetValues(TEntity entity)
    {
        var properties = entity.GetType().GetProperties();
        return string.Join(", ", properties.Select(p => $"@{p.Name}"));
    }

    private string GetUpdateValues(TEntity entity)
    {
        var properties = entity.GetType().GetProperties();
        return string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
    }
}