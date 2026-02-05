namespace Minecraft_Server_Maker.Models;

public class MinecraftServer
{
	public string Name { get; set; } = "My Server";
	public string JarPath { get; set; } = string.Empty;
	public int RamMb { get; set; } = 2048;
	public bool Local { get; set; } = false;
	public int Port { get; set; } = 80;
}