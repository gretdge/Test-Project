using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int m_speedBullet;
    [Space]
    [SerializeField] private Transform m_firePoin;
    [SerializeField] private GameObject m_prefabBullet;



    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Shooting"))
        {
            GameObject bullet = Instantiate(m_prefabBullet, m_firePoin.position, m_firePoin.rotation);
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(m_firePoin.up * m_speedBullet, ForceMode.Impulse);
            //rigidbody.AddForce(new Vector3(75, 0, 0));
        }
    }
}
