using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの移動速度")] private float playerMoveSpeed;
    private CharacterController characterController;
    private PlayerInputScript playerInputScript;
    [SerializeField] private GameManager gameManager;
    [Header("プレイヤーの移動範囲")]
    [SerializeField, Tooltip("横移動の最小")] private float minPlayerRangeX;
    [SerializeField, Tooltip("横移動の最大")] private float maxPlayerRangeX;
    [SerializeField, Tooltip("縦移動の最小")] private float minPlayerRangeY;
    [SerializeField, Tooltip("縦移動の最大")] private float maxPlayerRangeY;

    [SerializeField] private MoistureGaugeManager moistureGauge;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInputScript = GetComponent<PlayerInputScript>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        //入力に応じて移動
        var moveVelocity = new Vector3(playerInputScript.GetSetInputMove.x * playerMoveSpeed, playerInputScript.GetSetInputMove.y * playerMoveSpeed, 0);
        characterController.Move(moveVelocity * Time.deltaTime);

        Vector3 currentPosition = this.transform.position;//現在の位置
        currentPosition.x = Mathf.Clamp(currentPosition.x, minPlayerRangeX, maxPlayerRangeX);//X軸の移動範囲
        currentPosition.y = Mathf.Clamp(currentPosition.y, minPlayerRangeY, maxPlayerRangeY);//Y軸の移動範囲
        this.transform.position = currentPosition;//現在の位置をcurrentPositionにする
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();//障害物に触れたらゲームオーバー
        }
        else if (collision.gameObject.tag == "recovery")
        {
            Destroy(collision.gameObject);
            moistureGauge.GetSetCurrentGauge += moistureGauge.GetSetMaxGaugeTime / 5;//回復アイテムに触れたらゲージを回復
        }
    }
}
