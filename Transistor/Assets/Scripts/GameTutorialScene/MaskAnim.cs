using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskAnim : MonoBehaviour
{
    public float scaleSpeed;
    public float scaleUpTime;
    public float scaleDownTime;

    float timePassed;

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed < scaleUpTime)
        {
            transform.localScale = new Vector2(transform.localScale.x + (scaleSpeed * Time.deltaTime),
                                               transform.localScale.y + (scaleSpeed * Time.deltaTime));
        }
        else if (timePassed < scaleUpTime + scaleDownTime)
        {
            transform.localScale = new Vector2(transform.localScale.x - (scaleSpeed * Time.deltaTime),
                                               transform.localScale.y - (scaleSpeed * Time.deltaTime));
        }
        else
        {
            timePassed = 0;
        }
    }
}
