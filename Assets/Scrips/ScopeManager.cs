using UnityEngine;
using UnityEngine.UI;

public class ScopeManager : MonoBehaviour
{
    [SerializeField] private Text m_score;


    private void Start()
    {
        m_score.text = GameManager.Instance.Scope;
    }
}
