using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootingRate;
    private float shootCooldown;
    public bool canShoot;
    
    public Transform canon;
    public GameObject fireBallPrefab;

    public float fireBallForce;

    void Start()
    {
        canShoot = true;
        shootCooldown = shootingRate;
    }
    
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && canShoot)
        {
                Shoot();
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