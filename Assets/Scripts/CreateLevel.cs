using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour {
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject goalPrefab;
    [SerializeField] private LineRenderer lineRendererPrefab;
    [SerializeField] private GameObject lineAnchorPrefab;

    private void Start() {
        //InitializeLevel(level);
    }

    private void InitializeLevel(Level level) {
        GameObject player = Instantiate(playerPrefab, level.playerPosition, playerPrefab.transform.rotation);
        GameObject goal = Instantiate(goalPrefab, level.goalPosition, goalPrefab.transform.rotation);

        foreach (var p in level.platforms) {
            LineRenderer platform = Instantiate(lineRendererPrefab);

            platform.SetPosition(0, p.startPosition);
            platform.SetPosition(1, p.endPosition);

            GameObject startAnchor = Instantiate<GameObject>(lineAnchorPrefab, p.startPosition, transform.rotation);
            GameObject endAnchor = Instantiate<GameObject>(lineAnchorPrefab, p.endPosition, transform.rotation);

            startAnchor.transform.SetParent(platform.transform);
            endAnchor.transform.SetParent(platform.transform);

            EdgeCollider2D edgeCollider = platform.GetComponent<EdgeCollider2D>();
            edgeCollider.SetPoints(new List<Vector2>() { p.startPosition, p.endPosition });
        }
    }
}
