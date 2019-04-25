using ReactNative.Bridge;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace App.Center.RNAppCenter
{
    /// <summary>
    /// A module that allows JS to share data.
    /// </summary>
    class RNAppCenterModule : NativeModuleBase
    {
        /// <summary>
        /// Instantiates the <see cref="RNAppCenterModule"/>.
        /// </summary>
        internal RNAppCenterModule()
        {

        }

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
        public void  start(String appId)
        {
            AppCenter.Start(appId, typeof(Microsoft.AppCenter.Analytics.Analytics));
        }

        [ReactMethod]
        public void track(string eventName)
        {
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(eventName);
        }
    }
}
