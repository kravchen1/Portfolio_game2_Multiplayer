using Photon.Pun;
using System.Collections;
using UnityEngine;
//using UnityEngine.
public class BulletController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        PhotonNetwork.Destroy(gameObject);
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HP_Bar>().minus_hp(20f);
        }
    }
}
