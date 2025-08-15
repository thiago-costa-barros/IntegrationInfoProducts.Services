using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.Context.Extensions.SqlServer
{
    public static class DbContextSpExtensions
    {
        public static SqlCommand StoredProcedureCommand(this DbContext ctx, string procName, params (string name, object? value)[] parameters)
        {
            var conn = (SqlConnection)ctx.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open) conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;

            var tx = ctx.Database.CurrentTransaction;
            if (tx is not null)
                cmd.Transaction = (SqlTransaction)tx.GetDbTransaction();

            var sqlParams = parameters?.Length > 0
                ? parameters.Select(CreateParameter).ToArray()
                : Array.Empty<SqlParameter>();

            if (sqlParams.Length > 0)
                cmd.Parameters.AddRange(sqlParams);

            return cmd;
        }

        // Converte tupla em SqlParameter (normaliza nome, trata enum etc.)
        private static SqlParameter CreateParameter((string name, object? value) p)
        {
            // Aceita "param" ou "@param"
            var paramName = p.name.StartsWith("@") ? p.name : "@" + p.name;
            var value = p.value;

            // Converte enums para int
            if (value is Enum e) value = Convert.ToInt32(e);

            // Ajustes ocasionais de tipos: Guid/DateTime/etc. (opcional)
            // if (value is DateTime dt) { /* se precisar DateTime2 */ }

            return new SqlParameter(paramName, value ?? DBNull.Value);
        }
    }
}
