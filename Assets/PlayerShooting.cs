using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public KeyCode shootKey = KeyCode.Space;
    public float bulletSpeed = 20f;
    public float cooldown = 0.5f;

    private float lastShotTime = -999f;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement != null && playerMovement.IsJumpingOrDropping())
            return;

        if (Input.GetKeyDown(shootKey) && Time.time - lastShotTime >= cooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void Shoot()
    {
        Vector2 shootDir = playerMovement.facingDirection;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().owner = gameObject;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = shootDir.normalized * bulletSpeed;

        // Play gunshot SFX
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.gunshotSE);
        }
    }
}