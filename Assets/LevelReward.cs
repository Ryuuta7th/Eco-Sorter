using UnityEngine;

public class LevelReward : MonoBehaviour
{
   public virtual string Deskripsi => "Reward";
   public virtual void Terapkan(PlayerController pemain)
    {
        Debug.Log("Reward ini belum punya efek.");
    }
}
