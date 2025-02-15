using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("コインの回転速度")]
    [SerializeField] float _rotateSpeed = 10f;

    void Update()
    {
        // コインを回転させる
        transform.Rotate(Vector3.up * _rotateSpeed * 10 * Time.deltaTime);
    }
}
