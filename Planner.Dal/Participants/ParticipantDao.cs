using Dapper;
using MySql.Data.MySqlClient;
using Planner.DalInterfaces.Participants;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Planner.Dal.Participants {
    public class ParticipantDao : IParticipantDao {
        private readonly string ConnectionString;

        public ParticipantDao(string connectionString) {
            ConnectionString = connectionString;
        }

        public List<ParticipantDto> GetParticipants() {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "select * from participants;";
            return connection.Query<ParticipantDto>(sql).ToList();
        }

        public int CreateParticipant(ParticipantDto participantDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "insert into participants(`FirstName`, `LastName`, `Email`) values (@FirstName, @LastName, @Email);";
            return connection.Execute(sql, new { participantDto.FirstName, participantDto.LastName, participantDto.Email });
        }

        public int UpdateParticipant(string email, ParticipantDto participantDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "update participants set `FirstName` = @FirstName, `LastName` = @LastName, `Email` = @Email where `Email` = @OriginalEmail;";
            return connection.Execute(sql, new { participantDto.FirstName, participantDto.LastName, participantDto.Email, OriginalEmail = email });
        }

        public int DeleteParticipant(string email) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "delete from participants where `Email` = @Email;";
            return connection.Execute(sql, new { Email = email });
        }
    }
}
