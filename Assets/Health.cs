using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int maxHP = 3;
    [SerializeField] private float invincibilityTime = 0.5f;
    [SerializeField] private Color warnaKena = Color.white;

    public int CurrentHP { get; private set; }
    public bool IsDead => CurrentHP <= 0;
    public event Action Died;

    private float invincibilityTimer;
    private SpriteRenderer sr;
    private Color warnaAsli;

    void Awake()
    {
        CurrentHP = maxHP;
        sr = GetComponent<SpriteRenderer>();
        if (sr != null) warnaAsli = sr.color;
    }

    void Update()
    {
        if (invincibilityTimer <= 0f) return;
        invincibilityTimer -= Time.deltaTime;
        if (invincibilityTimer <= 0f && sr != null)
            sr.color = warnaAsli;
    }

    public void TakeDamage(int jumlah)
    {
        if (IsDead || invincibilityTimer > 0f) return;
        CurrentHP = Mathf.Max(CurrentHP - jumlah, 0);
        invincibilityTimer = invincibilityTime;
        if (sr != null) sr.color = warnaKena;
        Debug.Log(name + " kena " + jumlah
            + " damage, sisa HP " + CurrentHP);
        if (IsDead) Die(); 
    }

    public void Heal(int jumlah)
    {
        if(IsDead || jumlah <= 0) return;
        CurrentHP = Mathf.Min(CurrentHP + jumlah, maxHP);
        Debug.Log(name + " dipulihkan, HP Sekarang "
            + CurrentHP);
    }

    private void Die()
    {
        Died?.Invoke();
        GameEntity entity = GetComponent<GameEntity>();
        if (entity != null) entity.Remove();
        else Destroy(gameObject);
    }
}