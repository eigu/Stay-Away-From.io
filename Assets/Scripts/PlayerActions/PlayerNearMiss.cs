using UnityEngine;
using UnityEngine.Events;

public class PlayerNearMiss : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPlayerNearMiss;

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onPlayerNearMiss.Invoke();
    }
}
