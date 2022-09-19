using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points instance;

    [SerializeField] private PointsPlacement currentPoint;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance == this) Destroy(instance);
    }

    public void SavePoint(PointsPlacement point)
    {
        currentPoint = point;

    }
    public PointsPlacement CurrentPoint()
    {
        return currentPoint;
    }
}

