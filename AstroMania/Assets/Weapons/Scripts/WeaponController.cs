using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected WeaponData weaponData;
    public WeaponManager WeaponManager { get; private set; }
    private float FireRate => weaponData.FireRate * WeaponManager.FireRateBonus.Value;
    private float CooldownTime => 1 / FireRate;

    private bool canFire = true;

    private void Start()
    {
        WeaponManager = GetComponentInParent<WeaponManager>();
    }

    public void HandleFire()
    {
        if (!canFire || FireRate == 0) return;
        Fire();
        StartCoroutine(CoolDown());
    }

    protected virtual void Fire()
    {
        Fire(firePoint);
    }

    protected virtual void Fire(Transform firePoint)
    {
        var projectile = Instantiate(weaponData.Projectile, firePoint.position, firePoint.rotation);
        
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(weaponData.FirePower * firePoint.right, ForceMode2D.Impulse);
        
        projectile.damage = weaponData.Damage * WeaponManager.DamageBonus.Value;
        projectile.effectAppliers = WeaponManager.effectAppliers;
    }

    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(CooldownTime);
        canFire = true;
    }
}