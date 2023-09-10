using UnityEngine;

public class FrameRateCap : MonoBehaviour {

    [SerializeField] private int targetFrameRate = 600;

    private void Start() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}