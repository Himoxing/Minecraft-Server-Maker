using System.IO;
using System.Diagnostics;

namespace Minecraft_Server_Maker.Models;

public class MinecraftServer
{
	public string Name { get; set; } = "My Server";
	public string JarPath { get; set; } = string.Empty;
	public int RamMb { get; set; } = 2048;
	public bool Local { get; set; } = false;
	public int Port { get; set; } = 80;

	public void CreateAndRun()
	{
		if (string.IsNullOrEmpty(JarPath)) return;

		string? serverDir = Path.GetDirectoryName(JarPath);
		if (serverDir == null) return;

		File.WriteAllText(Path.Combine(serverDir, "eula.txt"), "eula=true");

		string serverIp = Local ? "127.0.0.1" : "0.0.0.0";
		string properties = $"server-port={Port}\n" +
		                    $"server-ip={serverIp}\n" +
		                    $"motd={Name}";
		File.WriteAllText(Path.Combine(serverDir, "server.properties"), properties);

		ProcessStartInfo psi = new ProcessStartInfo
		{
			FileName = "java",
			Arguments = $"-Xmx{RamMb}M -jar \"{JarPath}\" nogui",
			WorkingDirectory = serverDir,
			UseShellExecute = true,
		};
		
		Process.Start(psi);
	}
}