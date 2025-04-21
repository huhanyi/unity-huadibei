using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void OnMouseDown()  // 鼠标点击时触发
    {
        Debug.Log("物品被点击，准备切换场景");
        SceneManager.LoadScene("MoziLight"); // 替换成你目标场景名
    }
}
