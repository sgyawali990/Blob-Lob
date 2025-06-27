using UnityEngine;

public class BottomKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.ForceTakeDamage();
        }
    }
}
