using Minecraft_Server_Maker.Models;
using Microsoft.Win32;
using Minecraft_Server_Maker.Services;
namespace Minecraft_Server_Maker.ViewModels;

public class ServerConfigViewModel : ViewModelBase
{
	private readonly ServerSettings _settings;
	private readonly MinecraftServer _server;
	private readonly MemoryMonitor _memory;

	public double FreeMemory { get; private set; }
	public double TotalMemory { get; private set; }
	
	public ServerConfigViewModel(ServerSettings settings, MinecraftServer server)
	{
		_settings = settings;
		_server = server;
		_memory = new MemoryMonitor();

		TotalMemory = _memory.GetTotalRamBytes(Units.Megabyte);
		FreeMemory = _memory.GetFreeRamBytes(Units.Megabyte);
		Console.WriteLine("In ServerConfigViewModel " + TotalMemory);
		Console.WriteLine("In Memory Monitor (free)" + FreeMemory);

		if (_server.setRam < 1024) _server.setRam = 2048;
	}

	public string JarPathDisplay => string.IsNullOrEmpty(_server.JarPath)
		? "Not chosen file"
		: System.IO.Path.GetFileName(_server.JarPath);
	
	public void SelectJarFile()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Jar files (*.jar)|*.jar";

		if (openFileDialog.ShowDialog() == true)
		{
			_server.JarPath = openFileDialog.FileName;
			OnPropertyChanged(nameof(JarPathDisplay));
		}
	}
	
	public bool IsPremium
	{
		get => _settings.Premium;

		set
		{
			if (_settings.Premium != value)
			{
				_settings.Premium = value;
				OnPropertyChanged();
			}
		}
	}


	public bool IsWhiteListed
	{
		get => _settings.WhiteListed;

		set
		{
			if (_settings.WhiteListed != value)
			{
				_settings.WhiteListed = value;
				OnPropertyChanged();
			}
		}
	}

	public bool IsLocalStatus
	{
		get => _server.Local;
		set
		{
			if (_server.Local != value)
			{
				_server.Local = value;
				OnPropertyChanged();
			}
		}
	}

	public int ServerPort
	{
		get => _settings.Port;
		set
		{
			if (_settings.Port != value)
			{
				_settings.Port = value;
				OnPropertyChanged();
			}
		}
	}



	public double SetMemory
	{
		get => _server.setRam;

		set
		{
			if (_server.setRam != value)
			{
				_server.setRam = Math.Clamp(value, 1024, FreeMemory);
				OnPropertyChanged();
			}
		}
	}



	public string ServerName
	{
		get => _settings.Name;
		set
		{
			if (_settings.Name != value)
			{
				_settings.Name = value;
				OnPropertyChanged();
			}
		}
	}
}