using UnityEngine;

public class Player : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D col) {
        switch (col.gameObject.tag) {
            case "Platform":
                Destroy(col.gameObject, 0.5f);
                break;
        }
    }
}
