using System.Collections;
using UnityEngine;

namespace HGS.CallLimiter.WeaponSample
{
  public class DestroyAfterTime : MonoBehaviour
  {
    [SerializeField] float time = 5;

    void Start()
    {
      StartCoroutine(DestroyObject(time));
    }

    IEnumerator DestroyObject(float delay)
    {
      yield return new WaitForSeconds(delay);
      Destroy(gameObject);
    }
  }
}
