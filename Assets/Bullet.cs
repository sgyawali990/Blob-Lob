using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    public GameObject owner;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == owner) return;

        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
            return;
        }

        PlayerHealth targetHealth = other.GetComponent<PlayerHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage();
            Destroy(gameObject);
        }
    }
}
