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


    // Start is called before the first frame update
    void Start()
    {
        selectClass();    
    }

    // Update is called once per frame
    void Update()
    {
        
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
