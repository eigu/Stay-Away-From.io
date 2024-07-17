using UnityEngine;

public class PlayerSkinImporter : MonoBehaviour
{
    [SerializeField] private GameObject _selectedSkin;

    private void Start()
    {
        transform.GetComponent<SpriteRenderer>().sprite = _selectedSkin.GetComponent<SpriteRenderer>().sprite;
    }
}
