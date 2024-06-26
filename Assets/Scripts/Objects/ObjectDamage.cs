using UnityEngine;

public class ObjectDamage : MonoBehaviour, ICollidable
{
    public void Collide(GameObject obj) => Damage(obj);

    private void Damage(GameObject obj)
    {
        ObjectStats objectStats = obj.GetComponent<ObjectStats>();

        objectStats.CurrentHealth -= objectStats.CurrentDamage;
    }
}
