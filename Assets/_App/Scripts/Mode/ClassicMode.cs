﻿using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace MobaVR
{
    public class ClassicMode : GameMode, IClassicModeState
    {
        [SerializeField] private ClassicGameSession m_GameSession;
        [SerializeField] private BaseModeView m_ModeView;
        [SerializeField] private StateMachine m_StateMachine;

        public BaseModeView ModeView => m_ModeView;
        public Team RedTeam => m_GameSession != null ? m_GameSession.RedTeam : null;
        public Team BlueTeam => m_GameSession != null ? m_GameSession.BlueTeam : null;
        public List<PlayerVR> Players
        {
            get
            {
                if (m_GameSession == null)
                {
                    return new List<PlayerVR>();
                }

                List<PlayerVR> players = new List<PlayerVR>();
                players.AddRange(m_GameSession.RedTeam.Players);
                players.AddRange(m_GameSession.BlueTeam.Players);

                return players;
            }
        }

        private void Awake()
        {
            //m_StateMachine = new StateMachine(this);
            m_StateMachine.Init(this);
        }

        public void InitMode()
        {
            //m_StateMachine.SetState(m_StateMachine.InitModeState);
            m_StateMachine.InitMode();
        }

        public void DeactivateMode()
        {
            m_StateMachine.DeactivateMode();
        }

        public void StartMode()
        {
            m_StateMachine.StartMode();
        }

        public void ReadyRound()
        {
            m_StateMachine.ReadyRound();
        }

        public void PlayRound()
        {
            m_StateMachine.PlayRound();
        }

        public void CompleteRound()
        {
            m_StateMachine.CompleteRound();
        }

        public void CompleteMode()
        {
            m_StateMachine.CompleteMode();
        }
    }
}