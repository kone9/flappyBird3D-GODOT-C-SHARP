using Godot;
using System;

public class flappyBirdMenuInicio : RigidBody
{
    [Export]
    public PackedScene nivel1;

    public override void _Process(float delta)//funcion se procesa en cada frame
    {
       if (Input.IsActionJustPressed("clickIzquierdo"))//si presiono click izquierdo
        {
            GD.Print("hola mundo cambia de escena");
            GetTree().ChangeSceneTo(nivel1);
        } 
    }
 


}
