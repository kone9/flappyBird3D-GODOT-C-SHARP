using Godot;
using System;
using System.Collections.Generic;




public class JUGADORflappyBird : RigidBody
{

    //public override void _Ready()
    //{
    //    GravityScale = GetParent<Nivel1>().gravedad; //tomo la gravedad y se la doy al jugador
        
    //}

    public override void _PhysicsProcess(float delta) //se puede agregar async a cualquier funcion para crear una corrutina
    {
        if (GetParent<Nivel1>().gameOver == false) //si game over variable global de nivel1 es igual a false
        {
            
            if (Input.IsActionPressed("clickIzquierdo")) //si presiono click izquierdo
            {
                SetLinearVelocity(new Vector3(0,0,0));//la velocidad lineal es cero
                SetLinearVelocity(new Vector3(0,GetParent<Nivel1>().impulso_Del_pajaro,0));//se aplica una velocidad de impulso
                //SetTranslation(new Vector3(0,10,0));
                GD.Print("van a pasar 3 segundos hasta que pueda volver a presionar");
                
                
            }
        }

        if (GetParent<Nivel1>().gameOver == true)
        {
            
        }

    } 
        

    private async void _on_area_area_entered(Area area)//si entra a un area relacionado a morir///la funcion posee ""async"" para detener el tiempo con await...Sino tiene async no funciona
    {
        if (area.IsInGroup("columnas"))//si esa area esta en el grupo columnas
        {
            if(GetParent<Nivel1>().gameOver == false)//si game over es igual a falso
            {
                GetParent<Nivel1>().gameOver = true;//game over igual a verdadero
                SetGravityScale( GetParent<Nivel1>().escala_de_gravedad_al_morir);//aumento la gravedad al morir
                ((AudioStreamPlayer)GetTree().GetNodesInGroup("hit")[0]).Playing = true;//activo sonido golpe
                

                ((AudioStreamPlayer)GetTree().GetNodesInGroup("musica")[0]).Playing = false;//detiene la musica
                
                yield(GetTree().CreateTimer(0.5f), "timeout");
                
                
                await ToSignal(GetTree().CreateTimer(0.5f), "timeout");//detengo el flujo de ejecución por un tiempo para que no se detenga la musica
                //esto se va a ejecutar luego de que termine el timer de aqui arriba ya que detiene el codigo
                ((AudioStreamPlayer)GetTree().GetNodesInGroup("Sonido_pajaro")[0]).Playing = true;
                
                
                
                
            }
        }
    
        if (area.IsInGroup("suelo"))//si esa area esta en el grupo suelo relacionado a morir
        {
            if(GetParent<Nivel1>().gameOver == false)//si game over es igual a falso
            {
                GetParent<Nivel1>().gameOver = true;//game over igual a verdadero
                SetGravityScale( GetParent<Nivel1>().escala_de_gravedad_al_morir);//aumento la gravedad al morir
                ((AudioStreamPlayer)GetTree().GetNodesInGroup("hit")[0]).Playing = true;//activo sonido golpe
                ((AudioStreamPlayer)GetTree().GetNodesInGroup("musica")[0]).Playing = false;
            }
        }


    } 

        
    private Timer tiempoEspera(float tiempo)//creo una función de TIPO TIMER que devuelve el timer.
    {
        var timer = new Timer();//creo un nuevo timer
        AddChild(timer);//agrego el timer al arbol de nodos
        timer.WaitTime = tiempo;//tiempo que va a tener el timer
        timer.Start();//comienza el timer
        return timer;//retorna el timer
    }
        
        
        
}
