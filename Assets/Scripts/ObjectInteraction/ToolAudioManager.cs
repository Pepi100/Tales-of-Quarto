using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAudioManager : MonoBehaviour
{
    #region Singleton
    public static ToolAudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField]
    private AudioSource _audioSource;
    public void Play()
    {
        _audioSource.Play();
    }
}
