using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// コインの取得枚数を表示するテキスト
    /// </summary>
    TextMeshProUGUI _countText;

    /// <summary>
    /// ゴールしたときに表示するテキスト群
    /// </summary>
    GameObject _goalText;
    
    void Start()
    {
        _countText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        _goalText = GameObject.Find("GoalText");

        ResetUI();
    }

    /// <summary>
    /// コインを取得した時にコインの取得枚数のテキストを更新する
    /// </summary>
    /// <param name="count"></param>
    public void SetCoinText(int count)
    {
        _countText.text = $"Coin:{count}";
    }

    /// <summary>
    /// プレイヤーがゴールしたときにテキストを表示する
    /// </summary>
    public void SetGoalText()
    {
        _goalText.SetActive(true);
    }

    /// <summary>
    /// UI表示を初期状態に戻す
    /// </summary>
    public void ResetUI()
    {
        _countText.text = "Coin:0";
        _goalText.SetActive(false);
    }
}
