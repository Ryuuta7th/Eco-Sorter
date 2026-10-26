using UnityEngine;

public class WasteItem : GameEntity
{
    [SerializeField] protected int pointValue = 10;
    [SerializeField] protected float fallSpeed = 2f;
    [SerializeField] protected int xpvalue = 5; //P06
    protected string info = "Sampah terkumpul";
    protected ScoreKeeper scoreKeeper;
    protected ProgressionSystem progression; //P06

    protected override void Start()
    {
        base.Start();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        progression = FindAnyObjectByType<ProgressionSystem>(); //P06
    }

    protected virtual void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime,
                0f, Space.World);
        if (transform.position.y < -6f)
        {
            scoreKeeper.AddMissed();
            Remove();
        }
    }

    void OnMouseDown()
    {
        scoreKeeper.PlayClickSound();
        Collect(); 
    }

    protected virtual void Collect()
    {
        Debug.Log(info);
        scoreKeeper.AddPoints(pointValue, info);
        BeriXP(); //P06
        Remove();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnTouchPlayer(other.gameObject);
        }
    }

    protected virtual void OnTouchPlayer(GameObject player)
    {
        Collect();
    }

    protected virtual int HitungXP()
    {
        return xpvalue;
    }

    public virtual void TerapkanLevel(int level)
    {
        fallSpeed = fallSpeed * (1f * 0.1f * (level - 1));
    }

    protected void BeriXP()
    {
        if(progression == null) return;
        progression.AddXP(HitungXP());
    }
}
