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
                float scale = Random.Range(0.0f,1.0f);
                float hue = Random.RandomRange(0.05f, .137f);
                float s = (.73f-.35f)*scale + .35f;
                float v = (1.0f - .24f) * (1-scale) + .24f; 


                m.color = Color.HSVToRGB(hue, s, v);
            }
            else if (m.name.Contains("Hair"))
            {
                float scale = Random.Range(0.0f, 1.0f);
                float hue = Random.RandomRange(0.04f, .14f);
                float s = (.73f - .35f) * scale + .35f;
                float v = (1.0f - .00f) * (1 - scale) + .00f;


                m.color = Color.HSVToRGB(hue, s, v);
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
