using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebuggingStatus
{
    public static bool isDebugging{
        get {return true;}
        set {}
    }

    public static bool isDebuggingDamage{
        get {return (isDebugging && true); }
    }
}
