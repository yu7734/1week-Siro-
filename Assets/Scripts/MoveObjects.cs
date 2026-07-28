using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField, Tooltip("移動速度")] private float ObjectMoveSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ObjectMove();
    }

    private void ObjectMove()
    {
        rigidbody.linearVelocity = new Vector3(0, 0, -ObjectMoveSpeed);//プレイヤーの方面に向かって移動
    }
}
