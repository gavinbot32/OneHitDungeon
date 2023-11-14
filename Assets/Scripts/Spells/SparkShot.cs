using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkShot : Spell
{
    public float spellSpeed;
    public Vector3 mousePos;
    public Vector3 startPos;
    public float range;
    public GameObject deathParticle;

    private bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
        mousePos = Input.mousePosition;

         mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            killSpell();
        }
        if (move)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, spellSpeed * Time.deltaTime);
        }
        if ((transform.position.x > startPos.x + range || transform.position.x < startPos.x - range) || 
            (transform.position.y > startPos.y + range || transform.position.y < startPos.y - range))
        {
            killSpell();
        }

        if (Vector2.Distance(transform.position, mousePos) <= 0.05f)
        {
            killSpell();
        }


    }

    void killSpell()
    {
        if(move == false)
        {
            return;
        }
        move = false;
        col.enabled = false;
        Destroy(Instantiate(deathParticle, transform.position, Quaternion.identity),1.5f);
        Destroy(gameObject,1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            return;
        }

        if (collision.CompareTag("Enemy"))
        {
            //deal damage to enemy
            print("Enemy hit");
        }
        else
        {
            killSpell();
        }
        
    }




}
