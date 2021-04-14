using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;





namespace IWantMyMummy.Models
{
    public class Helpers
    {
        public static string GetRDSConnectionString()
        {
            //var appConfig = ConfigurationManager.AppSettings;



            //string dbname = appConfig["RDS_DB_NAME"];
            //if (string.IsNullOrEmpty(dbname)) return null;



            //string username = appConfig["group16"];
            //string password = appConfig["Test123!"];
            //string hostname = appConfig["aa13u30f57vnp5s.cvgavxq5by3r.us-east-1.rds.amazonaws.com"];
            //string port = appConfig["1433"];

            string connect = "Data Source=aa13u30f57vnp5s.cvgavxq5by3r.us-east-1.rds.amazonaws.com; Initial Catalog=ebdb;User ID=group16;Password=Test123!group16;";
            //return "Data Source=" + hostname + ";Initial Catalog=ebdb" + ";User ID=" + username + ";Password=" + password + ";";
            return connect;
        }
    }
}