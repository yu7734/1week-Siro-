using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MoistureGaugeManager : MonoBehaviour
{
    [SerializeField] private Image gaugeImage;
    [SerializeField] private float gaugeTime;
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
        currentGauge = gaugeTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentGauge -= Time.deltaTime;
        gaugeImage.fillAmount = currentGauge / gaugeTime;
    }
}
