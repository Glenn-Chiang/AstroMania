using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : WeaponController
{
    [SerializeField] private List<Transform> firePoints;

    protected override void Fire()
    {
        foreach (var firePoint in firePoints)
        {
            Fire(firePoint);
        }
    }
}