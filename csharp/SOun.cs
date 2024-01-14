using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOun : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] private float rotatespeed;
    void Start()
    {
        car.DORotate(new Vector3(0, 360, 0), rotatespeed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
    }
}
