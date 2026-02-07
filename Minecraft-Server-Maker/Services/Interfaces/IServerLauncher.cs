using Minecraft_Server_Maker.Models;
namespace Minecraft_Server_Maker.Services.Interfaces;

public interface IServerLauncher
{
	void Launch(MinecraftServer _server, ServerSettings _settings);
}