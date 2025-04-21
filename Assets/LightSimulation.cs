using UnityEngine;

public class LightSimulation : MonoBehaviour
{
    public Transform candleFlame;    // 火焰位置
    public Transform hole;          // 小孔位置
    public Transform screen;        // 成像屏幕位置
    public LineRenderer line;       // LineRenderer 组件
    public GameObject flameImage; // 火焰图像预设体（Sprite 或小模型）public GameObject flameImage; // 火焰图像预设体（Sprite 或小模型）
    
    public UnityEngine.UI.Slider holeSlider;
    void Update()
    {
        // ...已有的 LineRenderer 逻辑

        float d1 = Vector3.Distance(candleFlame.position, hole.position);
        float d2 = Vector3.Distance(hole.position, screen.position);

        // 成像位置
        Vector3 imagePos = hole.position + (screen.position - hole.position).normalized * d2;

        // 设置倒立位置（Y 轴对称）
        float heightRatio = d2 / d1;
        Vector3 offset = candleFlame.position - hole.position;
        offset.y = -offset.y * heightRatio;

        flameImage.transform.position = hole.position + offset + (screen.position - hole.position).normalized * 0.1f;

        // 设置缩放（高度按比例）
        flameImage.transform.localScale = new Vector3(0.2f, 0.2f * heightRatio, 0.2f);
        Vector3 entry = hole.position;
        Vector3 direction = (hole.position - candleFlame.position).normalized;
        Vector3 projection = entry + direction * 10f; // 模拟到屏幕上

        line.SetPosition(0, candleFlame.position);
        line.SetPosition(1, entry); // 光线到小孔
                                    // 控制小孔大小
        float s = holeSlider.value;
        hole.localScale = new Vector3(s, s, s);
    }
}
