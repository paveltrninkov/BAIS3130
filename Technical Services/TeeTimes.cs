using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3130.Domain;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BAIS3130.Technical_Services
{
    public class TeeTimes
    {
        public bool ScheduleTeeTime (TeeTime teeTime)
        {
            bool Confirmation = false;
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            //SqlConnection DataSource = new();
            //ConfigurationBuilder DatabaseUsersBuilder = new();
            //DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            //DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            //IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            //DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand ScheduleTeeTime = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ScheduleTeeTime"
            };

            // Date Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = teeTime.DesiredDate.Date
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Member Number Parameter
            Parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberNumber
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Day Of Week Parameter
            Parameter = new()
            {
                ParameterName = "DayOfWeek",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = teeTime.DesiredDate.DayOfWeek
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Time Parameter
            Parameter = new()
            {
                ParameterName = "Time",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = teeTime.DesiredTime
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Number Of Carts Parameter
            Parameter = new()
            {
                ParameterName = "NumberOfCarts",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.NumberOfCarts
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Team Member One Parameter
            Parameter = new()
            {
                ParameterName = "MemberOne",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberOneID
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Team Member Two Parameter
            Parameter = new()
            {
                ParameterName = "MemberTwo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberTwoID
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Team Member Three Parameter
            Parameter = new()
            {
                ParameterName = "MemberThree",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberThreeID
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Requested Date Parameter
            Parameter = new()
            {
                ParameterName = "RequestedDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = teeTime.RequestedDate
            };
            ScheduleTeeTime.Parameters.Add(Parameter);
            // Requested Time Parameter

            Parameter = new()
            {
                ParameterName = "RequestedTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = teeTime.RequestedTime
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            // Employee Name Parameter (Hard Coded)
            Parameter = new()
            {
                ParameterName = "EmployeeName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = teeTime.EmployeeName
            };
            ScheduleTeeTime.Parameters.Add(Parameter);

            ScheduleTeeTime.ExecuteNonQuery();
            Confirmation = true;
            DataSource.Close();
            return Confirmation;
        }
        // GetTeeTimes

        public List<TeeTime> GetTeeTimesForMembers(int memberNumber)
        {
            List<TeeTime> MemberTeeTimes = new List<TeeTime>();
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            //SqlConnection DataSource = new();
            //ConfigurationBuilder DatabaseUsersBuilder = new();
            //DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            //DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            //IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            //DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand GetTeeTimes = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetTeeTimesForMember"
            };

            // Member Number Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = memberNumber
            };
            GetTeeTimes.Parameters.Add(Parameter);

            SqlDataReader DataReader = GetTeeTimes.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    TeeTime ListTeeTime = new();
                    ListTeeTime.TeeTimeNumber = (int)DataReader["TeeTimeNumber"];
                    ListTeeTime.DesiredTime = TimeSpan.Parse(DataReader["Time"].ToString());
                    ListTeeTime.DesiredDate = DateTime.Parse(DataReader["Date"].ToString());
                    ListTeeTime.FullName = DataReader["FullName"].ToString();
                    ListTeeTime.MemberOneID =(int) DataReader["MemberOne"];
                    ListTeeTime.MemberTwoID = (int)DataReader["MemberTwo"];
                    ListTeeTime.MemberThreeID = (int)DataReader["MemberThree"];
                    ListTeeTime.NumberOfCarts = (int)DataReader["NumberOfCarts"];
                    ListTeeTime.RequestedTime = TimeSpan.Parse(DataReader["RequestedTime"].ToString());
                    ListTeeTime.RequestedDate = DateTime.Parse(DataReader["RequestedDate"].ToString());
                    MemberTeeTimes.Add(ListTeeTime);
                }
            }

            DataReader.Close();
            DataSource.Close();
            return MemberTeeTimes;
        }

        public bool DeleteTeeTimeForMember(int memberNumber, DateTime date, TimeSpan time)
        {
            bool Confirmation = false;
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            //SqlConnection DataSource = new();
            //ConfigurationBuilder DatabaseUsersBuilder = new();
            //DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            //DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            //IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            //DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand DeleteTeeTime = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteTeeTimeForMember"
            };
            
            // Member Number Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = memberNumber
            };
            DeleteTeeTime.Parameters.Add(Parameter);

            // Date Parameter
            Parameter = new()
            {
                ParameterName = "Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = date.Date
            };
            DeleteTeeTime.Parameters.Add(Parameter);

            // Time Parameter
            Parameter = new()
            {
                ParameterName = "Time",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = time
            };
            DeleteTeeTime.Parameters.Add(Parameter);

            Confirmation = DeleteTeeTime.ExecuteNonQuery() != 1;

            DataSource.Close();
            return Confirmation;
        }

        public bool UpdateTeeTime(TeeTime teeTime)
        {
            bool Confirmation = false;

            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            //SqlConnection DataSource = new();
            //ConfigurationBuilder DatabaseUsersBuilder = new();
            //DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            //DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            //IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            //DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand UpdateTeeTime = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateTeeTime"
            };

            SqlParameter Parameter = new()
            {
                ParameterName = "TeeTimeNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.TeeTimeNumber
            };

            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Time",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = teeTime.DesiredTime
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = teeTime.DesiredDate
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "MemberOne",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberOneID
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "MemberTwo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberTwoID
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "MemberThree",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberThreeID
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "NumberOfCarts",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.NumberOfCarts
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "RequestedDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = teeTime.RequestedDate
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "RequestedTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = teeTime.RequestedTime
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "DayOfWeek",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = teeTime.RequestedDate.DayOfWeek
            };
            UpdateTeeTime.Parameters.Add(Parameter);

            Confirmation = UpdateTeeTime.ExecuteNonQuery() == 0;

            DataSource.Close();
            return Confirmation;
        }

        public TeeTime GetTeeTime(int teeTimeNumber)
        {
            TeeTime ScheduledTeeTime = new();

            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            //SqlConnection DataSource = new();
            //ConfigurationBuilder DatabaseUsersBuilder = new();
            //DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            //DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            //IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            //DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand GetTeeTime = new()
            {
                Connection = DataSource,
                CommandText = "GetTeeTime",
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter Parameter = new()
            {
                ParameterName = "TeeTimeNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTimeNumber
            };

            GetTeeTime.Parameters.Add(Parameter);

            SqlDataReader DataReader = GetTeeTime.ExecuteReader();

            if (DataReader.HasRows)
            {
                DataReader.Read();
                ScheduledTeeTime.DesiredTime = TimeSpan.Parse(DataReader["Time"].ToString());
                ScheduledTeeTime.DesiredDate = DateTime.Parse(DataReader["Date"].ToString());
                ScheduledTeeTime.MemberNumber = (int)DataReader["MemberNumber"];
                ScheduledTeeTime.MemberOneID = (int)DataReader["MemberOne"];
                ScheduledTeeTime.MemberTwoID = (int)DataReader["MemberTwo"];
                ScheduledTeeTime.MemberThreeID = (int)DataReader["MemberThree"];
                ScheduledTeeTime.NumberOfCarts = (int)DataReader["NumberOfCarts"];
                ScheduledTeeTime.EmployeeName = DataReader["EmployeeName"].ToString();
            }

            DataReader.Close();
            DataSource.Close();
            return ScheduledTeeTime;
        }
    }
}
