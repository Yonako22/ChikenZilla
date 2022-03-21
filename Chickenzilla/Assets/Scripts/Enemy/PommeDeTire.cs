using UnityEngine;

public class PommeDeTire : Enemy
{
    public Rigidbody2D rb;
    public float vitesse;
    
    public float shootingRate;
    private float shootCooldown;
    
    public Transform canon;
    public GameObject potatoPrefab;

    public float potatoForce;
    void Start()
    {
        shootCooldown = shootingRate;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        ShootPotato();
    }
    void ShootPotato()
    {
        if (shootCooldown < Time.deltaTime)
        {
            GameObject potato = Instantiate(potatoPrefab, canon.position, canon.rotation);
            Rigidbody2D rb = potato.GetComponent<Rigidbody2D>();
            rb.AddForce(-canon.right * potatoForce, ForceMode2D.Impulse);
            shootCooldown = shootingRate;
        }
    }
}
