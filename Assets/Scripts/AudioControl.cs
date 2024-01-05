using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> audioClipBalon;
    public List<AudioClip> audioClipInfo;
    void Start()    {       audioSource= GetComponent<AudioSource>();    }

    public void BaloonNumber(int index) //Sayiyi Seslendir
    {
        audioSource.clip = audioClipBalon[index];
        audioSource.Play();
    }
    public void BaloonCount(int index) //Kac balon kaldi seslendir
    {
        
        audioSource.clip = audioClipInfo[index];
        audioSource.Play();
    }
  
}
