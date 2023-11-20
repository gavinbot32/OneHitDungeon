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

    public int rotComplete;
    protected private float trueSpeed;
    public float cooldown;
    public float cooldownRemaining;
    protected private float rotDur;
    private float defScale;

    [Tooltip("Turn this on if you want the weapon to rotate in the opposite direction")]
    public bool inverseRotation;

    [Tooltip("The weapon type index, 0-Magical, 1-Stealth, 2-Battle")]
    public int weaponType;

    [Header("Components")]
    protected private Rigidbody2D rig;
    protected private SpriteRenderer sr;
    protected private Collider2D col;
    protected private PlayerController player;
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
    protected void Update()
    {
        if (cooldownRemaining >= 0)
        {
            cooldownRemaining -= Time.deltaTime;
        }
    }
    public virtual void onAttack()
    {
        StartCoroutine(weaponAttack());
        cooldownRemaining = cooldown;
    }

    IEnumerator weaponAttack()
    {
        transform.localScale = new Vector3(player.dir, transform.localScale.y, transform.localScale.z);
        sr.enabled = true;
        col.enabled = true;
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
        col.enabled = false;
    }

}
