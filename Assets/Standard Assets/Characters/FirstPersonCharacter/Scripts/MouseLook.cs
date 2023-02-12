using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 5f;
        public bool lockCursor = true;

        private float yRot;
        private float xRot;
        private Quaternion m_CameraTargetRot1;
        private Quaternion m_CameraTargetRot2;
        private bool m_cursorIsLocked = true;

        public void Init(Transform character, Transform camera)
        {
            // m_CharacterTargetRot = character.localRotation;
            // m_CameraTargetRot = camera.localRotation;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }


        public void LookRotation(Transform character, Transform camera)
        {
            yRot += CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            xRot += CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            m_CameraTargetRot1 = Quaternion.Euler (0f, yRot, 0f);
            m_CameraTargetRot2 = Quaternion.Euler (-xRot, 0f, 0f);

            camera.transform.localRotation = m_CameraTargetRot1;
            camera.localRotation = m_CameraTargetRot2;
            character.transform.localRotation = m_CameraTargetRot1;
            

            //UpdateCursorLock();
        }


        public void UpdateCursorLock()
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor)
                InternalLockUpdate();
        }

        private void InternalLockUpdate()
        {
            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
