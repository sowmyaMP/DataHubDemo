using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHubDemo;
using System.Configuration;
using System.IO;

namespace DataHubDemoConfig
{
    class Program
    {
       public static string strBrowser;
       public  static string strEnvironment;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Browser:"); // Prompt
             strBrowser = Console.ReadLine(); // Get string from user

            Console.WriteLine("Enter Environment:"); // Prompt
             strEnvironment = Console.ReadLine(); // Get
            Console.WriteLine("Setting up the Application Varialbles"); // Prompt
            Program.writeIntoConfiExcelFile();

        }

        private static  void writeIntoConfiExcelFile()
        {
            try
            {

               string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                Console.WriteLine(path);
                path = path + "\\TestVariables\\ApplicatonVariables\\ApplicationDataHubVariables.csv";

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    }

                

                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        var line = string.Format("{0},{1}", strBrowser, strEnvironment);
                        sw.WriteLine(line);
                    }
                }
              
                //System.Data.OleDb.OleDbConnection MyConnection;
                //System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                //string sql = null;
                //MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +path + ";Extended Properties=Excel 8.0;");
                //MyConnection.Open();
                //myCommand.Connection = MyConnection;
                //sql = "Insert into [App] (Browser,Environment) values('" + strBrowser + "','" +strEnvironment +"')";
                //myCommand.CommandText = sql;
                //myCommand.ExecuteNonQuery();
                //MyConnection.Close();
            }
            catch (Exception ex)
            {
                
            }            
        }
        private string ReadFromAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

      
private void WriteToAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
