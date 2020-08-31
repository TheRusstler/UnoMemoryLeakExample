# Uno Memory Leak on iOS

## Steps to Reproduce

Run these steps while using the [Xamarin Profiler](https://docs.microsoft.com/en-us/xamarin/tools/profiler/?tabs=macos) to watch the memory footprint increase linearly as you continue to navigate between the pages.

1. Run the application on an iOS device from Visual Studio for Mac.
2. Click the button on the main page of the app to navigate to the secondary page.
3. Click the button on the secondary page to navigate to the main page.
4. Repeat steps 2 and 3 ad nauseum (around 20-30 times will increase memory usage to ~30MB).
5. Stop repeatedly navigating and do nothing for however long you would like.
6. Take snapshots every 30 seconds or so in the Xamarin Profiler tool and see that the memory footprint remains roughly the same forever.

## What's causing the issue?

It's the `TextBlock` binding to the view model in the `SecondaryPage.xaml` that causes the view and view model to never be garbage collected. You can see the binding code [here](https://github.com/rc65/UnoMemoryLeakExample/blob/3b499b41bba4a73d96adb182742830dd8b0bf1e0/UnoMemoryLeakExample/UnoMemoryLeakExample.Shared/SecondaryPage.xaml#L21-L24).

You can remove the binding and set it to something like

```xaml
<TextBlock
    HorizontalAlignment="Center"
    FontSize="50"
    Text="This is not bound to the view model." />
```

and then rerun the `Steps to Reproduce` listed above and you will see that the memory leak no longer occurs.
