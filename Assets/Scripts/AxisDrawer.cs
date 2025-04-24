using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AxisDrawer : MonoBehaviour
{
    public static event Action<CustomAxis> OnAxisDraw;

    [SerializeField] private CustomAxis xAxis;
    [SerializeField] private CustomAxis yAxis;
    [SerializeField] private CustomAxis zAxis;

    [SerializeField] private Transform originPosition;

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = xAxis.AxisColor;
    //    Gizmos.DrawRay(originPosition.position, xAxis.AxisVector);
    //    Gizmos.DrawRay(originPosition.position, -xAxis.AxisVector);

    //    Gizmos.color = yAxis.AxisColor;
    //    Gizmos.DrawRay(originPosition.position, yAxis.AxisVector);
    //    Gizmos.DrawRay(originPosition.position, -yAxis.AxisVector);

    //    Gizmos.color = zAxis.AxisColor;
    //    Gizmos.DrawRay(originPosition.position, zAxis.AxisVector);
    //    Gizmos.DrawRay(originPosition.position, -zAxis.AxisVector);
    //}
    private void OnDrawGizmos()
    {
        DrawAxis(xAxis);
        DrawAxis(yAxis);
        DrawAxis(zAxis);
    }
    private void DrawAxis(CustomAxis axis)
    {
        Gizmos.color = axis.AxisColor;
        Gizmos.DrawRay(originPosition.position, axis.AxisVector);
        Gizmos.DrawRay(originPosition.position, -axis.AxisVector);
        OnAxisDraw?.Invoke(axis);
    }
    
}

[System.Serializable]
public struct CustomAxis
{
    public string AxisName;
    public Color AxisColor;
    public Vector3 AxisDirection;
    public float AxisMagnitude;

    public Vector3 AxisVector => AxisDirection * AxisMagnitude;
}
