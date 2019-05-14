using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rotation;

    //fire rate player
    public float firerate;
    private float playerCanFire;

    //audioclip
    public AudioClip m_Shot;
    public AudioClip m_Jump;

    //delegate to kill player
    public delegate void Kill_Player();
    public Kill_Player Death;

    //boss class
    public Boss Boss;

    //bullet position
    public Transform bullet_location;

    //animation player
    public Animator anim;

    //bulletpool
    public BulletPool pool;

    //gameobjects
    public GameObject Bullet_Boss;
    public GameObject HealthPowerUp;
    public GameObject GunPowerUp;

    //Player Speed
    public float Move_Speed = 20.0f;

    //Player hp
    public float hp;

    //Player jump Height
    public float Jump_Height;

    private bool Is_Player_Jumping = false;


    void Update()
    {
        playerCanFire -= Time.deltaTime;
        Control_Player();
        jump();
        Shooting();
    }

    private void Control_Player()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //Sprite Rotation
            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(Vector2.right * Move_Speed * Time.deltaTime);
            rotation = 1;
            anim.SetBool("Run", true);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.Translate(Vector2.right * Move_Speed * Time.deltaTime);
            rotation = -1;
            anim.SetBool("Run", true);

        }
        else
        {
            anim.SetBool("Run", false);
            rotation = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", false);
            anim.SetTrigger("Jump");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Crouching", true);
        }
        else
        {
            anim.SetBool("Crouching", false);
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Is_Player_Jumping == false)
            {
                Is_Player_Jumping = true;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * Jump_Height);
                anim.SetBool("Jump", true);
                anim.SetBool("Run", false);
                PlaySound(m_Jump);
            }
            else
            {
                anim.SetBool("Jump", false);
            }
        }

    }
    //Collision of player with the ground ( no double jump )
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Is_Player_Jumping = false;
            anim.SetBool("Jump", false);
        }
        if (col.gameObject.tag == "Boss")
        {
            Is_Player_Jumping = false;
            anim.SetBool("Jump", false);
        }
        //destroy powerup Health
        if (col.gameObject.tag == "BulletBoss")
        {
            hp -= Boss.damage;
            Debug.Log("hp :" + hp);

        }

    }
    //player shoot
    private void Shooting()
    {
        if (playerCanFire > 0)
            return;
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlaySound(m_Shot);
            Bullets bullet = pool.shoot();
            bullet.transform.position = bullet_location.position;
            bullet.transform.rotation = bullet_location.rotation;
            playerCanFire = firerate;
            bullet.Fire();

        }
    }
    //kill player
    public void KillPlayer()
    {

    }
}
