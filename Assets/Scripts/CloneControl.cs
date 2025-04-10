using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CloneControl : MonoBehaviour
{

    // Reference to the NavMeshAgent component for pathfinding.
    private NavMeshAgent navMeshAgent;
    public GameObject explosion;


    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the NavMeshAgent component attached to this object.
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame.
    void Update()
    {
        // If there's a reference to the player...
        if (GameObject.Find("Player") != null)
        {
            // Set the enemy's destination to the player's current position.
            navMeshAgent.SetDestination(GameObject.Find("Player").transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player Weapon"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            ExplosionControl.size = 7;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
