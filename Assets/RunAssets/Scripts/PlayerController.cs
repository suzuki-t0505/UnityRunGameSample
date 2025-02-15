using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager _gameManager;

    public GameManager GameManager => _gameManager;

    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    void LateUpdate()
    {
        if (transform.position.y < -5f)
        {
            _gameManager.Reset();
        }
    }

    /// <summary>
    /// オブジェクトに触れた時に実行する
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // 取得したコインの枚数を増やす
            _gameManager.AddCoinCount();
            // コインを削除する
            Destroy(other.gameObject);
        }

        // ゴールに触れたらゴールの処理
        if (other.CompareTag("Finish"))
        {
            _gameManager.Goal();
        }
    }
}
