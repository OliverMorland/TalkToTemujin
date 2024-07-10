using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VRMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public InputActionReference pauseAction;
        public Canvas canvas;
        Transform userView;
        public float distanceFromUser = 2f;
        public bool isOffAtStart = true;

        private void Start()
        {
            pauseAction.action.performed += OnPauseAction;
            userView = Camera.main.transform;
            if (isOffAtStart )
            {
                canvas.enabled = false;
            }
        }

        private void OnPauseAction(InputAction.CallbackContext context)
        {
            canvas.enabled = !canvas.enabled;
            PositionInFrontOfUser();
            SnapToFaceUser();
        }

        private void SnapToFaceUser()
        {
            Vector3 directionToUser = GetDirectionToUser();
            Quaternion lookAtRotation = Quaternion.LookRotation(-directionToUser);
            transform.rotation = lookAtRotation;
        }

        Vector3 GetDirectionToUser()
        {
            Vector3 directionToUser = (userView.transform.position - transform.position);
            directionToUser.y = 0;
            directionToUser.Normalize();
            return directionToUser;
        }

        private void PositionInFrontOfUser()
        {
            Vector3 userForward = GetXYPlaneForwardDir();
            Vector3 offset = userForward * distanceFromUser;
            transform.position = userView.position + offset;
        }

        private Vector3 GetXYPlaneForwardDir()
        {
            Vector3 userForward = userView.transform.forward;
            userForward.y = 0;
            userForward.Normalize();
            return userForward;
        }
    }
}
