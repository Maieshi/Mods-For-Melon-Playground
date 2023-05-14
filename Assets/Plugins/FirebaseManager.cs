using Firebase.Analytics;
using UnityEngine;

namespace Firebase
{
    public class FirebaseManager : MonoBehaviour
    {
        private FirebaseApp _firebaseApp;

        private void Awake()
        {
            CreateFireBase();
            ConfirmGooglePlayServices();
            DontDestroyOnLoad(this);
        }

        private void CreateFireBase()
        {
            _firebaseApp = FirebaseApp.Create();
        }

        private void SendFirebaseEvent()
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAppOpen);
        }

        private void ConfirmGooglePlayServices()

        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                    _firebaseApp = FirebaseApp.DefaultInstance;
                else
                    Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
                SendFirebaseEvent();
            });
        }
    }
}

