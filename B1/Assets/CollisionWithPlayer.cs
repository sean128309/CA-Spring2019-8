﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
    }
}
