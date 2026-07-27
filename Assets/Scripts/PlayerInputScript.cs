using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Vector2 _inputMove = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //インスタンス生成
        inputActions = new InputSystem_Actions();

        //イベントの明示的な登録
        //移動イベントの登録
        inputActions.Player.Move.started += OnMove;
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;

        //InputSystemの有効化
        inputActions.Enable();
    }

    //生成したインスタンスの解放
    private void OnDisable()
    {
        inputActions?.Disable();
    }

    //移動イベント
    private void OnMove(InputAction.CallbackContext context)
    {
        //if (context.started)
        //{

        //}

        if (context.performed)
        {
            _inputMove = context.ReadValue<Vector2>();
        }

        if (context.canceled)
        {
            _inputMove = Vector2.zero;
        }
    }

    public Vector2 GetSetInputMove
    {
        // メンバ変数の値を取得するアクセサ
        get { return _inputMove; }
        set { _inputMove = value; }
    }
}
