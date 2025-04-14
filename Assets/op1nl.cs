using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class op1nl : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = 0.5f;
        anim.Play("op1nl");
    }
}
