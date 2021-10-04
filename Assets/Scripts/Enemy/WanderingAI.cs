using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float speedBotAI = 4.0f;
    [SerializeField] private float abstactRange = 5.0f;
    private bool aLive;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private void Start()
    {
        aLive = true;
    }
    private void Update()
    {
        if (aLive)
        {
            transform.Translate(0, 0, speedBotAI * Time.deltaTime);//непрвыровно движемся в перед в каждом кадре есмотря на повороты
        }
        Ray ray = new Ray(transform.position, transform.forward);// непрерывно движемся вперёд в каждом кадре несмотря на повороты
        RaycastHit raycastHit;
        if (Physics.SphereCast(ray, 0.75f, out raycastHit)) // бросаем луч с описаной вокруг него окрдностью
        {
            if (raycastHit.distance < abstactRange)
            {
                float angle = Random.Range(-110, 110);//поворот случайным выбором нового направлеия
                transform.Rotate(0, angle, 0);
            }
        }
        if(Physics.SphereCast(ray,0.75f,out raycastHit))
        {
            GameObject hitObject = raycastHit.transform.gameObject;
            if(hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if(raycastHit.distance < abstactRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }

    }
    public void SetAlive(bool aLive)
    {
        aLive = aLive;
    }    
}
