using UnityEngine;

/// <summary>
/// 更新擁有保護色青蛙的生成數量
/// </summary>
public class SpawnFrogHaveColor : SpawnManager
{
    private void Awake()
    {
        count = GameManager.frogHaveColor;
    }
}
