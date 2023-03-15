using Facesign.Services.Entities.Configuration;
using System;
using System.IO;

namespace Facesign.Services.Infra.LogService
{
    public class LogLocalService
    {
        public static void Log(string information)
        {
            //if (!ClientModel.EnabledLog)
            //   return;

            try
            {
                if (!Directory.Exists($"C:\\ProgramData\\ApiLog\\"))
                    Directory.CreateDirectory($"C:\\ProgramData\\ApiLog\\");

                string caminho = $"C:\\ProgramData\\ApiLog\\{DateTime.Now.Month.ToString("00")}-{DateTime.Now.Year.ToString("00")}\\{DateTime.Now.Day.ToString("00")}-{DateTime.Now.Month.ToString("00")}-{DateTime.Now.Year.ToString("00")}\\LockID.txt";
                string pasta = Path.GetDirectoryName(caminho);

                information = $"-- {DateTime.Now}, Log: {information}, ConnectionString: {BuildConfigurationModel.ConnectionString}";


                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }


                if (File.Exists(caminho))
                {
                    StreamWriter writer1 = File.AppendText(caminho);
                    writer1.WriteLine(information);
                    writer1.Close();
                }
                else
                {
                    StreamWriter writer = new StreamWriter(caminho);
                    writer.WriteLine(information);
                    writer.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
