﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using BAIS3130.Domain;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BAIS3130.Technical_Services
{
    public class Members
    {
        public double ViewPlayerHandicap (int memberNumber)
        {
            double ReturnHandicap;
            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand ViewHandicap = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ViewPlayerHandicap"
            };

            // Member Number Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = memberNumber
            };
            ViewHandicap.Parameters.Add(Parameter);

            ReturnHandicap = double.Parse(ViewHandicap.ExecuteScalar().ToString());

            DataSource.Close();
            return ReturnHandicap;
        }
        
        public bool ApplyMembership(MembershipApplication application)
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

            SqlCommand ApplyMembership = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ApplyMembership"
            };

            // Name Parameters
            SqlParameter Parameter = new()
            {
                ParameterName = "FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.FirstName
            };
            ApplyMembership.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.LastName
            };
            ApplyMembership.Parameters.Add(Parameter);

            //Address Parameter
            Parameter = new()
            {
                ParameterName = "Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Address
            };
            ApplyMembership.Parameters.Add(Parameter);
            
            // Postal Code Parameter
            Parameter = new()
            {
                ParameterName = "PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.PostalCode
            };
            ApplyMembership.Parameters.Add(Parameter);

            //Phone Paramter
            Parameter = new()
            {
                ParameterName = "Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Phone
            };
            ApplyMembership.Parameters.Add(Parameter);

            // Alternate Phone Parameter
            Parameter = new()
            {
                ParameterName = "AlternatePhone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.AlternatePhone
            };
            ApplyMembership.Parameters.Add(Parameter);

            // Email Parameter
            Parameter = new()
            {
                ParameterName = "Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Email
            };
            ApplyMembership.Parameters.Add(Parameter);

            // DOB Parameter
            Parameter = new()
            {
                ParameterName = "DateOfBirth",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = application.DOB
            };
            ApplyMembership.Parameters.Add(Parameter);

            // Signature bool parameter
            Parameter = new()
            {
                ParameterName = "ApplicantSigned",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = application.Signed
            };
            ApplyMembership.Parameters.Add(Parameter);

            //Application Date Parameter
            Parameter = new()
            {
                ParameterName = "ApplicationDate",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = DateTime.Now.Date
            };
            ApplyMembership.Parameters.Add(Parameter);

            // Shareholder 1 Name + Signature + Date
            Parameter = new()
            {
                ParameterName = "Shareholder1Name",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Shareholder1Name
            };
            ApplyMembership.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Shareholder1Signed",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = application.Shareholder1Signed
            };
            ApplyMembership.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Shareholder1Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = DateTime.Now.Date
            };
            ApplyMembership.Parameters.Add(Parameter);

            // Shareholder 2 Name + Signature + Date
            Parameter = new()
            {
                ParameterName = "Shareholder2Name",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Shareholder2Name
            };
            ApplyMembership.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Shareholder2Signed",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = application.Shareholder1Signed
            };
            ApplyMembership.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Shareholder2Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = DateTime.Now.Date
            };
            ApplyMembership.Parameters.Add(Parameter);

            Confirmation = ApplyMembership.ExecuteNonQuery() == 0;

            DataSource.Close();
            return Confirmation;
        }

        public MembershipApplication ViewApplication(int applicationNumber)
        {
            MembershipApplication MemberApplication = new();
            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand ViewApplication = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ViewApplication"
            };

            //Application Number
            SqlParameter Parameter = new()
            {
                ParameterName = "ApplicationNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = applicationNumber
            };
            ViewApplication.Parameters.Add(Parameter);

            SqlDataReader DataReader = ViewApplication.ExecuteReader();

            if (DataReader.HasRows)
            {
                DataReader.Read();
                MemberApplication = new()
                {
                    FirstName = DataReader["FirstName"].ToString(),
                    LastName = DataReader["LastName"].ToString(),
                    Phone = DataReader["Phone"].ToString(),
                    Email = DataReader["Email"].ToString(),
                    AlternatePhone = DataReader["AlternatePhone"].ToString(),
                    PostalCode = DataReader["PostalCode"].ToString(),
                    Address = DataReader["Address"].ToString(),
                    Shareholder1Signed = (bool)DataReader["Shareholder1Signed"],
                    Shareholder2Signed = (bool)DataReader["Shareholder2Signed"],
                    DOB = DateTime.Parse(DataReader["DateOfBirth"].ToString()),
                    Signed = (bool)DataReader["ApplicantSigned"],
                    Shareholder1Name = DataReader["Shareholder1Name"].ToString(),
                    Shareholder2Name = DataReader["Shareholder2Name"].ToString(),
                    Shareholder1Date = DateTime.Parse(DataReader["Shareholder1Date"].ToString()),
                    Shareholder2Date = DateTime.Parse(DataReader["Shareholder2Date"].ToString()),
                };
            }
            DataReader.Close();
            DataSource.Close();
            return MemberApplication;
        }

        public bool RegisterApplicant(MembershipApplication application, string membership)
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

            SqlCommand RegisterApplicant = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "RegisterApplicant"
            };

            //Name Parameters
            SqlParameter Parameter = new()
            {
                ParameterName = "FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.FirstName
            };
            RegisterApplicant.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.LastName
            };
            RegisterApplicant.Parameters.Add(Parameter);

            //Address Parameter
            Parameter = new()
            {
                ParameterName = "Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Address
            };
            RegisterApplicant.Parameters.Add(Parameter);

            //Postal Code Paramter
            Parameter = new()
            {
                ParameterName = "PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.PostalCode
            };
            RegisterApplicant.Parameters.Add(Parameter);

            //Phone Parameters
            Parameter = new()
            {
                ParameterName = "Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Phone
            };
            RegisterApplicant.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "AlternatePhone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.AlternatePhone
            };
            RegisterApplicant.Parameters.Add(Parameter);

            //Email Parameter
            Parameter = new()
            {
                ParameterName = "Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = application.Email
            };
            RegisterApplicant.Parameters.Add(Parameter);

            // DOB Parameter
            Parameter = new()
            {
                ParameterName = "DateOfBirth",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = application.DOB
            };
            RegisterApplicant.Parameters.Add(Parameter);

            // Membership Level Parameter
            Parameter = new()
            {
                ParameterName = "Membership",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = membership
            };
            RegisterApplicant.Parameters.Add(Parameter);

            Confirmation = RegisterApplicant.ExecuteNonQuery() == 0;

            DataSource.Close();
            return Confirmation;
        }
        public bool DeleteApplication(int applicationNumber)
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

            SqlCommand DeleteApplication = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteApplication"
            };

            //Application Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "ApplicationNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = applicationNumber
            };
            DeleteApplication.Parameters.Add(Parameter);

            Confirmation = DeleteApplication.ExecuteNonQuery() == 0;

            DataSource.Close();
            return Confirmation;
        }
        public Member GetMemberPassword(string username)
        {
            Member MemberInformation = new();

            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand GetMemberPassword = new()
            {
                Connection = DataSource,
                CommandText = "GetMemberPassword",
                CommandType = CommandType.StoredProcedure
            };

            // Username Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "Username",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = username
            };
            GetMemberPassword.Parameters.Add(Parameter);

            SqlDataReader DataReader = GetMemberPassword.ExecuteReader();

            if (DataReader.HasRows)
            {
                DataReader.Read();

                MemberInformation.MemberNumber = (int)DataReader["MemberNumber"];
                MemberInformation.Password = DataReader["Password"].ToString();
                MemberInformation.Username = DataReader["Username"].ToString();
                MemberInformation.Membership = DataReader["Membership"].ToString();
            }

            DataReader.Close();
            DataSource.Close();
            return MemberInformation;
        }

        public Member ViewMember(int memberNumber)
        {
            Member MemberInformation = new();

            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Name");
            DataSource.Open();

            SqlCommand ViewMember = new()
            {
                Connection = DataSource,
                CommandText = "ViewMember",
                CommandType = CommandType.StoredProcedure
            };

            // MemberNumber Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = memberNumber
            };
            ViewMember.Parameters.Add(Parameter);

            SqlDataReader DataReader = ViewMember.ExecuteReader();

            if (DataReader.HasRows)
            {
                DataReader.Read();
                MemberInformation = new()
                {
                    FirstName = DataReader["FirstName"].ToString(),
                    LastName = DataReader["LastName"].ToString(),
                    Address = DataReader["Address"].ToString(),
                    PostalCode = DataReader["PostalCode"].ToString(),
                    Phone = DataReader["Phone"].ToString(),
                    AlternatePhone = String.IsNullOrEmpty(DataReader["AlternatePhone"].ToString()) ? "" : DataReader["AlternatePhone"].ToString(),
                    Email = DataReader["Email"].ToString(),
                    DOB = DateTime.Parse(DataReader["DateOfBirth"].ToString()),
                    Handicap = (double)DataReader["HandicapIndex"],
                    Membership = DataReader["Membership"].ToString()
                };
            }
            DataReader.Close();
            DataSource.Close();
            return MemberInformation;
        }

        public List<Member> GetMemersLogins()
        {
            List<Member> MemberLogins = new();

            //SqlConnection DataSource = new();
            //DataSource.ConnectionString = @"Persist Security Info=False;User=ptrninkov1;Password=rageking1A;server=dev1.baist.ca";

            SqlConnection DataSource = new();
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("Connection");
            DataSource.Open();

            SqlCommand GetAllMembersLoginInformation = new()
            {
                Connection = DataSource,
                CommandText = "GetAllMembersLoginInformation",
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader DataReader = GetAllMembersLoginInformation.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Member MemberLogin = new()
                    {
                        FirstName = DataReader["FirstName"].ToString(),
                        LastName = DataReader["LastName"].ToString(),
                        Username = DataReader["Username"].ToString(),
                        Password = DataReader["Password"].ToString(),
                        Membership = DataReader["Membership"].ToString()
                    };
                    MemberLogins.Add(MemberLogin);
                }
            }

            DataReader.Close();
            DataSource.Close();
            return MemberLogins;
        }
    }
}
