using UnityEditor;
using UnityEngine;

public class PlayerSkins : MonoBehaviour
{
    [SerializeField] private GameObject _playerSkin;
    [SerializeField] private int _skinIndex;

    [SerializeField] private Sprite[] _skins;
    private SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("skinIndex"))
        {
            _skinIndex = 0;
        }
        else
        {
            LoadSkin();
        }

        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (_skinIndex > _skins.Length - 1) _skinIndex = 0;
        else if (_skinIndex < 0) _skinIndex = _skins.Length - 1;
    }

    private void LateUpdate()
    {
        m_spriteRenderer.sprite = _skins[_skinIndex];
    }
    
    public void ChooseNextSkin()
    {
        _skinIndex++;
        SaveSkin();
    }

    public void ChoosePreviousSkin()
    {
        _skinIndex--;
        SaveSkin();
    }

    private void LoadSkin()
    {
        _skinIndex = PlayerPrefs.GetInt("skinIndex");
    }

    private void SaveSkin()
    {
        PlayerPrefs.SetInt("skinIndex", _skinIndex);
    }

    //public void SelectSkin()
    //{
    //    PrefabUtility.SaveAsPrefabAsset(_playerSkin, "Assets/Resources/Prefabs/PlayerSkin.prefab");
    //}
}