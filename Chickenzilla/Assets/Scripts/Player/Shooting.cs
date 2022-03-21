using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootingRate;
    private float shootCooldown;
    public bool canShoot;
    
    public Transform canon;
    public GameObject fireBallPrefab;

    public float fireBallForce;

    public PlayerController playerController;

    void Start()
    {
        canShoot = true;
        shootCooldown = shootingRate;
        playerController = gameObject.GetComponent<PlayerController>();
    }
    
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (playerController.isPlayerOne)
        {
            if (Input.GetButton("Fire1") && canShoot)
            {
                Shoot();
                canon.gameObject.GetComponent<Animation>().Play("Shoot");
            }
        }
        else
        {
            if (Input.GetButton("Fire2") && canShoot)
            {
                Shoot();
                canon.gameObject.GetComponent<Animation>().Play("Shoot2");
            } 
        }
     
    }

    private void Shoot()
    {
        if (shootCooldown < Time.deltaTime)
        {
            GameObject fireBall = Instantiate(fireBallPrefab, canon.position, canon.rotation);
            Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
            rb.AddForce(canon.right * fireBallForce, ForceMode2D.Impulse);
            shootCooldown = shootingRate;
        }
    }
}