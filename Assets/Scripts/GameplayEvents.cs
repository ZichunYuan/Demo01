using System;
using UnityEngine;

namespace CrawfisSoftware
{
    static class GameplayEvents
    {
        public static event Action<GameObject> CharacterChanged;
        public static event Action<Camera> CameraChanged;

        public static void ChangeCharacter(GameObject character)
        {
            CharacterChanged?.Invoke(character);
        }

        public static void ChangeCamera(Camera camera)
        {
            CameraChanged?.Invoke(camera);
        }
    }
}