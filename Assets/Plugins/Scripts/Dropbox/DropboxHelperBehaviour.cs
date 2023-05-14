using UnityEngine;

namespace Plugins.Scripts.Dropbox
{
    public class DropboxHelperBehaviour : MonoBehaviour
    {
#if UNITY_EDITOR

        // You can place DropboxHelperBehaviour on any scene and call those methods by RMB on a components. For easier method use

        [ContextMenu("GetAuthCode")]
        public void GetAuthCode()
        {
            DropboxHelper.GetAuthCode();
        }

        [ContextMenu("GetRefreshToken")]
        public void GetRefreshToken()
        {
            DropboxHelper.GetRefreshToken();
        }
#endif
    }
}