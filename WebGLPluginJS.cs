using System.Runtime.InteropServices;
/// <summary>
/// Class with a JS Plugin functions for WebGL.
/// </summary>
public static class WebGLPluginJS
{
   // Importing "CallFunction"
   [DllImport("__Internal")]
   public static extern void CallFunction(string roomname);
   [DllImport("__Internal")]
   public static extern void MicrophoneMute(string text);
      [DllImport("__Internal")]
   public static extern void MicrophoneUnMute(string text);
   // Importing "PassNumberParam"
   [DllImport("__Internal")]
   public static extern void PassNumberParam(int number);
   // Importing "GetTextValue"
   [DllImport("__Internal")]
   public static extern string GetTextValue();
   // Importing "GetNumberValue"
   [DllImport("__Internal")]
   public static extern int GetNumberValue();
}
