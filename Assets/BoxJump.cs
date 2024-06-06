using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{

    protected float Animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animation += Time.deltaTime;

        Animation = Animation % 1f;

        transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward *  20f,5f, Animation / 1f);
    }
}
