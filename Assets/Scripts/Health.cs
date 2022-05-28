using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool isDead;

    Enemy isEnemy;

    private void Awake()
    {
        isEnemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Missile damageDealer = other.GetComponent<Missile>();

        if (damageDealer)
        {
            TakeDamage(damageDealer.Damage);
            damageDealer.OnHit();
        }
        Instantiate(GameManager.Instance.flameFXPrefab, other.transform.position, Quaternion.identity);

        AudioController.Instance.PlayHitAudio();
    }

    void OnDeath()
    {
        isDead = true;

        if (isEnemy)
        {
            GameManager.Instance.AddScore(isEnemy.scoreValue);
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }

        AudioController.Instance.PlayDeathAudio();

    }
}