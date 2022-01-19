using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _offSet;

    private void Update()
    {
        transform.position = new Vector3(_bird.transform.position.x - _offSet, transform.position.y, transform.position.z);
    }
}
