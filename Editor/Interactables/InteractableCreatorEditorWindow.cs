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
        private const string convertButtonText = "Convert To Interactable";
        private const string embedButtonText = "Embed Interactable Into GameObject";
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
                if (GUILayout.Button(convertButtonText))
                {
                    foreach (Transform selectedTransform in Selection.transforms)
                    {
                        ConvertSelectedGameObject(selectedTransform.gameObject);
                    }
                }

                if (GUILayout.Button(embedButtonText))
                {
                    foreach (Transform selectedTransform in Selection.transforms)
                    {
                        EmbedIntoSelectedGameObject(selectedTransform.gameObject);
                    }
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

        protected virtual void ConvertSelectedGameObject(GameObject objectToConvert)
        {
            if (!interactableFactory.CanConvert(objectToConvert))
            {
                return;
            }

            GameObject newInteractable = (GameObject)PrefabUtility.InstantiatePrefab(interactablePrefab);
            interactableFactory.Create(newInteractable, objectToConvert);
        }

        protected virtual void EmbedIntoSelectedGameObject(GameObject embedObject)
        {
            if (!interactableFactory.CanConvert(embedObject))
            {
                return;
            }

            GameObject newInteractable = (GameObject)PrefabUtility.InstantiatePrefab(interactablePrefab);
            interactableFactory.Embed(newInteractable, embedObject);
        }

        [MenuItem(windowPath + windowTitle)]
        private static void ShowWindow()
        {
            promptWindow = EditorWindow.GetWindow(typeof(InteractableCreatorEditorWindow));
            promptWindow.titleContent = new GUIContent(windowTitle);
        }
    }
}