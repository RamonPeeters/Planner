using Dapper;
using MySql.Data.MySqlClient;
using Planner.DalInterfaces.Appointments;
using Planner.DalInterfaces.Participants;
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
            Dictionary<int, AppointmentDto> appointments = new Dictionary<int, AppointmentDto>();
            string sql = @"select app.*, pri.*, par.* from appointments app
                           left join priorities pri on app.PriorityId = pri.Id
                           left join appointments_participants app_par on app.Id = app_par.AppointmentId
                           left join participants par on par.Id = app_par.ParticipantId;";
            return connection.Query<AppointmentDto, PriorityDto, ParticipantDto, AppointmentDto>(sql, (appointment, priority, participant) => {
                if (!appointments.TryGetValue(appointment.Id, out AppointmentDto actualAppointment)) {
                    actualAppointment = new AppointmentDto(appointment.Id, appointment.Title, appointment.Description, appointment.StartDate, appointment.EndDate, appointment.Finished, appointment.Priority, new List<ParticipantDto>());
                    appointments.Add(actualAppointment.Id, actualAppointment);
                }

                actualAppointment.Participants.Add(participant);
                return actualAppointment;
            }).Distinct().ToList();
        }

        public int CreateAppointment(AppointmentDto appointmentDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = @"insert into appointments(`Title`, `StartDate`, `EndDate`, `Description`, `PriorityId`) values (@Title, @StartDate, @EndDate, @Description, @PriorityId);
                           set @LastInsertedId = (select last_insert_id());
                           select @LastInsertedId;";
            string sqlParticipant = @"insert into appointments_participants(`AppointmentId`, `ParticipantId`) values (@LastInsertedId, @Id);";

            int id = connection.QuerySingle<int>(sql, new { appointmentDto.Title, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Description, PriorityId = appointmentDto.Priority?.Id });
            connection.Execute(sqlParticipant, appointmentDto.Participants ?? new List<ParticipantDto>());
            return id;
        }

        public int UpdateAppointment(int id, AppointmentDto appointmentDto) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = @"update appointments set `Title` = @Title, `StartDate` = @StartDate, `EndDate` = @EndDate, `Description` = @Description, `Finished` = @Finished, `PriorityId` = @PriorityId where `Id` = @Id;
                           set @AppointmentId = @Id;";
            string sqlParticipant = @"insert into appointments_participants(`AppointmentId`, `ParticipantId`) select @AppointmentId, @Id from dual
                                      where not exists (select 1 from appointments_participants where AppointmentId = @AppointmentId and ParticipantId = @Id) limit 1;";
            connection.Execute(sql, new { appointmentDto.Title, appointmentDto.StartDate, appointmentDto.EndDate, appointmentDto.Description, appointmentDto.Finished, PriorityId = appointmentDto.Priority?.Id, Id = id });
            return connection.Execute(sqlParticipant, appointmentDto.Participants ?? new List<ParticipantDto>());
        }

        public int DeleteAppointment(int id) {
            using IDbConnection connection = new MySqlConnection(ConnectionString);
            string sql = "delete from appointments where `Id` = @Id;";
            return connection.Execute(sql, new { Id = id });
        }
    }
}
