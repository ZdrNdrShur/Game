using UnityEngine;

public class EnemyHealthBar : MonoBehaviour {

    public void ReduceHealth(float health, int maxHealth) {
        transform.localScale = new Vector3(transform.localScale.x * (health / maxHealth), transform.localScale.y, transform.localScale.z);
    }
}
