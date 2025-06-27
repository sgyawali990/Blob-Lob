using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5;
    public Transform respawnPoint;
    public float spawnShieldDuration = 3f;
    public float deathDelay = 2f;
    public LivesUI livesUI;

    private int currentLives;
    private SpriteRenderer sr;
    private Collider2D col;
    private Rigidbody2D rb;
    private PlayerMovement movement;
    private PlayerShooting shooting;

    private bool isInvincible = false;
    private bool isDead = false;
    private bool justRespawned = false;
    private float originalGravity;

    void Start()
    {
        currentLives = maxLives;
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        shooting = GetComponent<PlayerShooting>();
        originalGravity = rb.gravityScale;
    }

    public void TakeDamage()
    {
        if (isInvincible || isDead) return;

        currentLives--;
        isDead = true;

        if (livesUI != null)
            livesUI.UpdateLives();

        // Play death SFX
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.deathSE);
        }

        StartCoroutine(DeathSequence());
    }

    public void ForceTakeDamage()
    {
        StopAllCoroutines();
        isInvincible = false;
        TakeDamage();
    }

    IEnumerator DeathSequence()
    {
        if (movement != null) movement.enabled = false;
        if (shooting != null) shooting.enabled = false;
        if (col != null) col.enabled = false;

        float direction = transform.localScale.x > 0 ? -1f : 1f;
        transform.rotation = Quaternion.Euler(0, 0, direction * 90f);

        yield return new WaitForSeconds(deathDelay);

        if (currentLives <= 0)
        {
            Debug.Log(gameObject.name + " is out of lives!");
            gameObject.SetActive(false);
            yield break;
        }

        StartCoroutine(RespawnPause());
    }

    IEnumerator RespawnPause()
    {
        transform.position = respawnPoint.position;
        transform.rotation = Quaternion.identity;

        rb.linearVelocity = Vector2.zero;
        float prevGravity = rb.gravityScale;
        rb.gravityScale = 0;

        if (col != null) col.enabled = false;
        if (movement != null) movement.enabled = false;
        if (shooting != null) shooting.enabled = false;

        yield return new WaitForSeconds(0.5f);

        rb.gravityScale = prevGravity;
        if (col != null) col.enabled = true;
        if (movement != null) movement.enabled = true;
        if (shooting != null) shooting.enabled = true;

        // Play respawn SFX
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.respawnSE);
        }

        StartCoroutine(SpawnShield());
        isDead = false;
    }

    IEnumerator SpawnShield()
    {
        isInvincible = true;

        Color originalColor = sr.color;
        float elapsed = 0f;
        bool toggle = false;

        while (elapsed < spawnShieldDuration)
        {
            Color blinkColor = originalColor;
            blinkColor.a = toggle ? 0.3f : 1f;
            sr.color = blinkColor;

            toggle = !toggle;
            yield return new WaitForSeconds(0.2f);
            elapsed += 0.2f;
        }

        sr.color = originalColor;
        isInvincible = false;
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }

    public bool JustRespawned()
    {
        return justRespawned;
    }
}