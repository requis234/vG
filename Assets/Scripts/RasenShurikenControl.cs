using Unity.VisualScripting;
using UnityEngine;

public class RasenShurikenControl : MonoBehaviour
{
    public GameObject explosion;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(GameObject.Find("Player").transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Wall"))
        {
            Explode();
        }
    }
    void Explode()
    {
        ExplosionControl.size = 10;
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
