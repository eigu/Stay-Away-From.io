using UnityEngine;

public interface ICollidable
{
    void Collide(GameObject obj);
}

public class ObjectCollision : MonoBehaviour
{
    public void CollisionTrigger(GameObject obj)
    {
        ICollidable collidableObject = obj.GetComponent<ICollidable>();

        collidableObject.Collide(obj);
    }
}