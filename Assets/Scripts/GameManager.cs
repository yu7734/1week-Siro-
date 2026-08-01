using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameOverUIObjects;
    [SerializeField] private TextMeshProUGUI gameOverText;
    private MaterCounter materCounter;

    private void Awake()
    {
        materCounter = GetComponent<MaterCounter>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < gameOverUIObjects.Length; ++i)
        {
            gameOverUIObjects[i].SetActive(false);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.text = materCounter.GetSetMaterCount.ToString("F2") + "MæŒ©‚½‚à‚Ì‚Æ‚ÍHI";
        for (int i = 0; i < gameOverUIObjects.Length; ++i)
            gameOverUIObjects[i].SetActive(true);
    }

    public void RETRY()
    {
        SceneManager.LoadScene("GameScene");
    }
}
