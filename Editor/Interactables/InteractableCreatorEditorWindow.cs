namespace Tilia.Interactions.Interactables.Interactables
{
    using Tilia.Interactions.Interactables.Interactables.Utility;
    using UnityEditor;
    using UnityEngine;

    [InitializeOnLoad]
    public class InteractableCreatorEditorWindow : EditorWindow
    {
        private const string windowPath = "Window/Tilia/Interactions/";
        private const string windowTitle = "Interactable Creator";
        private const string assetName = "Interactions.Interactable";
        private const string assetSuffix = ".prefab";
        private const string buttonText = "Convert To Interactable";
        private static EditorWindow promptWindow;
        private Vector2 scrollPosition;
        private GameObject interactablePrefab;
        private InteractableFactory interactableFactory = new InteractableFactory();

        public void OnGUI()
        {
            using (GUILayout.ScrollViewScope scrollViewScope = new GUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scrollViewScope.scrollPosition;
                GUILayout.Label(windowTitle, EditorStyles.boldLabel);
                if (GUILayout.Button(buttonText))
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
            if (!interactableFactory.CanConvert(objectToConvert))
            {
                return;
            }

            GameObject newInteractable = (GameObject)PrefabUtility.InstantiatePrefab(interactablePrefab);
            interactableFactory.Create(newInteractable, objectToConvert);
        }

        [MenuItem(windowPath + windowTitle)]
        private static void ShowWindow()
        {
            promptWindow = EditorWindow.GetWindow(typeof(InteractableCreatorEditorWindow));
            promptWindow.titleContent = new GUIContent(windowTitle);
        }
    }
}