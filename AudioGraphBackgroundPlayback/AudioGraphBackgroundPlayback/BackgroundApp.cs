using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace AudioGraphBackgroundPlayback
{
    sealed partial class App : Application
    {
        /// <summary>
        /// Flag to indicate whether the app is currently in
        /// foreground or background mode.
        /// </summary>
        /// <remarks>
        /// This is used later to determine when to load / unload UI.
        /// </remarks>
        bool isInBackgroundMode;

        /// <summary>
        /// Called from App.xaml.cs when the application is constructed.
        /// </summary>
        partial void Construct()
        {
            // Subscribe to key lifecyle events to know when the app
            // transitions to and from foreground and background.
            // Leaving the background is an important transition
            // because the app may need to restore UI.
            EnteredBackground += App_EnteredBackground;
            LeavingBackground += App_LeavingBackground;

            // Subscribe to regular lifecycle events to display a toast notification
            Suspending += App_Suspending;
            Resuming += App_Resuming;
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void App_Suspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // Optional: Save application state and stop any background activity
            Debug.WriteLine("Suspending");
            deferral.Complete();
        }

        /// <summary>
        /// Invoked when application execution is resumed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_Resuming(object sender, object e)
        {
            Debug.WriteLine("Resuming");
        }
        
        /// <summary>
        /// The application entered the background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_EnteredBackground(object sender, EnteredBackgroundEventArgs e)
        {
            // Place the application into "background mode" and note the
            // transition with a flag.
            Debug.WriteLine("Entered background");
            isInBackgroundMode = true;

            // An application may wish to release views and view data
            // at this point since the UI is no longer visible.
            //
            // As a performance optimization, here we note instead that 
            // the app has entered background mode with a boolean and
            // defer unloading views until AppMemoryUsageLimitChanging or 
            // AppMemoryUsageIncreased is raised with an indication that
            // the application is under memory pressure.
        }

        /// <summary>
        /// The application is leaving the background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_LeavingBackground(object sender, LeavingBackgroundEventArgs e)
        {
            // Mark the transition out of background mode.
            Debug.WriteLine("Leaving background");
            isInBackgroundMode = false;

            // Reastore view content if it was previously unloaded.
            if (Window.Current.Content == null)
            {
                Debug.WriteLine("Loading view");
                CreateRootFrame(ApplicationExecutionState.Running, string.Empty);
            }
        }

    }
}
