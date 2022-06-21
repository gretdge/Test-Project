using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float m_speedMovement;
    [SerializeField] private float m_speedRotate;

    [Space]
    [SerializeField] private float m_speedBullet;

    [SerializeField] private Transform m_firePoin;
    [SerializeField] private GameObject m_prefabBullet;
    [SerializeField] private Transform m_pointSpawn;

    private Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();        
    }

    public void SetMovement(Vector3 movementDirection)
    {

        m_rigidbody.AddRelativeForce(movementDirection * m_speedMovement * Time.deltaTime, ForceMode.Impulse);
    }

    public void SetRotate(float rotateDirection)
    {
        transform.Rotate(0, (rotateDirection * m_speedRotate * 10) * Time.deltaTime, 0);
    }

    public void SetShooting()
    {
        GameObject bullet = Instantiate(m_prefabBullet, m_firePoin.position, m_firePoin.rotation);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(m_firePoin.up * m_speedBullet, ForceMode.Impulse);
    }
}
