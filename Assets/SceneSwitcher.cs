using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void OnMouseDown()  // �����ʱ����
    {
        Debug.Log("��Ʒ�������׼���л�����");
        SceneManager.LoadScene("MoziLight"); // �滻����Ŀ�곡����
    }
}
