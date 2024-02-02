using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AudioControl sınıfı, ses efektlerini yönetir.
public class AudioControl : MonoBehaviour
{
    // AudioSource bileşeni.
    AudioSource audioSource;

    // Balon ses efektlerini içeren liste.
    public List<AudioClip> audioClipBalon;

    // Bilgi ses efektlerini içeren liste.
    public List<AudioClip> audioClipInfo;

    // Başlangıçta çalışan metod.
    void Start()
    {
        // AudioSource bileşenini al.
        audioSource = GetComponent<AudioSource>();
    }

    // Sayıyı seslendiren metod.
    public void BaloonNumber(int index)
    {
        // Belirtilen indeksteki balon ses efektini ayarla ve oynat.
        audioSource.clip = audioClipBalon[index];
        audioSource.Play();
    }

    // Kaç balon kaldığını seslendiren metod.
    public void BaloonCount(int index)
    {
        // Belirtilen indeksteki bilgi ses efektini ayarla ve oynat.
        audioSource.clip = audioClipInfo[index];
        audioSource.Play();
    }
}
