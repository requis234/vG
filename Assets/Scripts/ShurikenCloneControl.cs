using System;
using UnityEngine;

public class ShurikenCloneControl : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public static Boolean visible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (visible)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Weapon"))
        {
            Destroy(gameObject);
        }
    }
}
