using System;
using UnityEngine;

public class Level {
    [Serializable]
    public struct PlatformPosition {
        public Vector2 startPosition;
        public Vector2 endPosition;
    }
    public Vector2 playerPosition;
    public Vector2 goalPosition;

    public PlatformPosition[] platforms;
}
