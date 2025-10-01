using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    [SerializeField] private Handler _handler;

    [SerializeField] public int ChanceMax {  get; private set; }
    [SerializeField] public int CurrentChance { get; private set; }
    [SerializeField] public int ReductionFactor { get; private set; }

    private void OnEnable()
    {
        _handler.Destroyer += Destroyer;
    }
    private void OnDisable()
    {
        _handler.Destroyer -= Destroyer;
    }

    private void Destroyer()
    {
        Destroy(gameObject);
        CurrentChance /= ReductionFactor;
    }
}
