using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // 欄位 - 保存資料
    // 時間 
    // int 整數
    // float 浮點數

    // 欄位語法
    // 修飾詞 類型 名稱 指定 值；
    // public 公開 顯示在面板
    public float interval = 2.5f;

    // 存放物件可以用 GameObject
    public GameObject apple;

    // 事件 - 入口
    // 開始：播放時執行一次
    private void Start()
    {
        // 輸出 API 測試
        print("測試");

        Spawn();
    }

    // 函式 - 包含程式區塊
    // 函式語法
    // 修飾詞 類型 名稱 () { 程式區塊 }
    public void Spawn()
    {
        // 生成(物件)
        Instantiate(apple);
    }
}
