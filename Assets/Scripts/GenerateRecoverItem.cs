using UnityEngine;

public class GenerateRecoverItem : MonoBehaviour
{
    [SerializeField] private GameObject recoverItem;
    [SerializeField, Tooltip("生成する時間")] private float generateTime;
    private float gameTime = 0;//ゲームの時間
    int randomObject = 0;//配列の要素の乱数
    [SerializeField, Tooltip("X座標の最小位置")] private float minGeneratePositionX;
    [SerializeField, Tooltip("X座標の最大位置")] private float maxGeneratePositionX;
    [SerializeField, Tooltip("Y座標の最小位置")] private float minGeneratePositionY;
    [SerializeField, Tooltip("Y座標の最大位置")] private float maxGeneratePositionY;
    private float randomPositionX;
    private float randomPositionY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateObject();
    }

    private void GenerateObject()
    {
        randomPositionX = UnityEngine.Random.Range(minGeneratePositionX, maxGeneratePositionX);//X座標のランダム生成
        randomPositionY = UnityEngine.Random.Range(minGeneratePositionY, maxGeneratePositionY);//Y座標のランダム生成
        Vector3 generatePosition = new Vector3(randomPositionX, randomPositionY, transform.position.z);//ランダム生成の位置を宣言
        gameTime += Time.deltaTime;
        if (gameTime > generateTime)
        {
            Instantiate(recoverItem, generatePosition, Quaternion.identity);//ランダムなオブジェクトを生成
            gameTime = 0;
        }
    }
}
