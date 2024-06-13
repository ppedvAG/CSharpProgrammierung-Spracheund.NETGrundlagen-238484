using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace M014;

/// <summary>
/// Zweigeteilte GUI Programmierung:
/// - MainWindow.xaml: GUI
/// - MainWindow.xaml.cs: Backendcode von der GUI
/// - Im Solution Explorer ausklappen um auf den Backend Code zuzugreifen
/// 
/// Hilfreiche Fenster:
/// - Toolbox: View -> Toolbox
/// - Properties: View -> Properties
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
	private int zaehler;

	public MainWindow()
	{
		InitializeComponent();
		//CB.ItemsSource = new int[] { 1, 2, 3 };
		CB.ItemsSource = Enum.GetValues<DayOfWeek>();
		LB.ItemsSource = Enumerable.Range(0, 10);
	}

	/// <summary>
	/// Events:
	/// Zweigeteilte Programmierung
	/// - Entwicklerseite
	/// -- Legt fest, welche Bedingungen gegeben sein müssen um das Event zu feuern, und feuert das Event
	/// - Anwenderseite
	/// -- Legt fest, was passiert, wenn das Event gefeuert wird
	/// 
	/// Beispiel Button:
	/// - Entwicklerseite: Wenn die Maus im Button ist, wenn der User einen linksklick macht, wenn kein anderes Element über dem Button ist, ...
	/// - Anwenderseite: Die Methode unterhalb (Button_Click)
	/// 
	/// Zwei Aufgaben:
	/// - Zähler erhöhen
	/// - Zähler anzeigen
	/// </summary>
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		zaehler++;
		TB.Text = $"Zähler: {zaehler}";
	}

	/// <summary>
	/// Aufgabenstellung: Ausgewähltes Element in dem TextBlock anzeigen
	/// </summary>
	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = CB.SelectedItem.ToString();
	}

	/// <summary>
	/// Aufgabenstellung: Ausgewählte Elemente in dem TextBlock anzeigen
	/// </summary>
	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = string.Join(", ", LB.SelectedItems.OfType<int>());
	}

	/// <summary>
	/// Aufgabenstellung: Input von User im TextBlock anzeigen
	/// </summary>
	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		TB.Text = Eingabe.Text;
	}

	/// <summary>
	/// Aufgabenstellung: Wenn dieser Button geklickt wird, soll die ProgressBar erhöht werden
	/// </summary>
	private void Button_Click_2(object sender, RoutedEventArgs e)
	{
		PB.Value++;
	}

	/// <summary>
	/// Aufgabenstellung: Value vom Slider im Output anzeigen
	/// </summary>
	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		TB.Text = S.Value.ToString();
	}

	/// <summary>
	/// Aufgabenstellung: User fragen ob dieser das Programm beenden möchte, wenn das Beenden Menüitem gedrückt wird
	/// </summary>
	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult result = MessageBox.Show("Wirklich beenden?", "Beenden", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (result == MessageBoxResult.Yes)
		{
			this.Close();
		}
	}

	/// <summary>
	/// WICHTIG: using Microsoft.Win32;
	/// </summary>
	private void MenuItem_Click_1(object sender, RoutedEventArgs e)
	{
		OpenFileDialog ofd = new();
		ofd.Multiselect = true;
		ofd.ShowDialog();
		TB.Text = ofd.FileName; //Voller Pfad von dem ausgewählten File
    }

	/// <summary>
	/// WICHTIG: using Microsoft.Win32;
	/// </summary>
	private void MenuItem_Click_2(object sender, RoutedEventArgs e)
	{
		SaveFileDialog sfd = new();
		sfd.ShowDialog();
    }

	//Aufgabenstellung: Texteingabe Speichern und bei Neustart des Programms laden
	private string input;

	public string Input
	{
		get => input;
		set
		{
			input = value;
			File.WriteAllText("Speicher.txt", Input);
			Notify(nameof(Input));
		}
	}

	private void Window_Initialized(object sender, EventArgs e)
	{
		if (File.Exists("Speicher.txt"))
			Input = File.ReadAllText("Speicher.txt");
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}