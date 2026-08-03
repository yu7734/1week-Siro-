using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using unityroom.Api;

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
        Time.timeScale = 1;
        for (int i = 0; i < gameOverUIObjects.Length; ++i)
        {
            gameOverUIObjects[i].SetActive(false);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.text = materCounter.GetSetMaterCount.ToString("F2") + "M先見たものとは？！";//テキスト表示
        UnityroomApiClient.Instance.SendScore(1, materCounter.GetSetMaterCount, ScoreboardWriteMode.HighScoreDesc);//スコアをunityroomのランキングに送る
        for (int i = 0; i < gameOverUIObjects.Length; ++i)
            gameOverUIObjects[i].SetActive(true);
    }

    public void RETRY()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QUIT()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
