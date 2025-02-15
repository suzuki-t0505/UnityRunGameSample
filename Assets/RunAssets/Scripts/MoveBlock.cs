using UnityEngine;

enum Direction {
    X,
    Y,
    Z
}

public class MoveBlock : MonoBehaviour
{
    [Header("ブロックを動かす向き（X：左右/Y：上下/Z：前後）")]
    [SerializeField] Direction _direction;

    [Header("ブロックを動かす速度")]
    [SerializeField] float _moveSpeed = 2f;

    [Header("ブロックの最大移動幅")]
    [SerializeField] float _moveRange = 3f;

    /// <summary>
    /// ブロックの最初の位置
    /// </summary>
    Vector3 _defaultPos;

    /// <summary>
    /// ブロックの移動方向の管理
    /// </summary>
    bool _moveForward = true;

    void Start()
    {
        // ブロックの初期位置を記録
        _defaultPos = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(_defaultPos, transform.position) >= _moveRange)
        {
            // 指定した移動幅に達したら逆方向に向ける
            _moveForward = !_moveForward;
        }

        switch(_direction)
        {
            case Direction.X:
                MoveX();
                break;
            case Direction.Y:
                MoveY();
                break;
            case Direction.Z:
                MoveZ();
                break;
        }
    }

    /// <summary>
    /// ブロックをX方向（左右）に移動させる
    /// </summary>
    void MoveX()
    {
        Vector3 moveDirection = _moveForward ? Vector3.right : Vector3.left;
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// ブロックをy方向（上下）に移動させる
    /// </summary>
    void MoveY()
    {
        Vector3 moveDirection = _moveForward ? Vector3.up : Vector3.down;
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// ブロックをz方向（前後）に移動させる
    /// </summary>
    void MoveZ()
    {
        Vector3 moveDirection = _moveForward ? Vector3.forward : Vector3.back;
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }
}
