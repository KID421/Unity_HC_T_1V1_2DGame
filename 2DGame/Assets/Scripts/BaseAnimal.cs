using UnityEngine;
using System.Linq;                  // 引用 搜尋語言 API
using System.Collections.Generic;   // 引用 系統 集合 一般 API，裡面包含清單 List

public class BaseAnimal : MonoBehaviour
{
    [Header("行動速度")]
    public float speed;
    [Header("生命")]
    public float lifetime;
    [Header("吃東西的時間")]
    public float eatTime;
    [Header("吃幾個目標物會生成下一隻")]
    public int eatCount;
    [Header("要追蹤的目標名稱")]
    public string targetName;
    [Header("目標物件陣列")]
    public GameObject[] targets;
    [Header("目標物件的距離")]
    public List<float> targetDistances;

    /// <summary>
    /// 要追蹤的目標
    /// </summary>
    private Transform target;
    /// <summary>
    /// 吃掉目標物的數量
    /// </summary>
    private int eatTargetCount;
    /// <summary>
    /// 是否正在吃東西
    /// </summary>
    private bool isEating;
    /// <summary>
    /// 原始標籤
    /// </summary>
    private string tagOriginal;

    // protected 保護 - 允許子類別存取
    // virtual 虛擬 - 允許以類別複寫 override
    /// <summary>
    /// 搜尋所有目標
    /// </summary>
    protected virtual void FindTarget()
    {
        // 目標物件陣列 = 遊戲物件.透過標籤尋找物件(目標名稱)
        targets = GameObject.FindGameObjectsWithTag(targetName);
        // 呼叫 搜尋最靠近的目標
        FindNearTarget();
    }

    /// <summary>
    /// 搜尋最靠近的目標
    /// </summary>
    protected void FindNearTarget()
    {
        // 如果 目標物件 的 數量 為零 就 跳出
        if (targets.Length == 0) return;

        // 取得所有目標的距離

        // 刪除所有清單資料
        targetDistances.Clear();

        for (int i = 0; i < targets.Length; i++)
        {
            // 距離 = 二維向量.距離(A 座標，B 座標)
            float dis = Vector2.Distance(transform.position, targets[i].transform.position);
            // 目標物件的距離.添加(距離)
            targetDistances.Add(dis);
        }

        // 取得最靠近的目標
        float min = targetDistances.Min();
        //print("最近的距離：" + min);

        int index = targetDistances.IndexOf(min);
        //print("最近的距離目標編號：" + index);

        // 取得目前最近的目標物件
        target = targets[index].transform;
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {
        // 如果 有目標物件 就追蹤
        if (target)
        {
            // 將鎖定的目標 標籤 改為 預設標籤
            target.tag = "Untagged";

            // 變形 的 座標 = 二維向量.往前移動(A 座標，B 座標，速度 * 一個影格的時間)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            float dis = Vector2.Distance(transform.position, target.position);

            // 如果 距離 小於等於 零 並且 不是在吃東西 就呼叫 吃掉目標
            if (dis <= 0 && !isEating) EatTarget();
        }
        // 否則 搜尋所有目標
        else FindTarget();
    }

    /// <summary>
    /// 吃掉目標
    /// </summary>
    private void EatTarget()
    {
        // 正在吃東西
        isEating = true;

        // 刪除(目標.遊戲物件，延遲時間)
        Destroy(target.gameObject, eatTime);

        // 取消延遲呼叫，重新延遲呼叫
        CancelInvoke("Dead");
        Invoke("Dead", lifetime);

        // 吃完後在判定是否生成
        Invoke("Spawn", eatTime);
    }

    /// <summary>
    /// 生成，吃完後數量累加與判定
    /// </summary>
    private void Spawn()
    {
        // 不是在吃東西
        isEating = false;

        // 吃目標的數量 遞增
        eatTargetCount++;

        // 如果 吃目標的數量 與 吃幾個目標會生成下一隻 餘數 為 零
        if (eatTargetCount % eatCount == 0)
        {
            Invoke("SpawnDelay", 0.5f);
        }
    }

    /// <summary>
    ///  生成延遲
    /// </summary>
    private void SpawnDelay()
    {
        // 取得座標並設定 X 正負 2
        Vector2 pos = transform.position;
        pos.x += Random.Range(-2f, 2f);
        // 生成下一隻
        GameObject temp = Instantiate(gameObject, pos, Quaternion.identity);
        // 生成物件 的 標籤 = 原始標籤
        temp.tag = tagOriginal;
    }

    /// <summary>
    /// 死亡，刪除此動物物件
    /// </summary>
    private void Dead()
    {
        // 如果 目標物存在 就將目標物 的 標籤 恢復
        if (target) target.tag = targetName;
        Destroy(gameObject);
    }

    private void Start()
    {
        // 原始標籤 等於 遊戲一開始的標籤
        tagOriginal = tag;

        FindTarget();

        // 延遲呼叫("死亡"，生命)
        Invoke("Dead", lifetime);
    }

    /// <summary>
    /// 更新事件：一秒執行約 60 次 (60 FPS)
    /// </summary>
    private void Update()
    {
        // 如果 沒有 目標 就 持續 搜尋目標
        if (!target) FindTarget();

        Track();
    }

    // 刪除事件：此物件被刪除時會執行一次
    private void OnDestroy()
    {
        // 如果 目標物存在 就將目標物 的 標籤 恢復
        if (target) target.tag = targetName;
    }
}
