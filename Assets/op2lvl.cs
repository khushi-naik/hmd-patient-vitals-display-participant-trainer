using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class op2lvl : MonoBehaviour
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
        anim.speed = 0.25f;
        anim.Play("op2lvl");
    }
}
