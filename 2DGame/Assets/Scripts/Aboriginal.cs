using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Aboriginal : BaseAnimal
{
    [Header("是否視力良好")]
    public bool goodEyes;

    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();

        if (goodEyes) spr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    // 複寫 父類別
    // 行動快 並且 視力不好 可以 搜尋 行動快 並且 沒有保護色 的 青蛙
    // 行動慢 並且 視力良好 可以 搜尋 行動慢 並且 擁有保護色 的 青蛙
    protected override void FindTarget()
    {
        // 取得 所有 目標
        GameObject[] originalTarget = GameObject.FindGameObjectsWithTag(targetName);

        if (speed == 10 && !goodEyes)
        {
            // 新的目標 (添加條件後的目標) = 所有目標.轉為清單().搜尋(物件 => 沒有保護色 並且 行動快)
            var newTarget = originalTarget.ToList().Where(x => !x.GetComponent<Frog>().haveColor && x.GetComponent<BaseAnimal>().speed == 10);
            // 目標 = 新的目標 轉為陣列
            targets = newTarget.ToArray();
        }
        else if (speed == 8 && goodEyes)
        {
            // 新的目標 (添加條件後的目標) = 所有目標.轉為清單().搜尋(物件 => 擁有保護色 並且 行動慢)
            var newTarget = originalTarget.ToList().Where(x => x.GetComponent<Frog>().haveColor && x.GetComponent<BaseAnimal>().speed == 8);
            // 目標 = 新的目標 轉為陣列
            targets = newTarget.ToArray();
        }

        FindNearTarget();
    }
}
