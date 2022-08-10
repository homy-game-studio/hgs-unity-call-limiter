
using UnityEngine;

namespace HGS.CallLimiter.WeaponSample
{
  public class WeaponAmmo : MonoBehaviour
  {
    [SerializeField] int capacity = 10;
    [SerializeField] int amount = 10;

    public bool IsExausted => amount == 0;
    public int Capacity => capacity;
    public int Amount => amount;

    void Awake()
    {
      Reload();
    }

    public void Reload()
    {
      amount = capacity;
    }

    public void Remove(int value = 1)
    {
      amount -= value;
      amount = Mathf.Max(amount, 0);
    }
  }
}