using Avalonia.Controls;
using System.Linq;

namespace KiTab;

public partial class MainWindow : Window
{
	/*private ObservableCollection<string> _topicsIndexList;
	public ObservableCollection<string> TopicsIndexList
	{
		get => _topicsIndexList;
		set => this.RaiseAndSetIfChanged(ref _topicsIndexList, value);
	}*/

	public MainWindow()
	{
		//topicsIndexList = new ObservableCollection<string>(new string[] {"cat", "camel", "cow", "chameleon", "mouse", "lion", "zebra" });
		InitializeComponent();
	}
}
