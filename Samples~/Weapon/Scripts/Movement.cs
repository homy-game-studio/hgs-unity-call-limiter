using UnityEngine;

namespace HGS.CallLimiter.WeaponSample
{
  public class Movement : MonoBehaviour
  {
    [SerializeField] Vector3 speed = Vector3.forward;

    void Update()
    {
      transform.Translate(speed * Time.deltaTime);
    }
  }
}