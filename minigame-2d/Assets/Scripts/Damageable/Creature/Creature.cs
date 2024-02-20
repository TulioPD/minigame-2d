using UnityEngine;

public abstract class Creature : MonoBehaviour, IDamageable
{
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    [SerializeField] protected int resistance;
    [SerializeField] protected int damageTaken;    

    public string Name { get; protected set; }

    protected virtual void Start()
    {
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
    }

    protected virtual void Awake()
    {
    }

    public virtual void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }
    }
    

    public bool ShouldDie()=> health <= 0;
    

    public void Die(float lifetime)=>Destroy(gameObject, lifetime);
}
