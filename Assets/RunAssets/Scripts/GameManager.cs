using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 取得したコインの枚数
    /// </summary>
    int _coinCount = 0;

    /// <summary>
    /// フィールドにあるコインの最大枚数
    /// </summary>
    int _maxCoinCount = 0;

    /// <summary>
    /// ゴールにたどり着いたか？
    /// </summary>
    bool _isGoal = false;

    /// <summary>
    /// UIMangerを取得
    /// </summary>
    UIManager _uiManager;

    /// <summary>
    /// プレイヤーの位置
    /// </summary>
    Transform _player;

    /// <summary>
    /// スタート位置
    /// </summary>
    Transform _start;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
        _player = GameObject.FindWithTag("Player").transform;
        _start = GameObject.FindWithTag("Respawn").transform;

        _coinCount = 0;
        _maxCoinCount = GameObject.FindGameObjectsWithTag("Coin").Count();
    }

    /// <summary>
    /// プレイヤーがゴールしたときの処理
    /// </summary>
    public void Goal()
    {
        // コインを全て取得したらゴールできる
        if (_coinCount == _maxCoinCount)
        {
            _uiManager.SetGoalText();
            _isGoal = !_isGoal;
        }
    }

    /// <summary>
    /// リセット処理
    /// </summary>
    public void Reset()
    {
        // プレイヤーの座標をスタート位置に戻す
        _player.position = new Vector3(x: _start.position.x, y: 1f, z: _start.position.z);
    }

    /// <summary>
    /// プレイヤーがコインを取得したときコインの枚数を増やす
    /// </summary>
    public void AddCoinCount()
    {
        _coinCount++;
        _uiManager.SetCoinText(_coinCount);
    }
}
