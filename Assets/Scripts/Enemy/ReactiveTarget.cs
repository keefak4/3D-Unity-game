using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

   public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());

    }
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, -70, 0);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);

    }
}
