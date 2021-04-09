using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Muistio
{
    public class MainWindow : Window
    {
        Button btnExit;
        TextBlock title;
        Button btnTallenna;
        TextBox txtTeksti;
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

        private void BtnTallenna_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
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
