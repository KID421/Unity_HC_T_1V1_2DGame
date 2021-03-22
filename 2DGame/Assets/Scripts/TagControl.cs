using UnityEngine;

public class TagControl : MonoBehaviour
{
    [Header("恢復標籤時間")]
    public float resetTime = 2f;

    private string tagName;
    private float timer;

    private void Awake()
    {
        tagName = tag;
    }

    private void Update()
    {
        ResetTag();
    }

    private void ResetTag()
    {
        if (tag == "Untagged")
        {
            if (timer >= resetTime)
            {
                tag = tagName;
                timer = 0;
            }
            else timer += Time.deltaTime;
        }
    }
}
