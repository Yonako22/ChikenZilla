using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cannon : MonoBehaviour
{
    public GameObject milkLaser;
    public GameObject milkBall;
    public GameObject meteorCow;
    public float offsetX;
    public Boss boss;
    private BoxCollider2D milkLaserCollider;
    public AudioSource audioSource;
    public AudioClip sound;

    void Start()
    {
        StartCoroutine(Fire());
        milkLaser = Instantiate(milkLaser, new Vector3(transform.position.x + offsetX, transform.position.y),Quaternion.identity);
        milkLaser.SetActive(false);
        MeteorCowSpawn();
        milkLaserCollider = milkLaser.GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        milkLaser.transform.position = new Vector3(transform.position.x + offsetX, transform.position.y);

        if (boss.bossLife <= 0f)
        {
            StopAllCoroutines();
            milkLaser.SetActive(false);
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(3.5f);
        milkLaser.SetActive(true);
        audioSource.PlayOneShot(sound);
        milkLaserCollider.enabled = true;
        yield return new WaitForSeconds(3f);
        audioSource.Stop();
        milkLaser.SetActive(false);
        milkLaserCollider.enabled = false; 
        yield return new WaitForSeconds(1f);
        Instantiate(milkBall, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(milkBall, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(milkBall, transform.position, Quaternion.identity);
        
        StartCoroutine(Fire());
    }
    
    void MeteorCowSpawn()
    {
        StartCoroutine(Spawn());
        
        IEnumerator Spawn()
        {
            yield return new WaitForSeconds(8);
            Instantiate(meteorCow, new Vector3(Random.Range(transform.position.x - 2, transform.position.x - 15), transform.position.y + 11), quaternion.identity);
            StartCoroutine(Spawn());
        }
        
    }
}
