using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 蘋果第一次生成與間隔
    public int appleFirst;
    public float appleInterval;

    // 青蛙 沒有保護色 數量、生命與生成
    public int frogNoColor;
    public float frogNoColorLife;
    public int frogNoColorEat;

    // 青蛙 擁有保護色 數量、生命與生成
    public int frogHaveColor;
    public float frogHaveColorLife;
    public int frogHaveColorEat;

    // 原住民 視力良好 數量、生命與生成
    public int aboiginalGoodEye;
    public float aboiginalGoodEyeLife;
    public int aboiginalGoodEyeEat;

    // 原住民 視力不好 數量、生命與生成
    public int aboiginalBadEye;
    public float aboiginalBadEyeLife;
    public int aboiginalBadEyeEat;

    [Header("青蛙 擁有保護色")]
    public Frog objFrogHaveColor;
    [Header("青蛙 沒有保護色")]
    public Frog objFrogNoColor;
    [Header("原住民 視力良好")]
    public Aboriginal objAboriginalGoodEye;
    [Header("原住民 視力不好")]
    public Aboriginal objAboriginalBadEye;

    public void AppleFirst(string getValue)
    {
        // 整數 = 整數.轉型(字串) - 將字串轉為整數
        appleFirst = Int32.Parse(getValue);
    }

    public void AppleInterval(string getValue)
    {
        appleInterval = Int32.Parse(getValue);
    }

    public void FrogNoColor(string getValue)
    {
        frogNoColor = Int32.Parse(getValue);
    }

    public void FrogNoColorLife(string getValue)
    {
        frogNoColorLife = Int32.Parse(getValue);
        objFrogNoColor.lifetime = frogNoColorLife;                  // 更新 沒有保護色 生命
    }

    public void FrogNoColorEat(string getValue)
    {
        frogNoColorEat = Int32.Parse(getValue);
        objFrogNoColor.eatCount = frogNoColorEat;                   // 更新 沒有保護色 吃幾個
    }

    public void FrogHaveColor(string getValue)
    {
        frogHaveColor = Int32.Parse(getValue);
    }

    public void FrogHaveColorLife(string getValue)
    {
        frogHaveColorLife = Int32.Parse(getValue);
        objFrogHaveColor.lifetime = frogHaveColorLife;              // 更新 擁有保護色 生命
    }

    public void FrogHaveColorEat(string getValue)
    {
        frogHaveColorEat = Int32.Parse(getValue);
        objFrogHaveColor.eatCount = frogHaveColorEat;               // 更新 擁有保護色 吃幾個
    }

    public void AboiginalGoodEye(string getValue)
    {
        aboiginalGoodEye = Int32.Parse(getValue);
    }

    public void AboiginalGoodEyeLife(string getValue)
    {
        aboiginalGoodEyeLife = Int32.Parse(getValue);
        objAboriginalGoodEye.lifetime = aboiginalGoodEyeLife;       // 更新 視力良好 生命
    }

    public void AboiginalGoodEyeEat(string getValue)
    {
        aboiginalGoodEyeEat = Int32.Parse(getValue);
        objAboriginalGoodEye.eatCount = aboiginalGoodEyeEat;        // 更新 視力良好 吃幾個
    }

    public void AboiginalBadEye(string getValue)
    {
        aboiginalBadEye = Int32.Parse(getValue);
    }

    public void AboiginalBadEyeLife(string getValue)
    {
        aboiginalBadEyeLife = Int32.Parse(getValue);
        objAboriginalBadEye.lifetime = aboiginalBadEyeLife;         // 更新 視力不好 生命
    }

    public void AboiginalBadEyeEat(string getValue)
    {
        aboiginalBadEyeEat = Int32.Parse(getValue);
        objAboriginalBadEye.eatCount = aboiginalBadEyeEat;          // 更新 視力不好 吃幾個
    }

    /// <summary>
    /// 載入場景
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene("遊戲場景");
    }
}
