using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_minSpeed;
    [SerializeField] private float m_checkTime;

    private float m_CurrectTime;

    private Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_CurrectTime = Time.time;
    }

    private void Update()
    {
        float bulletTime = Time.time - m_CurrectTime;
        float bulletSpeed = m_rigidbody.velocity.magnitude;
        if (bulletTime > m_checkTime && bulletSpeed <= m_minSpeed)
        {
            Destroy(gameObject);            
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && gameObject.tag != "Bullet" || col.gameObject.tag == "Enemy" && gameObject.tag != "BulletEnemy")
        {
            GameManager.Instance.Respawn(col.gameObject.tag);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

}
