using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObjectEvent _onObjectCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onObjectCollision.Invoke(collision.gameObject);

        _onObjectCollision.Invoke(transform.parent.gameObject);
    }
}
