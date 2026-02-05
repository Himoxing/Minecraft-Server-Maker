using Minecraft_Server_Maker.Models;

namespace Minecraft_Server_Maker.ViewModels;

public class MainViewModel
{
	private MinecraftServer _server = new();

	public string ServerName
	{
		get => _server.Name;
		set
		{
			if (_server.Name != value)
			{
				_server.Name = value;
			}
		}
	}
}