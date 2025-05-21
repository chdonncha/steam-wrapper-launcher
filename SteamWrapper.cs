using System;
using System.Diagnostics;
using System.IO;

class Program
{
    private const string ConfigFileName = "launch_path.txt";
    private const string ErrorLogFile = "wrapper_error.log";

    static void Main(string[] args)
    {
        try
        {
            if (!File.Exists(ConfigFileName))
            {
                File.WriteAllText(ErrorLogFile, $"Missing config file: {ConfigFileName}");
                return;
            }

            var targetPath = File.ReadAllText(ConfigFileName).Trim();

            if (!File.Exists(targetPath))
            {
                File.WriteAllText(ErrorLogFile, $"Target file not found: {targetPath}");
                return;
            }

            var workingDir = Path.GetDirectoryName(targetPath);

            var process = new Process();
            process.StartInfo.FileName = targetPath;
            process.StartInfo.WorkingDirectory = workingDir;
            process.StartInfo.UseShellExecute = true;
            process.Start();

            // Prevent Steam from thinking the wrapper crashed instantly
            System.Threading.Thread.Sleep(3000);
        }
        catch (Exception ex)
        {
            File.WriteAllText(ErrorLogFile, ex.ToString());
        }
    }
}
