using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

namespace DissolveExample
{
    public class DissolveChilds : MonoBehaviour
    {
        // Start is called before the first frame update
        List<Material> materials = new List<Material>();
        public bool PingPong = false;
        [SerializeField] SkinnedMeshRenderer broken, healthy;

        public float value;

        private float timer;

        bool eventone;
        bool eventtwo;

        void Start()
        {
            //var renders = GetComponentsInChildren<Renderer>();
            //for (int i = 0; i < renders.Length; i++)
            //{
                //materials.AddRange(renders[i].materials);
            //}

            

            //SetValue(value);
        }


        public void Second_DNA_Activated() {
            if (First_Interactable.Instance.readyToTranstionSecondModel) {
                First_Interactable.Instance.HideUI();
                gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        public void Shader_Dissolve_Activated() {
            Debug.Log("shader Activated 1...");

            eventone = true;
            eventtwo = false;
            // make delay here....
            //timer = 0;
        }

        public void Shader_Dissolve_Activated1() {
            Debug.Log("shader Activated 2...");
            value = 1;
            eventone = false;
            eventtwo = true;
            // make delay here....
            //timer = 0;
        }

        public void Collider_Activated() {
            First_Interactable.Instance.Collider_Activated();
        }

        private void Reset()
        {
            //Start();
            //SetValue(0);
        }

        // Update is called once per frame
        void Update()
        {
           
            if (eventone) {


                value += Time.deltaTime;//Mathf.Lerp(0, 1, Time.time * 0.100f); // Mathf.PingPong(time.time * 0.5f);
                broken.material.SetFloat("_Dissolve", value);
            }

            if (eventtwo) {
                value -= Time.deltaTime;
                healthy.material.SetFloat("_Dissolve", value);
            }

        }

        //IEnumerator enumerator()
        //{

        //    //float value =         while (true)
        //    //{
        //    //    Mathf.PingPong(value, 1f);
        //    //    value += Time.deltaTime;
        //    //    SetValue(value);
        //    //    yield return new WaitForEndOfFrame();
        //    //}
        //}

        public void SetValue(float value)
        {
            
            for (int i = 0; i < materials.Count; i++) {
                materials[i].SetFloat("_Dissolve", value);
            }

            
        }

        public void Shader_Dissolve_Dectivated() {
            Debug.Log("shader Dectivated...");
            eventone = true;
        }

        public void Shader_Dissolve_Dectivated1() {
            Debug.Log("shader Dectivated...");
            
        }


        public void healthyLung_Activated() {
            // continuing the aniamtion..
             First_Interactable.Instance.healthyLung_Activated();
        }

        public void healthyLung_Dectivated() {
            // continuing the aniamtion..
            First_Interactable.Instance.healthyLung_Dectivated();
        }

        public void DelayToShowTheReference() {
            Invoke("TheReference", 3f);
        }

        private void TheReference() {
            First_Interactable.Instance.ShowTheReference();
        }
    }
}