using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Muistio
{
    public class MainWindow : Window
    {
        Button btnExit = new Button();
        TextBlock title = new TextBlock();
        Button btnTallenna = new Button();
        Button btnAvaa = new Button();
        TextBox txtTeksti = new TextBox();
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            btnExit = this.FindControl<Button>("btnExit");
            title = this.FindControl<TextBlock>("title");
            txtTeksti = this.FindControl<TextBox>("txtTeksti");
            btnTallenna = this.FindControl<Button>("btnTallenna");
            btnAvaa = this.FindControl<Button>("btnAvaa");
            btnAvaa.Click += BtnAvaa_Click;
            btnTallenna.Click += BtnTallenna_Click;
            btnExit.Click += BtnExit_Click;
            title.PointerPressed += Title_PointerPressed;
        }

        private async void BtnAvaa_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.AllowMultiple = false;
            openFile.Filters.Add(new FileDialogFilter() { Name = "Txt", Extensions = { "txt" } });
            openFile.Filters.Add(new FileDialogFilter() { Name = "*", Extensions = { "*" } });
            var valittu = await openFile.ShowAsync(this);
            if(valittu != null)
            {
                txtTeksti.Text = await System.IO.File.ReadAllTextAsync(valittu[0]);
            }
        }

        private async void BtnTallenna_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filters.Add(new FileDialogFilter() { Name = "Txt", Extensions = { "txt" } });
            saveFile.Filters.Add(new FileDialogFilter() { Name = "*", Extensions = { "*" } });
            var dialogresult = await saveFile.ShowAsync(this);
            if(dialogresult != null)
            {
                await System.IO.File.WriteAllTextAsync(dialogresult, txtTeksti.Text);
            }
        }

        private void Title_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }

        private void BtnExit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
