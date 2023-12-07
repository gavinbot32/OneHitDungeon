using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Datasets")]
    public ItemTierData itemTiers;
    
    [Header("UI Components")]
    public GameObject selectScreen;
    public SelectCell[] selectCells;
    public TextMeshProUGUI selectTitle;
    public GameObject invContainer;
    public GameObject itemCellPrefab;
    public GameObject inventory;

    [Header("Game Components")]
    private PlayerController player;
    public RoomScript curRoom;
    public RoomData roomData;

    [Header("Game Variables")]
    private List<GameObject[]> roomList;
    public int gameLevel;
    private int roomsTilLevel;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        roomList = new List<GameObject[]>();
        roomList.Add(roomData.rooms_oneDoor);
        roomList.Add(roomData.rooms_twoDoor);
        roomList.Add(roomData.rooms_threeDoor);
        roomList.Add(roomData.rooms_fourDoor);
        gameLevel = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(curRoom == null)
        {
            newRoom();
        }

        selectClass();    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void completeRoom()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors)
        {
            Destroy(door);
        }
    }
    public void newRoom()
    {
        if(curRoom != null)
        {
            Destroy(curRoom.gameObject);
        }
        int index = gameLevel;
        if(index >= roomList.Count)
        {
            index = roomList.Count-1;
        }
        GameObject roomPrefab = roomList[index][Random.Range(0, roomList[index].Length)];
        curRoom = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity).GetComponent<RoomScript>();
        player.transform.position = curRoom.playerSpawn.position;
       
    }
    public void levelProgress()
    {   
        roomsTilLevel++;
        int xpNeeded = gameLevel * 5;
        if (roomsTilLevel >= xpNeeded)
        {
            roomsTilLevel = 0;
            gameLevel++;
        }
    }
    private void newSelections(int tier)
    {
        if(tier == 0)
        {
            selectCells[0].weaponData = itemTiers.tier0[0];
            selectCells[1].weaponData = itemTiers.tier0[1];
            selectCells[2].weaponData = itemTiers.tier0[2];
        }
        foreach(SelectCell cell in selectCells)
        {
            cell.updateUI();
        }
        selectScreen.SetActive(true);

    }
    private void selectClass()
    {
        selectTitle.text = "Select a class";
        selectCells[0].playerClass = itemTiers.playerClasses[0];
        selectCells[1].playerClass = itemTiers.playerClasses[1];
        selectCells[2].playerClass = itemTiers.playerClasses[2];
        
        selectCells[0].weaponData = itemTiers.tier0[0];
        selectCells[1].weaponData = itemTiers.tier0[1];
        selectCells[2].weaponData = itemTiers.tier0[2];
        foreach (SelectCell cell in selectCells)
        {
            cell.classSelecting = true;
            cell.updateUI(true);
        }
        selectScreen.SetActive(true);
    }
    public void onItemSelected(SelectCell cell)
    {
        cell.itemSelected();
        selectScreen.SetActive(false);
    
    }

}
