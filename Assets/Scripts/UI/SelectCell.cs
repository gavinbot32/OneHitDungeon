using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SelectCell : MonoBehaviour
{

    public TextMeshProUGUI label;
    public Image portrait;

    public WeaponData weaponData;
    public GameManager gameManager;
    public GameObject prefab;
    public PlayerController player;

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

    public void itemSelected()
    {
        if(prefab != null)
        {
            GameObject weapon = Instantiate(prefab, player.transform.position, Quaternion.identity, player.transform);
            player.inventory.Add(weapon);
            weapon.SetActive(false);
            if(player.equippedWeapon == null)
            {
                player.equipWeapon(weapon.GetComponent<Weapon>());
            }
        }
    }

}
