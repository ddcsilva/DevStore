using DevStore.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Data.Mapping
{
    public static class ApplicationDbContextExtension
    {
        private static string RemoveGenericType(this string value)
        {
            var result = value;
            const string token = "<int>";

            if (result.EndsWith(token))
            {
                result = result.Substring(0, result.IndexOf(token));
            }

            return result;
        }

        public static void AddSnakeCase(this ModelBuilder modelBuilder, bool useIdentity)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Padrão de nomenclatura "Table Name"
                var tableName = entityType.DisplayName().ToSnakeCase().RemoveGenericType();
                entityType.SetTableName(tableName);

                // Padrão de nomenclatura de "Primary Key"
                var pk = entityType.FindPrimaryKey();
                if (pk != null)
                {
                    var pkName = $"pk_{tableName}";
                    pk.SetName(pkName);
                }

                foreach (var property in entityType.GetProperties())
                {
                    // Padrão de nomenclatura de "Columns"
                    var columnName = property.Name.ToSnakeCase();
                    property.SetColumnName(columnName);

                    // Padrão de nomenclatura de "Foreign Keys"
                    foreach (var fk in entityType.FindForeignKeys(property))
                    {
                        var fkName = $"fk_{tableName}_{columnName}";
                        fk.SetConstraintName(fkName);
                    }
                }

                // Padrão de nomenclatura de "Indices"
                foreach (var index in entityType.GetIndexes())
                {
                    var indexName = index.GetDatabaseName().ToSnakeCase();

                    if (useIdentity)
                    {
                        var token = "_index";
                        if (indexName.EndsWith(token))
                        {
                            indexName = indexName.Substring(0, indexName.IndexOf(token));
                        }

                        token = "ix_";
                        if (indexName.StartsWith(token))
                        {
                            indexName = indexName.Remove(0, 3);
                        }

                        token = "identity_";
                        if (!indexName.StartsWith(token))
                        {
                            indexName = token + indexName;
                        }
                    }
                    else
                    {
                        indexName = indexName.Remove(0, 3);
                    }

                    index.SetDatabaseName("idx_" + indexName);
                }
            }
        }
    }
}
