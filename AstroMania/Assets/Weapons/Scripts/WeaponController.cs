using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private Transform firePoint;

    public void Fire()
    {
        var projectile = Instantiate(weaponData.ProjectilePrefab, firePoint.position, firePoint.rotation);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(weaponData.FirePower * firePoint.right, ForceMode2D.Impulse);
    }
}