using Minecraft_Server_Maker.Models;

namespace Minecraft_Server_Maker.Services.Interfaces;

public interface IConfigService
{
	void SaveServerProperties(string directory, ServerSettings settings);
	void AcceptEula(string directory);
}