using System;
using System.Management;
using System.Windows.Automation.Peers;

namespace Minecraft_Server_Maker.Services;

public class MemoryMonitor
{
	public long GetTotalRamBytes(Units unit)
	{
		try
		{
			var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");
			foreach (var obj in searcher.Get())
			{
				long totalKb = Convert.ToInt64(obj["TotalVisibleMemorySize"]);

				double totalMb = totalKb / 1024.0;
				double totalGb = totalMb / 1024.0;

				if (unit == Units.Megabyte) return (long)totalMb;
				if (unit == Units.Gigabyte) return (long)totalGb;
			}
		}
		catch (Exception ex)
		{
			return 0;
		}

		return 0;

	}

	public long GetFreeRamBytes(Units unit)
	{
		try
		{
			var searcher = new ManagementObjectSearcher("SELECT FreePhysicalMemory FROM Win32_OperatingSystem");
			foreach (var obj in searcher.Get())
			{
				long freeKb = Convert.ToInt64(obj["FreePhysicalMemory"]);

				double freeMb = freeKb / 1024.0;
				double freeGb = freeMb / 1024.0;
				
				if (unit == Units.Megabyte) return (long)freeMb;
				if (unit == Units.Gigabyte) return (long)freeGb;
			}
		}
		catch (Exception ffffex)
		{
			return 0;
		}

		return 0;
	}
}
public enum Units
{
	Megabyte,
	Gigabyte,
}
