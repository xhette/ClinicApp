using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.IO;
using System.Diagnostics;
using Ionic.Zip;
using Ionic.Zlib;

namespace ClinicData
{
    public static class BackupWork
    {
        private static string strDatabaseName = "ClinicSuqa";
        private static string strServer = "localhost";
        private static int strPort = 5432;
        private static string strPG_dumpPath = "D:\\progs\\PostgreSQL\\bin";

        public static byte[] BackingUp(string backUpPath)
        {

            try
            {
                StreamWriter sw = new StreamWriter("DBBackup.bat");
                // Do not change lines / spaces b/w words.
                StringBuilder strSB = new StringBuilder(strPG_dumpPath);

                if (strSB.Length != 0)
                {
                    strSB.Append("pg_dump.exe --host " + strServer + " --port " + strPort +
                      " --username postgres --format custom --blobs --verbose --file ");
                    strSB.Append("\"" + backUpPath + "\"");
                    strSB.Append(" \"" + strDatabaseName + "\r\n\r\n");
                    sw.WriteLine(strSB);
                    sw.Dispose();
                    sw.Close();
                    Process processDB = Process.Start("DBBackup.bat");
                    do
                    {//dont perform anything
                    }
                    while (!processDB.HasExited);
                    {
                        using (ZipFile zipArchiver = new ZipFile(Encoding.GetEncoding("cp866")))
                        {
                            string filePath = backUpPath + "\\" + "DBBackup.bat";

                            if (File.Exists(filePath))
                            {

                                zipArchiver.AddDirectory(filePath);
                                zipArchiver.CompressionLevel = CompressionLevel.BestCompression;

                                using (MemoryStream output = new MemoryStream())
                                {
                                    zipArchiver.Save(output);
                                    return output.ToArray();
                                }
                            }
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public static string RestoringUp(string txtBackupFilePath)
        {
            string result = "";

            try
            {
                if (txtBackupFilePath != "")
                {
                    StreamWriter sw = new StreamWriter("DBRestore.bat");
                    // Do not change lines / spaces b/w words.
                    StringBuilder strSB = new StringBuilder(strPG_dumpPath);
                    if (strSB.Length != 0)
                    {
                        strSB.Append("pg_restore.exe --host " + strServer +
                           " --port " + strPort + " --username postgres --dbname");
                        strSB.Append(" \"" + strDatabaseName + "\"");
                        strSB.Append(" --verbose ");
                        strSB.Append("\"" + txtBackupFilePath + "\"");
                        sw.WriteLine(strSB);
                        sw.Dispose();
                        sw.Close();
                        Process processDB = Process.Start("DBRestore.bat");
                        do
                        {//dont perform anything
                        }
                        while (!processDB.HasExited);
                        {
                            result = "БД успешно восстановлена из резервной копии";
                        }
                    }
                    else
                    {
                        result = "Неверно указан путь к резервной копии";
                    }
                }

            }
            catch (Exception ex)
            {
                result = "Упс, что-то пошло не так: " + ex.Message;
            }

            return result;
        }
    }
}
