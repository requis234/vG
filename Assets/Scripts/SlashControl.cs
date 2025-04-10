using System.Threading;
using UnityEngine;

public class SlashControl : MonoBehaviour
{
    public float lifeTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        transform.Translate(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
        
    }
}
