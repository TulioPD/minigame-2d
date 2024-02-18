
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected ProjectileData projectileData;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Enemy enemy;

    public void Initialize(Vector2 direction)
    {
        movementDirection = direction.normalized;
    }
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SetVelocityX(projectileData.movementVelocity);
    }

    private void Update()
    {
        rb.MovePosition(rb.position + movementDirection * projectileData.movementVelocity * Time.deltaTime);
        
        projectileData.lifeTime -= Time.deltaTime;
        if (projectileData.lifeTime <= 0)
        {
            //Destroy(gameObject);
        }
    }

    private void SetVelocityX(float velocity)
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(projectileData.basicDamage);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}

