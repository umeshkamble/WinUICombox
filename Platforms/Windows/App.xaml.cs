using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIComboBox.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        public App()
        {
            this.InitializeComponent();
            
            PickerHandler.Mapper.AppendToMapping(nameof(Picker), (handler, view) =>
            {
                handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(1);
                SolidColorBrush brush = new SolidColorBrush(Colors.DarkGray);
                handler.PlatformView.BorderBrush = brush.ToBrush();

                handler.PlatformView.IsEditable = true;

                handler.PlatformView.Tapped += (sender, args) =>
                {
                    if (!handler.PlatformView.IsDropDownOpen)
                        handler.PlatformView.IsDropDownOpen = true;
                };

                handler.PlatformView.TextSubmitted += (sender, args) =>
                {
                    args.Handled = true;
                };
                handler.PlatformView.TextBoxStyle = App.Current.Resources["ComboBoxTextBoxStyle"] as Microsoft.UI.Xaml.Style;
            });
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

}
