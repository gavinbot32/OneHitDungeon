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
    private float trueSpeed;
    public float cooldown;
    public float cooldownRemaining;
    private float rotDur;
    [Tooltip("The weapon type index, 0-Magical, 1-Stealth, 2-Battle")]
    public int weaponType;

    [Header("Components")]
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private Collider2D col;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        sr.enabled = false;
        col.enabled = false;
        trueSpeed = weaponSpeed + Mathf.Abs(rotComplete);
        rotDur = Mathf.Abs(rotComplete) / Mathf.Abs(trueSpeed);
        cooldown = rotDur + cooldown;
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
        int dir = 1;
        sr.enabled = true;
        col.enabled = true;
        if(rotComplete < 0)
        {
            dir = -1;
        }
        rig.angularVelocity = trueSpeed * dir;
        yield return new WaitForSeconds(rotDur);
        rig.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        sr.enabled = false;
        col.enabled = false;
    }

}
