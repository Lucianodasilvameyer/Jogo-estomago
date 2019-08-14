using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffect : MonoBehaviour
{
    public static SoundEfecctScript Instance;

    public AudioClip destructionSoundBola;
    public AudioClip crushSoundBola;
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
    }
    public void MakeSomDeDestruicaoDaBola()
    {
        MakeSound (destructionSoundBola);
    }
    public void MakeSomDeBatidaDaBola()
    {
        MakeSound (crushSoundBola);
    }
    public void MakeSomDeDestruicaoDoTriangulo()
    {
        MakeSound(destructionSoundTriangulo);
    }
    public void MakeSomDeBatidaDoTriangulo()
    {
        MakeSound(crushSoundTriangulo);
    }
    public void MakeSomDeDestruicaoDoQuadrado()
    {
        MakeSound(destructionSoundQuadrado);
    }
    public void MakeSomDeBatidaDoQuadrado()
    {
        MakeSound(crushSoundQuadrado);
    }
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

}
