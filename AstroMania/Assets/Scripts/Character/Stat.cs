using System;
using UnityEngine;

[Serializable]
public class Stat
{
    public float Value { get; private set; }

    public Stat(float value)
    {
        Value = value;
    }

    public void Upgrade()
    {

    }
}