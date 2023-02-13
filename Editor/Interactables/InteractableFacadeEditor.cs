namespace Tilia.Interactions.Interactables.Interactables
{
    using System;
    using Tilia.Interactions.Interactables.Interactables.Grab.Action;
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Zinnia.Rule;
    using Zinnia.Tracking.Follow.Modifier.Property.Rotation;
    using Zinnia.Utility;

    [CustomEditor(typeof(InteractableFacade), true)]
    public class InteractableFacadeEditor : ZinniaInspector
    {
        private const string primaryActionTitle = "Primary Action Settings";
        private const string primaryActionLabel = "Primary Action";
        private const string secondaryActionTitle = "Secondary Action Settings";
        private const string secondaryActionLabel = "Secondary Action";
        private const string disallowedTouchInteractorTitle = "Disallowed Touch Interactor Settings";
        private const string disallowedGrabInteractorTitle = "Disallowed Grab Interactor Settings";
        private const string showMeshContainerButtonText = "Show Mesh Container";
        private const string showOrientationRuleButtonText = "Show Orientation Rule Container";
        private const string showOrientationHandleButtonText = "Show Orientation Handle Container";
        private const string showFollowContainerButtonText = "Show Follow Tracking Container";
        private const string velocityMultiplierTitle = "Velocity Multiplier Settings";
        private const string advancedFollowTitle = "Advanced Follow Settings";
        private const string customFollowOption = "Custom";

        private static readonly int[] primaryActionsIndexes = new int[] { 0, 1 };
        private static readonly int[] secondaryActionsIndexes = new int[] { 0, 1, 2, 3, 4 };

        private string[] primaryActions = new string[0];
        private string[] secondaryActions = new string[0];

        private InteractableFacade facade;
        private int currentPrimaryActionIndex;
        private int currentSecondaryActionIndex;
        private int selectedPrimaryActionIndex;
        private int selectedSecondaryActionIndex;
        private bool showFollowAdvancedFeatures;
        private bool grabConfigurationIsDirty;
        private bool showVelocityMultiplierFeatures;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!facade.Configuration.IsGrabConfigurationSet())
            {
                return;
            }

            string undoRedoWarningPropertyPath = UndoRedoWarningPropertyPath;
            grabConfigurationIsDirty = false;

            EditorHelper.DrawHorizontalLine();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField(primaryActionTitle, EditorStyles.boldLabel);

            selectedPrimaryActionIndex = EditorGUILayout.Popup(new GUIContent(primaryActionLabel), currentPrimaryActionIndex, primaryActions);

            GrabInteractableAction currentPrimaryAction = facade.Configuration.GetPrimaryAction();
            GrabInteractableAction updatedPrimaryAction =
                currentPrimaryActionIndex == selectedPrimaryActionIndex || selectedPrimaryActionIndex == 0
                ? facade.Configuration.GetPrimaryAction()
                : facade.Configuration.UpdatePrimaryAction(primaryActionsIndexes[selectedPrimaryActionIndex - 1]);
            currentPrimaryActionIndex = selectedPrimaryActionIndex;

            DrawFollowActionSettings(facade, facade.Configuration.GetPrimaryAction(), undoRedoWarningPropertyPath);

            EditorHelper.DrawHorizontalLine();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField(secondaryActionTitle, EditorStyles.boldLabel);

            selectedSecondaryActionIndex = EditorGUILayout.Popup(new GUIContent(secondaryActionLabel), currentSecondaryActionIndex, secondaryActions);

            GrabInteractableAction currentSecondaryAction = facade.Configuration.GetSecondaryAction();
            GrabInteractableAction updatedSecondaryAction =
                currentSecondaryActionIndex == selectedSecondaryActionIndex || selectedSecondaryActionIndex == 0
                ? facade.Configuration.GetSecondaryAction()
                : facade.Configuration.UpdateSecondaryAction(secondaryActionsIndexes[selectedSecondaryActionIndex - 1]);
            currentSecondaryActionIndex = selectedSecondaryActionIndex;

            grabConfigurationIsDirty = currentPrimaryAction != updatedPrimaryAction || currentSecondaryAction != updatedSecondaryAction;

            DrawFollowActionSettings(facade, facade.Configuration.GetSecondaryAction(), undoRedoWarningPropertyPath);

            EditorHelper.DrawHorizontalLine();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField(disallowedTouchInteractorTitle, EditorStyles.boldLabel);

            EditorGUI.indentLevel++;
            if (IsConfigurationSet())
            {
                DrawDisallowedInteractorsList(facade.Configuration.DisallowedTouchInteractors, undoRedoWarningPropertyPath);
            }
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField(disallowedGrabInteractorTitle, EditorStyles.boldLabel);

            EditorGUI.indentLevel++;
            if (IsConfigurationSet())
            {
                DrawDisallowedInteractorsList(facade.Configuration.DisallowedGrabInteractors, undoRedoWarningPropertyPath);
            }
            EditorGUI.indentLevel--;

            EditorHelper.DrawHorizontalLine();

            GUILayout.BeginHorizontal("GroupBox");
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(showMeshContainerButtonText))
            {
                EditorGUIUtility.PingObject(facade.Configuration.MeshContainer);
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            if (grabConfigurationIsDirty)
            {
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                EditorUtility.SetDirty(facade.Configuration.GrabConfiguration);
            }
        }

        protected virtual void OnEnable()
        {
            facade = (InteractableFacade)serializedObject.targetObject;
            SetActionArray(facade, primaryActionsIndexes, ref primaryActions);
            SetActionArray(facade, secondaryActionsIndexes, ref secondaryActions);

            currentPrimaryActionIndex = UpdateIndex(facade, facade.Configuration.GetPrimaryAction(), primaryActionsIndexes, currentPrimaryActionIndex);
            currentSecondaryActionIndex = UpdateIndex(facade, facade.Configuration.GetSecondaryAction(), secondaryActionsIndexes, currentSecondaryActionIndex);
        }

        protected virtual bool IsConfigurationSet()
        {
            return facade != null && facade.Configuration != null;
        }

        protected virtual SerializedProperty DrawPropertyFieldWithChangeHandlers(SerializedObject sourceObject, string propertyName, string undoRedoWarningPropertyPath)
        {
            SerializedProperty foundProperty = sourceObject.FindProperty(propertyName);
            if (foundProperty == null)
            {
                return null;
            }

            ProcessObjectProperty(foundProperty, undoRedoWarningPropertyPath);
            return foundProperty;
        }

        protected virtual void DrawFollowActionSettings(InteractableFacade facade, GrabInteractableAction actionProperty, string undoRedoWarningPropertyPath)
        {
            if (actionProperty == null || !typeof(GrabInteractableFollowAction).IsAssignableFrom(actionProperty.GetType()))
            {
                return;
            }

            EditorGUI.indentLevel++;
            GrabInteractableFollowAction followAction = (GrabInteractableFollowAction)actionProperty;
            SerializedObject actionObject = new SerializedObject(followAction);

            SerializedProperty followTracking = DrawPropertyFieldWithChangeHandlers(actionObject, "followTracking", undoRedoWarningPropertyPath);

            GameObject followContainer = null;

            switch (followTracking.intValue)
            {
                case 0:
                    followContainer = followAction.FollowTransformModifier.gameObject;
                    break;
                case 1:
                    followContainer = followAction.FollowRigidbodyModifier.gameObject;
                    break;
                case 2:
                    followContainer = followAction.FollowRigidbodyForceRotateModifier.gameObject;
                    break;
                case 3:
                    followContainer = followAction.FollowTransformRotateOnPositionDifferenceModifier.gameObject;
                    break;
                case 4:
                    followContainer = followAction.FollowRotateAroundAngularVelocityModifier.gameObject;
                    break;
            }

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(" ");
            if (followContainer != null && GUILayout.Button(showFollowContainerButtonText))
            {
                EditorGUIUtility.PingObject(followContainer);
            }
            GUILayout.EndHorizontal();

            EditorGUI.indentLevel++;
            switch (followTracking.intValue)
            {
                case 4:
                    RotateAroundAngularVelocity rotationModifier = (RotateAroundAngularVelocity)followAction.FollowRotateAroundAngularVelocityModifier.RotationModifier;
                    DrawPropertyFieldWithChangeHandlers(new SerializedObject(rotationModifier), "applyToAxis", undoRedoWarningPropertyPath);
                    DrawPropertyFieldWithChangeHandlers(new SerializedObject(rotationModifier), "sourceMultiplier", undoRedoWarningPropertyPath);
                    break;
            }
            EditorGUI.indentLevel--;

            SerializedProperty grabOffset = DrawPropertyFieldWithChangeHandlers(actionObject, "grabOffset", undoRedoWarningPropertyPath);

            if (grabOffset.intValue == 1)
            {
                EditorGUI.indentLevel++;
                SerializedProperty orientationHandleLogic = DrawPropertyFieldWithChangeHandlers(actionObject, "orientationHandleLogic", undoRedoWarningPropertyPath);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel(" ");
                if (GUILayout.Button(showOrientationRuleButtonText))
                {
                    GameObject logicContainerToPing = followAction.OrientationLogicContainer;
                    switch (orientationHandleLogic.intValue)
                    {
                        case 0:
                            logicContainerToPing = followAction.OrientationRelationsLogicContainer;
                            break;
                        case 1:
                            logicContainerToPing = followAction.OrientationRulesMatcherLogicContainer;
                            break;
                    }
                    EditorGUIUtility.PingObject(logicContainerToPing);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel(" ");
                if (GUILayout.Button(showOrientationHandleButtonText))
                {
                    EditorGUIUtility.PingObject(followAction.OrientationHandleContainer);
                }
                EditorGUILayout.EndHorizontal();
                EditorGUI.indentLevel--;
            }

            SerializedObject velocityMultiplierObject = new SerializedObject(followAction.VelocityMultiplier);

            EditorHelper.DrawHorizontalLine();

            showVelocityMultiplierFeatures = EditorGUILayout.Foldout(showVelocityMultiplierFeatures, velocityMultiplierTitle);
            if (showVelocityMultiplierFeatures)
            {
                EditorGUI.indentLevel++;
                SerializedProperty velocityMultiplerValue = DrawPropertyFieldWithChangeHandlers(velocityMultiplierObject, "velocityMultiplierFactor", undoRedoWarningPropertyPath);
                SerializedProperty angularVelocityMultiplerValue = DrawPropertyFieldWithChangeHandlers(velocityMultiplierObject, "angularVelocityMultiplierFactor", undoRedoWarningPropertyPath);
                EditorGUI.indentLevel--;
            }

            showFollowAdvancedFeatures = EditorGUILayout.Foldout(showFollowAdvancedFeatures, advancedFollowTitle);
            if (showFollowAdvancedFeatures)
            {
                EditorGUI.indentLevel++;
                DrawPropertyFieldWithChangeHandlers(actionObject, "isKinematicWhenActive", undoRedoWarningPropertyPath);
                DrawPropertyFieldWithChangeHandlers(actionObject, "isKinematicWhenInactive", undoRedoWarningPropertyPath);
                DrawPropertyFieldWithChangeHandlers(actionObject, "willInheritIsKinematicWhenInactiveFromConsumerRigidbody", undoRedoWarningPropertyPath);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        protected virtual void DrawDisallowedInteractorsList(RuleContainer rule, string undoRedoWarningPropertyPath)
        {
            if (rule.Interface == null)
            {
                return;
            }

            ListContainsRule listRule = (ListContainsRule)rule.Interface;

            SerializedObject listObject = new SerializedObject(listRule.Objects);
            DrawPropertyFieldWithChangeHandlers(listObject, "elements", undoRedoWarningPropertyPath);
        }

        protected virtual int UpdateIndex(InteractableFacade facade, GrabInteractableAction actionProperty, int[] template, int index)
        {
            if (actionProperty == null)
            {
                return 0;
            }

            for (int actionIndex = 0; actionIndex < facade.Configuration.GrabActionTypesCount; actionIndex++)
            {
                GrabInteractableAction actionComponent = facade.Configuration.GetGrabActionTypeObject(actionIndex).GetComponent<GrabInteractableAction>();
                if (actionComponent != null && actionComponent.GetType() == actionProperty.GetType())
                {
                    return Array.IndexOf(template, actionIndex) + 1;
                }
            }

            return 0;
        }

        protected virtual void SetActionArray(InteractableFacade facade, int[] template, ref string[] actions)
        {
            if (actions.Length > 0)
            {
                return;
            }

            actions = new string[template.Length + 1];
            actions[0] = customFollowOption;
            for (int actionIndex = 0; actionIndex < template.Length; actionIndex++)
            {
                if (!facade.Configuration.IsGrabConfigurationSet() || facade.Configuration.GrabActionTypesCount == 0)
                {
                    continue;
                }

                string actionName = facade.Configuration.GetGrabActionTypeObject(template[actionIndex]).name;
                actions[actionIndex + 1] = actionName;
            }
        }
    }
}