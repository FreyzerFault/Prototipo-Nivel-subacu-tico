using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{
    public enum TransitionPlace
    { None = -1, GrietaEntrada, TechoEnfermeria, TechoSalaOperaciones, GrietaCamarote, GrietaSalaMaquinas }

    public static TransitionPlace currentTransitionLocation = TransitionPlace.None;

    public Transform spawnPointT;
    public TransitionPlace transitionLocation;
    public Color color;
    public bool isInOut;
    
    private GameObject player;
    
    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
        player = GameObject.FindWithTag("Player");
        if (currentTransitionLocation == transitionLocation)
            SpawnPlayer();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.tag}");
        if (other.CompareTag("Player"))
            DoTransition();
    }
    
    public void DoTransition()
    {
        // Update Transition Spawn for the other Scene
        currentTransitionLocation = transitionLocation;

        Debug.Log($"Transition {transitionLocation.ToString()} triggered " +
                  $"from {(isInOut ? "inside" : "outside")} to {(isInOut ? "outside" : "inside")}" +
                  $" with color {color.ToString()}");
        
        // Load the scene after a Fade Out with its color
        GameManager.Instance.LoadSceneWithFadeOut(isInOut ? 0 : 1, color);
    }
    
    private void SpawnPlayer()
    {
        player.transform.position = spawnPointT.position;
        player.transform.rotation = spawnPointT.rotation;
    }
}
