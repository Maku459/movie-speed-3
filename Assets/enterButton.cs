using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class enterButton : MonoBehaviour
{
    public Text firstText;
    public Text resultText;
    
    [SerializeField]
    private Text _time;

    private readonly char[] _buffer = new char[5];

    private float _awakeTime;
    private int _lastSecondsSinceAwake;

    // Start is called before the first frame update
    void Start()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        //firstText.text = g.playbackSpeed.ToString("F2");
        int firstHundred = (int) (g.playbackSpeed * 100);
        firstText.text = System.Convert.ToString(firstHundred, 16);
        _awakeTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    public void OnClick()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        //resultText.text = g.playbackSpeed.ToString("F2");
        int resultHundred = (int) (g.playbackSpeed * 100);
        resultText.text = System.Convert.ToString(resultHundred, 16);
        firstText.color = new Color(1.0f,1.0f,1.0f,1.0f);
        
        var secondsSinceAwake = (int)(Time.realtimeSinceStartup - _awakeTime);
        if (_lastSecondsSinceAwake != secondsSinceAwake)
        {
            int minutes = secondsSinceAwake / 60;
            _buffer[0] = (char)('0' + minutes / 10);
            _buffer[1] = (char)('0' + minutes % 10);

            _buffer[2] = ':';

            int seconds = secondsSinceAwake % 60;
            _buffer[3] = (char)('0' + seconds / 10);
            _buffer[4] = (char)('0' + seconds % 10);

            _time.text = new string(_buffer);

            _lastSecondsSinceAwake = secondsSinceAwake;
        }
    }
}
