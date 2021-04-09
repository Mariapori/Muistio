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
            btnTallenna.Click += BtnTallenna_Click;
            btnExit.Click += BtnExit_Click;
            title.PointerPressed += Title_PointerPressed;
        }

        private async void BtnTallenna_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filters.Add(new FileDialogFilter() { Name = "Txt", Extensions = { "txt" } });
            saveFile.Filters.Add(new FileDialogFilter() { Name = "*", Extensions = { "*" } });
            var dialogresult = await saveFile.ShowAsync(this);
            await System.IO.File.WriteAllTextAsync(dialogresult, txtTeksti.Text);
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
