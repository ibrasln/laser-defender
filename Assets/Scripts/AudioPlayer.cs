using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] List<AudioClip> audioClips;

    public static AudioPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayAudioClip(int index)
    {
        if (audioClips[index] != null)
        {
            AudioSource.PlayClipAtPoint(audioClips[index], Camera.main.transform.position, .25f);
        }
    }

}
