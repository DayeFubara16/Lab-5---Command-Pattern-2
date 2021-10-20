using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform cubePrefab;
    public Transform spherePrefab;

    //new code
    public int switcherInt = 0;

    // Start is called before the first frame update
    void Awake()
    {
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            switcherInt = 1;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            switcherInt = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity) && switcherInt == 0)
            {
                Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

                ICommand command = new PlaceCubeCommand(hitInfo.point, c, cubePrefab);
                CommandInvoker.AddCopmmand(command);
            }

            else if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity) && switcherInt == 1)
            {
                Color d = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

                ECommand command = new PlaceCubeCommandE(hitInfo.point, d, spherePrefab);
                CommandInvoker.AddCommand(command);
            }
        }
        
    }
}
