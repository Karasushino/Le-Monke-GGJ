using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float dmgValue = 4;
    public GameObject throwableObject;
    public GameObject bombObject;
    public Transform attackCheck;
    private Rigidbody2D m_Rigidbody2D;
    public Animator animator;
    public bool canAttack = true;
    public bool isTimeToCheck = false;

    public bool isAlmostMonke = false;

    public bool isMonkey = false;
    public bool isLEMONKE = false;


    public GameObject cam;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLEMONKE)
            return;

        //Melee attack
        if (!isMonkey)
        {
            if (Input.GetButtonDown("Fire1") && canAttack)
            {
                canAttack = false;
                animator.SetBool("IsAttacking", true);
                DoDashDamage();
                StartCoroutine(AttackCooldown());
            }
        }
        else if(isMonkey)
        {
             if (Input.GetButtonDown("Fire1") && canAttack)
            {
                canAttack = false;
                animator.SetBool("IsAttacking", true);
                StartCoroutine(AttackCooldown());
                GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f, -0.2f), Quaternion.identity) as GameObject;
                Vector2 direction = new Vector2(transform.localScale.x, 0);
                throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
                throwableWeapon.name = "ThrowableWeapon";
                
            }

            if (Input.GetButtonDown("Bomb"))
            {
                GameObject bombWeapon = Instantiate(bombObject, transform.position, Quaternion.identity) as GameObject;
                //Vector2 direction = new Vector2(0, 0);
                // bombWeapon.GetComponent<ThrowableWeapon>().direction = direction;
                bombWeapon.name = "Plant Bomb";
                Debug.Log("Plant Bomb");
            }
        }
       
        
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.25f);
        canAttack = true;
    }

    public void DoDashDamage()
    {
        dmgValue = Mathf.Abs(dmgValue);
        Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
        for (int i = 0; i < collidersEnemies.Length; i++)
        {
            if (collidersEnemies[i].gameObject.tag == "Enemy")
            {
                if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
                {
                    dmgValue = -dmgValue;
                }
                collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
                cam.GetComponent<CameraFollow>().ShakeCamera();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana 1"))
        {
            canAttack = true;
            Debug.Log("Banana 1 collided");
        }
        else if (collision.gameObject.CompareTag("Banana 2"))
        {
            isAlmostMonke = true;
            Destroy(collision.gameObject);

            Debug.Log("Banana 2 collided");

        }
        else if (collision.gameObject.CompareTag("Banana 3"))
        {
            isMonkey = true;
            Destroy(collision.gameObject);

            Debug.Log("Banana 3 collided");

        }
        else if (collision.gameObject.CompareTag("Banana 4"))
        {
            isLEMONKE = true;
            Destroy(collision.gameObject);

            Debug.Log("Banana 4 collided");

        }
    }


  
}
