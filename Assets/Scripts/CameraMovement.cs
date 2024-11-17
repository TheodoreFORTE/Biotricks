using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerController;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;

    [SerializeField]
    private Camera mainCamera;

    private bool isActivatingFloatingCamera = false;

    [SerializeField]
    private float floatingSpeed;

    [SerializeField]
    private float sensitivityZone;

    public GameObject boundary1;       // Limite minimale pour le déplacement de la caméra
    public GameObject boundary2;       // Limite maximale pour le déplacement de la caméra

    void Awake()
    {
        mainCamera.enabled = true;  
    }

    void Update()
    {
        if(playerController == null)
        {
            return; 
        }
       
        if (!isActivatingFloatingCamera)
        {
            FollowPlayer();
        }

        // Activer/Désactiver le mode caméra flottante avec la touche H
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("The floating camera is active");
            isActivatingFloatingCamera = true;
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            Debug.Log("The floating camera is disabled");
            isActivatingFloatingCamera = false;
        }

        // Si le mode caméra flottante est activé, ajuste la position de la caméra en fonction du curseur
        if (isActivatingFloatingCamera)
        {
            ActivateFloatingCamera();
        }
    }

    // Suivre la position du joueur avec un lissage de mouvement
    private void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            playerController.transform.position + posOffset, 
            ref velocity, 
            timeOffset
        );
    }

    public void ChangeFocus(GameObject newFocus)
    {
        playerController = newFocus;
    }

    // Mode de caméra flottante activé
    public void ActivateFloatingCamera()
    {
        // Obtenir la position du curseur en pourcentage de l'écran
        Vector2 screenPosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

        // Calculer le centre de l'écran
        Vector2 screenCenter = new Vector2(0.5f, 0.5f);

        // Calculer la direction entre le centre de l'écran et le curseur
        Vector2 direction = screenPosition - screenCenter;

        // Vérifier si le curseur est en dehors de la zone de sensibilité
        if (Mathf.Abs(direction.x) > sensitivityZone || Mathf.Abs(direction.y) > sensitivityZone)
        {
            // Normaliser la direction pour garder une vitesse constante et multiplier par floatingSpeed
            direction.Normalize();
            Vector3 move = new Vector3(direction.x, direction.y, 0) * floatingSpeed * Time.deltaTime;

            // Calculer la nouvelle position de la caméra
            Vector3 targetPosition = mainCamera.transform.position + move;

            // Appliquer les limites de position
            targetPosition.x = Mathf.Clamp(targetPosition.x, boundary1.transform.position.x, boundary2.transform.position.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, boundary2.transform.position.y, boundary1.transform.position.y);

            // Déplacer la caméra
            mainCamera.transform.position = targetPosition;
        }
    }
}
