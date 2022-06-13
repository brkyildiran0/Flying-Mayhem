using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        print(this.name + "--- collided with ---" + other.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        print(this.name + "--- triggered with ---" + other.gameObject.name);
    }
}
