using System;

namespace LogitechLEDController
{
    public class LogitechGSDKException : Exception
    {
        public LogitechGSDKException(string msg) : base(msg)
        {
        }
    }
}
