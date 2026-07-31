using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MoistureGaugeManager : MonoBehaviour
{
    [SerializeField] private Image gaugeImage;
    [SerializeField] private float maxGaugeTime;
    private float currentGauge;
    private float timer;

    private void Awake()
    {
        gaugeImage = GetComponent<Image>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gaugeImage.fillAmount = 1;
        currentGauge = maxGaugeTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentGauge -= Time.deltaTime;
        gaugeImage.fillAmount = currentGauge / maxGaugeTime;//ゲージを減らす
    }

    public float GetSetCurrentGauge { get { return currentGauge; } set { currentGauge = value; } }//現在のゲージ変数のアクセッサ
    public float GetSetMaxGaugeTime { get { return maxGaugeTime; } set { maxGaugeTime = value; } }//最大時間変数のアクセッサ
}
