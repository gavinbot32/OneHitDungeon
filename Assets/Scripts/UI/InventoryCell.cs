using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class InventoryCell : MonoBehaviour
{
    public TextMeshProUGUI label;
    public Image portrait;

    public WeaponData weaponData;
    public GameManager gameManager;
    public UIManager uiManager;
    public PlayerController player;
    public GameObject item;
    public Outline outline;
    public Color highlight;
    public bool inited;
   // public bool highlighted;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
        inited = false;
   //     highlighted = false;
    }
     

    public void initialize(WeaponData itemData, GameObject itemAssigned) 
    {
        item = itemAssigned;
        weaponData = itemData;
        portrait.sprite = weaponData.sprite;
        label.text = weaponData.weaponName;
        inited = true;
    }


    private void FixedUpdate()
    {

  

        if (inited && item == null)
        {
            Destroy(gameObject);
        }
        if(player.equippedWeapon == item.GetComponent<Weapon>())
        {
            outline.effectColor = highlight;
        }
        else
        {
            outline.effectColor = Color.black;
        }
    }

  public void onClick()
    {
        player.equipWeapon(item.GetComponent<Weapon>());
    }
/*
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlighted = true;
        uiManager.setCursor(weaponData);
    }
    public void OnPointerExit(PointerEventData eventData) { 
        highlighted = false;
    }   */
}
