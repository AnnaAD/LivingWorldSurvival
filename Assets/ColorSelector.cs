using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{

    [SerializeField] private Slider rSlider;
    [SerializeField] private Slider gSlider;
    [SerializeField] private Slider bSlider;

    [SerializeField] private Text text;




    public Color color;
    private Material m;


    // Start is called before the first frame update
    void Start()
    {
        rSlider.onValueChanged.AddListener(delegate { updateRed(); }) ;
        gSlider.onValueChanged.AddListener(delegate { updateGreen(); });
        bSlider.onValueChanged.AddListener(delegate { updateBlue(); });

    }


    public void updateRed()
    {
        color.r = rSlider.value;
        m.color = color;

    }

    public void updateGreen()
    {
        color.g = gSlider.value;
        m.color = color;
    }

    public void setMaterial(Material mat)
    {
        m = mat;
    }
    public void setText(string s)
    {
        text.text = s;
    }
    public void updateBlue()
    {
        color.b = bSlider.value;
        m.color = color;

    }
    public void setColor(Color c)
    {
        color = c;
        rSlider.value = c.r;
        gSlider.value = c.g;
        bSlider.value = c.b;
    }
}
