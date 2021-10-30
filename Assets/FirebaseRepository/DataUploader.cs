using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DataUploader : MonoBehaviour
{
    [SerializeField] private DataClass data;
    [SerializeField] private Transform target;

    private async void Start()
    {
        while (Application.isPlaying)
        {
            data.rotation.Add(target.rotation.eulerAngles);
            await UniTask.Delay(1000);
        }
    }

    public void OnClick()
    {
        FirebaseRepository.PushDataToFirebaseWithTimestamp(data);
    }
}