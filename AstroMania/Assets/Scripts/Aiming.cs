using UnityEngine;

public class Aiming : MonoBehaviour
{
    public void Aim(Vector3 aimPos)
    {
        var aimDir = (aimPos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}