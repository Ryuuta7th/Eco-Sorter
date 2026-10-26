using UnityEngine;

public class FireRateReward : LevelReward
{
   [SerializeField] private float faktor = 0.8f;

    public override string Deskripsi 
        => "Tembakan lebih cepat";

    public override void Terapkan(PlayerController pemain)
    {
        pemain.PercepatTembak(faktor);
    }
}
