using UnityEngine;

public class SpawnApple : SpawnManager
{
    // 喚醒：在 Start 前執行一次
    private void Awake()
    {
        // 取得 GM 內的蘋果間隔與第一次生成
        interval = GameManager.appleInterval;
        count = GameManager.appleFirst;
    }
}
