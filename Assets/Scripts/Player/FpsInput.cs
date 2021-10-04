using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsInput : MonoBehaviour
{
    [SerializeField] private float speedInput = 9.0f;
    [SerializeField] private float gravity = -9.5f;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speedInput;
        float deltaZ = Input.GetAxis("Vertical") * speedInput;

        Vector3 movemoment = new Vector3(deltaX, 0, deltaZ);
        movemoment = Vector3.ClampMagnitude(movemoment, speedInput);//Ограничим дживение по диагонали той же скоростью что и джвижение параллельно осям
        movemoment *= Time.deltaTime;
        movemoment.y = gravity;
        movemoment = transform.TransformDirection(movemoment); //Преобразуем вектор движения от локальных к глобальным координатам
        _characterController.Move(movemoment); //заставим этот вектор перемешать компонент _characterController
    }
}
