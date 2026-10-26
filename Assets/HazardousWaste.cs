using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HazardousWaste : WasteItem
{
    [SerializeField] private int damageKePemain = 1;
    [SerializeField] private int pengaliXP = 2;
    private Health health;

    protected override void Start()
    {
        base.Start();
        health = GetComponent<Health>();
        health.Died += SaatDinetralkan;
        health.Died += BeriXP;
    }

    protected override void OnTouchPlayer(GameObject player)
    {
        if (player.TryGetComponent(out Health hpPemain))
        {
            hpPemain.TakeDamage(damageKePemain);
        }
        Remove();
    }

    protected override int HitungXP()
    {
        return base.HitungXP() * pengaliXP;
    }

    public override void TerapkanLevel(int level)
    {
        base.TerapkanLevel(level);
        if (level >= 4) damageKePemain = 2;
    }

    protected override void Collect()
    {
        info = "BERBAHAYA: serahkan ke pengelola B3 (+"
                + pointValue + " poin)";
        base.Collect();
    }

    private void SaatDinetralkan()
    {
        if (scoreKeeper == null) return;
        scoreKeeper.AddPoints(pointValue,
            "Limbah B3 Dinetralkan! (+" + pointValue + "poin)");
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (health != null)
        {
            health.Died -= SaatDinetralkan;
            health.Died -= BeriXP;
        }
    }
}
