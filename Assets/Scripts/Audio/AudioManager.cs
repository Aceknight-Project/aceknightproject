using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource mAudioManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBGM(AudioClip music)
    {
        if (music == null || mAudioManager.clip == music) return;
        mAudioManager.Stop();
        mAudioManager.clip = music;
        mAudioManager.Play();
    }
}
