
using UnityEngine;
using UnityEngine.InputSystem;

namespace LP.SpawnMenNewInput
{
    public class SpawnMen : MonoBehaviour
               
    {
        [SerializeField] GameObject prefab = null;
        private Camera cam = null;
        public InputAction button;
        private void Start()
        {
            cam = Camera.main;

        }

        private void Update()
        {
            button.Enable();
            SpawnAtMousePos();
        }

        private void SpawnAtMousePos()
        {
           // Debug.Log(-button.ReadValue<float>() * .05f);
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                 
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    var startPos = hit.point;
                    var startRot = Quaternion.Euler(0f, 180f, 0f);
                    Instantiate(prefab, startPos, Quaternion.FromToRotation(transform.up, hit.normal));

                }
            }
        }
    }
}

