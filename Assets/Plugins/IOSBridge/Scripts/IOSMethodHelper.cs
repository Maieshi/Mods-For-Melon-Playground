#if UNITY_IOS
using System.Runtime.InteropServices;

namespace IOSBridge
{
    public class IOSMethodHelper
    {

        [DllImport("__Internal")]
        private static extern void _createActionSheet(string objectName, string methodName, string[] callCount,
            int count);

        [DllImport("__Internal")]
        private static extern void _shareUrl(string url);

        /// <summary>
        /// This method will help you share Link (maybe app link) with others
        /// </summary>
        /// <param name="url">Link you want to share</param>
        public static void ShareUrl(string url)
        {
#if !UNITY_EDITOR && UNITY_IOS
            _shareUrl(url);
#endif
        }

        /// <summary>
        /// This method create iOS action list and tell CallBacks method to Unity
        /// </summary>
        /// <param name="objectName">GameObject name with CallBackMethod (don't call inactive GM)</param>
        /// <param name="methodName">Name CallBack method (can be privat)</param>
        /// <param name="callCount">An array of names with which buttons will be created, and these one of the names will be sent to the method</param>
        public static void CreateActionSheet(string objectName, string methodName, string[] callCount)
        {

#if !UNITY_EDITOR && UNITY_IOS
            _createActionSheet(objectName, methodName, callCount, callCount.Length);
#endif
        }

    }
}
#endif