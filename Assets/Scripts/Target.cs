using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private LayerMask animal;
    public Transform nextTarget;

    public void OnTriggerEnter(Collider other)
    {
       // Debug.Log(this.gameObject, other.gameObject);
        
            Animal InAnimal = other.GetComponent<Animal>();
            if (InAnimal != null)
            {
                InAnimal.target = nextTarget;
            }
        
    }
}
