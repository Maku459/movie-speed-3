using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using MiniJSON;
using UnityEngine;

public class DataDownloader : MonoBehaviour
{
    [SerializeField] private List<DataClass> box = new List<DataClass>();

    async void Start()
    {
        var t = Time.time;
        box = await FirebaseRepository.GetAllData<DataClass>();
        box = box.OrderBy(x => x.timeStamp).ToList();

        Debug.Log("fin : " + (Time.time - t));
    }
}