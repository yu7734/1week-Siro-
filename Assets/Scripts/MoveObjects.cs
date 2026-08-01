using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField, Tooltip("移動速度")] private float ObjectMoveSpeed;
    [SerializeField, Tooltip("オブジェクトを削除する位置")] private float destroyTransform;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ObjectMove();
    }

    private void ObjectMove()
    {
        rigidbody.linearVelocity = new Vector3(0, 0, -ObjectMoveSpeed);//プレイヤーの方面に向かって移動
        if (transform.position.z < destroyTransform) Destroy(this.gameObject);//一定の位置に来たらオブジェクトを破壊
    }
}
