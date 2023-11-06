using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{

    [Header("Player Stats")]
    public Weapon equippedWeapon;
    //public Armor armor;
    public int armorClass;
    



    [Header("Movement")]
    private float walkCooldown;
    public float walkDur;
    public Vector2 walkClamp;
    public float moveSpeed;

    [Header("Components")]
    private Rigidbody2D rig;
    public Transform playerSprite;


  

    private void Awake()
    {
       rig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        inputManagement();
    }

    private void FixedUpdate()
    {
        if(equippedWeapon != null)
        {
            equippedWeapon.transform.position = transform.position;
        }
    }

    void inputManagement()
    {
        float xInput = 0;
        float yInput = 0;


        if (walkCooldown > 0)
        {
            walkCooldown -= Time.deltaTime;
        }
        if (walkCooldown <= 0)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
        }
        if (xInput != 0)
        {
            walkCooldown = walkDur;
            int dir;
            if (xInput < 0)
            {
                dir = -1;
            }
            else { dir = 1; };
            playerSprite.transform.localScale = new Vector2(dir, playerSprite.transform.localScale.y);
            rig.MovePosition(new Vector2(transform.position.x + (0.5f * dir), transform.position.y));

        }
        if (yInput != 0)
        {
            walkCooldown = walkDur;
            int dir = 1;
            if (yInput < 0)
            {
                dir = -1;
            }
            rig.MovePosition(new Vector2(transform.position.x, transform.position.y + (0.5f * dir)));
        }


        if (Input.GetAxisRaw("Fire1") != 0)
        {
            if(equippedWeapon != null)
            {
                if (equippedWeapon.cooldownRemaining <= 0)
                {
                    equippedWeapon.onAttack();
                }
                
            }
        }


    }
}
