using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public float FirePower { get; private set; }
    [field: SerializeField] public float AmmoCost { get; private set; }
    [field: SerializeField] public WeaponController Controller { get; private set; }
    [field: SerializeField] public GameObject Projectile { get; private set; }

}
