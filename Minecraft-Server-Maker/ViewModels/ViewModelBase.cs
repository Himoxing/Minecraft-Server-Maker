using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Minecraft_Server_Maker.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}