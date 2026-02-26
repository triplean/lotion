using System.Diagnostics;

namespace Lotion.Backend;

public class Bootstrapper
{
    public static bool SoberInstalled()
    {
        Process flatpakProcess = new Process();
        flatpakProcess.StartInfo.FileName = "flatpak";
        flatpakProcess.StartInfo.Arguments = "info org.vinegarhq.Sober";
        flatpakProcess.Start();
        flatpakProcess.WaitForExit();
        
        return flatpakProcess.ExitCode == 0;
    }

    public static void InstallSober()
    {
        if (!Utils.IsFlathubConfigured()) Utils.AddFlathubRepo();
        
        Process flatpakProcess = new Process();
        flatpakProcess.StartInfo.FileName = "flatpak";
        flatpakProcess.StartInfo.Arguments = "install org.vinegarhq.Sober";
        flatpakProcess.Start();
    }

    public static void UpdateSober()
    {
        if (!Utils.IsFlathubConfigured()) Utils.AddFlathubRepo();
        
        Process flatpakProcess = new Process();
        flatpakProcess.StartInfo.FileName = "flatpak";
        flatpakProcess.StartInfo.Arguments = "update org.vinegarhq.Sober";
        flatpakProcess.Start();
        flatpakProcess.WaitForExit();
    }

    public static void StartSober()
    {
        Process flatpakProcess = new Process();
        flatpakProcess.StartInfo.FileName = "flatpak";
        flatpakProcess.StartInfo.Arguments = "run org.vinegarhq.Sober";
        flatpakProcess.Start();
        flatpakProcess.WaitForExit();
    }
}