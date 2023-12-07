using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Stats")]
    public Weapon equippedWeapon;
    //public Armor armor;
    public int armorClass;
    public List<GameObject> inventory;
    public PlayerClass playerClass;


    [Header("Movement")]
    private float walkCooldown;
    public float walkDur;
    public Vector2 walkClamp;
    public float moveSpeed;
    public int dir;


    [Header("Components")]
    private Rigidbody2D rig;
    public Transform playerSprite;
    private GameManager manager;

    [Header("Keybinds")]
    public KeyCode invKeybind;
  

    private void Awake()
    {
       rig = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dir = 1;
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

    public void equipWeapon(Weapon weapon)
    {
        equippedWeapon = weapon;
        equippedWeapon.gameObject.SetActive(true);

    }

    public void addToInv(WeaponData itemData, GameObject item)
    {
        inventory.Add(item);
        InventoryCell cell = Instantiate(manager.itemCellPrefab, manager.invContainer.transform).GetComponent<InventoryCell>();
        cell.initialize(itemData, item);

        item.SetActive(false);
        if (equippedWeapon == null)
        {
            equipWeapon(item.GetComponent<Weapon>());
        }


    }
    
    void inputManagement()
    {

        movementInput();


        if (Input.GetKeyDown(invKeybind)){
            manager.inventory.SetActive(!manager.inventory.active);
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

    public void movementInput()
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Floor"))
        {
            print("left floor");
            try{
                manager.levelProgress();
                manager.newRoom();
            }catch(Exception e)
            {
                return;
            }
        }
    }

}
