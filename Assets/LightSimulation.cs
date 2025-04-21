using UnityEngine;

public class LightSimulation : MonoBehaviour
{
    public Transform candleFlame;    // ����λ��
    public Transform hole;          // С��λ��
    public Transform screen;        // ������Ļλ��
    public LineRenderer line;       // LineRenderer ���
    public GameObject flameImage; // ����ͼ��Ԥ���壨Sprite ��Сģ�ͣ�public GameObject flameImage; // ����ͼ��Ԥ���壨Sprite ��Сģ�ͣ�
    
    public UnityEngine.UI.Slider holeSlider;
    void Update()
    {
        // ...���е� LineRenderer �߼�

        float d1 = Vector3.Distance(candleFlame.position, hole.position);
        float d2 = Vector3.Distance(hole.position, screen.position);

        // ����λ��
        Vector3 imagePos = hole.position + (screen.position - hole.position).normalized * d2;

        // ���õ���λ�ã�Y ��Գƣ�
        float heightRatio = d2 / d1;
        Vector3 offset = candleFlame.position - hole.position;
        offset.y = -offset.y * heightRatio;

        flameImage.transform.position = hole.position + offset + (screen.position - hole.position).normalized * 0.1f;

        // �������ţ��߶Ȱ�������
        flameImage.transform.localScale = new Vector3(0.2f, 0.2f * heightRatio, 0.2f);
        Vector3 entry = hole.position;
        Vector3 direction = (hole.position - candleFlame.position).normalized;
        Vector3 projection = entry + direction * 10f; // ģ�⵽��Ļ��

        line.SetPosition(0, candleFlame.position);
        line.SetPosition(1, entry); // ���ߵ�С��
                                    // ����С�״�С
        float s = holeSlider.value;
        hole.localScale = new Vector3(s, s, s);
    }
}
