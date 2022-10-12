using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenBGM : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip TitleScreenMusic;
    void Start()
    {
        AudioSource.PlayClipAtPoint(TitleScreenMusic, Camera.main.transform.position);
    }
}
