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
		try
		{
			string? serverDir = Path.GetDirectoryName(JarPath);


			if (serverDir == null) return;

			string javaPath = Path.Combine(AppContext.BaseDirectory, "Runtime", "bin", "java.exe");

			if (!File.Exists(javaPath))
			{
				System.Windows.MessageBox.Show("Jar file doesn't exist!");
				return;
			}


			File.WriteAllText(Path.Combine(serverDir, "eula.txt"), "eula=true");

			string serverIp = Local ? "127.0.0.1" : "0.0.0.0";
			string properties = $"server-port={Port}\n" +
			                    $"server-ip={serverIp}\n" +
			                    $"motd={Name}";
			File.WriteAllText(Path.Combine(serverDir, "server.properties"), properties);

			ProcessStartInfo psi = new ProcessStartInfo
			{
				FileName = javaPath,
				Arguments = $"-Xmx{RamMb}M -jar \"{JarPath}\" nogui",
				WorkingDirectory = serverDir,
				UseShellExecute = true,
			};

			Process.Start(psi);
		}

		catch (Exception ex)
		{
			System.Windows.MessageBox.Show(ex.Message);
		}
	}
}