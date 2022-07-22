using HGS.CallLimiter;
using UnityEngine;

namespace HGS.CallLimiter.WeaponSample
{
  public class WeaponFire : MonoBehaviour
  {
    [SerializeField] WeaponAmmo ammo;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject textPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Transform textSpawnPoint;
    [SerializeField] float ratio = 0.5f;

    Throttle _fireThrottle = new Throttle();

    void DirectFire()
    {
      if (ammo.IsExausted) return;

      ammo.Remove(1);
      Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
      Instantiate(textPrefab, textSpawnPoint.position, textSpawnPoint.rotation);
    }

    public void Fire()
    {
      _fireThrottle.Run(DirectFire, ratio);
    }

    void Update()
    {
      if (Input.GetMouseButton(0)) Fire();
    }
  }
}