using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataImporter : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFile;
    [SerializeField] private DataClass data;

    void Start()
    {
        JsonConverter.LoadJson(jsonFile, out data);
    }
}

public static class JsonConverter
{
    public static void LoadJson<T>(TextAsset textFile, out T obj)
    {
        var textLines = textFile.text;
        obj = JsonUtility.FromJson<T>(textLines);
        Debug.Log("Json読み込み完了");
    }
}