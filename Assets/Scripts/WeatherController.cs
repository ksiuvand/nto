using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeatherController : MonoBehaviour
{
    public GameObject rain;
    public float delayWeather = 5f;
    public float speedWeather = 3f;

    [SerializeField]
    private GameObject mat;
    [SerializeField]
    private GameObject _skyFog;

    private WaterController wat;
    
    
    private int randomWeatherNum;
    private float nextTime;
    SerializedObject serializedObj;
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time;
        wat = mat.GetComponent<WaterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fog = enabled;
        if (Time.time > nextTime){
            nextTime = Time.time + delayWeather;
            randomWeatherNum = Random.Range(0, 8);
            if (randomWeatherNum == 0){
                rain.SetActive(true);
            }
            else if (randomWeatherNum == 1){
                rain.SetActive(false);
            }
            else if (randomWeatherNum == 2){
                rain.SetActive(false);
            }else if (randomWeatherNum == 3){
                rain.SetActive(true);
            }else if (randomWeatherNum == 4){
                rain.SetActive(false);
            }
            else if (randomWeatherNum == 5){
                RenderSettings.fog = false;
                wat.material.SetFloat("Wavelength1", 2);
                wat.material.SetFloat("Speed1", 0.5f);
                wat.material.SetFloat("Steepness1", 0.1f);

                wat.material.SetFloat("Wavelength2", 1);
                wat.material.SetFloat("Speed2", 0.3f);
                wat.material.SetFloat("Steepness2", 0.2f);

                wat.material.SetFloat("Wavelength3", 0.5f);
                wat.material.SetFloat("Speed3", 0.1f);
                wat.material.SetFloat("Steepness3", -0.26f);
            }else if (randomWeatherNum == 6){
                RenderSettings.fog = true;
                wat.material.SetFloat("Wavelength1", 8);
                wat.material.SetFloat("Speed1", 5);
                wat.material.SetFloat("Steepness1", 0.25f);

                wat.material.SetFloat("Wavelength2", 10);
                wat.material.SetFloat("Speed2", 3);
                wat.material.SetFloat("Steepness2", 0.2f);

                wat.material.SetFloat("Wavelength3",20);
                wat.material.SetFloat("Speed3", 2);
                wat.material.SetFloat("Steepness3", -0.26f);
                rain.SetActive(true);
            }else if (randomWeatherNum == 7){
                rain.SetActive(true);
                RenderSettings.fog = true;
                wat.material.SetFloat("Wavelength1", 4);
                wat.material.SetFloat("Speed1", 1);
                wat.material.SetFloat("Steepness1", 0.25f);

                wat.material.SetFloat("Wavelength2", 5);
                wat.material.SetFloat("Speed2", 3);
                wat.material.SetFloat("Steepness2", 0.2f);

                wat.material.SetFloat("Wavelength3", 3);
                wat.material.SetFloat("Speed3", 5);
                wat.material.SetFloat("Steepness3", 0.3f);
            }
        }
    }
}
