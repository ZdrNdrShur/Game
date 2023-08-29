using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options() {
        //todo
    }

    public void Exit() {
        Application.Quit();
    }
}
