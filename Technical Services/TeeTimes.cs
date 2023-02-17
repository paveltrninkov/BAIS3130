using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3130.Domain;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BAIS3130.Technical_Services
{
    public class TeeTimes
    {
        public bool ScheduleTeeTime (TeeTime teeTime, int memberNumber)
        {
            bool confimration = false;
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=makedonija1A!;server=dev1.baist.ca";
            DataSource.Open();

            SqlCommand ScheduleTeeTime = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ScheduleTeeTime"
            };

            SqlParameter parameter = new()
            {
                ParameterName = "Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = teeTime.DesiredDate.Date
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = memberNumber
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "DayOfWeek",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = teeTime.DesiredDate.DayOfWeek
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "Time",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "NumberOfCarts",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.NumberOfCarts
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "TeamMemberOne",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberOne
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "TeamMemberTwo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberTwo
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "TeamMemberThree",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = teeTime.MemberThree
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = teeTime.RequestedTime.Date
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "RequestedTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                Value = teeTime.RequestedTime.TimeOfDay
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "EmployeeName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = teeTime.EmployeeName
            };
            ScheduleTeeTime.Parameters.Add(parameter);

            ScheduleTeeTime.ExecuteNonQuery();
            DataSource.Close();
            confimration = true;
            return confimration;
        }
    }
}
