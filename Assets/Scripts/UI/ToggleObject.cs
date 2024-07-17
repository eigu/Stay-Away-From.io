using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public void ToggleObjectState(GameObject targetObject)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
