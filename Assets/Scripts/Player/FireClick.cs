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
        if(Input.GetMouseButtonDown(0))// нажатие кнопки мыги
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2); //середина экрана
            Ray ray = camera.ScreenPointToRay(point); //создание луче методом ScreenPointToRay
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)) //испущенныйлуч заполняет информацией переменную на которую имеется ссылка 
            {
                //StartCoroutine(SphereIndicator(hit.point));стрельба сферами
                GameObject hitObject = hit.transform.gameObject;//получаем объект в которых попадёт луч
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
