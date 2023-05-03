using System;
using System.Collections;
using System.Collections.Generic;
using AppMana.ComponentModel;
using Cinemachine;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace AppMana.InteractionToolkit
{
    public class OrbitOnIdle : UIBehaviour
    {
        [SerializeField] private InputActionReference m_CancelsIdle;
        [SerializeField] private CinemachineVirtualCameraBase m_Camera;
        [SerializeField] private float m_HorizontalOrbitSpeed = 1f;
        [SerializeField] private float m_Timeout = 3f;
        [SerializeField] private float m_Acceleration = 1f;
        [SerializeField] private float m_MinimumInteractionTime = 1f;

        protected override void Start()
        {
            var pov = m_Camera.GetComponentInChildren<CinemachinePOV>();
            if (pov == null)
            {
                return;
            }

            var speed = m_HorizontalOrbitSpeed;

            if (m_CancelsIdle != null)
            {
                m_CancelsIdle.action.OnPerformedAsObservable()
                    .Where(ctx => ctx.time > m_MinimumInteractionTime)
                    .Subscribe(ctx =>
                    {
                        if (ctx.control is ButtonControl { wasReleasedThisFrame: true })
                        {
                            return;
                        }

                        speed = -m_Acceleration * m_Timeout;
                    })
                    .AddTo(this);
            }

            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    if (speed < m_HorizontalOrbitSpeed)
                    {
                        speed += m_Acceleration * Time.smoothDeltaTime;
                    }

                    pov.m_HorizontalAxis.Value += Mathf.Clamp(speed, 0, m_HorizontalOrbitSpeed) * Time.deltaTime;
                })
                .AddTo(this);
        }
    }
}