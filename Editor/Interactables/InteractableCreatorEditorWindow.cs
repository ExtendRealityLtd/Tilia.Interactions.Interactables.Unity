namespace Tilia.Interactions.Interactables
{
    using UnityEditor;
    using UnityEngine;

    [InitializeOnLoad]
    public class InteractableCreatorEditorWindow : EditorWindow
    {
        private const string windowTitle = "Interactable Creator";
        private const string assetName = "Interactions.Interactable";
        private const string assetSuffix = ".prefab";
        private static EditorWindow promptWindow;
        private Vector2 scrollPosition;
        private GameObject interactablePrefab;

        public void OnGUI()
        {
            using (GUILayout.ScrollViewScope scrollViewScope = new GUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scrollViewScope.scrollPosition;
                GUILayout.Label("Interactable Creator", EditorStyles.boldLabel);
                if (GUILayout.Button("Convert To Interactable"))
                {
                    ProcessSelectedGameObjects();
                }
            }
        }

        protected virtual void OnEnable()
        {
            foreach (string assetGUID in AssetDatabase.FindAssets(assetName))
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetGUID);
                if (assetPath.Contains(assetName + assetSuffix))
                {
                    interactablePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                }
            }
        }

        protected virtual void ProcessSelectedGameObjects()
        {
            foreach (Transform selectedTransform in Selection.transforms)
            {
                ConvertSelectedGameObject(selectedTransform.gameObject);
            }
        }

        protected virtual void ConvertSelectedGameObject(GameObject objectToConvert)
        {
            InteractableFacade interactable = objectToConvert.GetComponentInParent<InteractableFacade>();
            if (interactable == null)
            {
                CreateInteractable(objectToConvert);
            }
        }

        protected virtual void CreateInteractable(GameObject objectToWrap)
        {
            int siblingIndex = objectToWrap.transform.GetSiblingIndex();
            GameObject newInteractable = (GameObject)PrefabUtility.InstantiatePrefab(interactablePrefab);
            newInteractable.name += "_" + objectToWrap.name;
            InteractableFacade facade = newInteractable.GetComponent<InteractableFacade>();

            newInteractable.transform.SetParent(objectToWrap.transform.parent);
            newInteractable.transform.localPosition = objectToWrap.transform.localPosition;
            newInteractable.transform.localRotation = objectToWrap.transform.localRotation;
            newInteractable.transform.localScale = objectToWrap.transform.localScale;

            foreach (MeshRenderer defaultMeshes in facade.Configuration.MeshContainer.GetComponentsInChildren<MeshRenderer>())
            {
                defaultMeshes.gameObject.SetActive(false);
            }

            objectToWrap.transform.SetParent(facade.Configuration.MeshContainer.transform);
            objectToWrap.transform.localPosition = Vector3.zero;
            objectToWrap.transform.localRotation = Quaternion.identity;
            objectToWrap.transform.localScale = Vector3.one;

            newInteractable.transform.SetSiblingIndex(siblingIndex);
        }

        [MenuItem("Window/Tilia/Interactions/" + windowTitle)]
        private static void ShowWindow()
        {
            promptWindow = EditorWindow.GetWindow(typeof(InteractableCreatorEditorWindow));
            promptWindow.titleContent = new GUIContent(windowTitle);
        }
    }
}