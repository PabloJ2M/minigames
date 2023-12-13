using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance) { Destroy(gameObject); return; }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayClip(AudioClip clip) => _source.PlayOneShot(clip);
}