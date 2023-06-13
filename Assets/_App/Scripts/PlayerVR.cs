using System.Collections.Generic;
using BNG;
using Photon.Pun;
using UnityEngine;

namespace MobaVR
{
    /// <summary>
    /// Основной класс, который содержит в себе все зависимости игрока.
    /// Этот класс используется для инициализации игрока, передачи ему InputVR, выбор команды
    /// ИК: сейчас не работает.
    /// </summary>
    public class PlayerVR : MonoBehaviourPunCallbacks
    {
        [SerializeField] private WizardPlayer m_WizardPlayer;
        [SerializeField] private PlayerMode m_PlayerMode;
        [SerializeField] private Teammate m_Teammate;

        [Header("Hands")]
        [SerializeField] private HandController m_LeftHand;
        [SerializeField] private HandController m_RightHand;

        [Header("Renderers")]
        [SerializeField] private bool m_IsRender = false;
        [SerializeField] private List<Renderer> m_Renderers;

        private InputVR m_InputVR;
        private bool m_IsLocalPlayer = false;
        private bool m_IsInit = false;
        private TeamType m_TeamType = TeamType.RED;
        private Team m_Team = null;

        //public bool IsLocalPlayer => photonView.IsMine || !PhotonNetwork.IsConnected;
        public bool IsLocalPlayer => m_IsLocalPlayer;
        public bool IsInit => m_IsInit;
        public TeamType TeamType
        {
            get
            {
                if (m_Team != null)
                {
                    return m_Team.TeamType;
                }

                return m_TeamType;
            }
        }
        public InputVR InputVR => m_InputVR;
        public Team Team => m_Team;
        public PlayerMode PlayerMode => m_PlayerMode;
        public WizardPlayer WizardPlayer => m_WizardPlayer;


        private void OnValidate()
        {
            if (m_WizardPlayer == null)
            {
                TryGetComponent(out m_WizardPlayer);
            }

            if (m_Teammate == null)
            {
                TryGetComponent(out m_Teammate);
            }

            if (m_PlayerMode == null)
            {
                TryGetComponent(out m_PlayerMode);
            }
        }

        private void Update()
        {
            if (m_IsLocalPlayer && m_IsInit)
            {
                transform.position = m_InputVR.BngPlayerController.transform.position;
                transform.rotation = m_InputVR.BngPlayerController.transform.rotation;

                m_LeftHand.transform.position = m_InputVR.IKLeftHand.transform.position;
                m_LeftHand.transform.rotation = m_InputVR.IKLeftHand.transform.rotation;

                m_RightHand.transform.position = m_InputVR.IKRightHand.transform.position;
                m_RightHand.transform.rotation = m_InputVR.IKRightHand.transform.rotation;
            }
        }

        public void SetLocalPlayer()
        {
            photonView.RPC(nameof(SetLocalPlayer), RpcTarget.All);
        }

        public void SetState(PlayerState playerState)
        {
            photonView.RPC(nameof(RpcSetState), RpcTarget.AllBuffered, playerState);
        }
        
        public void SetState(PlayerStateSO playerStateSo)
        {
            //m_PlayerMode.SetState(playerStateSo);
            //photonView.RPC(nameof(RpcSetStateSo), RpcTarget.AllBuffered, playerStateSo);
            
            //photonView.RPC(nameof(RpcSetState), RpcTarget.AllBuffered, playerStateSo.State);
            photonView.RPC(nameof(RpcSetState), RpcTarget.AllBuffered, playerStateSo.State);
        }
        
        [PunRPC]
        public void RpcSetState(PlayerState playerState)
        {
            m_PlayerMode.SetState(playerState);
        }
        
        [PunRPC]
        public void RpcSetStateSo(PlayerStateSO playerStateSo)
        {
            m_PlayerMode.SetState(playerStateSo);
        }
        
        public void SetTeam(TeamType teamType)
        {
            m_TeamType = teamType;
            photonView.RPC(nameof(SetTeamRpc), RpcTarget.AllBuffered, teamType);
        }

        public void SetTeam(Team team)
        {
            m_Team = team;
            m_TeamType = m_Team.TeamType;
            photonView.RPC(nameof(SetTeamRpc), RpcTarget.AllBuffered, m_TeamType);
        }

        [PunRPC]
        private void SetTeamRpc(TeamType teamType)
        {
            m_TeamType = teamType;

            if (m_WizardPlayer != null)
            {
                m_WizardPlayer.TeamType = m_TeamType;
            }

            if (m_Teammate != null)
            {
                m_Teammate.SetTeam(m_TeamType);

                if (photonView.IsMine)
                {
                    TeamItem leftHandTheme = m_InputVR.LeftController.GetComponentInChildren<TeamItem>();
                    if (leftHandTheme != null)
                    {
                        leftHandTheme.SetTeam(m_TeamType);
                    }

                    TeamItem rightHandTheme = m_InputVR.RightController.GetComponentInChildren<TeamItem>();
                    if (rightHandTheme != null)
                    {
                        rightHandTheme.SetTeam(m_TeamType);
                    }
                }
            }
        }

        public void SetLocalPlayer(InputVR inputVR)
        {
            m_IsLocalPlayer = true;
            m_InputVR = inputVR;

            if (m_InputVR == null)
            {
                m_InputVR = FindObjectOfType<InputVR>();
            }

            if (m_InputVR == null)
            {
                return;
            }

            if (m_WizardPlayer != null)
            {
                m_WizardPlayer.SetLeftGrabber(m_InputVR.LeftGrabber,
                                              m_InputVR.LeftSmallFireballPoint,
                                              m_InputVR.LeftBigFireballPoint);

                m_WizardPlayer.SetRightGrabber(m_InputVR.RightGrabber,
                                               m_InputVR.RightSmallFireballPoint,
                                               m_InputVR.RightBigFireballPoint);

                m_WizardPlayer.DamageIndicator = m_InputVR.DamageIndicator;
            }

            if (m_LeftHand != null)
            {
                //m_LeftHand = m_InputVR.LeftController;
                m_LeftHand.handPoser = m_InputVR.LeftController.handPoser;
                m_LeftHand.grabber = m_InputVR.LeftController.grabber;
            }

            if (m_RightHand != null)
            {
                //m_RightHand = m_InputVR.RightController;
                m_RightHand.handPoser = m_InputVR.RightController.handPoser;
                m_RightHand.grabber = m_InputVR.RightController.grabber;
            }

            if (!m_IsRender)
            {
                foreach (Renderer meshRenderer in m_Renderers)
                {
                    meshRenderer.enabled = false;
                }
            }

            m_IsInit = true;
        }
    }
}