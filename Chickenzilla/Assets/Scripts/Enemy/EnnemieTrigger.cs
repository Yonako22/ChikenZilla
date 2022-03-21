using UnityEngine;
using System.Collections;
public class EnnemieTrigger : MonoBehaviour
{
    public GameObject groupe;
    public float bossDelay = 3f;
    private bool bossStarted;
 
    private void Start()
    {
        groupe.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (groupe.name == "Body" && !bossStarted)
        {
            StartCoroutine(SpawnBoss());
            bossStarted = true;
        }
        else
        {
            groupe.SetActive(true);
        }
    }

    private IEnumerator SpawnBoss()
    {
        AudioManager.instance.BossTheme();
        yield return new WaitForSeconds(bossDelay);
        groupe.SetActive(true);
        StopCoroutine(SpawnBoss());
    }
}
