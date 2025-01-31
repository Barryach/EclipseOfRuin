//using UnityEngine;

//public class SaveCubePlayer : MonoBehaviour
//{
//    GuidComponent guidComponent;

//    private void Awake()
//    {
//        guidComponent = GetComponent<GuidComponent>();
//    }

//    void Start()
//    {
//        LoadSavedData();
//    }

//    void Update()
//    {
//        SaveData();
//    }

//    private void SaveData()
//    {
//        SaveGameSystem.SetFloat(guidComponent.GetGuid() + SaveGameStrings.posicionX, transform.position.x);
//        SaveGameSystem.SetFloat(guidComponent.GetGuid() + SaveGameStrings.posicionY, transform.position.y);
//        SaveGameSystem.SetFloat(guidComponent.GetGuid() + SaveGameStrings.posicionZ, transform.position.z);
//    }
//    private void LoadSavedData()
//    {
//        Vector3 loadedPosition = new Vector3();

//        loadedPosition.x = SaveGameSystem.GetFloat(guidComponent.GetGuid() + SaveGameStrings.posicionX, transform.position.x);
//        loadedPosition.y = SaveGameSystem.GetFloat(guidComponent.GetGuid() + SaveGameStrings.posicionY, transform.position.y);
//        loadedPosition.z = SaveGameSystem.GetFloat(guidComponent.GetGuid() + SaveGameStrings.posicionZ, transform.position.z);

//        transform.position = loadedPosition;
//    }    
//}
