namespace Minecraft_Server_Maker.Services.Interfaces;

public interface IMemoryMonitor
{
	long GetTotalRamBytes();
	long GetFreeRamBytes();
}