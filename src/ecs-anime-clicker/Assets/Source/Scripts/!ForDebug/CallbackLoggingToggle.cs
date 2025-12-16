using Agava.YandexGames;
using UnityEngine;

namespace Source.Scripts._ForDebug
{
  public class CallbackLoggingToggle : MonoBehaviour
  {
    public void EnableLogging(bool isEnable) =>
      YandexGamesSdk.CallbackLogging = isEnable;
  }
}