using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class GameSystem : MonoBehaviour {
 
    //　スタートボタンを押したら実行する
    public void OnClick() {
        SceneManager.LoadScene ("WorldInteractionDemo");
    }
}