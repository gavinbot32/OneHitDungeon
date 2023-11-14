using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWeapon : Weapon
{
    [Header("Magic Components")]
    public GameObject[] spells;

    [SerializeField]
    private float waitTime;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        player = FindObjectOfType<PlayerController>();
        sr.enabled = false;
        col.enabled = false;
        cooldown = cooldown + waitTime;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
        
    }

    public override void onAttack()
    {
        StartCoroutine(weaponAttack());
        cooldownRemaining = cooldown;
    }

    IEnumerator weaponAttack()
    {
        sr.enabled = true;
        GameObject curSpell = spells[Random.Range(0, spells.Length)];
        Instantiate(curSpell);
        yield return new WaitForSeconds(waitTime);
        sr.enabled = false;

    }

}
