using System.Collections;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject Bullet_Boss;

    public Enemy Enemy;
    public Health Hp;
    public Animator anim;

    //Speed of bullets
    public float Player_Bullet_speed;
    public float Boss_Bullet_Speed;
    public float ShootCoolDown;



    public float damage;

    public void Active()
    {
        this.gameObject.SetActive(true);
    }

    void Update()
    {
    }

    //Fire bullet
    public void Fire()
    {

        Rigidbody2D bulletMove = GetComponent<Rigidbody2D>();
        bulletMove.velocity = new Vector2(transform.right.x * Player_Bullet_speed, transform.right.y);
        Destroy(gameObject, 1f);

    }

    //le transforum du position de la ball
    public void Fire_Boss()
    {
        Rigidbody2D bulletMove = GetComponent<Rigidbody2D>();
    }
}
