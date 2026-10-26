using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 titik = collision.GetContact(0).point;
        Debug.Log(name + "MENABRAK"
            + collision.gameObject.name
            + " di tiitk " + titik);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(name + " LEPAS DARI "
            + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(name + " MASUK area " + other.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(name + " KELUAR dari area " + other.name);
    }
}
