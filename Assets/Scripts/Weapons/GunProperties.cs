using UnityEngine;

public class GunProperties : MonoBehaviour {

    [SerializeField] private GameObject bullet;
    [SerializeField] private Sprite gunSprite;

    [SerializeField] private string weaponName;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private bool isAuto;

    private bool hasShot = false;

    public void Shoot(GameObject weapon) {
        if (!hasShot) {
            GameObject newBullet = Instantiate(bullet, weapon.transform.position, weapon.transform.rotation);
            newBullet.GetComponent<BulletMovement>().SetGunCarrier(transform.parent.gameObject);
            newBullet.GetComponent<BulletMovement>().SetDirection(transform.parent.GetComponentInChildren<CameraMovement>().CurrentRotation);
            newBullet.GetComponent<BulletMovement>().SetInitialPosition(weapon.transform.position);    //every function for the instance should be above this line
            hasShot = true;
            Invoke(nameof(CanShootAgain), timeBetweenShots);
        }
    }

    private void CanShootAgain() {
        hasShot = false;
    }

    //getters
    public Sprite Sprite {
        get { return gunSprite; }
    }
    public string Name {
        get { return weaponName; }
    }
    public bool Auto {
        get { return isAuto; }
    }
    public string ItemName() {
        return "WEAPON" + weaponName;
    }

    //setters
    public void ToggleAuto() {
        isAuto = !isAuto;
    }
}
