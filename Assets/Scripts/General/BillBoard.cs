using UnityEngine;

public class BillBoard : MonoBehaviour {

    [SerializeField] private Camera cameraPlayer;

    void Update() {
        if (cameraPlayer != null) {
            // Créer une position cible avec seulement l'axe Y de la caméra
            Vector3 targetPosition = new Vector3(
                cameraPlayer.transform.position.x,
                transform.position.y,  // Garde la hauteur du sprite
                cameraPlayer.transform.position.z
            );
            transform.LookAt(targetPosition);
            transform.Rotate(0, 180, 0);
        }
    }
}
