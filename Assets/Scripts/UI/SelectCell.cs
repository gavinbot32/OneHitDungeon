using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SelectCell : MonoBehaviour
{

    public TextMeshProUGUI label;
    public Image portrait;

    public PlayerClass playerClass;
    public WeaponData weaponData;
    public GameManager gameManager;
    public GameObject prefab;
    public PlayerController player;
    public bool classSelecting;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
    }


    public void updateUI()
    {
        portrait.sprite = weaponData.sprite;
        label.text = weaponData.weaponName;
        prefab = weaponData.prefab;

    }

    public void updateUI(bool classSelecting)
    {
        portrait.sprite = weaponData.sprite;
        label.text = playerClass.className;
        prefab = weaponData.prefab;

    }

    public void itemSelected()
    {
        if (classSelecting)
        {
            player.playerClass = playerClass;
            if (prefab != null)
            {
                GameObject weapon = Instantiate(prefab, player.transform.position, Quaternion.identity, player.transform);
                player.inventory.Add(weapon);
                weapon.SetActive(false);
                if (player.equippedWeapon == null)
                {
                    player.equipWeapon(weapon.GetComponent<Weapon>());
                }
            }
            classSelecting = false;
        }
        else
        {
            if (prefab != null)
            {
                GameObject weapon = Instantiate(prefab, player.transform.position, Quaternion.identity, player.transform);
                player.inventory.Add(weapon);
                weapon.SetActive(false);
                if (player.equippedWeapon == null)
                {
                    player.equipWeapon(weapon.GetComponent<Weapon>());
                }
            }
        }
    }

}
