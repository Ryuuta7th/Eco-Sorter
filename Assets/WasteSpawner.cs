using UnityEngine;
using UnityEngine.UIElements;

public class WasteSpawner : MonoBehaviour
{
    [SerializeField] WasteItem[] wastePrefabs;
    [SerializeField] float interval = 1f;
    [SerializeField] float spawnY = 6f;
    [SerializeField] float xRange = 7f;
    [SerializeField] ProgressionSystem progression;
    [SerializeField] float intervalMin = 0.4f;
    [SerializeField] float percepatanLevel = 0.08f;
    float timer = 0f;
    int level = 1;
    float intervalSekarang;

    void Start()
    {
        intervalSekarang = interval;
        if (progression != null)
            progression.LevelUp += SaatLevelUp;
    }

    void Update()
    {
        if (wastePrefabs == null || wastePrefabs.Length == 0) return;
        timer += Time.deltaTime;
        if (timer >= intervalSekarang)
        {
            timer = 0f;
            int i = Random.Range(0, wastePrefabs.Length);
            Vector3 pos = new Vector3(Random.Range(-xRange, xRange), spawnY, 0f);
            WasteItem w = Instantiate(wastePrefabs[i], pos, Quaternion.identity);
            w.TerapkanLevel(level);
        }
    }

    void SaatLevelUp(int levelBaru)
    {
        level = levelBaru;
        intervalSekarang = Mathf.Max(intervalMin,
            interval - percepatanLevel * (level - 1));
        Debug.Log("Kesulitan naik: sampah muncul tiap "
            + intervalSekarang.ToString("0.00") + " detik");
    }

    void OnDestroy()
    {
        if(progression != null)
           progression.LevelUp -= SaatLevelUp;
    }
}
