using LedCSharp;

namespace LogitechLEDController
{
    public class LogitechLEDSDKWrapper
    {
        public LogitechLEDSDKWrapper()
        {
            LogitechGSDK.LogiLedInit();
        }

        public void SetKeyLighting(int keyCode, int red, int green, int blue)
        {
            if (!LogitechGSDK.LogiLedSetLightingForKeyWithScanCode(keyCode, red, green, blue))
                throw new LogitechGSDKException("LogiLedSetLightingForKeyWithScanCode returned an Error Code.");
        }

        public void SetGlobalLighting(int red, int green, int blue)
        {
            LogitechGSDK.LogiLedSetLighting(red, green, blue);
        }
    }
}