using System.Diagnostics;
using System.IO;
using Minecraft_Server_Maker.Models;
using Minecraft_Server_Maker.Services.Interfaces;

namespace Minecraft_Server_Maker.Services;

public class ServerLauncher : IServerLauncher
{
	
	private readonly IConfigService _configService;

	public ServerLauncher(IConfigService configService)
	{
		_configService = configService;
	}

	public void Launch(MinecraftServer _server, ServerSettings _settings)
	{
		try
		{
			string? serverDir = Path.GetDirectoryName(_server.JarPath);
			
			if (serverDir == null) return;

			_configService.AcceptEula(serverDir);

			var serverSettings = new ServerSettings
			{
				Port = _settings.Port,
				Name = _settings.Name,
				Premium = _settings.Premium,
				WhiteListed = _settings.WhiteListed,
			};
			_settings.ServerIp = _server.Local ? "127.0.0.1" : "";
			_configService.SaveServerProperties(serverDir, serverSettings);
			
			string javaPath = Path.Combine(AppContext.BaseDirectory, "Runtime", "bin", "java.exe");

			if (!File.Exists(javaPath))
			{
				System.Windows.MessageBox.Show($"Jar file doesn't exist! Found in: {javaPath}");
				return;
			}
			
			ProcessStartInfo psi = new ProcessStartInfo
			{
				FileName = javaPath,
				Arguments = $"-Xmx{_server.RamMb}M -jar \"{_server.JarPath}\" nogui",
				WorkingDirectory = serverDir,
				UseShellExecute = false,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden
			};

			_server.ServerProcess = Process.Start(psi);
			
			if (_server.ServerProcess != null) _server.ServerProcess.EnableRaisingEvents = true;
		}

		catch (Exception ex)
		{
			System.Windows.MessageBox.Show(ex.Message);
		}
	}
}