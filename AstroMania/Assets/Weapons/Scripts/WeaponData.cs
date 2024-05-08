using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class WeaponData : EntityData
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public float FirePower { get; private set; }
    [field: SerializeField] public float EnergyCost { get; private set; }
    [field: SerializeField] public WeaponController Controller { get; private set; }
    [field: SerializeField] public ProjectileController Projectile { get; private set; }

}
