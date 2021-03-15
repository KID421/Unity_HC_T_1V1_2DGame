using UnityEngine;

public class Frog : BaseAnimal
{
    [Header("是否有保護色")]
    public bool haveColor;

    /// <summary>
    /// 圖片渲染元件
    /// </summary>
    private SpriteRenderer spr;

    // 喚醒事件：在 Start 前執行一次
    private void Awake()
    {
        // 圖片渲染欄位 = 取得元件<圖片渲染元件>()
        spr = GetComponent<SpriteRenderer>();

        // 如果 有保護色 就將 圖片渲染 的 顏色 改為 灰色 (R，G，B)
        if (haveColor) spr.color = new Color(0.5f, 0.5f, 0.5f);
    }
}
