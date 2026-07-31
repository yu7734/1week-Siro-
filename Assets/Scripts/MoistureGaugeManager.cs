using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class MoistureGaugeManager : MonoBehaviour
{
    [SerializeField] private Image gaugeImage;
    [SerializeField] private float maxGaugeTime;
    private float currentGauge;

    [SerializeField] private Volume volume;
    private DepthOfField depth;
    [SerializeField, Tooltip("ぼかしの最大数値")] private float maxDepth;
    [SerializeField, Tooltip("ぼかしの最小数値")] private float minDepth;

    private void Awake()
    {
        gaugeImage = GetComponent<Image>();
        volume.profile.TryGet<DepthOfField>(out depth);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gaugeImage.fillAmount = 1;
        currentGauge = maxGaugeTime;
        depth.focusDistance.value = maxDepth;
    }

    // Update is called once per frame
    void Update()
    {
        MoistureGauge();
    }

    private void MoistureGauge()
    {
        currentGauge -= Time.deltaTime;//時間が経つにつれてゲージを減らす
        gaugeImage.fillAmount = currentGauge / maxGaugeTime;//画像のゲージを減らす
        depth.focusDistance.value = currentGauge / maxDepth;//ゲージによってぼかすようにする
        if (depth.focusDistance.value < minDepth) depth.focusDistance.value = minDepth;//最小ぼかしまでとどめる
        else if (depth.focusDistance.value > maxDepth) depth.focusDistance.value = maxDepth;//最大ぼかしまでとどめる
    }

    public float GetSetCurrentGauge { get { return currentGauge; } set { currentGauge = value; } }//現在のゲージ変数のアクセッサ
    public float GetSetMaxGaugeTime { get { return maxGaugeTime; } set { maxGaugeTime = value; } }//最大時間変数のアクセッサ
}
