using UnityEngine;

/// <summary>
/// 更新視力不好原住民的生成數量
/// </summary>
public class SpawnAboriginalBadEye : SpawnManager
{
    private void Awake()
    {
        count = GameManager.aboiginalBadEye;
    }
}
