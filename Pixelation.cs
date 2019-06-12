using Assets.Pixelation.Example.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Pixelation.Scripts
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Pixelation")]
    public class Pixelation : ImageEffectBase
    {
        [Range(64.0f, 512.0f)] public float BlockCount = 128;
        public Slider pixelSlider;
        private void Start()
        {
            if (GameObject.FindGameObjectWithTag("PixelSlider"))
            {
                pixelSlider = GameObject.FindGameObjectWithTag("PixelSlider").GetComponentInChildren<Slider>();
            }
            
            
        }
        

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            float c = 0;
            if (Camera.main != null)
            {
                 c = Camera.main.aspect;

            }
            else
            {
                 c = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>().aspect;
            }
            float k = c;
            Vector2 count = new Vector2(BlockCount, BlockCount/k);
            Vector2 size = new Vector2(1.0f/count.x, 1.0f/count.y);
            //
            material.SetVector("BlockCount", count);
            material.SetVector("BlockSize", size);
            Graphics.Blit(source, destination, material);
        }
        public void PixelSlider()
        {

            if (GameObject.FindGameObjectWithTag("PixelSlider"))
            {
                pixelSlider = GameObject.FindGameObjectWithTag("PixelSlider").GetComponentInChildren<Slider>();
            }
            //pixelSlider = GameObject.FindGameObjectWithTag("StartScreen").GetComponentInChildren<Slider>();

            BlockCount = pixelSlider.value;
        }
    }
}