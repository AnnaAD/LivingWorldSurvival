using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class event_catcher_exchange : event_catcher {

    private bool inTrade = false;

    public override void OnPointerClick(PointerEventData evd)
    {
        if (evd.button == PointerEventData.InputButton.Left)
        {
            inTrade = !inTrade;
        }
        Debug.Log("selectForTrade");
        Debug.Log(inTrade);

        if (inTrade)
        {
            transform.GetComponent<Image>().color = Color.cyan;
            transform.Find("Image").GetComponent<Image>().color = Color.cyan;
        } else
        {
            transform.GetComponent<Image>().color = Color.white;
            transform.Find("Image").GetComponent<Image>().color = Color.white;
        }

    }
   

    
}
