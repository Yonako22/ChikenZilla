using System.Collections;
using UnityEngine;

public class MilkLaser : MonoBehaviour
{
    private bool hitPlayer;
    private Collider2D col;

    private void Awake()
    {
        col= GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (hitPlayer)
        {
            StartCoroutine(Cooldown());
        }
        else
        {
            col.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hitPlayer = true;
            GameManager.instance.PlayerIsHit(true);
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            hitPlayer = true;
            GameManager.instance.PlayerIsHit(false);
        }
    }

    IEnumerator Cooldown()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1);
        hitPlayer = false;
    }
}
