using HGS.CallLimiter;
using TMPro;
using UnityEngine;

namespace HGS.CallLimiter.WeaponSample
{
  public class WeaponAmmoIndicator : MonoBehaviour
  {
    [SerializeField] TextMeshPro textMesh;
    [SerializeField] WeaponAmmo ammo;
    [SerializeField] float updateRatio = 0.5f;

    Throttle _updateThrottle = new Throttle();

    void UpdateText()
    {
      _updateThrottle.Run(() =>
      {
        textMesh.text = $"Ammo: {ammo.Amount}/{ammo.Capacity}";
      }, updateRatio);
    }

    void Update()
    {
      UpdateText();
    }
  }
}