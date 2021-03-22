using UnityEngine;

/// <summary>
/// 更新沒有保護色青蛙的生成數量
/// </summary>
public class SpawnFrogNoColor : SpawnManager
{
    private void Awake()
    {
        count = GameManager.frogNoColor;
    }
}
