using Dapper;
using MySql.Data.MySqlClient;
using Planner.DalInterfaces.Appointments;
using Planner.DalInterfaces.Priorities;
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
            string sql = @"select app.*, pri.* from appointments app
                           left join priorities pri
                           on app.PriorityId = pri.Id;";
            return connection.Query<AppointmentDto, PriorityDto, AppointmentDto>(sql, (appointment, priority) => {
                return new AppointmentDto(appointment.Id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished, priority);
            }).ToList();
        }

        public int CreateAppointment(AppointmentDto appointmentDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = @"insert into appointments(`Title`, `StartDate`, `EndDate`, `Description`, `PriorityId`) values (@Title, @StartDate, @EndDate, @Description, @PriorityId);
                           select last_insert_id();";
            return connection.Query<int>(sql, new { appointmentDto.Title, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Description, PriorityId = appointmentDto.Priority?.Id }).Single();
        }

        public int UpdateAppointment(int id, AppointmentDto appointmentDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "update appointments set `Title` = @Title, `StartDate` = @StartDate, `EndDate` = @EndDate, `Description` = @Description, `Finished` = @Finished, `PriorityId` = @PriorityId where `Id` = @Id;";
            return connection.Execute(sql, new { appointmentDto.Title, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Description, appointmentDto.Finished, PriorityId = appointmentDto.Priority?.Id, Id = id });
        }

        public int DeleteAppointment(int id) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "delete from appointments where `Id` = @Id;";
            return connection.Execute(sql, new { Id = id });
        }
    }
}
