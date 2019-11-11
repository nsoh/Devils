using System;

namespace Devils
{
    public enum DevilErrorCode : UInt32
    {
        Ok = 0,

        ErrorUnknown            = 10000000,
        ErrorTaskNotExists      = 10000001,
        
    }
}