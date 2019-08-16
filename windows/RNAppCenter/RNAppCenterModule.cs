using System;
using System.Collections.Generic;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using ReactNative.Bridge;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
namespace App.Center.RNAppCenter
{
  /// <summary>
  /// A module that allows JS to share data.
  /// </summary>
  class RNAppCenterModule : ReactContextNativeModuleBase
  {
    /// <summary>
    /// Instantiates the <see cref="RNAppCenterModule"/>.
    /// </summary>
    public RNAppCenterModule(ReactContext reactContext) : base(reactContext) { }

    /// <summary>
    /// The name of the native module.
    /// </summary>
    public override string Name
    {
      get
      {
        return "RNAppCenter";
      }
    }

    [ReactMethod]
    public void start(string appId)
    {
      RunOnDispatcher(async () =>
      {
        try
        {
          bool isEnabled = await AppCenter.IsEnabledAsync();
          bool isConfigured = AppCenter.Configured;
          if (isConfigured == false)
          {
            AppCenter.Configure(appId);
            AppCenter.Start(typeof(Analytics));
          }
          else
          {
            if (isEnabled == false)
            {
              await AppCenter.SetEnabledAsync(true);
            }
          }
        }
        catch (Exception e)
        {
          var ex = e;
        }
      });
    }

    [ReactMethod]
    public void trackEvent(string eventName, IDictionary<string, string> properties)
    {
      Analytics.TrackEvent(eventName, properties);
    }

    [ReactMethod]
    public void track(string eventName)
    {
      Analytics.TrackEvent(eventName);
    }

    /// <summary>
    /// Run action on UI thread.
    /// </summary>
    /// <param name="action">The action.</param>
    private static async void RunOnDispatcher(DispatchedHandler action)
    {
      await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, action).AsTask().ConfigureAwait(false);
    }
  }
}
