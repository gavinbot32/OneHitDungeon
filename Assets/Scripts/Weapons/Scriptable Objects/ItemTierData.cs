using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ItemTierData", menuName = "ScriptableObjects/TierData", order = 1)]
public class ItemTierData : ScriptableObject
{
    public WeaponData[] tier0;
}
