using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
    public static float size;
    public float lifetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 resize = new Vector3(size, size, size);
        transform.localScale += resize;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
