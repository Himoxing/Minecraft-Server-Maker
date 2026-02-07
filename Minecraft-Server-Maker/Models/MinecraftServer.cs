using System.IO;
using System.Diagnostics;

namespace Minecraft_Server_Maker.Models;

public class MinecraftServer
{
	public string JarPath { get; set; } = string.Empty;
	public int RamMb { get; set; } = 2048;
	public bool Local { get; set; } = false;
	public Process? ServerProcess { get; set; }
	
	public bool IsServerRunning => ServerProcess != null && !ServerProcess.HasExited;

}