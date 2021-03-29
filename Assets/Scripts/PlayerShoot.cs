using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : MonoBehaviourPunCallbacks
{
    public Weapon weapon;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject Bullet = null;
    void Start()
    {
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        //RaycastHit _hit;
        GameObject bullet = PhotonNetwork.Instantiate(Bullet.name, transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * weapon.range, ForceMode.Impulse);
        //if (Physics.Raycast(PlayerTransform.position, PlayerTransform.forward, out _hit, weapon.range,mask))
        //{
            
        //}
    }
}
