using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsManager : MonoBehaviour
{
	//Todo communiquer avec le command manager pour dire le range de déplacement maximum
    private bool isMoving = false;
    private Vector3 destination;

    public class OnMovementsPlayerEventArgs : EventArgs
    {
        public Vector3 destination;
        public int actionPointSpent; 
    }

    private void Awake()
    {

        // S'abonner à CommandManager => mousePosition (from InputManager);
        // S'abonner à CharacterManager => actionPoints;
        // S'abonner à autre chose ? ;
        FindObjectOfType<MovementsPlayer>().onStoppedMovingEvent += OnStoppedMovingEventListener;

    }

    private void OnStoppedMovingEventListener(object sender, MovementsPlayer.OnStoppedMovingEventArgs e)
    {
		isMoving = false;
    }

    public event EventHandler<OnMovementsPlayerEventArgs> onMovementPlayer;

    private void OnMovementPlayer(OnMovementsPlayerEventArgs e)
    {
        if (onMovementPlayer != null)
            onMovementPlayer(this, e);
    }

 //   private void OnCommandEventHandler(CommandManager.LeftClick e)
 //   {
	//	// mousePosition = e.mousePosition;
	//	// Retirer CalculPointSpent() de nos points d'action;
	//	// -> RayCastMethod() Check pas de murs
	//	// Si pas de murs-> OnMovementEventHandler(); 
	//}

	//private void OnMoveIntentionDeclaredEventHandler(CharacterManager.Something)
 //   {
 //       // Get les action points restant
 //       // Check si il peut bouger 
 //   }

    private void RayCastMethod()
    {
        // A faire mdr lolll;
        // RaycastHit2D hit2D = new RaycastHit2D();
        // hit2D
    }

    private int CalculPointSpent()
    {
        // Delta des positions souris/player => actionPoints, pythagore, ...
        // Retourne actionPointSpent
        int lol = 0;
        return lol;
    }

}
