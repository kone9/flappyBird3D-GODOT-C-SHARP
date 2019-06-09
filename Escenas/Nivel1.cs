using Godot;
using System;



public class Nivel1 : Spatial
{
    
    //estas variables son globales a todo el juego como 
    //no funciona el export las voy a cambiar desde Aqui.

    [Export]
    public float velocidadDesplazamientoX  = -50;//velocidad de desplazamiento de todos los objetos en la escena
    [Export]
    public float impulso_Del_pajaro = 60; //impulso de pajaro
    [Export]
    public int Y_minimo = -80;
    [Export]
    public int Y_maximo = 25;
    [Export]
    public float gravedad = 5;
    [Export]
    public int escala_de_gravedad_al_morir = 50;
    [Export]
    public int puntuacion = 0;
    public bool gameOver = false; //el juego puede comenzar game over cuando gameOver es falso
    

    public override void _Ready() //funcion para inicializar las cosas antes que el juego
    {
        columnasAleatorias(); //inicializo las columnas con un valor aleatorio en el Eje "Y"
    }
    public override void _Process(float delta) //esta funcion se repite 60 veces por segundo

    {
        sumarPuntuacion();//llamo a la funcion que suma el puntaje 

    }
    private void columnasAleatorias() //funcion que calcula la las columnas aleatorias al comenzar
        
    {
      var columnas = ((Godot.Spatial)GetTree().GetNodesInGroup("columnas")[0]).GetChildren();//tomo todos los hijos de nodo que esta en el grupo columnas
      Random IniciarAleatoriedad = new Random(); //inicio random.Siempre iniciarlo 1 ves y llamarlo en otros lados.
      foreach (var i in columnas)//recorro la variable columnas que posee un lista de nodos
      {
          //GD.Print(((Godot.Spatial)i).Name );//imprimo por pantalla el nombre del nodo para identificarlo
          int posicionAleatoria_en_Y = IniciarAleatoriedad.Next(Y_minimo,Y_maximo); //inicio la posición random en Y tomando en cuenta 2 valores "minimo / maximo"
          //GD.Print(posicionAleatoria_en_Y);//muestro el valor aleatorio creado
          ((Godot.Spatial)i).SetTranslation(new Vector3(((Godot.Spatial)i).Translation.x,posicionAleatoria_en_Y,0));//posiciono la columna en un valor aletarorio en el eje "Y" manteniendo su eje "X"
      }
    }
    private void sumarPuntuacion() //funcion que calcula la puntuación

    {
      string puntuacionCadena = Convert.ToString(puntuacion);//convierto el puntaje de numero en texto
      (((Label)GetTree().GetNodesInGroup("puntos")[0])).SetText("Puntos: " + puntuacionCadena); //tomo el texto en pantalla y le sumo la puntuación
    }
    

}
       
    
    


