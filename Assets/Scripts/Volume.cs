using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicSource;
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
