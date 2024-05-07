using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponData weaponData;
    private bool canFire = true;

    public void HandleFire()
    {
        if (!canFire) return;
        Fire();
        StartCoroutine(CoolDown());
    }

    private void Fire()
    {
        var projectile = Instantiate(weaponData.ProjectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(weaponData.FirePower * firePoint.right, ForceMode2D.Impulse);
    }

    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(weaponData.FireRate);
        canFire = true;
    }
}