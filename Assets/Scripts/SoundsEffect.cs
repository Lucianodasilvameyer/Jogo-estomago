using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffect : MonoBehaviour
{
    public static SoundsEffect Instance;


    public AudioClip destructionSoundTriangulo;
    public AudioClip crushSoundTriangulo;
    public AudioClip destructionSoundQuadrado;
    public AudioClip crushSoundQuadrado;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Existem multiplas instancias do script SoundEffectScript.");

        }
        Instance = this;

        MakeSound(crushSoundQuadrado);
    }
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

}
