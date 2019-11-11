using System;

namespace Devils
{
    class DevilException : Exception
    {
        public readonly DevilErrorCode ErrorCode = DevilErrorCode.ErrorUnknown;

        public DevilException(DevilErrorCode errorCode, string _strFormat = "", params object[] _arrObj) 
            : base(string.Format(_strFormat, _arrObj))
        {
            ErrorCode = errorCode;
        }
    }
}