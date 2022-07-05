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

            string undoRedoWarningPropertyPath = UndoRedoWarningPropertyPath;
            grabConfigurationIsDirty = false;

            EditorHelper.DrawHorizontalLine();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField(primaryActionTitle, EditorStyles.boldLabel);

            selectedPrimaryActionIndex = EditorGUILayout.Popup(new GUIContent(primaryActionLabel), currentPrimaryActionIndex, primaryActions);

            GrabInteractableAction updatedPrimaryAction = UpdateAction(facade, primaryActionsIndexes, currentPrimaryActionIndex, selectedPrimaryActionIndex, GetPrimaryAction(), 0);
            if (IsGrabConfigurationSet() && GetPrimaryAction() != updatedPrimaryAction)
            {
                facade.Configuration.GrabConfiguration.PrimaryAction = updatedPrimaryAction;
                grabConfigurationIsDirty = true;
            }
            currentPrimaryActionIndex = selectedPrimaryActionIndex;

            DrawFollowActionSettings(facade, GetPrimaryAction(), undoRedoWarningPropertyPath);

            EditorHelper.DrawHorizontalLine();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField(secondaryActionTitle, EditorStyles.boldLabel);

            selectedSecondaryActionIndex = EditorGUILayout.Popup(new GUIContent(secondaryActionLabel), currentSecondaryActionIndex, secondaryActions);
            GrabInteractableAction updatedSecondaryAction = UpdateAction(facade, secondaryActionsIndexes, currentSecondaryActionIndex, selectedSecondaryActionIndex, GetSecondaryAction(), 1);
            if (IsGrabConfigurationSet() && GetSecondaryAction() != updatedSecondaryAction)
            {
                facade.Configuration.GrabConfiguration.SecondaryAction = updatedSecondaryAction;
                grabConfigurationIsDirty = true;
            }
            currentSecondaryActionIndex = selectedSecondaryActionIndex;

            DrawFollowActionSettings(facade, GetSecondaryAction(), undoRedoWarningPropertyPath);

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
                CheckFollowAndControlDirectionPair(updatedPrimaryAction, updatedSecondaryAction);
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                EditorUtility.SetDirty(facade.Configuration.GrabConfiguration);
            }
        }

        protected virtual void OnEnable()
        {
            facade = (InteractableFacade)serializedObject.targetObject;
            SetActionArray(facade, primaryActionsIndexes, ref primaryActions);
            SetActionArray(facade, secondaryActionsIndexes, ref secondaryActions);

            currentPrimaryActionIndex = UpdateIndex(facade, GetPrimaryAction(), primaryActionsIndexes, currentPrimaryActionIndex);
            currentSecondaryActionIndex = UpdateIndex(facade, GetSecondaryAction(), secondaryActionsIndexes, currentSecondaryActionIndex);
        }

        protected virtual bool IsConfigurationSet()
        {
            return facade != null && facade.Configuration != null;
        }

        protected virtual bool IsGrabConfigurationSet()
        {
            return IsConfigurationSet() && facade.Configuration.GrabConfiguration != null;
        }

        protected virtual GrabInteractableAction GetPrimaryAction()
        {
            return IsGrabConfigurationSet() && facade.Configuration.GrabConfiguration.PrimaryAction != null ? facade.Configuration.GrabConfiguration.PrimaryAction : null;
        }

        protected virtual GrabInteractableAction GetSecondaryAction()
        {
            return IsGrabConfigurationSet() && facade.Configuration.GrabConfiguration.SecondaryAction != null ? facade.Configuration.GrabConfiguration.SecondaryAction : null;
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

            if (followTracking.intValue == 4)
            {
                EditorGUI.indentLevel++;
                RotateAroundAngularVelocity rotationModifier = (RotateAroundAngularVelocity)followAction.FollowRotateAroundAngularVelocityModifier.RotationModifier;
                DrawPropertyFieldWithChangeHandlers(new SerializedObject(rotationModifier), "applyToAxis", undoRedoWarningPropertyPath);
                DrawPropertyFieldWithChangeHandlers(new SerializedObject(rotationModifier), "sourceMultiplier", undoRedoWarningPropertyPath);
                EditorGUI.indentLevel--;
            }

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

            for (int actionIndex = 0; actionIndex < facade.Configuration.GrabConfiguration.ActionTypes.NonSubscribableElements.Count; actionIndex++)
            {
                GrabInteractableAction actionComponent = facade.Configuration.GrabConfiguration.ActionTypes.NonSubscribableElements[actionIndex].GetComponent<GrabInteractableAction>();
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
                if (!IsGrabConfigurationSet() || facade.Configuration.GrabConfiguration.ActionTypes.NonSubscribableElements.Count == 0)
                {
                    continue;
                }

                string actionName = facade.Configuration.GrabConfiguration.ActionTypes.NonSubscribableElements[template[actionIndex]].name;
                actions[actionIndex + 1] = actionName;
            }
        }

        protected virtual GrabInteractableAction UpdateAction(InteractableFacade facade, int[] template, int currentAction, int selectedAction, GrabInteractableAction actionProperty, int siblingPosition)
        {
            if (currentAction == selectedAction || selectedAction == 0)
            {
                return actionProperty;
            }

            if (actionProperty != null)
            {
                DestroyImmediate(actionProperty.gameObject);
            }

            int actualSelectedAction = template[selectedAction - 1];
            GameObject actionPrefab = (GameObject)PrefabUtility.InstantiatePrefab(facade.Configuration.GrabConfiguration.ActionTypes.NonSubscribableElements[actualSelectedAction], facade.Configuration.GrabConfiguration.ActionTypes.transform);
            actionPrefab.transform.SetSiblingIndex(siblingPosition);
            return actionPrefab.GetComponent<GrabInteractableAction>();
        }

        protected virtual void CheckFollowAndControlDirectionPair(GrabInteractableAction primaryAction, GrabInteractableAction secondaryAction)
        {
            GrabInteractableFollowAction followAction;
            GrabInteractableControlDirectionAction controlDirectionAction;

            if (secondaryAction != null && typeof(GrabInteractableControlDirectionAction).IsAssignableFrom(secondaryAction.GetType()))
            {
                controlDirectionAction = (GrabInteractableControlDirectionAction)secondaryAction;
                controlDirectionAction.LinkedObjects = null;
            }

            if (primaryAction == null ||
                secondaryAction == null ||
                !typeof(GrabInteractableFollowAction).IsAssignableFrom(primaryAction.GetType()) ||
                !typeof(GrabInteractableControlDirectionAction).IsAssignableFrom(secondaryAction.GetType()))
            {
                return;
            }

            followAction = (GrabInteractableFollowAction)primaryAction;
            controlDirectionAction = (GrabInteractableControlDirectionAction)secondaryAction;

            controlDirectionAction.LinkedObjects = followAction.RotationModifiers;
        }
    }
}