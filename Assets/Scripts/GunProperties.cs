using UnityEngine;

public class GunProperties : MonoBehaviour {

    [SerializeField] private GameObject bullet;

    [SerializeField] private string gunName = "Pistol";

    public void Shoot() {
        GameObject newBullet = Instantiate(bullet, transform.parent.position, transform.parent.rotation);
        newBullet.GetComponent<BulletMovement>().SetGunCarrier(transform.parent.gameObject);
        newBullet.GetComponent<BulletMovement>().SetDirection(transform.parent.GetComponentInChildren<CameraMovement>().CurrentRotation); //keep everything above this line
    }

    //getters
    public string Name {
        get { return gunName; }
    }
}
