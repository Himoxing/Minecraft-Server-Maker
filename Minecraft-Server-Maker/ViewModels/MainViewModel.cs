using Minecraft_Server_Maker.Models;
using System.Windows.Input;
using Microsoft.Win32;
using Minecraft_Server_Maker.Services.Interfaces;
using Minecraft_Server_Maker.Services;

namespace Minecraft_Server_Maker.ViewModels;

public class MainViewModel : ViewModelBase
{
	private MinecraftServer _server;
	private ServerSettings _settings;
	private readonly IServerLauncher _launcher;
	private readonly INetworkService _network;
	private readonly IConfigService _config;
	private string _status = "Offline";
	private string _publicIp = "---";
	private string _localIp = "---";
	public ServerConfigViewModel Config { get; }

	
	public MainViewModel()
	{
		SelectJarCommand = new RelayCommand(_ => Config.SelectJarFile());
		CreateServerCommand = new RelayCommand(_ => StartServer());
		
		_config = new ConfigService();
		_launcher = new ServerLauncher(_config);
		_network = new NetworkService();
		_settings = new ServerSettings();
		_server = new MinecraftServer();
		Config = new ServerConfigViewModel(_settings, _server);

	}
	
	public string LocalIp
	{
		get => _localIp;
		set
		{ 
			_localIp = value;
			OnPropertyChanged();
		}
	}

	public string Status
	{
		get => _status;

		set
		{
			if (_status != value)
			{
				_status = value;
				OnPropertyChanged();
			}
		}
	}

	public bool UseShellExecute
	{
		get => _server.UseShellExecute;
		set
		{
			if (_server.UseShellExecute != value) _server.UseShellExecute = value;
		}
	}

	public string PublicIp
	{
		get => _publicIp;
		set
		{
			if (_publicIp != value)
			{
				_publicIp = value;
				OnPropertyChanged();
			}
		}
	}

	private async void StartServer()
	{

		if (_server.IsServerRunning == true)
		{
			try
			{
				Status = "Stopping...";
				_server.ServerProcess?.Kill();
				Status = "Offline";
				OnPropertyChanged(nameof(ActionButtonText));
				OnPropertyChanged(nameof(ActionButtonColor));
			}
			catch (Exception ex)
			{
				Status = "Error stopping: " + ex.Message;
			}
			return;
		}
		try
		{
			Status = "Starting...";

			_launcher.Launch(_server, _settings);

			if (_server.IsServerRunning)
			{
				Status = "Running";

				_server.ServerProcess.Exited += (s, e) =>
				{
					Status = "Offline";
					LocalIp = "---";
					PublicIp = "---";
				};
				int port = _settings.Port;

				if (!Config.IsLocalStatus)
				{
					LocalIp = _network.GetLocalIp();
					Status = "Fetching public IP...";
					string publicIp = await _network.GetPublicIpAsync();
					PublicIp = publicIp + ":" + port;
				}

				else
				{
					LocalIp = "127.0.0.1" + ":" + port;
					PublicIp = "Not available (Local Mode)";
				}

				Status = "Online";
			}

			else Status = "Failed to start server";
		}
		catch (Exception ex)
		{
			Status = "Error: " + ex.Message;
		}
		
		OnPropertyChanged(nameof(ActionButtonText));
		OnPropertyChanged(nameof(ActionButtonColor));
	}

	public void OnWindowClosing()
	{
		if (_server?.ServerProcess != null && _server.ServerProcess.HasExited);
		{
			try
			{
				_server.ServerProcess.Kill();
				_server.ServerProcess.Dispose();
			}
			catch {}
		}
	}
	
	public string ActionButtonText => _server.IsServerRunning ? "STOP SERVER" : "CREATE SERVER";
	public string ActionButtonColor => _server.IsServerRunning ? "#D32F2F" : "#0078D4";
	public ICommand SelectJarCommand { get; }

	public ICommand CreateServerCommand { get; }
}