using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public heatlhBar healthBarScript; // Drag the health bar script from the canvas or wherever it lives
    public float health;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (healthBarScript != null)
            {
               takeDamage(10); // Or any damage value you want
            }
            else
            {
                Debug.LogWarning("Health Bar Script not assigned!");
            }
        }
    }
    void takeDamage(float damage)
    {
        health -= damage;
    }
}
