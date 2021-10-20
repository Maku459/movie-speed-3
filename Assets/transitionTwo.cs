using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public class transitionTwo : MonoBehaviour {

    //　スタートボタンを押したら実行する
    public void OnClick() {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.LoadScene ("World_2");
    }
    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded (Scene nextScene, LoadSceneMode mode) {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        //float[] speedArray = new float[9] {0.8f, 0.85f, 0.9f, 0.95f, 1.0f, 1.05f, 1.1f, 1.15f, 1.2f};
        float[] speedArray = new float[8] {0.5f, 0.6f, 0.7f, 0.8f, 1.2f, 1.3f, 1.4f, 1.5f};
        
        //小数点以下第二位
        var firstSpeed = speedArray[Random.Range(0,8)];
        g.playbackSpeed = firstSpeed;
        Debug.Log(g.playbackSpeed);
    }
}