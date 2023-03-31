using BAIS3130.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3130.Technical_Services
{
    public class Scorecards
    {
        public bool RecordScorecard(Scorecard scorecard)
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

            SqlCommand RecordScore = new()
            {
                Connection = DataSource,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "RecordTeeTimeScore"
            };

            //Member Number Parameter
            SqlParameter Parameter = new()
            {
                ParameterName = "MemberNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.MemberNumber
            };
            RecordScore.Parameters.Add(Parameter);

            // Handicap Index Parameter
            Parameter = new()
            {
                ParameterName = "HandicapIndex",
                SqlDbType = System.Data.SqlDbType.Decimal,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.HandicapIndex
            };
            RecordScore.Parameters.Add(Parameter);

            // Course Handicap Parameter
            Parameter = new()
            {
                ParameterName = "CourseHandicap",
                SqlDbType = System.Data.SqlDbType.Decimal,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.CourseHandicap
            };
            RecordScore.Parameters.Add(Parameter);

            //Slope Rating Parameter
            Parameter = new()
            {
                ParameterName = "SlopeRating",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.HandicapIndex
            };
            RecordScore.Parameters.Add(Parameter);

            // Course Rating Paramter
            Parameter = new()
            {
                ParameterName = "CourseRating",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.CourseRating
            };
            RecordScore.Parameters.Add(Parameter);

            // Tee Time Number
            Parameter = new()
            {
                ParameterName = "TeeTimeNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.TeeTimeNumber
            };
            RecordScore.Parameters.Add(Parameter);

            // Hole Scores (alternates par then score up to 18 holes)
            Parameter = new()
            {
                ParameterName = "Hole1Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole1Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole1Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole1Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole2Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole2Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole2Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole2Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole3Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole3Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole3Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole3Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole4Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole4Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole4Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole4Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole5Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole5Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole5Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole5Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole6Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole6Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole6Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole6Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole7Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole7Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole7Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole7Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole8Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole8Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole8Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole8Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole9Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole9Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole9Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole9Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole10Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole10Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole10Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole10Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole11Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole11Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole11Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole11Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole12Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole12Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole12Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole12Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole13Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole13Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole13Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole13Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole14Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole14Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole14Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole14Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole15Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole15Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole15Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole15Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole16Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole16Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole16Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole16Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole17Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole17Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole17Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole17Score
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole18Par",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole18Par
            };
            RecordScore.Parameters.Add(Parameter);

            Parameter = new()
            {
                ParameterName = "Hole18Score",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = scorecard.Hole18Score
            };
            RecordScore.Parameters.Add(Parameter);

            Confirmation = RecordScore.ExecuteNonQuery() == 0;

            DataSource.Close();
            return Confirmation;
        }
    }
}
