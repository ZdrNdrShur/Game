using UnityEngine;

public class AudioHandler : MonoBehaviour {

    private AudioSource[] playerAudio;

    private void Start() {
        playerAudio = GetComponents<AudioSource>();
    }

    public void Jump() {
        playerAudio[0].Play();
    }

    public void Damage() {
        playerAudio[1].Play();
    }

    public void Death() {
        playerAudio[2].Play();
    }
}
