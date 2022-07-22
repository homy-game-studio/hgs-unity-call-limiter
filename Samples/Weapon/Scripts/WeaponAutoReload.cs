using HGS.CallLimiter;
using UnityEngine;

namespace HGS.CallLimiter.WeaponSample
{
  public class WeaponAutoReload : MonoBehaviour
  {
    [SerializeField] WeaponAmmo ammo;
    [SerializeField] float debounceInterval = 3;
    [SerializeField] Transform textSpawnPoint;
    [SerializeField] GameObject textPrefab;

    Debounce _debounce = new Debounce();

    void DirectReload()
    {
      ammo.Reload();
      Instantiate(textPrefab, textSpawnPoint.position, textSpawnPoint.rotation);
    }

    public void Reload()
    {
      _debounce.Run(DirectReload, debounceInterval, this);
    }

    void Update()
    {
      if (Input.GetMouseButton(0)) Reload();
    }
  }
}