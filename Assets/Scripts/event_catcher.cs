using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class event_catcher : MonoBehaviour, IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler,
    ISelectHandler
{

    [SerializeField] private GameObject popUp;
    private Item item;
    private Inventory inventory;

    private bool tracking;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(tracking)
        {
            popUp.transform.position = Input.mousePosition + new Vector3(40f,-30f,0);
        }
    }

    public void OnPointerEnter(PointerEventData evd)
    {
        popUp.active = true;
        tracking = true;
        popUp.transform.Find("Text").GetComponent<Text>().text = item.itemType.ToString();
    }

    public void setItem(Item item)
    {
        this.item = item;
    }

    public void setInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void OnPointerExit(PointerEventData evd)
    {
        popUp.active = false;
        tracking = false;
    }
    public void OnPointerClick(PointerEventData evd)
    {
        if(evd.button == PointerEventData.InputButton.Right)
        {
            inventory.removeItem(item);
            Instantiate(item.getPickup(), GameObject.Find("Player").transform.position, Quaternion.identity);
            return;
        }

        if(item.itemType == Item.ItemType.Tent)
        {
            inventory.removeItem(item);
            Instantiate(item.getDeployedTent(), GameObject.Find("Player").transform.position, Quaternion.identity);
        }

        if (item.itemType == Item.ItemType.Mushroom || item.itemType == Item.ItemType.Meat)
        {
            inventory.removeItem(item);
            GameObject.Find("Player").GetComponent<PlayerStats>().hunger += 3;
        }

    }
    public void OnPointerDown(PointerEventData evd)
    {
        Debug.Log("OnPointerDown");
    }
    public void OnPointerUp(PointerEventData evd)
    {
        Debug.Log("OnPointerUp");
    }
    public void OnSelect(BaseEventData evd)
    {
        Debug.Log("OnSelect");
    }
}