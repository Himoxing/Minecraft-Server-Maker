using System.IO;
using System.Text;
using Minecraft_Server_Maker.Models;
using Minecraft_Server_Maker.Services.Interfaces;

namespace Minecraft_Server_Maker.Services;

public class ConfigService : IConfigService
{
	public void SaveServerProperties(string directory, ServerSettings _settings)
	{
		var sb = new StringBuilder();
		sb.AppendLine($"server-port={_settings.Port}");
		sb.AppendLine($"server-ip={_settings.ServerIp}");
		sb.AppendLine($"motd={_settings.Name}");
		sb.AppendLine($"online-mode={_settings.Premium.ToString().ToLower()}");
		sb.AppendLine($"white-list={_settings.WhiteListed.ToString().ToLower()}");
		
		string filePath = Path.Combine(directory, "server.properties");
		File.WriteAllText(filePath, sb.ToString());
	}

	public void AcceptEula(string directory)
	{
		string filePath = Path.Combine(directory, "eula.txt");
		File.WriteAllText(filePath, "eula=true");
	}
}