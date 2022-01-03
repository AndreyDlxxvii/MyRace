using System;
using UnityEngine;

public class CarView : MonoBehaviour
{
    [SerializeField] private Transform _windowTransform;
    [SerializeField] private Transform _weightTransform;
    [SerializeField] private Transform _springLeftTransform;
    [SerializeField] private Transform _springRightTransform;
    [SerializeField] private Transform _tireLeftTransform;
    [SerializeField] private Transform _tireRightTransform;

    public Transform WindowTransform => _windowTransform;

    public Transform WeightTransform => _weightTransform;

    public Transform SpringLeftTransform => _springLeftTransform;

    public Transform SpringRightTransform => _springRightTransform;

    public Transform TireLeftTransform => _tireLeftTransform;

    public Transform TireRightTransform => _tireRightTransform;
}
