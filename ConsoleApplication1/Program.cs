using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Location of Python
            string PythonExecutable = @"C:\Python\python.exe";

            //Location of Python File
            string PythonFileToCall = "C:\\Sample\\RAS.py";
            
            //Arguments to be passed to the python script
            int x = 20 , y = 3;


            //Process Start Information for the Python Process
            ProcessStartInfo PythonProcessStartInfo = new ProcessStartInfo(PythonExecutable);


            //If we need to access the standard output, set this to false
            PythonProcessStartInfo.UseShellExecute = false;

            PythonProcessStartInfo.RedirectStandardOutput = true;

            //Arguments
            PythonProcessStartInfo.Arguments = PythonFileToCall + " " + x + " " + y;

            //The main process
            Process PythonProcess = new Process();

            //Process information
            PythonProcess.StartInfo = PythonProcessStartInfo;


            Console.WriteLine("Calling Python script with arguments {0} and {1}", x, y);

            //Start The process
            PythonProcess.Start();

            
            //Get the output of the python process
            StreamReader StreamReader = PythonProcess.StandardOutput;

            //Read to the end, the output
            string PythonOutput = StreamReader.ReadToEnd();

            PythonProcess.WaitForExit();
            PythonProcess.Close();

            Console.WriteLine(PythonOutput);

        }
    }
}
