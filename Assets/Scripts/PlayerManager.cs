using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの移動速度")] private float playerMoveSpeed;
    private CharacterController characterController;
    private PlayerInputScript playerInputScript;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInputScript = GetComponent<PlayerInputScript>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
