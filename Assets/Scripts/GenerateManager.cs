using System;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    [SerializeField, Tooltip("障害物")] private GameObject[] gameObjects;
    [SerializeField, Tooltip("生成する時間")] private float generateTime;
    private float gameTime = 0;//ゲームの時間
    int randomObject = 0;//配列の要素の乱数
    [SerializeField, Tooltip("X座標の最小位置")] private float minGeneratePositionX;
    [SerializeField, Tooltip("X座標の最大位置")] private float maxGeneratePositionX;
    [SerializeField, Tooltip("Y座標の最小位置")] private float minGeneratePositionY;
    [SerializeField, Tooltip("Y座標の最大位置")] private float maxGeneratePositionY;
    private float randomPositionX;
    private float randomPositionY;

    // Update is called once per frame
    void Update()
    {
        GenerateObject();
    }

    private void GenerateObject()
    {
        randomObject = UnityEngine.Random.Range(0, gameObjects.Length);
        randomPositionX = UnityEngine.Random.Range(minGeneratePositionX, maxGeneratePositionX);//X座標のランダム生成
        randomPositionY = UnityEngine.Random.Range(minGeneratePositionY, maxGeneratePositionY);//Y座標のランダム生成
        Vector3 generatePosition = new Vector3(randomPositionX, randomPositionY, transform.position.z);//ランダム生成の位置を宣言
        gameTime += Time.deltaTime;
        if (gameTime > generateTime)
        {
            Instantiate(gameObjects[randomObject], generatePosition, Quaternion.identity);//ランダムなオブジェクトを生成
            gameTime = 0;
        }
    }
}
