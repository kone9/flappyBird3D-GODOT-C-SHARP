using Godot;
using System;

public class plataforma_chica : Spatial
{
    private float posicion_X_actual;
    private float movimiento_X;
    
    public override void _PhysicsProcess(float delta) 
    {
        if(GetParent().GetParent<Nivel1>().gameOver == false)//sino es game over
        {    
            posicion_X_actual = GetTranslation().x; //tomo la posicion en X actual
            movimiento_X = posicion_X_actual + GetParent().GetParent<Nivel1>().velocidadDesplazamientoX  * delta; //creo el movimiento en X
            SetTranslation(new Vector3(movimiento_X,0,0));  
            if(GetTranslation().x < -1000)//tomo la posición para saber si es menor a -1000
            {   
                ReposicionarSuelo();//cambio a la posición a 0 la tarima.SE usa set para moverlo
            }

        }
    }
  
  
    private void ReposicionarSuelo()
    {
        GD.Print("vuelve la plataforma 1");
        SetTranslation(new Vector3(2000,0,0));//cambio a la posición a 0 la tarima.SE usa set para mover

    }

}
