using UnityEngine;

public class PlasticWaste : WasteItem
{
    protected override void Collect()
    {
        info = "Plastik: didaur ulang (+" + pointValue
                + " poin)";
        base.Collect();
    }

    public override void TerapkanLevel(int level)
    {
        base.TerapkanLevel(level);
        pointValue =  pointValue + 5 * (level - 1);
    }
}
