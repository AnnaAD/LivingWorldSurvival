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
        popUp.SetActive(true);
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
        popUp.SetActive(false);
        tracking = false;
    }
    public virtual void OnPointerClick(PointerEventData evd)
    {
        Debug.Log("what");
        if(evd.button == PointerEventData.InputButton.Right)
        {
            inventory.removeItem(item);
            Instantiate(item.getPickup(), GameObject.Find("Player").transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            return;
        }

        if(item.itemType == Item.ItemType.Tent)
        {
            inventory.removeItem(item);
            Instantiate(item.getDeployedTent(), GameObject.Find("Player").transform.position, item.getDeployedTent().transform.rotation);
        }

        if (item.itemType == Item.ItemType.Knife)
        {
            Debug.Log(GameObject.Find("Palm.R"));
            GameObject knife = Instantiate(item.getWeapon(), RecursiveFindChild(GameObject.Find("Player").transform, "Fingers.R").transform.position, GameObject.Find("Player").transform.rotation) as GameObject;
            knife.transform.parent = RecursiveFindChild(GameObject.Find("Player").transform, "Palm.R");
            inventory.removeItem(item);
        }

        if (item.itemType == Item.ItemType.Mushroom || item.itemType == Item.ItemType.Meat)
        {
            inventory.removeItem(item);
            GameObject.Find("Player").GetComponent<PlayerStats>().hunger += 3;
        }

    }
    public void OnPointerDown(PointerEventData evd)
    {
        //Debug.Log("OnPointerDown");
    }
    public void OnPointerUp(PointerEventData evd)
    {
        //Debug.Log("OnPointerUp");
    }
    public void OnSelect(BaseEventData evd)
    {
        //Debug.Log("OnSelect");
    }

    Transform RecursiveFindChild(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
            {
                return child;
            }
            else
            {
                Transform found = RecursiveFindChild(child, childName);
                if (found != null)
                {
                    return found;
                }
            }
        }
        return null;
    }
}
