using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject controller = null;
    [SerializeField]
    private GameObject Item;

    private MyController controllerComponent;


    void Start()
    {
        controllerComponent = controller.GetComponent<MyController>();
    }

    void Update()
    {
        if (controllerComponent == null)
        {
            return;
        }

        transform.position = controllerComponent.GetTransform().position;
        transform.rotation = controllerComponent.GetTransform().rotation;

        if (controllerComponent.IsGrabDown())
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }
}
