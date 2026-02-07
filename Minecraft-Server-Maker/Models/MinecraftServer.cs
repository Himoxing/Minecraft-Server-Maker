using System.IO;
using System.Diagnostics;
using System.Management;

namespace Minecraft_Server_Maker.Models;

public class MinecraftServer
{
	
	public string JarPath { get; set; } = string.Empty;
	public double freeRam { get; set; } = 4096;
	public double totalRam { get; set; }
	
	public double setRam { get; set; }
	public bool UseShellExecute { get; set; } = false;
	public bool Local { get; set; } = false;
	public Process? ServerProcess { get; set; }
	
	public bool IsServerRunning => ServerProcess != null && !ServerProcess.HasExited;

}