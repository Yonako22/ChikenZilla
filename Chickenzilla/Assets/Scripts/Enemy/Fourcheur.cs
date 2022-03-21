using UnityEngine;

public class Fourcheur : Enemy
{
    public Rigidbody2D rb;
    public float vitesseCharge;
    public float vitesseAvancée;
    private float firstMoveCooldown;
    public float tempsAvancée = 1f;
    private bool pause;
    private float pauseCooldown;
    public float tempsDePause = 2f;

    void Start()
    {
        pause = true;
        pauseCooldown = tempsDePause;
        firstMoveCooldown = tempsAvancée;
    }
    
    
    void Update()
    {
        if (pause == true)                 //Avant la pause
        {

            if (firstMoveCooldown > 0)     //Avance pendant "tempsAvancée" secondes
            {
                rb.velocity = new Vector2(-vitesseAvancée, 0);
                firstMoveCooldown -= Time.deltaTime;
            }
            else                           //S'arrête
            {
                rb.velocity = new Vector3(0, 0, 0);
                
                if (pauseCooldown > 0)     //Fait une pause pendant "tempsDePause" secondes
                {
                    pauseCooldown -= Time.deltaTime;
                }
                else                       //Pause faite
                {
                    pause = false;
                }
            }
        }
        else                               //Commence à charger si la pause a été faite
        {
            rb.velocity = new Vector2(-vitesseCharge, 0);
        }
    }
}