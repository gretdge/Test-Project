using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");

                DontDestroyOnLoad(go);

                instance = go.AddComponent<GameManager>();
            }
                
            return instance;
        }
    }

    private int m_winPlayer = 0;
    private int m_winEnemy = 0;

    private bool m_isRespawnProccess = false;
    
    public string Scope { get => "Player " + m_winPlayer.ToString() + " : " + m_winEnemy.ToString() + " Enemy"; }
    public bool IsRespawn { get => m_isRespawnProccess; set => m_isRespawnProccess = value; }

    public void Respawn(string loser)
    {
        if (m_isRespawnProccess) return;

        if (loser == "Player")
        {
            ++m_winEnemy;
        }
        else
        {
            ++m_winPlayer;
        }

        SceneManager.LoadScene(0);
    }
}
