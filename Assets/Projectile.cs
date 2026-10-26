using Unity.ProjectAuditor.Editor.Core;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField] private float speed = 10f;
   [SerializeField] private int damage = 1;
   [SerializeField] private float umur = 2f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.up * speed;
        Destroy(gameObject, umur);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
