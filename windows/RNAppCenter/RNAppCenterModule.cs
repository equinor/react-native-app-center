using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json.Linq;
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
          Debug.WriteLine(e.Message);
        }
      });
    }

    [ReactMethod]
    public void TrackEvent(string eventName, JObject extraData)
    {
      try
      {
        IDictionary<string, string> dictObj = new Dictionary<string, string>();
        foreach (var item in extraData)
        {
          dictObj.Add(item.Key, item.Value?.ToString());
        }
        Analytics.TrackEvent(eventName, dictObj);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }

    }

    [ReactMethod]
    public void Track(string eventName)
    {
      try
      {
        Analytics.TrackEvent(eventName);

      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
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
