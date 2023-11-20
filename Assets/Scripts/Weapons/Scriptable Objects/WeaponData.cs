using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public GameObject prefab;

    [Tooltip("0-Magic, 1-Stealth, 2-Battle")]
    public int weaponType;
    public int tier;
    public string weaponName;
    public Sprite sprite;
    

}
