#if UNITY_IOS
using System.Runtime.InteropServices;

namespace IOSBridge
{
    public static class IOStoUnityBridge
    {
        [DllImport("__Internal")]
        private static extern void _showAlert(string title, string message);

        [DllImport("__Internal")]
        private static extern void _initWithActivity(string pathToMode);

        [DllImport("__Internal")]
        private static extern void _saveImageToAlbum(string pathToImage);

        [DllImport("__Internal")]
        private static extern void _copyText(string textToCopy);

        [DllImport("__Internal")]
        private static extern void _showActionSheet(string objectName, string methodName);

        [DllImport("__Internal")]
        private static extern void _setNewFileName(string objectName, string methodName, string fileName);

        [DllImport("__Internal")]
        private static extern void _showAlertWithCallBack(string title, string message, string objectName, string action);

        /// <summary>
        /// Share file
        /// </summary>
        /// <param name="pathToMode">Path to the file</param>
        public static void InitWithActivity(string pathToMode)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _initWithActivity(pathToMode);
#endif
        }

        /// <summary>
        /// Show the alert with custom text
        /// </summary>
        /// <param name="title">The text to be displayed in the header</param>
        /// <param name="message">The text to be displayed in the description</param>
        public static void ShowAlert(string title, string message)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _showAlert(title, message);
#endif
        }

        /// <summary>
        /// Saves the image to the gallery
        /// </summary>
        /// <param name="pathToImage">Path to the picture on the device</param>
        public static void SaveImageToAlbum(string pathToImage)
        {

#if !UNITY_EDITOR && UNITY_IOS
                // Debug.Log("saved");
            _saveImageToAlbum(pathToImage);
#endif
        }

        //Don't ask me what do it do this method:)
        public static void ShowActionSheet(string objectName, string methodName)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _showActionSheet(objectName, methodName);
#endif
        }

        /// <summary>
        /// Activate input field
        /// </summary>
        /// <param name="objectName">The name of the GameObject on the Scene in which the method will be called</param>
        /// <param name="methodName">Method name CallBack. CallBack receive empty string when we click to "Cancel" button and receive input string when click to "Ok" button</param>
        /// <param name="fileName">Start file name</param>
        public static void SetNewFileName(string objectName, string methodName, string fileName)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _setNewFileName(objectName, methodName, fileName);
#endif
        }

        /// <summary>
        /// Show the alert with custom text and with awake CallBack method
        /// </summary>
        /// <param name="title">The text to be displayed in the header</param>
        /// <param name="message">The text to be displayed in the description</param>
        /// <param name="objectName">The GameObject's name which contain the call method </param>
        /// <param name="action">The method's CallBack name</param>
        public static void ShowAlertWithCallBack(string title, string message, string objectName, string action)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _showAlertWithCallBack(title, message, objectName, action);
#endif
        }

        /// <summary>
        /// Copy text to the clipboard
        /// </summary>
        /// <param name="textToCopy">The text which will be copied to the clipboard</param>
        public static void CopyText(string textToCopy)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _copyText(textToCopy);
#endif
        }
    }
}
#endif