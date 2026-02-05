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

	public MainViewModel()
	{
		SelectJarCommand = new RelayCommand(_ => SelectJarFile());
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
	
	public bool LocalStatus (bool boolStatus)
	{
		if (_server.Local != boolStatus) _server.Local = boolStatus;
		return boolStatus;
	}

	public int ServerPort
	{
		get => _server.Port;
		set
		{
			if (_server.Port != value)
			{
				_server.Port = value;
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

