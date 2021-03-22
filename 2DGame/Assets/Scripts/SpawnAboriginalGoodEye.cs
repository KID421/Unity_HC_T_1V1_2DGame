using UnityEngine;

/// <summary>
/// 更新視力良好原住民的生成數量
/// </summary>
public class SpawnAboriginalGoodEye : SpawnManager
{
    private void Awake()
    {
        count = GameManager.aboiginalGoodEye;
    }
}
