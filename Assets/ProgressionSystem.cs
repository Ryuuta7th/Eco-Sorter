using System;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class ProgressionSystem : MonoBehaviour
{
    [SerializeField] private int xpDasar = 20;
    [SerializeField] private float pangkat = 1.5f;
    [SerializeField] private int levelMaks = 10;
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelReward[] rewards;

    public int Level { get; private set; } = 1;
    public int CurrentXP { get; private set; }
    public event Action<int> LevelUp;

    private string pesan = "Kumpulkan XP untuk naik level";

    public int XpUntukNaik(int level)
    {
        return Mathf.RoundToInt(
            xpDasar * Mathf.Pow(level, pangkat));
    }

    public void AddXP(int jumlah)
    {
        if (jumlah <= 0 || Level >= levelMaks) return;

        CurrentXP += jumlah;

        while (Level < levelMaks
                && CurrentXP >= XpUntukNaik(Level))
        {
            CurrentXP -= XpUntukNaik(Level);
            Level++;
            NaikLevel();
        }

        if (Level >= levelMaks) CurrentXP = 0;
    }

    public void NaikLevel()
    {
        pesan = "LEVEL UP! Sekarang level " + Level;
        Debug.Log(pesan);
        BeriReward();
        LevelUp?.Invoke(Level);
    }

    public void BeriReward()
    {
        if (player == null) return;
        if (player == null || rewards.Length == 0) return;

        int indeks = (Level - 2) % rewards.Length;
        LevelReward reward = rewards[indeks];
        if (reward == null) return;

        reward.Terapkan(player);
        pesan = pesan + " Reward: " + reward.Deskripsi;
        Debug.Log("Reward: " + reward.Deskripsi); 
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 24;
        bool maks = Level >= levelMaks;
        int butuh = XpUntukNaik(Level);
        string teksXP = maks ? "MAKS"
                             : CurrentXP + " / " + butuh;
        GUI.Label(new Rect(20, 180, 700, 40),
            "Level " + Level + "   XP " + teksXP);

        float rasio = maks ? 1f : (float)CurrentXP / butuh;
        GUI.color = Color.gray;
        GUI.DrawTexture(new Rect(20, 222, 300, 14),
            Texture2D.whiteTexture);
        GUI.color = Color.green;
        GUI.DrawTexture(new Rect(20, 222, 300 * rasio, 14),
            Texture2D.whiteTexture);
        GUI.color = Color.white;

        GUI.Label(new Rect(20, 244, 1000, 40), pesan);         
    }
}