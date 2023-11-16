using BepInEx;
using ExitGames.Client.Photon;
using GorillaNetworking;
using Photon.Pun;
using Photon.Realtime;
using PlayFab.EventsModels;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace KmanMenu
{
    internal class KmanUI : MonoBehaviour
    {
        // button
        private static Texture2D button = new Texture2D(1, 1);
        private static Texture2D buttonhovered = new Texture2D(1, 1);
        private static Texture2D buttonactive = new Texture2D(1, 1);

        // window
        private static Texture2D windowbackground = new Texture2D(1, 1);
        private static Texture2D windowbackgroundhover = new Texture2D(1, 1);

        // text field & text area
        private static Texture2D textarea = new Texture2D(1, 1);
        private static Texture2D textareahovered = new Texture2D(1, 1);
        private static Texture2D textareaactive = new Texture2D(1, 1);

        // scroll view
        private static Texture2D scrollview = new Texture2D(1, 1);
        private static Texture2D scrollviewhovered = new Texture2D(1, 1);
        private static Texture2D scrollviewactive = new Texture2D(1, 1);

        // box
        private static Texture2D box = new Texture2D(1, 1);

        public void Init()
        {
            // button
            button.SetPixel(0, 0, new Color32(38, 38, 38, 255));
            button.Apply();
            buttonhovered.SetPixel(0, 0, new Color32(42, 42, 42, 255));
            buttonhovered.Apply();
            buttonactive.SetPixel(0, 0, new Color32(56, 56, 56, 255));
            buttonactive.Apply();

            // window
            windowbackground.SetPixel(0, 0, new Color32(23, 23, 23, 255));
            windowbackground.Apply();
            windowbackgroundhover.SetPixel(0, 0, new Color32(23, 23, 23, 255));
            windowbackgroundhover.Apply();

            // text field & text area
            textarea.SetPixel(0, 0, new Color32(23, 23, 23, 255));
            textarea.Apply();
            textareahovered.SetPixel(0, 0, new Color32(23, 23, 23, 255));
            textareahovered.Apply();
            textareaactive.SetPixel(0, 0, new Color32(23, 23, 23, 255));
            textareaactive.Apply();

            // box
            box.SetPixel(0, 0, new Color32(30, 30, 30, 255));
            box.Apply();

            // scroll bar
            scrollview.SetPixel(0, 0, new Color32(55, 55, 55, 255));
            scrollview.Apply();
            scrollviewhovered.SetPixel(0, 0, new Color32(75, 75, 75, 255));
            scrollviewhovered.Apply();
            scrollviewactive.SetPixel(0, 0, new Color32(100, 100, 100, 255));
            scrollviewactive.Apply();

        }
        public void Updatestuff()
        {
            // button
            GUI.skin.button.onNormal.background = button;
            GUI.skin.button.onHover.background = buttonhovered;
            GUI.skin.button.onActive.background = buttonactive;
            GUI.skin.button.normal.background = button;
            GUI.skin.button.hover.background = buttonhovered;
            GUI.skin.button.active.background = buttonactive;
            GUI.skin.button.richText = true;
            GUI.skin.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            GUI.skin.button.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

            // window
            GUI.skin.window.onNormal.background = windowbackground;
            GUI.skin.window.onHover.background = windowbackgroundhover;
            GUI.skin.window.onActive.background = windowbackground;
            GUI.skin.window.onNormal.textColor = Color.gray * 1.8f;
            GUI.skin.window.onHover.textColor = Color.white;
            GUI.skin.window.onActive.textColor = Color.white;
            GUI.skin.window.normal.background = windowbackground;
            GUI.skin.window.hover.background = windowbackgroundhover;
            GUI.skin.window.active.background = windowbackground;
            GUI.skin.window.normal.textColor = Color.gray * 1.8f;
            GUI.skin.window.hover.textColor = Color.white;
            GUI.skin.window.active.textColor = Color.white;

            // text field & text area
            GUI.skin.textArea.onNormal.background = textarea;
            GUI.skin.textArea.onHover.background = textareahovered;
            GUI.skin.textArea.onActive.background = textareaactive;
            GUI.skin.textField.onNormal.background = textarea;
            GUI.skin.textField.onHover.background = textareahovered;
            GUI.skin.textField.onActive.background = textareaactive;
            GUI.skin.textField.onFocused.background = textareaactive;
            GUI.skin.textArea.normal.background = textarea;
            GUI.skin.textArea.hover.background = textareahovered;
            GUI.skin.textArea.active.background = textareaactive;
            GUI.skin.textField.normal.background = textarea;
            GUI.skin.textField.hover.background = textareahovered;
            GUI.skin.textField.active.background = textareaactive;
            GUI.skin.textField.focused.background = textareaactive;

            // box
            GUI.skin.box.onNormal.background = box;
            GUI.skin.box.onHover.background = box;
            GUI.skin.box.onActive.background = box;
            GUI.skin.box.onNormal.textColor = Color.white;
            GUI.skin.box.onHover.textColor = Color.white;
            GUI.skin.box.onActive.textColor = Color.white;
            GUI.skin.box.normal.background = box;
            GUI.skin.box.hover.background = box;
            GUI.skin.box.active.background = box;
            GUI.skin.box.normal.textColor = Color.white;
            GUI.skin.box.hover.textColor = Color.white;
            GUI.skin.box.active.textColor = Color.white;
            GUI.skin.box.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            GUI.skin.box.fontSize = 12;
            GUI.skin.box.richText = true;
            GUI.skin.box.alignment = TextAnchor.UpperCenter;

            // scroll bar
            GUI.skin.scrollView.onNormal.background = scrollview;
            GUI.skin.scrollView.onHover.background = scrollviewhovered;
            GUI.skin.scrollView.onActive.background = scrollviewactive;
            GUI.skin.scrollView.normal.background = scrollview;
            GUI.skin.scrollView.hover.background = scrollviewhovered;
            GUI.skin.scrollView.active.background = scrollviewactive;


        }
        public Rect windowRect = new Rect(20, 20, 550, 350);
        static bool Open = false;
        static bool stopopen = false;
        static float deltaTime;
        static int page = -1;
        static bool Follownearest = false;
        static VRRig closestrig;
        static bool followner = false;
        static bool Raisehands = false;
        static bool ESP = false;
        static Texture2D playerpic = new Texture2D(1, 1);
        void OnGUI()
        {
            Init();
            Updatestuff();
            if (UnityInput.Current.GetKeyDown(KeyCode.RightShift))
            {
                if (stopopen)
                {
                    Open = !Open;
                    stopopen = false;
                }
            }
            else
            {
                stopopen = true;
            }
            if (Open)
            {
                
                deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
                windowRect = GUI.Window(0, windowRect, DoMyWindow, "");
            }
            if (UnityInput.Current.GetKeyDown(KeyCode.Backspace))
            {

            }
        }
        void ResetWindow()
        {
            windowRect = new Rect(windowRect.x, windowRect.y, 550, 350);
        }
        void DoMyWindow(int windowID)
        {
            #region Window INIT
            GUI.Box(new Rect(0, 0, 120, windowRect.height), "KMAN UI [FPS: " + Mathf.Round(1f / deltaTime) + "]");
            GUI.BeginGroup(new Rect(0, 30, 120, 250));
            
            if (GUI.Button(new Rect(0, 20, 120, 50), "<size=16>Player</size>"))
            {
                page = 1;
            }
            Init();
            //GUI.DrawTexture(new Rect(0, 20, 50, 50), playerpic);
            GUI.EndGroup();
            #endregion

            #region ModManager
            switch (page)
            {
                case 1:

                    if (GUI.Button(new Rect(130, 10, 75, 25), "WASD"))
                    {
                        WASD = !WASD;
                    }

                    break;
                case 2:

                    break;
            }
            #endregion




            GUI.DragWindow(new Rect(0, 0, 1000, 1000));
        }
        static bool WASD = false;
        internal static Vector3 previousMousePosition;
        static float speed = 10;
        static float grav = -9.81f;
        static bool sesp = false;
        static bool once2 = true;
        static GameObject pointer = null;
        static bool Spammer;
        static bool spammer2;
        static int hashtype = -820530352;
        static void AdvancedWASD()
        {
            float NSpeed = speed * Time.deltaTime;
            if (UnityInput.Current.GetKey(KeyCode.LeftShift) || UnityInput.Current.GetKey(KeyCode.RightShift))
            {
                NSpeed *= 10f;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftArrow) || UnityInput.Current.GetKey(KeyCode.A))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.right * -1f * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.RightArrow) || UnityInput.Current.GetKey(KeyCode.D))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.right * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.UpArrow) || UnityInput.Current.GetKey(KeyCode.W))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.forward * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.DownArrow) || UnityInput.Current.GetKey(KeyCode.S))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.forward * -1f * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.Space) || UnityInput.Current.GetKey(KeyCode.PageUp))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.up * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftControl) || UnityInput.Current.GetKey(KeyCode.PageDown))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.up * -1f * NSpeed;
            }
            if (UnityInput.Current.GetMouseButton(1))
            {
                Vector3 val = UnityInput.Current.mousePosition - previousMousePosition;
                float num2 = GorillaLocomotion.Player.Instance.transform.localEulerAngles.y + val.x * 0.3f;
                float num3 = GorillaLocomotion.Player.Instance.transform.localEulerAngles.x - val.y * 0.3f;
                GorillaLocomotion.Player.Instance.transform.localEulerAngles = new Vector3(num3, num2, 0f);
            }
            previousMousePosition = UnityInput.Current.mousePosition;

        }
        void Update()
        {
            Physics.gravity = new Vector3(0, grav, 0);

            if (WASD)
            {
                AdvancedWASD();
            }
            if (Spammer)
            {

                Ray ray = GameObject.Find("Shoulder Camera").GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition);

                RaycastHit raycastHit;
                Physics.Raycast(ray.origin, ray.direction, out raycastHit);
                if (pointer == null)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Object.Destroy(pointer.GetComponent<Rigidbody>());
                    Object.Destroy(pointer.GetComponent<SphereCollider>());
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
                pointer.transform.position = raycastHit.point;
                if (UnityInput.Current.GetMouseButton(0))
                {
                    Vector3 startPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
                    Vector3 targetPosition = raycastHit.point;
                    Vector3 directionToTarget = (targetPosition - startPosition).normalized;
                    float strength = 140f;
                    directionToTarget *= strength;
                    int num2 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                    GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", RpcTarget.All, new object[]
                    {
                             startPosition,
                             directionToTarget,
                             hashtype,
                             -1,
                             true,
                             num2,
                             false,
                             1f,
                             1f,
                             1f,
                             1f,
                    });


                }

            }
            if (spammer2)
            {
                Ray ray = GameObject.Find("Shoulder Camera").GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition);

                RaycastHit raycastHit;
                Physics.Raycast(ray.origin, ray.direction, out raycastHit);
                if (pointer == null)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Object.Destroy(pointer.GetComponent<Rigidbody>());
                    Object.Destroy(pointer.GetComponent<SphereCollider>());
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
                pointer.transform.position = raycastHit.point;
                if (UnityInput.Current.GetMouseButton(0))
                {
                    Vector3 startPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
                    Vector3 targetPosition = raycastHit.point;
                    Vector3 directionToTarget = (targetPosition - startPosition).normalized;
                    float strength = 140f;
                    directionToTarget *= strength;
                    float random1 = UnityEngine.Random.Range(0f, 1f);
                    float random2 = UnityEngine.Random.Range(0f, 1f);
                    float random3 = UnityEngine.Random.Range(0f, 1f);
                    Type photon = typeof(PhotonNetwork);
                    MethodInfo ExecuteRpc = photon.GetMethod("ExecuteRpc", BindingFlags.Static | BindingFlags.NonPublic);
                    MethodInfo RaiseEventInternal = photon.GetMethod("RaiseEventInternal", BindingFlags.Static | BindingFlags.NonPublic);
                    RaiseEventOptions RaiseEventOptionsInternal = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.All
                    };
                    Hashtable tabel = new Hashtable();
                    tabel.Add(0, GorillaGameManager.instance.photonView.ViewID);
                    tabel.Add(2, (int)PhotonNetwork.Time);
                    tabel.Add(3, "LaunchSlingshotProjectile");
                    tabel.Add(4, 
                    new object[]
                        {
                             startPosition,
                             directionToTarget,
                             -675036877,
                             -1,
                             true,
                             GorillaGameManager.instance.IncrementLocalPlayerProjectileCount(),
                            true,
                            random1,
                            random2,
                             random3,
                             1f,
                        });
                    RaiseEventInternal.Invoke(photon, new object[]
                    {
                    (byte)200,
                    tabel,
                    RaiseEventOptionsInternal,
                    SendOptions.SendReliable
                    });
                    ExecuteRpc.Invoke(photon, new object[] { tabel, PhotonNetwork.LocalPlayer });
                }
            }
            if (ESP)
            {
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (rig != null && !rig.isOfflineVRRig && !rig.isMyPlayer)
                    {
                        if (!rig.isOfflineVRRig && !rig.isMyPlayer && rig.mainSkin.material.name.Contains("fected"))
                        {
                            rig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            rig.mainSkin.material.color = new Color(9f, 0f, 0f, 0.15f);
                        }
                        else if (!rig.isOfflineVRRig && !rig.isMyPlayer)
                        {
                            rig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            rig.mainSkin.material.color = new Color(0f, 9f, 0f, 0.15f);
                        }
                        GameObject lines = new GameObject("Line");
                        LineRenderer lr = lines.AddComponent<LineRenderer>();
                        var color = new Color(rig.mainSkin.material.color.r, rig.mainSkin.material.color.b, rig.mainSkin.material.color.b, 1);
                        lr.startColor = color;
                        lr.endColor = color;
                        lr.startWidth = 0.01f;
                        lr.endWidth = 0.01f;
                        lr.positionCount = 2;
                        lr.useWorldSpace = true;
                        lr.SetPosition(0, GorillaLocomotion.Player.Instance.headCollider.transform.position);
                        lr.SetPosition(1, rig.transform.position);
                        lr.material.shader = Shader.Find("GUI/Text Shader");
                        Destroy(lr, Time.deltaTime);
                        Destroy(lines, Time.deltaTime);
                        sesp = false;
                    }
                }
            }
            else
            {
                if (!sesp)
                {
                    if (!sesp)
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                            {
                                vrrig.ChangeMaterialLocal(vrrig.currentMatIndex);
                            }
                        }
                        sesp = true;
                    }
                    sesp = true;
                }
            }
            if (Raisehands)
            {
                GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position += new Vector3(0, 10, 0);
                GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position += new Vector3(0, 10, 0);
            }
            if (followner)
            {
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (!rig.isMyPlayer && rig.playerText.text != PhotonNetwork.LocalPlayer.NickName && !rig.isOfflineVRRig)
                    {
                        if (closestrig == null)
                        {
                            closestrig = rig;
                        }
                        if (Vector3.Distance(GorillaLocomotion.Player.Instance.transform.position, closestrig.transform.position) > Vector3.Distance(GorillaLocomotion.Player.Instance.transform.position, rig.transform.position))
                        {
                            closestrig = rig;
                        }
                    }
                    GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position = closestrig.transform.position;
                    GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position = closestrig.transform.position;
                }
            }
            if (Follownearest)
            {
                if (once2)
                {
                    MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    if (array != null)
                    {
                        foreach (MeshCollider collider in array)
                        {
                            if (!collider.gameObject.name.Contains("pit"))
                            {
                                if (collider.enabled == true)
                                {
                                    collider.enabled = false;
                                }
                                else
                                {
                                    collider.enabled = true;
                                }
                            }
                        }
                    }
                    once2 = false;
                }
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (!rig.isMyPlayer && rig.playerText.text != PhotonNetwork.LocalPlayer.NickName && !rig.isOfflineVRRig)
                    {
                        if (closestrig == null)
                        {
                            closestrig = rig;
                        }
                        if (Vector3.Distance(GorillaLocomotion.Player.Instance.transform.position, closestrig.transform.position) > Vector3.Distance(GorillaLocomotion.Player.Instance.transform.position, rig.transform.position))
                        {
                            closestrig = rig;
                        }
                    }
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity = new Vector3(0, 0, 0);
                    GorillaLocomotion.Player.Instance.transform.LookAt(closestrig.transform.position);
                    GorillaLocomotion.Player.Instance.transform.position = Vector3.Lerp(GorillaLocomotion.Player.Instance.transform.position, closestrig.transform.position, 0.1f * Time.deltaTime);
                    GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position = closestrig.transform.position;
                    GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position = closestrig.transform.position;
                }
            }
            else
            {
                if (!once2)
                {
                    MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    if (array != null)
                    {
                        foreach (MeshCollider collider in array)
                        {
                            if (!collider.gameObject.name.Contains("pit"))
                            {
                                if (collider.enabled == true)
                                {
                                    collider.enabled = false;
                                }
                                else
                                {
                                    collider.enabled = true;
                                }
                            }
                        }
                    }
                    once2 = true;
                }
            }
        }

    }
}
