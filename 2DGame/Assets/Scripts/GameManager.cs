using UnityEngine;
using System;

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

    public void AppleFirst(string getValue)
    {
        // 整數 = 整數.轉型(字串) - 將字串轉為整數
        appleFirst = Int32.Parse(getValue);
    }
}
