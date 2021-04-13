using Dapper;
using MySql.Data.MySqlClient;
using Planner.DalInterfaces.Appointments;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Planner.Dal.Appointments {
    public class AppointmentDao : IAppointmentDao {
        private readonly string ConnectionString;

        public AppointmentDao(string connectionString) {
            ConnectionString = connectionString;
        }

        public List<AppointmentDto> GetAppointments() {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "select * from appointments;";
            return connection.Query<AppointmentDto>(sql).ToList<AppointmentDto>();
        }

        public int CreateAppointment(AppointmentDto appointmentDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = @"insert into appointments(`Title`, `StartDate`, `EndDate`, `Description`) values (@Title, @StartDate, @EndDate, @Description);
                           select last_insert_id();";
            return connection.Query<int>(sql, new { appointmentDto.Title, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Description }).Single();
        }

        public int UpdateAppointment(int id, AppointmentDto appointmentDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "update appointments set `Title` = @Title, `StartDate` = @StartDate, `EndDate` = @EndDate, `Description` = @Description, `Finished` = @Finished where `Id` = @Id;";
            return connection.Execute(sql, new { appointmentDto.Title, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Description, appointmentDto.Finished, Id = id });
        }

        public int DeleteAppointment(int id) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "delete from appointments where `Id` = @Id;";
            return connection.Execute(sql, new { Id = id });
        }
    }
}
