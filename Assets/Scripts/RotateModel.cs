using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    // public Transform modelTrans;
    private bool isRotate;
    private Vector3 startPoint;
    private Vector3 startAngle;
    [Range(0.1f, 1f)] public float rotateScale = 0.8f;

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0) && !isRotate)
    //     {
    //         isRotate = true;
    //         startPoint = Input.mousePosition;
    //         startAngle = transform.eulerAngles;
    //     }
    //
    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         isRotate = false;
    //     }
    //
    //     if (isRotate)
    //     {
    //         var currentPoint = Input.mousePosition;
    //         var x = startPoint.x - currentPoint.x;
    //         // 改变y 当前 = 初始+鼠标拖动变化量
    //         transform.eulerAngles = startAngle + new Vector3(0, x * rotateScale, 0);
    //     }
    // }
    
    public void BeginDrag()
    {
        isRotate = true;
        startPoint = Input.mousePosition;
        startAngle = transform.eulerAngles;
    }
    
    public void Drag()
    {
        if (isRotate)
        {
            var currentPoint = Input.mousePosition;
            var x = startPoint.x - currentPoint.x;
            // 改变y 当前 = 初始+鼠标拖动变化量
            transform.eulerAngles = startAngle + new Vector3(0, x * rotateScale, 0);
        }
    }
    
    public void EndDrag()
    {
        isRotate = false;
    }
}