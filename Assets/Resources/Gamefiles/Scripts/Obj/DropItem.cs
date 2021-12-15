using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public info itemType;
    public float itemNumber;
    public int ItemCount;
    public bool dropCount;
    public SpriteRenderer sp;

    /*             GameObject InvenDrop = Instantiate(Inventory.instance.DropItem);
                InvenDrop.GetComponent<DropItem>().itemType = _slot.info;
                InvenDrop.GetComponent<DropItem>().itemNumber = _slot.DropItemNumber;
                InvenDrop.GetComponent<DropItem>().ItemCount = _slot.ItemCount;
                Vector2 rand = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                InvenDrop.transform.position = new Vector2(player.transform.position.x + rand.x, player.transform.position.y + rand.y); */
    private void Start()
    {
        if (dropCount)
            StartCoroutine(ItemDelete());
    }

    IEnumerator ItemDelete()
    {
        yield return new WaitForSeconds(60f);
        dropCount = false;
        Destroy(gameObject);
    }
    IEnumerator ItemGetAnis()
    {
        ButtonManager.instance.dropgets = false;
        sp.sortingLayerName = "Players & MapLayer";
        sp.sortingOrder = 99;
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector2(Inventory.instance.player.position.x, Inventory.instance.player.position.y - 0.9f);
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector2(Inventory.instance.player.position.x, Inventory.instance.player.position.y - 0.7f);
        yield return new WaitForSeconds(0.15f);
        gameObject.transform.position = new Vector2(Inventory.instance.player.position.x, Inventory.instance.player.position.y - 0.5f);
        Destroy(gameObject);
        Inventory.instance.AddItem(itemType, itemNumber, ItemCount);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropGet"))
        {
            for (int i = 0; i < Inventory.instance.slot_Table.Count; i++)
            {
                if (Inventory.instance.slot_Table[i].checkItem == false || ((Inventory.instance.slot_Table[i].info == info.OTHERS && Inventory.instance.slot_Table[i].ItemCount < 99) && Inventory.instance.slot_Table[i].checkItem == false))
                {
                    StartCoroutine(ItemGetAnis());
                    //Destroy(gameObject);
                    if (dropCount == false)
                    {
                        DataManager.instance.dropQuestItem(gameObject.name);
                    }
                    break;
                }
            }
        }
    }
}
