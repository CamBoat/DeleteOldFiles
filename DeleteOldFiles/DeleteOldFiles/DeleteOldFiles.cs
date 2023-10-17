using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace DeleteOldFiles
{
    class DeleteOldFiles
    {
        static string dir = "";
        static int days = 0;
        Thread threadDeleteOldFiles = null;
        private static bool isOldFile(string fileName)
        {
            int dayFileLastWriteTime = (File.GetLastWriteTime(fileName)).Day;
            int dayNow = DateTime.Now.Day;
            if ((dayNow + 31 - dayFileLastWriteTime) % 31 > DeleteOldFiles.days)
                return true;
            else
                return false;
        }
        private static void deleteOldFiles()
        {
            string[] fileNames = null;
            while (true)
            {
                fileNames = Directory.GetFiles(DeleteOldFiles.dir);
                foreach (string fileName in fileNames)
                {
                    if (isOldFile(fileName))
                        File.Delete(fileName);
                }
                //every 60 seconds
                Thread.Sleep(1000 * 60);
            }
        }
        private void startThread()
        {
            threadDeleteOldFiles = new Thread(deleteOldFiles);
            threadDeleteOldFiles.Start();
        }
        public DeleteOldFiles(string dir,int days)
        {
            DeleteOldFiles.days = days;
            DeleteOldFiles.dir = dir;
            this.startThread();
        }

        public void endThread()
        {
            if (threadDeleteOldFiles != null)
            {
                threadDeleteOldFiles.Abort();
                threadDeleteOldFiles.Join();
            }
        }
    }
}
