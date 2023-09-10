using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour {

    private const string playerTag = "Player";
    private const string enemyTag = "Enemy";

    private bool hasEnemies;

    private void OnTriggerEnter(Collider collision) {
        hasEnemies = false;
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.CompareTag(playerTag)) {
            for (int i = 0; i < transform.parent.childCount; i++) {
                if (transform.parent.GetChild(i).CompareTag(enemyTag)) {
                    hasEnemies = true;
                    break;
                }
            }
            if (!hasEnemies) {
                SceneManager.LoadScene(0);
            }
        }
    }
}
