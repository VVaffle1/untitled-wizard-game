using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource musicClip;

    // Start is called before the first frame update
    void Awake()
    {
        musicClip.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
