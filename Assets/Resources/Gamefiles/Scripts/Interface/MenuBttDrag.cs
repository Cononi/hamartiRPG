using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuBttDrag : MonoBehaviour, IPointerClickHandler
{
    public ButtonManager buttonManager;
    private void Start()
    {
    }
    void BttReset()
    {
        for (int i = 0; i < 6; i++)
            buttonManager.bttS[i].image.sprite = buttonManager.mbt_baseSprite[i];
    }
    public void OnPointerClick(PointerEventData data)
    {
        BttReset();
        switch (this.name)
        {
            case "player_info_btt":
                buttonManager.bttS[0].image.sprite = buttonManager.mbt_clickSprite[0];
                break;
            case "Inventory_info_btt":
                buttonManager.bttS[1].image.sprite = buttonManager.mbt_clickSprite[1];
                Inventory.instance.ItemSlotsCheck(-1, true);
                break;
            case "Npc_info_btt":
                buttonManager.bttS[2].image.sprite = buttonManager.mbt_clickSprite[2];
                break;
            case "Skill_info_btt":
                buttonManager.bttS[3].image.sprite = buttonManager.mbt_clickSprite[3];
                break;
            case "WorldMap_Menu_btt":
                buttonManager.bttS[4].image.sprite = buttonManager.mbt_clickSprite[4];
                break;
            case "Option_Menu_btt":
                buttonManager.bttS[5].image.sprite = buttonManager.mbt_clickSprite[5];
                break;
        }
    }
}


