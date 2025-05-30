using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Noose : MonoBehaviour
{
    public Collider[] targets;
    public Collider target;

    public float radius;
    [SerializeField] LayerMask animal;

    private void OnEnable()
    {
        transform.localScale = Vector3.one * radius;
    }
    private void Update()
    {
        target = SelectTarget();
    }

    private void OnDisable()
    {
        transform.localScale = Vector3.one;
    }
    private Collider SelectTarget()
    {
        targets = Physics.OverlapSphere(transform.position, radius, animal);
        if (targets.Length > 0)
        {
            return targets[0];
        }
        return null;
    }


}
