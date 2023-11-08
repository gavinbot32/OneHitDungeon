using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Stats")]
    public string weaponName;
    public string weaponDesc;
    public float weaponSpeed;
    public float weaponDamage;

    [Tooltip("Determines if it rotates based upon direction of player")]
    public bool dirBased;

    public int rotComplete;
    private float trueSpeed;
    public float cooldown;
    public float cooldownRemaining;
    private float rotDur;
    private float defScale;
    [Tooltip("The weapon type index, 0-Magical, 1-Stealth, 2-Battle")]
    public int weaponType;

    [Header("Components")]
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private Collider2D col;
    private PlayerController player;
    [Tooltip("The gameobject that parents the sprite")]
    public GameObject spriteHolder;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        player = FindObjectOfType<PlayerController>();
        sr.enabled = false;
        col.enabled = false;
        trueSpeed = weaponSpeed + Mathf.Abs(rotComplete);
        rotDur = Mathf.Abs(rotComplete) / Mathf.Abs(trueSpeed);
        cooldown = rotDur + cooldown;
        defScale = spriteHolder.transform.localScale.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownRemaining >= 0)
        {
            cooldownRemaining -= Time.deltaTime;
        }
    }
    public void onAttack()
    {
        StartCoroutine(weaponAttack());
        cooldownRemaining = cooldown;
    }

    IEnumerator weaponAttack()
    {
        
        sr.enabled = true;
        col.enabled = true;
        int dir = 1;
        if (dirBased)
        {
            if(player.dir != 0)
            {
                dir = player.dir;
            }
            spriteHolder.transform.localScale = new Vector3(defScale * dir, spriteHolder.transform.localScale.y, spriteHolder.transform.localScale.z);
        }
        else
        {
            if (rotComplete < 0)
            {
                dir = -1;
            }
        }
        rig.angularVelocity = trueSpeed * dir;
        yield return new WaitForSeconds(rotDur);
        rig.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        sr.enabled = false;
        col.enabled = false;
    }

}
