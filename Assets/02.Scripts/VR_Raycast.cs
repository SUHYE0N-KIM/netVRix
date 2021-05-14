using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using UnityEngine.EventSystems;

namespace VR_SH
{
    public class VR_Raycast : MonoBehaviour
    {
        public AudioClip EffectSound;
        public AudioSource audioSource;

        private SteamVR_LaserPointer laserPointer;

        private void OnEnable()
        {
            laserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

            // �̺�Ʈ �Ҵ�
            laserPointer.PointerIn += OnPointerEnter;
            laserPointer.PointerOut += OnPointerExit;
            laserPointer.PointerClick += OnPointerClick;
        }

        private void OnDisable()
        {
            // �̺�Ʈ ���� ����
            laserPointer.PointerIn -= OnPointerEnter;
            laserPointer.PointerOut -= OnPointerExit;
            laserPointer.PointerClick -= OnPointerClick;
        }

        //������ �����Ͱ� ���� ���
        void OnPointerEnter(object sender, PointerEventArgs e)
        {
            IPointerEnterHandler enterHandler = e.target.GetComponent<IPointerEnterHandler>();
            if (enterHandler == null) return;

            enterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));

            // UI ���ͷ��� ����
            if (GameObject.FindWithTag("UI")) {
                audioSource.PlayOneShot(EffectSound);
            }
        }

        // ������ �����Ͱ� ���������
        void OnPointerExit(object sender, PointerEventArgs e)
        {
            IPointerExitHandler exitHandler = e.target.GetComponent<IPointerExitHandler>();
            if (exitHandler == null) return;

            exitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
        }

        //Ʈ��Ŀ ��ư�� Ŭ���������
        void OnPointerClick(object sender, PointerEventArgs e)
        {
            IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
            if (clickHandler == null) return;

            clickHandler.OnPointerClick(new PointerEventData(EventSystem.current));
        }
    }
}