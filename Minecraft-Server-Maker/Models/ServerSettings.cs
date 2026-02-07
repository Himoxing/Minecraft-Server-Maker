using System.IO;
using System.Diagnostics;
namespace Minecraft_Server_Maker.Models;

public class ServerSettings
{
	public string Name { get; set; } = "My Server";
	public int Port { get; set; } = 25565;
	public bool Premium { get; set; } = true;
	public bool WhiteListed { get; set; } = false;
	public string ServerIp { get; set; } = "127.0.0.1";

}