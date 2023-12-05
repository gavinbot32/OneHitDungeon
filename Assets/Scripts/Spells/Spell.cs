using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public string spellName;
    public string spellSchool;

    public float spellDmg;
    public string dmgType;
    public float lifetime;

    protected private PlayerController player;
    protected private Rigidbody2D rig;
    protected private Collider2D col;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        lifetime -= Time.deltaTime;
        if( lifetime < 0 )
        {
            Destroy(gameObject);
        }
        
    }
}
