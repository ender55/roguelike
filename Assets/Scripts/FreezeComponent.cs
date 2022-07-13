using System;
using UnityEngine;

[Serializable]
public struct FreezeComponent
{
    [Range(0, 90f)] public float slownessPower;
    public float slownessTime;
}