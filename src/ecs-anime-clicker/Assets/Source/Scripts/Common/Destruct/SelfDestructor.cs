using UnityEngine;

namespace Source.Scripts.Common.Destruct
{
  public class SelfDestructor : MonoBehaviour
  {
    public float Countdown = 3.0f;

    private void Update()
    {
      Countdown -= Time.deltaTime;
      if(Countdown <= 0)
        Destroy(gameObject);
    }
  }
}