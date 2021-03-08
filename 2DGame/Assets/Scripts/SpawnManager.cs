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
    [Header("間隔")]
    public float interval = 2.5f;

    [Header("生成物件")]
    public GameObject obj;

    [Header("設定左右與上下生成範圍")]
    public Vector2 posMin = new Vector2(-8, -4);
    public Vector2 posMax = new Vector2(+8, +4);

    [Header("第一次生成的數量")]
    public int count;

    [Header("是否需要間隔生成")]
    public bool needSpawn;
    [Header("目前物件的數量")]
    public int currentCount;

    // 事件 - 入口
    // 開始：播放時執行一次
    private void Start()
    {
        // 第一次生成
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }

        // 如果 需要間隔生成 重複呼叫("函式名稱"，開始時間，間隔時間)
        if (needSpawn) InvokeRepeating("Spawn", interval, interval);
    }

    // 函式 - 包含程式區塊
    // 函式語法
    // 修飾詞 類型 名稱 () { 程式區塊 }
    public void Spawn()
    {
        // 數量遞增
        currentCount++;

        // 取得隨機座標 x 與 y
        float x = Random.Range(posMin.x, posMax.x);
        float y = Random.Range(posMin.y, posMax.y);

        // 生成(物件，座標，角度)
        // 零角度 Quaternion.identity
        Instantiate(obj, new Vector2(x, y), Quaternion.identity);
    }
}
