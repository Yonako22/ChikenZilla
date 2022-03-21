using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Quand la fireball rencontre le bord de l'écran
        {
            GameManager.instance.PlayerLifeUp();
            Destroy(gameObject);
        }
    }
}
