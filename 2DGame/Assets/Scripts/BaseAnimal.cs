using UnityEngine;

public class BaseAnimal : MonoBehaviour
{
    [Header("行動速度")]
    public float speed;
    [Header("生命")]
    public float lifetime;
    [Header("吃幾個目標物會生成下一隻")]
    public int eatCount;
    [Header("要追蹤的目標名稱")]
    public string targetName;
    [Header("目標物件陣列")]
    public GameObject[] targets;

    /// <summary>
    /// 搜尋目標
    /// </summary>
    private void FindTarget()
    {
        // 目標物件陣列 = 遊戲物件.透過標籤尋找物件(目標名稱)
        targets = GameObject.FindGameObjectsWithTag(targetName);
    }

    private void Start()
    {
        FindTarget();
    }
}
