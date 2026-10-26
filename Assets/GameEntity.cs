using UnityEngine;

public class GameEntity : MonoBehaviour
{
    protected virtual void Start()
    {
        Debug.Log(name + " created");
    }

    protected virtual void OnDestroy()
    {
        Debug.Log(name + " destroyed");
    }

    public virtual void Remove()
    {
        Destroy(gameObject);
    }

}
