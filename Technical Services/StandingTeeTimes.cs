using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using BAIS3130.Domain;

namespace BAIS3130.Technical_Services
{
    public class StandingTeeTimes
    {
        public bool ScheduleStandingTeeTime(Group group, StandingTeeTime standingTeeTime)
        {
            bool Confirmation = false;
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=makedonija1A;server=dev1.baist.ca";
            DataSource.Open();

            SqlCommand ScheduleStandingTeeTime = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ScheduleStandingTeeTime"
            };

            SqlParameter parameter = new()
            {
                ParameterName = "ShareholderMemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = group.ShareholderNumber
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "ShareholderMemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = group.ShareholderName
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedDayOfWeek",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.StartDate.DayOfWeek
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedTeeTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.RequestedTime.TimeOfDay
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedStartDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.StartDate.Date
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedEndDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.EndDate.Date
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "PriorityNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.PriorityNumber
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "ApprovedTeeTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.ApprovedDate.TimeOfDay
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "ApprovedBy",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.ApprovedBy
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "ApprovedDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.ApprovedDate.Date
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "GroupMemberOne",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = group.MemberOne
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "GroupMemberTwo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = group.MemberTwo
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "GroupMemberThree",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = group.MemberThree
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            ScheduleStandingTeeTime.ExecuteNonQuery();

            DataSource.Close();
            return Confirmation;
        }
    }
}
