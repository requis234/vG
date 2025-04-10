using System;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public GameObject cam;
    public GameObject slash;
    public float speed;
    private float initialSpeed;
    public float dashSpeed;
    public float dashCooldown;
    private float dashCooldownRemaining;
    public float dashDuration;
    private float dashDurationRemaining;
    public float slashCooldown;
    private float slashCooldownRemaining;
    public Boolean grabbed;
    public float health;

    public GameObject lockOnTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
        //movement
        if (!grabbed)
        {
            MovePlayerRelativeToCamera();
        }
        else
        {
            speed = 0;
        }
        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift)&&dashCooldownRemaining<=0 && !grabbed)
        {
            speed = dashSpeed;
            dashCooldownRemaining = dashCooldown;
            dashDurationRemaining = dashDuration;
        }
        if(dashDurationRemaining <= 0)
        {
            speed = initialSpeed;
        }
        else
        {
            dashDurationRemaining -= Time.deltaTime;
        }
        if(dashCooldownRemaining >= 0)
        {
            dashCooldownRemaining -= Time.deltaTime;
        }
        //slash
        if (Input.GetMouseButtonDown(0)&&slashCooldownRemaining <=0)
        {
            slashCooldownRemaining = slashCooldown;
            Instantiate(slash, GameObject.Find("Player").transform.position,transform.rotation);
        }
        if(slashCooldownRemaining>= 0)
        {
            slashCooldownRemaining -= Time.deltaTime;
        }
    }
    void MovePlayerRelativeToCamera()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float playerVerticalinput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVerticalInput = playerVerticalinput * forward;
        Vector3 rightRelativeHorizontalInput = playerHorizontalInput * right;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        rb.linearVelocity = cameraRelativeMovement*speed;
    }
   
   



}
