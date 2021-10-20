using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeCommand : ICommand
{
    Vector3 position;
    Color color;
    Transform cube;

    public PlaceCubeCommand(Vector3 position, Color color, Transform cube)
    {
        this.position = position;
        this.color = color;
        this.cube = cube;
    }
    
    public void Execute()
    {
        CubePlacer.PlaceCube(position, color, cube);
    }

    public void Undo()
    {
        CubePlacer.RemoveCube(position, color);
    }
}

//more new code 
public class PlaceCubeCommandE : ECommand
{
    Vector3 positionE;
    Color colorE;
    Transform sphere;

    public PlaceCubeCommandE(Vector3 positionE, Color colorE, Transform sphere)
    {
        this.positionE = positionE;
        this.colorE = colorE;
        this.sphere = sphere;
    }

    public void ExecuteE()
    {
        CubePlacer.PlaceCube(positionE, colorE, sphere);
    }

    public void UndoE()
    {
        CubePlacer.RemoveCube(positionE, colorE);
    }
}