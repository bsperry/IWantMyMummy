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
            var appConfig = ConfigurationManager.AppSettings;



            string dbname = appConfig["ebdb"];
            if (string.IsNullOrEmpty(dbname)) return null;



            string username = appConfig["group16"];
            string password = appConfig["Test123!"];
            string hostname = appConfig["aaelhq5ido7553.ctqvxzjxajyn.us-east-2.rds.amazonaws.com"];
            string port = appConfig["1433"];
            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
            //return "Data Source=aaelhq5ido7553.ctqvxzjxajyn.us-east-2.rds.amazonaws.com; Initial Catalog=ebdb;User ID=group16;Password=Test123!group16;";
        }
    }
}