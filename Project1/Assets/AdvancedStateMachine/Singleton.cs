using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public float timeTook = 0;
    public List<float> TopSpeeds = new List<float>();
    public static Singleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeedList()
    {
        TopSpeeds.Add(timeTook);
        TopSpeeds.Sort();
        TopSpeeds.Reverse();
        timeTook = 0;
    }
}