using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UnoMemoryLeakExample.Shared.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UnoMemoryLeakExample.Shared
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
