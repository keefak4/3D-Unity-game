using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;// связть с объектом шаблонов
    private GameObject _enemy;
    private void Update()
    {
        if (_enemy == null) //порождаем нового врага ,когда их нет на сцене
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; // метод копируюший объект шаблона
            _enemy.transform.position = new Vector3(0, 4, 0);
            float angle = Random.Range(0,360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
