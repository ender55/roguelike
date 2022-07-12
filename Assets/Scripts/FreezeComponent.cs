using System;
using UnityEngine;

[Serializable]
public struct FreezeComponent
{
    [Range(0, 99.9f)] public float slownessPower;
    public float slownessTime;
}