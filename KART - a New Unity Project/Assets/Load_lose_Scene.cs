using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_lose_Scene : MonoBehaviour
{
    public FadeAndLoad fadeManager;  // 拖入 FadeManager 物体

    private void OnTriggerEnter(Collider other)  // ✅ 用 OnTriggerEnter
    {
        if (other.CompareTag("lose trigger"))  // 注意大小写和空格
        {
            fadeManager.StartFadeAndLoad();  // 撞到失败触发器就执行淡出
        }
    }
}