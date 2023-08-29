using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour {

    private const string playerTag = "Player";
    private const string enemyTag = "Enemy";

    private bool hasEnemies = false;

    private void OnTriggerEnter(Collider collision) {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.tag == playerTag) {
            for (int i = 0; i < transform.parent.childCount; i++) {
                if (transform.parent.GetChild(i).tag == enemyTag) {
                    hasEnemies = true;
                    break;
                }
            }
        }
        if (!hasEnemies) {
            SceneManager.LoadScene(0);
        }
    }
}
