using System;

namespace Devils
{
    // 예외 처리 클래스
    class DevilException : Exception
    {
        public readonly DevilErrorCode ErrorCode = DevilErrorCode.ErrorUnknown;

        public DevilException(DevilErrorCode errorCode, string format = "", params object[] param) 
            : base(string.Format(format, param))
        {
            ErrorCode = errorCode;
        }
    }
}