using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
//using DG.Tweening;
using UnityEngine;

public class RandomRoll : MonoBehaviour
{
    async void Start()
    {
        while (Application.isPlaying)
        {
            var randomPosition = Random.onUnitSphere + transform.position;
            Debug.DrawLine(transform.position, randomPosition);
            // transform.DOLookAt(randomPosition, 1);
            await UniTask.Delay(1000);
        }
    }
}