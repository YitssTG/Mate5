using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CubeDrawer : MonoBehaviour
{
    public static event Action<Vector3, Vector3> OnCubeTranformed;

    [SerializeField] private Vector3 translationVector;
    [SerializeField] private Vector3 scaleVector;
    [SerializeField] private PivotDrawer[] pivots;

    private void FixedUpdate()
    {
        foreach (PivotDrawer points in pivots)
        {
            points.TranslatePivot(translationVector);
            points.ScalePivot(scaleVector);
        }
        OnCubeTranformed?.Invoke(translationVector, scaleVector);
    }
    private void OnEnable()
    {
        PivotDrawer.OnPivotTranslated += HandleTranslation;
        CubeDrawer.OnCubeTranformed += HandleCubeUpdate;
    }
    private void OnDisable()
    {
        PivotDrawer.OnPivotTranslated -= HandleTranslation;
        CubeDrawer.OnCubeTranformed -= HandleCubeUpdate;
    }
    private void HandleTranslation(PivotDrawer pivot, Vector3 translation)
    {
        Debug.Log($"Pivote{pivot.name} fue movido :{translation}");
    }
    private void HandleCubeUpdate(Vector3 translation , Vector3 scale)
    {
        Debug.Log($"Cubo actualizado - Translacion: {translation}, Escala: {scale}");
    }
}