using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{

    public Transform playerSpawn;
    private GameManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        Physics2D.callbacksOnDisable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


}
