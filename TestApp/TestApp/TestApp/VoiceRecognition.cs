using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.SpeechRecognition;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class VoiceRecognition
    {
        public VoiceRecognition()
        {
            InitRecognitionAsync();
        }

        async System.Threading.Tasks.Task InitRecognitionAsync()
        {
            var granted = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Microphone);
            PermissionStatus micStatus = PermissionStatus.Unknown;
            if (granted.ContainsKey(Permission.Microphone))
            {
                micStatus = granted[Permission.Microphone];
            }
            try
            {
                if (micStatus == PermissionStatus.Granted)
                {
                    var Listener = CrossSpeechRecognition.Current
                    .ListenForFirstKeyword("Exit", "Hello", "Hi", "My Books")
                    .Subscribe(async firstKeywordHeard => { await App.Current.MainPage.DisplayAlert("Exception", firstKeywordHeard, "OK"); });
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Exception", e.Message, "OK");
            }
        }
    }
}
