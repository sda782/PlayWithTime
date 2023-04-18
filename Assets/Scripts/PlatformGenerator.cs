using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    [SerializeField] private InputController inputController;
    [SerializeField] private LineRenderer lineRendererPrefab;
    [SerializeField] private GameObject lineAnchorPrefab;
    [SerializeField] private GameObject[] previewAnchor;
    [SerializeField] private LineRenderer previewLine;

    private struct LinePoints {
        public Vector2 startPoint;
        public Vector2 endPoint;
        public void ClearPoints() {
            startPoint = Vector2.zero;
            endPoint = Vector2.zero;
        }
    }
    private LinePoints linePoints;
    void Start() {
        inputController.MouseLeftDown += OnMouseLeftDown;
        inputController.MouseLeftUp += OnMouseLeftUp;
        inputController.MouseLeft += OnMouseLeft;
        linePoints = new LinePoints();
    }
    private void OnMouseLeftDown() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        linePoints.startPoint = mousePosition;

        previewLine.gameObject.SetActive(true);
        previewAnchor[0].transform.position = mousePosition;
        previewLine.SetPosition(0, mousePosition);
    }

    private void OnMouseLeft() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previewAnchor[1].transform.position = mousePosition;
        previewLine.SetPosition(1, mousePosition);
    }

    private void OnMouseLeftUp() {
        linePoints.endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previewLine.gameObject.SetActive(false);
        DrawLine();
    }

    private void SpawnEmptyAtMousePosition(Vector2 pointPosition) {
        GameObject point = new GameObject("point");
        point.transform.position = pointPosition;
    }

    private void DrawLine() {
        LineRenderer platform = Instantiate(lineRendererPrefab);

        platform.SetPosition(0, linePoints.startPoint);
        platform.SetPosition(1, linePoints.endPoint);

        GameObject startAnchor = Instantiate<GameObject>(lineAnchorPrefab, linePoints.startPoint, transform.rotation);
        GameObject endAnchor = Instantiate<GameObject>(lineAnchorPrefab, linePoints.endPoint, transform.rotation);

        startAnchor.transform.SetParent(platform.transform);
        endAnchor.transform.SetParent(platform.transform);

        SetCollider(platform);
        linePoints.ClearPoints();
    }

    private void SetCollider(LineRenderer platform) {
        EdgeCollider2D edgeCollider = platform.GetComponent<EdgeCollider2D>();
        edgeCollider.SetPoints(new List<Vector2>() { linePoints.startPoint, linePoints.endPoint });
    }

}
