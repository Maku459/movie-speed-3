using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showResult : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private Slider slider;
    //private adjustSpeed script;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        //script = slider.GetComponent<adjustSpeed>(); //Sliderの中にあるadjustSpeedを取得して変数に格納する
    }

    // Update is called once per frame
    
    /*
    void Update()
    {
        //string speed = script.speedSlider.value.ToString("F1");
        _text.text = slider.value.ToString("F1");
    }
    */
    
    public void OnClick()
    {
        _text.text = slider.value.ToString("F1");
    }
}
