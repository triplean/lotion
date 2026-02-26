using System;
using System.Diagnostics;

namespace Lotion.Backend;

public class Utils
{
    
    public static bool IsFlathubConfigured()
    {
        Process flatpakProcess = new Process();
        flatpakProcess.StartInfo.FileName = "flatpak";
        flatpakProcess.StartInfo.Arguments = "remotes -d";
        flatpakProcess.StartInfo.RedirectStandardOutput = true;
        flatpakProcess.StartInfo.CreateNoWindow = true;
        flatpakProcess.Start();
        
        string output = flatpakProcess.StandardOutput.ReadToEnd();

        flatpakProcess.WaitForExit();
        
        if (output.Contains("flathub.org")) return true;
        
        return false;
    }

    public static void AddFlathubRepo()
    {
        Process flatpakProcess = new Process();
        flatpakProcess.StartInfo.FileName = "flatpak";
        flatpakProcess.StartInfo.Arguments =
            "remote-add --if-not-exists flathub https://dl.flathub.org/repo/flathub.flatpakrepo";
        flatpakProcess.Start();
        flatpakProcess.WaitForExit();
    }

    public static bool IsSoberRunning()
    {
        Process psProcess = new Process();
        psProcess.StartInfo.FileName = "ps";
        psProcess.StartInfo.Arguments = "aux";
        psProcess.StartInfo.RedirectStandardOutput = true;
        psProcess.StartInfo.CreateNoWindow = true;
        psProcess.Start();
        
        string output = psProcess.StandardOutput.ReadToEnd();
        
        psProcess.WaitForExit();
        
        return output.Contains("sober");
    }
}