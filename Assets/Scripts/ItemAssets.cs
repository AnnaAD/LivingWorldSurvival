using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite stickSprite;
    public Sprite stoneSprite;
    public Sprite mushroomSprite;
    public Sprite meatSprite;
    public Sprite matchesSprite;
    public Sprite tentSprite;
    public Sprite knifeSprite;


    public GameObject stickPrefab;
    public GameObject stonePrefab;
    public GameObject mushroomPrefab;
    public GameObject meatPrefab;
    public GameObject matchesPrefab;
    public GameObject tentPrefab;
    public GameObject knifePrefab;

    public GameObject deployedTent;
    public GameObject deployedFire;

}
