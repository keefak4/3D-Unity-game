using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireClick : MonoBehaviour
{
    private Camera camera;
    private void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))// ������� ������ ����
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2); //�������� ������
            Ray ray = camera.ScreenPointToRay(point); //�������� ���� ������� ScreenPointToRay
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)) //������������� ��������� ����������� ���������� �� ������� ������� ������ 
            {
                //StartCoroutine(SphereIndicator(hit.point));�������� �������
                GameObject hitObject = hit.transform.gameObject;//�������� ������ � ������� ������ ���
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
        
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
