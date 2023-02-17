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
        public bool ScheduleStandingTeeTime(StandingTeeTime standingTeeTime)
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
                Value = standingTeeTime.ShareholderMemberNumber
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "ShareholderMemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.ShareholderMemberName
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedDayOfWeek",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.DayOfWeek
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedTeeTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.RequestedTime
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedStartDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.StartDate
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedEndDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.EndDate
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
                Value = standingTeeTime.ApprovedTeeTime
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
                Value = standingTeeTime.ApprovedDate
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "GroupMemberOne",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.GroupMemberOne
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "GroupMemberTwo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.GroupMemberTwo
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "GroupMemberThree",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.GroupMemberThree
            };
            ScheduleStandingTeeTime.Parameters.Add(parameter);

            ScheduleStandingTeeTime.ExecuteNonQuery();

            DataSource.Close();
            return Confirmation;
        }
        // GetStandingTeeTimeForMember
        public List<StandingTeeTime> GetStandingTeeTimeForMember(int memberNumber)
        {
            List<StandingTeeTime> TeeTimes = new();
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=makedonija1A;server=dev1.baist.ca";
            DataSource.Open();

            SqlCommand GetStandingTeeTimeForMember = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStandingTeeTimeForMember"
            };

            SqlParameter parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = memberNumber
            };
            GetStandingTeeTimeForMember.Parameters.Add(parameter);

            SqlDataReader DataReader = GetStandingTeeTimeForMember.ExecuteReader();

            StandingTeeTime StandingTeeTime = new();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    StandingTeeTime = new();
                    StandingTeeTime.ShareholderMemberName = (string)DataReader["ShareholderMemberName"];
                    StandingTeeTime.ShareholderMemberNumber = (int)DataReader["ShareholderMemberNumber"];
                    StandingTeeTime.GroupMemberOne = (int)DataReader["GroupMemberOne"];
                    StandingTeeTime.GroupMemberThree = (int)DataReader["GroupMemberTwo"];
                    StandingTeeTime.GroupMemberThree = (int)DataReader["GroupMemberThree"];
                    StandingTeeTime.PriorityNumber = (int)DataReader["PriorityNumber"];
                    StandingTeeTime.ApprovedBy = (string)DataReader["ApprovedBy"];
                    StandingTeeTime.EndDate = (string)DataReader["RequestedEndDate"];
                    StandingTeeTime.StartDate = (string)DataReader["RequestedStartDate"];
                    StandingTeeTime.DayOfWeek = (string)DataReader["RequestedDayOfWeek"];
                    StandingTeeTime.ApprovedDate = (string)DataReader["ApprovedDate"];
                    StandingTeeTime.ApprovedTeeTime = (string)DataReader["ApprovedTeeTime"];

                    TeeTimes.Add(StandingTeeTime);
                }
            }
            DataReader.Close();
            DataSource.Close();
            return TeeTimes;
        }
    }
}
