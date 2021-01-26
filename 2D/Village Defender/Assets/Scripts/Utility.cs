using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static void ErrorIfNull(GameObject gameObject, UnityEngine.Object Object, string objectName)
    {
        if (Object == null)
        {
            Debug.LogError(objectName + " == null on " + gameObject.name);
        }
    }
}
