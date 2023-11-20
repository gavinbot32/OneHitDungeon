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
        trueSpeed = weaponSpeed + Mathf.Abs(rotComplete);
        rotDur = Mathf.Abs(rotComplete) / Mathf.Abs(trueSpeed);
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
        transform.localScale = new Vector3(player.dir, transform.localScale.y, transform.localScale.z);
        sr.enabled = true;
        GameObject curSpell = spells[Random.Range(0, spells.Length)];
        Instantiate(curSpell);

        int dir = -player.dir;
        if (inverseRotation)
        {
            dir = player.dir;
        }
        rig.angularVelocity = trueSpeed * dir;
        
        yield return new WaitForSeconds(rotDur);
        rig.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        sr.enabled = false;

    }

}
