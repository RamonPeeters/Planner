using Dapper;
using MySql.Data.MySqlClient;
using Planner.DalInterfaces.Priorities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Planner.Dal.Priorities {
    public class PriorityDao : IPriorityDao {
        private readonly string ConnectionString;

        public PriorityDao(string connectionString) {
            ConnectionString = connectionString;
        }

        public List<PriorityDto> GetPriorities() {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "select * from priorities;";
            return connection.Query<PriorityDto>(sql).ToList();
        }

        public int CreatePriority(PriorityDto priorityDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = @"insert into priorities(`Name`, `Colour`) values (@Name, @Colour);";
            return connection.Execute(sql, new { priorityDto.Name, priorityDto.Colour });
        }

        public int UpdatePriority(string priorityName, PriorityDto priorityDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "update appointments set `Name` = @Name, `Colour` = @Colour where `Name` = @OriginalName;";
            return connection.Execute(sql, new { priorityDto.Name, priorityDto.Colour, OriginalName = priorityName });
        }

        public int DeletePriority(string priorityName) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "delete from appointments where `Name` = @Name;";
            return connection.Execute(sql, new { Name = priorityName });
        }
    }
}
