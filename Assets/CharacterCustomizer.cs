using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomizer : MonoBehaviour
{

    [SerializeField] private GameObject[] players;
    private int playerIndex = 0;
    private GameObject player;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private GameObject slider;
    [SerializeField] private List<GameObject> oldList;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        oldList = new List<GameObject>();
        CreateMaterialCustomizer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateMaterialCustomizer()
    {

        Debug.Log(oldList.Count);
        foreach (GameObject old in oldList)
        {
            Destroy(old);
        }
        oldList.Clear();


        Material[] mats = player.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().materials;
        int yOff = 0;
        foreach(Material m in mats)
        {
            Debug.Log(m.name + " " + m.color);
            GameObject s = Instantiate(slider, uiPanel.transform) as GameObject;
            s.active = true;
            s.transform.position = s.transform.position + new Vector3(0,yOff, 0);
            s.GetComponent<ColorSelector>().setMaterial(m);
            s.GetComponent<ColorSelector>().setColor(m.color);
            s.GetComponent<ColorSelector>().setText(m.name.Split()[0]);
            yOff -= 60;
            oldList.Add(s);
        }
    }

    public void OnValueChanged(float test)
    {
        GameObject oldPlayer = player;
        playerIndex = Mathf.RoundToInt(test);
        Debug.Log(players[playerIndex]);
        player = Instantiate(players[playerIndex], oldPlayer.transform.position, Quaternion.identity) as GameObject;
        player.name = "Player";
        Destroy(oldPlayer);
        CreateMaterialCustomizer();
    }
}
