using Photon.Pun;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviourPunCallbacks
{
    private Rigidbody rb;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    public Weapon weapon;
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject Bullet = null;

    [SerializeField]
    private Transform stvol;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }


    void FixedUpdate()
    {
        PerformMove();
        PerformRotation();
        
    }
    void PerformMove()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        if (rotation != Vector3.zero)
        {
            rb.transform.LookAt(rotation);
        }
    }

    public void Jump(float force)
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    public void Shoot()
    {
        RaycastHit _hit;
        GameObject bullet = PhotonNetwork.Instantiate(Bullet.name, stvol.position, stvol.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(stvol.forward * weapon.range, ForceMode.Impulse);
        if (Physics.Raycast(stvol.position, stvol.forward, out _hit, weapon.range,mask))
        {

        }
    }

}
