using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(HP_Bar))]
public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float JumpForce = 10f;

    private PlayerMotor motor;
    private PlayerShoot shoot;

   // private PhotonView _PhotonView = new PhotonView();
    private Camera cam;
    private Transform camPos;
    private HP_Bar HP;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /*
        if(stream.IsWriting)
        {
            stream.SendNext(isRed);
        }
        else
        {
            isRed = (bool)stream.ReceiveNext();
        }
        */
    }

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        //_PhotonView = GetComponent<PhotonView>();
        cam = Camera.main;
        camPos = cam.transform;
        HP = GetComponent<HP_Bar>();
        //Cursor.visible = false;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            #region move
            float xMov = Input.GetAxisRaw("Horizontal");
            float zMov = Input.GetAxisRaw("Vertical");

            Vector3 moveHor = transform.right * xMov;
            Vector3 moveVer = transform.forward * zMov;

            Vector3 velocity = (moveHor + moveVer).normalized * speed;

            motor.Move(velocity);
            #endregion

            #region rotate

            Vector3 mousePosMain = Input.mousePosition;
            mousePosMain.z = camPos.position.y;
            Vector3 lookPos = cam.ScreenToWorldPoint(mousePosMain);
            lookPos.y = transform.position.y;

            motor.Rotate(lookPos);

            #endregion

            if (Input.GetButtonDown("Fire1"))
            {
                motor.Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                motor.Jump(JumpForce);
            }
        }
    }
}
