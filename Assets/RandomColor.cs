using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        generateColors();
    }

    public void generateColors()
    {
        Material[] mats = GetComponent<SkinnedMeshRenderer>().materials;

        foreach (Material m in mats)
        {
            if (m.name.Contains("Skin"))
            {
                m.color = Color.HSVToRGB(Random.RandomRange(11f, 15f)/100f, Random.RandomRange(40, 70f)/100f, Random.RandomRange(50f, 95f)/100f);
                Debug.Log(m.color);
            }
            else if (m.name.Contains("Hair"))
            {
                m.color = Color.HSVToRGB(Random.RandomRange(11f, 20f) / 100f, Random.RandomRange(40, 70f) / 100f, Random.RandomRange(0f, 95f) / 100f);
            }
            else
            {
                m.color = Random.ColorHSV();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            generateColors();
        }
    }
}
