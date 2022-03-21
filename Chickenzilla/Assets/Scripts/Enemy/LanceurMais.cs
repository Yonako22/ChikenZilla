using UnityEngine;

public class LanceurMais : Enemy
{
    public Rigidbody2D rb;
    public float vitesse;
    
    public float shootingRate;
    private float shootCooldown;
    
    public Transform canon;
    public GameObject cornPrefab;

    public float cornForce;
    
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

        rb.velocity = new Vector2(-vitesse, 0);
        ShootCorn();
    }

    void ShootCorn()
    {
        if (shootCooldown < Time.deltaTime)
        {
            GameObject corn = Instantiate(cornPrefab, canon.position, canon.rotation);
            Rigidbody2D rb = corn.GetComponent<Rigidbody2D>();
            rb.AddForce(canon.up * cornForce, ForceMode2D.Impulse);
           shootCooldown = shootingRate;
        }
    }
    
}