using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    public GameObject music;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy the duplicate instance
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keep this instance alive between scenes
    }
}