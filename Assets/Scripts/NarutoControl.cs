using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;

public class NarutoControl : MonoBehaviour
{
    public GameObject clone;
    public GameObject RasenShuriken;
    public GameObject explosion;
    public GameObject player;
    public GameObject shurikenClone;
    public GameObject Location1;
    public GameObject Location2;
    public GameObject Location3;   
    public GameObject Location4;
    public float SpawningRange;
    public float speed;
    private float currentSpeed;
    public int CloneCount;
    private Boolean grabState = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine(SummonClones(3));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
    IEnumerator rasengan()
    {
        tpToMiddle();
        transform.Translate(0, 10, 0);
        transform.LookAt(player.transform.position);
        yield return new WaitForSeconds(3);
        Vector3 location = player.transform.position;
        yield return new WaitForSeconds(0.5f);
        transform.position = location;
        transform.rotation = Quaternion.identity;
        currentSpeed = 0;
        ExplosionControl.size = 10;
        Instantiate(explosion, transform.position, transform.rotation);
        Invoke("grabDash", 3);
    }
    IEnumerator SummonClones(int clones)
    {
        for (int i = 0; i < clones; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(clone, RandomSpawningPostion(), transform.rotation);
        }
        CloneCount++;
        yield return new WaitForSeconds(1);
        StartCoroutine("rasenShurikenBarrage");
     }
    Vector3 RandomSpawningPostion()
    {
        float xPos = UnityEngine.Random.Range(transform.position.x - SpawningRange, transform.position.x + SpawningRange);
        float zPos = UnityEngine.Random.Range(transform.position.z - SpawningRange, transform.position.z + SpawningRange);
        Vector3 spawningPos = new Vector3(xPos, transform.position.y, zPos);
        return spawningPos;
    }
    void rasenShuriken(Vector3 location)
    {
         transform.LookAt(player.transform.position);
         Instantiate(RasenShuriken, location, transform.rotation);
    }
    IEnumerator rasenShurikenBarrage()
    {
        ShurikenCloneControl.visible = true;
        int shurikenCount = 16;
        transform.position = Location1.transform.position;
        transform.LookAt(player.transform.position);
        yield return new WaitForSeconds(3);
        for(int i = 0; i < shurikenCount; i++)
        {
            switch ((i+4)%4)
            {
                case 0:
                    rasenShuriken(Location1.transform.position);
                    break;
                case 1:
                    rasenShuriken(Location2.transform.position);
                    break;
                case 2:
                    rasenShuriken(Location3.transform.position);
                    break;
                case 3:
                    rasenShuriken(Location4.transform.position);
                    break;
            }
            yield return new WaitForSeconds(1);
        }
        shurikenCount += 4;
        yield return new WaitForSeconds(1);
        ShurikenCloneControl.visible = false;
        StartCoroutine(rasengan());
     }
    void tpToMiddle()
    {
        Vector3 middle = new Vector3(0, 1.708333f, 0);
        transform.position = middle;
        SummonClones(CloneCount);
    }
    void grabDash()
    {
        transform.LookAt(player.transform.position);
        currentSpeed = 100;
        grabState = true;
    }
    void grab()
    {
        currentSpeed = 0;
        PlayerControl playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();
        playerCtrl.grabbed = true;
        Invoke("grabAttack", 3);
    }
    void grabAttack()
    {
        PlayerControl playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();
        playerCtrl.health--;
        playerCtrl.grabbed = false;
        tpToMiddle();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && grabState)
        {
            grab();
        }
        if(collision.gameObject.CompareTag("Wall") && grabState)
        {
            currentSpeed = 0;
            grabState = false;
            //vulnerable state
            Invoke("tpToMiddle", 10);
        }
    }
}
