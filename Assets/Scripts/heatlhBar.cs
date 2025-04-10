using UnityEngine;
using UnityEngine.UI;

public class heatlhBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }



    void takeDamage(float damage)
    {
        health -= damage;
    }
    // New code to handle trigger damage from enemies
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            takeDamage(10);
        }
        if (other.CompareTag("Clone"))
        {
            takeDamage(5);
        }
        if (other.CompareTag("Rasengan"))
        {
            takeDamage(5);
        }
        if (other.CompareTag("Explosion"))
        {
            takeDamage(2);
        }
    }

}


