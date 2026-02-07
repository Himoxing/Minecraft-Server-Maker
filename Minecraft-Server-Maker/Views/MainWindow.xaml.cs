using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Minecraft_Server_Maker.ViewModels;

namespace Minecraft_Server_Maker.Views;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		this.DataContext = new MainViewModel();
	}

	protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
	{
		if (DataContext is MainViewModel vm)
		{
			vm.OnWindowClosing();
		}
		base.OnClosing(e);
	}
	
}