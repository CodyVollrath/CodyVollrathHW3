using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public Camera camera;
    public GameObject selected;
    private float movementScale = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selectedItem = hit.transform;
                this.selected = getSelectedTarget(selectedItem.name);
                this.ChangeColor();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            selected.transform.position = new Vector3(selected.transform.position.x - movementScale, selected.transform.position.y, selected.transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            selected.transform.position = new Vector3(selected.transform.position.x + movementScale, selected.transform.position.y, selected.transform.position.z);
        }
    }
    private void ChangeColor() 
    {
        if (this.selected == null) 
        {
            return;
        }
        var target1Render = target1.GetComponent<Renderer>();
        var target2Render = target2.GetComponent<Renderer>();
        var target3Render = target3.GetComponent<Renderer>();
        var selectedRender = this.selected.GetComponent<Renderer>();
        target1Render.material.color = Color.white;
        target2Render.material.color = Color.white;
        target3Render.material.color = Color.white;
        selectedRender.material.color = Color.red;
    }
    private GameObject getSelectedTarget(string name) 
    {
        //Determine if touch position is within the vector
        switch (name) 
        {
            case "Moveable1":
                return target1;
            case "Moveable2":
                return target2;
            case "Moveable3":
                return target3;
            default: return null;
        }
    }
}
