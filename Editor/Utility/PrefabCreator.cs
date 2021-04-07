namespace Tilia.Interactions.Interactables.Utility
{
    using System.IO;
    using UnityEditor;
    using Zinnia.Utility;

    public class PrefabCreator : BasePrefabCreator
    {
        private const string group = "Tilia/";
        private const string project = "Interactions/";
        private const string menuItemRoot = topLevelMenuLocation + group + subLevelMenuLocation + project;
        private const string interactorRoot = "Interactors/";
        private const string interactableRoot = "Interactables/";

        private const string package = "io.extendreality.tilia.interactions.interactables.unity";
        private const string baseDirectory = "Runtime";
        private const string prefabDirectory = "Prefabs";
        private const string prefabSuffix = ".prefab";

        private const string prefabInteractionsInteractor = "Interactions.Interactor";
        private const string prefabInteractionsActionPublisher = "Interactions.ActionPublisher";
        private const string prefabInteractionsInteractable = "Interactions.Interactable";
        private const string prefabInteractionsActionReceiver = "Interactions.ActionReceiver";

        [MenuItem(menuItemRoot + interactorRoot + prefabInteractionsInteractor, false, priority)]
        private static void AddInteractionsInteractor()
        {
            string prefab = prefabInteractionsInteractor + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, interactorRoot, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }

        [MenuItem(menuItemRoot + interactorRoot + prefabInteractionsActionPublisher, false, priority)]
        private static void AddInteractionsActionPublisher()
        {
            string prefab = prefabInteractionsActionPublisher + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, interactorRoot, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }

        [MenuItem(menuItemRoot + interactableRoot + prefabInteractionsInteractable, false, priority)]
        private static void AddInteractionsInteractable()
        {
            string prefab = prefabInteractionsInteractable + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, interactableRoot, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }

        [MenuItem(menuItemRoot + interactableRoot + prefabInteractionsActionReceiver, false, priority)]
        private static void AddInteractionsActionReceiver()
        {
            string prefab = prefabInteractionsActionReceiver + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, interactableRoot, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }
    }
}