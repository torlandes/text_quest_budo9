using System;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _movesCount;

    #endregion

    #region Properties

    public int MovesCount
    {
        get => _movesCount;
        set => _movesCount = value;
    }

    #endregion

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}