using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MiniJSON;
using UnityEngine;
using UnityEngine.Networking;

// 投稿するデータの型。好きに追加、削除していい。
[Serializable]
public class DataClass
{
    public int id;
    public string device;
    public int scene;
    public bool framebool;
    public string timeStamp;
    public List<Vector3> rotation;
    
    // タイムスタンプを設定
    public string SetTimeStamp()
    {
        timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        return timeStamp;
    }
}


public static class FirebaseRepository
{
    private const string FirebaseUrl = "https://movie-speed-qu-default-rtdb.firebaseio.com/";
    private const string StorageName = "questrecord";
    
    public static GameObject parent;
    public static GameObject frame;

    // アップロード系の関数
    public static async void PushDataToFirebaseWithTimestamp(DataClass data)
    {
        var timeStamp = data.SetTimeStamp();
        
        parent = GameObject.Find("Main Camera");
        frame = parent.transform.Find("Frame").gameObject;
        Debug.Log(frame);
        if (frame.activeSelf)
        {
            data.framebool = true;
        }
        else
        {
            data.framebool = false;
        }
        await PushDataToFirebase<DataClass>(data, timeStamp);
    }

    public static async UniTask PushDataToFirebase<T>(T data, string dataName)
    {
        // URL生成
        var url = FirebaseUrl + StorageName + "/" + dataName + "/.json";

        // インスタンスをJSONに変換
        var myJson = JsonUtility.ToJson(data);

        // バイト配列に変換
        var byteData = System.Text.Encoding.UTF8.GetBytes(myJson);

        // リクエスト生成＆送信
        var request = new UnityWebRequest(url, "PATCH");
        request.uploadHandler = new UploadHandlerRaw(byteData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // 完了待機
        await request.SendWebRequest();

        // 結果通知
        var isSuccess = request.result == UnityWebRequest.Result.ConnectionError;
        if (isSuccess) Debug.Log("アップロード失敗" + request.error);
        else Debug.Log("アップロード完了");
    }

    // ダウンロード系の関数

    // すべてのデータをダウンロードし、jsonからTにパースしてリストで返す。下の方の関数を連結することで実現してる。
    public static async UniTask<List<T>> GetAllData<T>()
    {
        // JsonUtilityの仕様で、Realtime Databaseの全体をパースできない。<string, obj>にパースできない。
        // なので、それが可能なOSSのMiniJsonをkeyの取得にだけ使う。

        // keyの取得（shallowクエリ）
        var text = await FirebaseRepository.GetDataKeys();
        var dictionary = Json.Deserialize(text) as Dictionary<string, object>;
        var keys = dictionary?.Select(x => x.Key);
        if (keys is null) return null;
        

        var list = await keys.Select(async key =>
        {
            var d = await GetDataIndividual(key);
            var t = JsonUtility.FromJson<T>(d);
            return t;
        });

        return list.ToList();
    }

    public static async UniTask<string> GetDataKeys()
    {
        var url = FirebaseUrl + StorageName + ".json?shallow=true";
        return await GetDataFromFirebase(url);
    }

    public static async UniTask<string> GetDataWithQuery(string query)
    {
        var url = FirebaseUrl + StorageName + ".json" + query;
        return await GetDataFromFirebase(url);
    }

    public static async UniTask<string> GetDataIndividual(string dataName)
    {
        var url = FirebaseUrl + StorageName + "/" + dataName + ".json";
        return await GetDataFromFirebase(url);
    }

    public static async UniTask<string> GetDataFromFirebase(string url)
    {
        var request = UnityWebRequest.Get(url);
        Debug.Log(url + "をリクエスト。");
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            throw new Exception("通信エラーだよ！");
        }
        else
        {
            Debug.Log("ダウンロード完了");
            return request.downloadHandler.text;
        }
    }
}