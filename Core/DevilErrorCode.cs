using System;

namespace Devils
{
    // 에러 코드 정의
    public enum DevilErrorCode : UInt32
    {
        Ok = 0,

        ErrorUnknown            = 10000000,
        ErrorTaskNotExists      = 10000001,

    }
}