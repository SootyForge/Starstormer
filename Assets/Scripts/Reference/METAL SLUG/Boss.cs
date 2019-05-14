using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour {
    

    public Transform Spawn_Bullet;
    public GameObject Bullet;
    public Player player;
    public BulletPool pool;
    public Animator aim;

    private float playerDistance;


    public float firerate;
    private float BossCanFire;


    private float lastShootTime;

    public float Hp;
    public float speed = 10.0f;
    public float damage;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BossCanFire -= Time.deltaTime;

        playerDistance = Vector2.Distance(player.transform.position, transform.position);

        if (playerDistance <= 5f)
        {
            Fire();
        }
        else
        {
            anim.SetBool("Fire", false);
        }

    }
    //la function qui fait tirer le boss
    public void Fire()
    {
        if (BossCanFire > 0)
            return;
        Bullets bullet = pool.shoot_Boss();
        bullet.transform.position = Spawn_Bullet.position;
        bullet.transform.rotation = Spawn_Bullet.rotation;
        anim.SetBool("Fire", true);
        BossCanFire = firerate;
        bullet.Fire_Boss();

    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player.hp -= damage;
            Debug.Log("PlayerHealthVsBoss" + player.hp);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Bullets bullets = collider.gameObject.GetComponent<Bullets>();

        if (bullets != null)
        {
            Hp -= bullets.damage;
            Debug.Log("Hp");
        }
        if (Hp == 0)
        {
            Destroy(gameObject);
            Application.LoadLevel(3);
        }
    }
}
