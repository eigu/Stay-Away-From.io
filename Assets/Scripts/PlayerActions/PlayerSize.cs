using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    private Transform m_size => this.GetComponent<Transform>();

    [SerializeField] private float _sizeMultiplier;

    private void Start()
    {
        m_size.localScale = Vector3.one;
    }

    private void Update()
    {
        m_size.localScale *= _sizeMultiplier;
    }
}
