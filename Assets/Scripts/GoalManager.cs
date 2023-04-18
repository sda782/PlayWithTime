using UnityEngine;
using static Utils;

public class GoalManager : MonoBehaviour {
    [SerializeField] private Vector2 upper_right, lower_left;
    public void SpawnGoal() {
        Vector2 position = RandomVector(lower_left, upper_right);
        Instantiate<GameObject>(gameObject, position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D col) {
        switch (col.tag) {
            case "Player":
                SpawnGoal();
                Destroy(gameObject);
                break;
        }
    }
}
