using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public GameObject player;
    CharacterController Controller;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position;
        target.y = transform.position.y;
        Vector3 moveDirection = target - transform.position;
        Controller.SimpleMove(moveDirection * speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation(moveDirection), turnSpeed * Time.deltaTime);
    }
}
