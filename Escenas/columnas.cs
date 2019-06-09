using Godot;
using System;

public class columnas : Spatial
{
    private float posicion_X_actual;
    private float posicion_Y_actual;
    private float movimiento_X;

    
     public override void _Process(float delta) 
    {
        
        if(GetParent().GetParent<Nivel1>().gameOver == false)//sino es game over
        {
            posicion_X_actual = GetTranslation().x; //tomo la posicion en X actual
            posicion_Y_actual = GetTranslation().y; //tomo la posicion en Y actual
            movimiento_X = posicion_X_actual + GetParent().GetParent<Nivel1>().velocidadDesplazamientoX  * delta;//creo el movimiento en X
            
            SetTranslation(new Vector3(movimiento_X,posicion_Y_actual,0));//cambio la posición de la columna en "X" y "Y"       
            
            if(this.GetTranslation().x < -1000)//tomo la posición para saber si es menor a -1000
            {
                ReposicionarColumnas();//cambio a la posición a 0 la tarima.SE usa set para moverlo
            }
        }

        
    
    }
  
    private void ReposicionarColumnas()
    {
        GD.Print("vuelve la columna ");
        Random IniciarAleatoriedad = new Random();
        int posicionAleatoria_en_Y = IniciarAleatoriedad.Next(GetParent().GetParent<Nivel1>().Y_minimo,GetParent().GetParent<Nivel1>().Y_maximo);
        GD.Print(posicionAleatoria_en_Y);
        this.SetTranslation(new Vector3(2000 - 1000,posicionAleatoria_en_Y,0));//reposiciono las columnas tengo en cuenta la distancia al principio
        
    }

    private void _on_Area_body_exited(KinematicBody body)//si el cuerpo entro al area esta relacionado al puntaje
    {
        if (body.IsInGroup("pajaro"))//si esta en el grupo pajaro
        {
            GD.Print("el pajaro paso por la columna");//imprimo por consola
            GetParent().GetParent<Nivel1>().puntuacion ++;//sumo 1 a puntuación
            ((AudioStreamPlayer)GetTree().GetNodesInGroup("sonido_puntos")[0]).Playing = true;//pongo play al sonido puntos
        }
    }


}
