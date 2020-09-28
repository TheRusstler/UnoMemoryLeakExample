using UnoMemoryLeakExample.Shared.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnoMemoryLeakExample.Shared
{
    public sealed partial class SecondaryPage : Page
    {
        private SecondaryPageViewModel VM { get; set; }

        public SecondaryPage()
        {
            this.InitializeComponent();
            this.VM = new SecondaryPageViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
