using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public GameObject eyeSpark;
    public Boss boss;
    public Animation anim;
   
    void Start()
    {
        StartCoroutine(EyeSparkling());
        eyeSpark = Instantiate(eyeSpark, transform.position, quaternion.identity);
        eyeSpark.SetActive(false);
    }

    
    void Update()
    {
        eyeSpark.transform.position = transform.position;

        if (boss.bossLife <= 0f)
        {
            eyeSpark.SetActive(false);
        }
    }

    IEnumerator EyeSparkling()
    {
        yield return new WaitForSeconds(2.5f);
        eyeSpark.SetActive(true);
        yield return new WaitForSeconds(4f);
        eyeSpark.SetActive(false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(EyeSparkling());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FireBall"))
        {
            boss.bossLife--;
            anim.Play("DegatsBoss");
        }
    }
}