using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using BAIS3130.Domain;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BAIS3130.Technical_Services
{
    public class StandingTeeTimes
    {
        public bool ScheduleStandingTeeTime(StandingTeeTime standingTeeTime)
        {
            bool Confirmation = false;
            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand ScheduleStandingTeeTime = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ScheduleStandingTeeTime"
            };

            // Shareholer Member Number Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "ShareholderMemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.ShareholderMemberNumber
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            // Shareholder Member Name Parameter
            Parameter = new()
            {
                ParameterName = "ShareholderMemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.ShareholderMemberName
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            // Requested Day Of Week Parameter
            Parameter = new()
            {
                ParameterName = "RequestedDayOfWeek",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.DayOfWeek
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            //Requested Tee Time Parameter
            Parameter = new()
            {
                ParameterName = "RequestedTeeTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.RequestedTime
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            // Requested Start Date Parameter
            Parameter = new()
            {
                ParameterName = "RequestedStartDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.StartDate
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            // Requested End Date Parameter
            Parameter = new()
            {
                ParameterName = "RequestedEndDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.EndDate
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            // Priority Number (Hard Coded)
            Parameter = new()
            {
                ParameterName = "PriorityNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.PriorityNumber
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            // Group Member One Parameter
            Parameter = new()
            {
                ParameterName = "GroupMemberOne",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.GroupMemberOne
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            //Group Member Two Parameter
            Parameter = new()
            {
                ParameterName = "GroupMemberTwo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.GroupMemberTwo
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            // Grop Member Three Paramter
            Parameter = new()
            {
                ParameterName = "GroupMemberThree",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTime.GroupMemberThree
            };
            ScheduleStandingTeeTime.Parameters.Add(Parameter);

            Confirmation = (int)ScheduleStandingTeeTime.ExecuteNonQuery() != 1;

            DataSource.Close();
            Confirmation = true;
            return Confirmation;
        }
        // GetStandingTeeTimeForMember
        public List<StandingTeeTime> GetStandingTeeTimeForMember(int memberNumber)
        {
            List<StandingTeeTime> StandingTeeTimes = new();
            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand GetStandingTeeTimeForMember = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStandingTeeTimesForMember"
            };

            //Member Number Parameter
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
                    StandingTeeTime.StandingTeeTimeNumber = (int)DataReader["StandingTeeTimeNumber"];
                    StandingTeeTime.ShareholderMemberName = (string)DataReader["ShareholderMemberName"];
                    StandingTeeTime.ShareholderMemberNumber = (int)DataReader["ShareholderMemberNumber"];
                    StandingTeeTime.GroupMemberOne = String.IsNullOrEmpty(DataReader["GroupMemberOneName"].ToString()) ? "Unknown" : (string)DataReader["GroupMemberOneName"];
                    StandingTeeTime.GroupMemberThree = String.IsNullOrEmpty(DataReader["GroupMemberTwoName"].ToString()) ? "N/A" : (string)DataReader["GroupMemberTwoName"];
                    StandingTeeTime.GroupMemberThree = String.IsNullOrEmpty(DataReader["GroupMemberThreeName"].ToString()) ? "Unknown" : (string)DataReader["GroupMemberThreeName"];
                    StandingTeeTime.PriorityNumber = (int)DataReader["PriorityNumber"];
                    StandingTeeTime.EndDate = DataReader["RequestedEndDate"].ToString();
                    StandingTeeTime.StartDate = DataReader["RequestedStartDate"].ToString();
                    StandingTeeTime.DayOfWeek = (string)DataReader["RequestedDayOfWeek"];
                    StandingTeeTime.RequestedTime = DataReader["ApprovedTeeTime"].ToString();

                    StandingTeeTimes.Add(StandingTeeTime);
                }
            }
            DataReader.Close();
            DataSource.Close();
            return StandingTeeTimes;
        }
        // DELETE Standing Tee Time
        public bool DeleteStandingTeeTime (int standingTeeTimeNumber)
        {
            bool Confirmation = false;
            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand DeleteStandingTeeTime = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteStandingTeeTimeForMember"
            };

            //Standing Tee Time Number Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "StandingTeeTimeNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = standingTeeTimeNumber
            };
            DeleteStandingTeeTime.Parameters.Add(Parameter);

            Confirmation = DeleteStandingTeeTime.ExecuteNonQuery() == 0;

            DataSource.Close();
            return Confirmation;
        }
    }
}
