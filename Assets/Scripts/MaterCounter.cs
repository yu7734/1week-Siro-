using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaterCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI materText;
    private float materCount = 0;

    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Count();
    }

    private void Count()
    {

        materCount += Time.deltaTime;
        materText.text = materCount.ToString("F2") + "M";
    }
}
