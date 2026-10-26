using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    int missed = 0;
    string message = "Klik sampah sebelum jatuh";

    [SerializeField] AudioClip clickSound;
    [SerializeField] private Health playerHealth;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
    public void AddPoints(int points, string info)
    {
        score += points;
        message = info;
    }

    public void AddMissed()
    {
        missed++;
        message = "Sampah terlewat dan mencemari lingkungan";
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 24;
        GUI.color = Color.black;
        GUI.Label(new Rect(20, 20, 700, 40),"Skor: "
                + score + "   Terlewat: " + missed);
        GUI.Label(new Rect(20, 60, 1000, 40), message);

        int hp = playerHealth != null
                ? playerHealth.CurrentHP : 0;
        GUI.Label(new Rect(20, 100, 700, 40),
            "Nyawa: " + hp);
        if (hp <= 0)
            GUI.Label(new Rect(20, 140, 700, 40), "GAME OVER");
    }
}
