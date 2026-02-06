using System.Windows.Input;
using Minecraft_Server_Maker.Models;
using System.Windows.Input;
using Microsoft.Win32;

namespace Minecraft_Server_Maker.ViewModels;

public class MainViewModel : ViewModelBase
{

	private bool isInt;
	private MinecraftServer _server = new();
	
	public string JarPathDisplay => string.IsNullOrEmpty(_server.JarPath) ? "Not chosen file" : System.IO.Path.GetFileName(_server.JarPath);
	
	public ICommand SelectJarCommand { get; }
	
	public ICommand CreateServerCommand { get; }
	
	public MainViewModel()
	{
		SelectJarCommand = new RelayCommand(_ => SelectJarFile());
		
		CreateServerCommand = new RelayCommand(_ => _server.CreateAndRun());

	}

	private void SelectJarFile()
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
		get => _server.Premium;

		set
		{
			if (_server.Premium != value)
			{
				_server.Premium = value;
				OnPropertyChanged();
			}
		}
	}

	
	public bool IsWhiteListed
	{
		get => _server.WhiteListed;

		set
		{
			if (_server.WhiteListed != value)
			{
				_server.WhiteListed = value;
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
		get => _server.Port;
		set
		{
			if (_server.Port != value)
			{
				_server.Port = value;
				OnPropertyChanged();
			}
		}
		
	}

	public string ServerName
	{
		get => _server.Name;
		set
		{
			if (_server.Name != value)
			{
				_server.Name = value;
				OnPropertyChanged();
			}
		}
	}
}

