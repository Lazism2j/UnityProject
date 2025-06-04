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
            Debug.Log(InAnimal);
            if (InAnimal != null)
            {
                InAnimal.target = nextTarget;
            }
        
    }
}
