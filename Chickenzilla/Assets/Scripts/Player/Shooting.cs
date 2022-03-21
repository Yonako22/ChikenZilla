using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootingRate;
    private float shootCooldown;
    public bool canShoot;
    
    public Transform canon;
    public GameObject fireBallPrefab;
    public GameObject fireBallPrefab2;

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
                Shoot2();
                canon.gameObject.GetComponent<Animation>().Play("Shoot2");
            } 
        }
     
    }

    private void Shoot()
    {
        if (shootCooldown < Time.deltaTime)
        {
            GameObject fireBall = Instantiate(fireBallPrefab, canon.position, new Quaternion(canon.rotation.x, canon.rotation.y, canon.rotation.z + 90, -90f));
            Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();
            rb.AddForce(canon.right * fireBallForce, ForceMode2D.Impulse);
            shootCooldown = shootingRate;
        }
    }
    
    private void Shoot2()
    {
        if (shootCooldown < Time.deltaTime)
        {
            GameObject fireBall2 = Instantiate(fireBallPrefab2, canon.position, new Quaternion(canon.rotation.x, canon.rotation.y, canon.rotation.z + 90, -90f));
            Rigidbody2D rb = fireBall2.GetComponent<Rigidbody2D>();
            rb.AddForce(canon.right * fireBallForce, ForceMode2D.Impulse);
            shootCooldown = shootingRate;
        }
    }
}