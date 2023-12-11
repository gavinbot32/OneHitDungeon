using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Device;
using System.Dynamic;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [Header("Game Components")]
    private GameManager manager;
    private Vector3 mousePos;

    [Header("Inventory")]
    private InventoryCell[] invSlots;
    private bool invOpen;

    [Header("Tooltip Components")]
    public GameObject toolTips;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemClass;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemDesc;
    public TextMeshProUGUI itemDMG;
    public TextMeshProUGUI itemSpeed;

    private void Awake()
    {
        manager = GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    private void FixedUpdate()
    {

    }

    public void setCursor(WeaponData itemData)
    {
        Weapon item = itemData.prefab.GetComponent<Weapon>();
        string[] classStrings = {"Mage", "Rogue", "Warrior" };
        string[] weaponType = {"Magic", "Stealth", "Battle" };
        itemName.text = item.weaponName;
        itemClass.text = classStrings[item.weaponType];
        itemType.text = "Tier "+itemData.tier.ToString()+"-"+weaponType[item.weaponType];
        itemDesc.text = item.weaponDesc;
        itemDMG.text = item.weaponDamage.ToString();
        itemSpeed.text = item.weaponSpeed.ToString();
        toolTips.transform.position = mousePos; 
    }

    public void setScreen(GameObject screen)
    {
        screen.SetActive(!screen.active);
    }

}
