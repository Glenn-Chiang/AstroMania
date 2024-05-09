using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected WeaponData weaponData;
    private bool canFire = true;

    [HideInInspector] public Stat damageBonus;
    [HideInInspector] public Stat fireRateBonus;

    public void HandleFire()
    {
        if (!canFire) return;
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
        projectile.damage = weaponData.Damage * damageBonus.Value;
    }

    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(weaponData.FireRate * fireRateBonus.Value);
        canFire = true;
    }
}