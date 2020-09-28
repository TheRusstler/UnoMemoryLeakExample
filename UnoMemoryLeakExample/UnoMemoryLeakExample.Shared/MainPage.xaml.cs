using System;
using System.Runtime;
using UnoMemoryLeakExample.Shared;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnoMemoryLeakExample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondaryPage));
        }

        private void GarbageButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Forcing Garbage Collection");
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            GC.Collect(3, GCCollectionMode.Forced, true, true);
            GC.WaitForPendingFinalizers();

            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            GC.Collect(3, GCCollectionMode.Forced, true, true);
            GC.WaitForPendingFinalizers();
        }
    }
}
