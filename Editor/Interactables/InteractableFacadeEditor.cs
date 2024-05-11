namespace Tilia.Interactions.Interactables.Interactables
{
#if ZINNIA_IGNORE_CUSTOM_INSPECTOR_EDITOR
#else
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
        private const string dropdownButtonHelperIcon = "animationvisibilitytoggleon";
        private const string dropdownButtonHelperText = "|View Action GameObject";
        private Vector2 dropdownButtonHelperSize = new Vector2(22f, 14f);

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

            DrawPrimaryActionDropdown(undoRedoWarningPropertyPath, out GrabInteractableAction currentPrimaryAction, out GrabInteractableAction updatedPrimaryAction);

            EditorHelper.DrawHorizontalLine();
            EditorGUILayout.Space();

            DrawSecondaryActionDropdown(undoRedoWarningPropertyPath, out GrabInteractableAction currentSecondaryAction, out GrabInteractableAction updatedSecondaryAction);

            EditorHelper.DrawHorizontalLine();

            EditorGUILayout.Space();

            DrawDisallowedInteractors(disallowedTouchInteractorTitle, facade.Configuration.DisallowedTouchInteractors, undoRedoWarningPropertyPath);

            EditorGUILayout.Space();

            DrawDisallowedInteractors(disallowedGrabInteractorTitle, facade.Configuration.DisallowedGrabInteractors, undoRedoWarningPropertyPath);

            EditorHelper.DrawHorizontalLine();

            DrawShowMeshContainerButton();

            grabConfigurationIsDirty = currentPrimaryAction != updatedPrimaryAction || currentSecondaryAction != updatedSecondaryAction;
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

        protected virtual void DrawPrimaryActionDropdown(string undoRedoWarningPropertyPath, out GrabInteractableAction currentPrimaryAction, out GrabInteractableAction updatedPrimaryAction)
        {
            EditorGUILayout.LabelField(primaryActionTitle, EditorStyles.boldLabel);
            selectedPrimaryActionIndex = DrawActionDropdown(primaryActionLabel, currentPrimaryActionIndex, primaryActions, facade.Configuration.GetPrimaryAction());

            currentPrimaryAction = facade.Configuration.GetPrimaryAction();
            updatedPrimaryAction =
                currentPrimaryActionIndex == selectedPrimaryActionIndex || selectedPrimaryActionIndex == 0
                ? facade.Configuration.GetPrimaryAction()
                : facade.Configuration.UpdatePrimaryAction(primaryActionsIndexes[selectedPrimaryActionIndex - 1]);
            currentPrimaryActionIndex = selectedPrimaryActionIndex;

            DrawNullActionSettings(facade, facade.Configuration.GetPrimaryAction(), undoRedoWarningPropertyPath);
            DrawFollowActionSettings(facade, facade.Configuration.GetPrimaryAction(), undoRedoWarningPropertyPath);
        }

        protected virtual void DrawSecondaryActionDropdown(string undoRedoWarningPropertyPath, out GrabInteractableAction currentSecondaryAction, out GrabInteractableAction updatedSecondaryAction)
        {

            EditorGUILayout.LabelField(secondaryActionTitle, EditorStyles.boldLabel);
            selectedSecondaryActionIndex = DrawActionDropdown(secondaryActionLabel, currentSecondaryActionIndex, secondaryActions, facade.Configuration.GetSecondaryAction());

            currentSecondaryAction = facade.Configuration.GetSecondaryAction();
            updatedSecondaryAction =
                currentSecondaryActionIndex == selectedSecondaryActionIndex || selectedSecondaryActionIndex == 0
                ? facade.Configuration.GetSecondaryAction()
                : facade.Configuration.UpdateSecondaryAction(secondaryActionsIndexes[selectedSecondaryActionIndex - 1]);
            currentSecondaryActionIndex = selectedSecondaryActionIndex;

            DrawNullActionSettings(facade, facade.Configuration.GetSecondaryAction(), undoRedoWarningPropertyPath);
            DrawFollowActionSettings(facade, facade.Configuration.GetSecondaryAction(), undoRedoWarningPropertyPath);
            DrawControlDirectionActionSettings(facade, facade.Configuration.GetSecondaryAction(), undoRedoWarningPropertyPath);
            DrawScaleActionSettings(facade, facade.Configuration.GetSecondaryAction(), undoRedoWarningPropertyPath);
        }

        protected virtual void DrawDisallowedInteractors(string title, RuleContainer interactorRule, string undoRedoWarningPropertyPath)
        {
            EditorGUILayout.LabelField(title, EditorStyles.boldLabel);

            EditorGUI.indentLevel++;
            if (IsConfigurationSet())
            {
                DrawDisallowedInteractorsList(interactorRule, undoRedoWarningPropertyPath);
            }
            EditorGUI.indentLevel--;
        }

        protected virtual void DrawShowMeshContainerButton()
        {
            GUILayout.BeginHorizontal("GroupBox");
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(showMeshContainerButtonText))
            {
                EditorGUIUtility.PingObject(facade.Configuration.MeshContainer);
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        protected virtual int DrawActionDropdown(string actionLabel, int actionIndex, string[] actions, GrabInteractableAction actionTarget)
        {
            GUILayout.BeginHorizontal();
            int returnIndex = EditorGUILayout.Popup(new GUIContent(actionLabel), actionIndex, actions);
            if (GUILayout.Button(EditorGUIUtility.IconContent(dropdownButtonHelperIcon, dropdownButtonHelperText), GUILayout.Width(dropdownButtonHelperSize.x), GUILayout.Height(dropdownButtonHelperSize.y)))
            {
                EditorGUIUtility.PingObject(actionTarget);
            }
            GUILayout.EndHorizontal();

            return returnIndex;
        }

        protected virtual void DrawNullActionSettings(InteractableFacade facade, GrabInteractableAction actionProperty, string undoRedoWarningPropertyPath)
        {
            if (actionProperty == null || !typeof(GrabInteractableNullAction).IsAssignableFrom(actionProperty.GetType()))
            {
                return;
            }

            GrabInteractableNullAction nullAction = (GrabInteractableNullAction)actionProperty;
            SerializedObject actionObject = new SerializedObject(nullAction);
            EditorGUI.indentLevel++;
            DrawPropertyFieldWithChangeHandlers(actionObject, "forceEmitEvents", undoRedoWarningPropertyPath);
            EditorGUI.indentLevel--;
        }

        protected virtual void DrawControlDirectionActionSettings(InteractableFacade facade, GrabInteractableAction actionProperty, string undoRedoWarningPropertyPath)
        {
            if (actionProperty == null || !typeof(GrabInteractableControlDirectionAction).IsAssignableFrom(actionProperty.GetType()))
            {
                return;
            }

            GrabInteractableControlDirectionAction controlDirectionAction = (GrabInteractableControlDirectionAction)actionProperty;
            SerializedObject actionObject = new SerializedObject(controlDirectionAction.DirectionModifier);
            EditorGUI.indentLevel++;
            DrawPropertyFieldWithChangeHandlers(actionObject, "snapToLookAt", undoRedoWarningPropertyPath);
            DrawPropertyFieldWithChangeHandlers(actionObject, "resetOrientationSpeed", undoRedoWarningPropertyPath);
            EditorGUI.indentLevel--;
        }

        protected virtual void DrawScaleActionSettings(InteractableFacade facade, GrabInteractableAction actionProperty, string undoRedoWarningPropertyPath)
        {
            if (actionProperty == null || !typeof(GrabInteractableScaleAction).IsAssignableFrom(actionProperty.GetType()))
            {
                return;
            }

            GrabInteractableScaleAction scaleAction = (GrabInteractableScaleAction)actionProperty;
            SerializedObject actionObject = new SerializedObject(scaleAction.PinchScaler);

            EditorGUI.indentLevel++;
            DrawPropertyFieldWithChangeHandlers(actionObject, "multiplier", undoRedoWarningPropertyPath);
            DrawPropertyFieldWithChangeHandlers(actionObject, "calculateByPower", undoRedoWarningPropertyPath);
            DrawPropertyFieldWithChangeHandlers(actionObject, "applyScaleOnAxis", undoRedoWarningPropertyPath);
            DrawPropertyFieldWithChangeHandlers(actionObject, "minimumScaleLimit", undoRedoWarningPropertyPath);
            DrawPropertyFieldWithChangeHandlers(actionObject, "maximumScaleLimit", undoRedoWarningPropertyPath);
            EditorGUI.indentLevel--;
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

            GameObject followContainer = GetFollowContainer(followAction, followTracking);

            DrawShowFollowContainerButton(followContainer);
            DrawFollowActionTrackingOptions(followAction, followTracking, undoRedoWarningPropertyPath);
            DrawFollowActionGrabOffset(followAction, actionObject, undoRedoWarningPropertyPath);

            EditorHelper.DrawHorizontalLine();

            DrawFollowActionVelocitySettings(followAction, undoRedoWarningPropertyPath);
            DrawFollowActionAdvancedSettings(actionObject, undoRedoWarningPropertyPath);

            EditorGUI.indentLevel--;
        }

        protected virtual GameObject GetFollowContainer(GrabInteractableFollowAction followAction, SerializedProperty followTracking)
        {
            switch (followTracking.intValue)
            {
                case 0:
                    return followAction.FollowTransformModifier.gameObject;
                case 1:
                    return followAction.FollowRigidbodyModifier.gameObject;
                case 2:
                    return followAction.FollowRigidbodyForceRotateModifier.gameObject;
                case 3:
                    return followAction.FollowTransformRotateOnPositionDifferenceModifier.gameObject;
                case 4:
                    return followAction.FollowRotateAroundAngularVelocityModifier.gameObject;
            }

            return null;
        }

        protected virtual void DrawShowFollowContainerButton(GameObject followContainer)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(" ");
            if (followContainer != null && GUILayout.Button(showFollowContainerButtonText))
            {
                EditorGUIUtility.PingObject(followContainer);
            }
            GUILayout.EndHorizontal();
        }

        protected virtual void DrawFollowActionTrackingOptions(GrabInteractableFollowAction followAction, SerializedProperty followTracking, string undoRedoWarningPropertyPath)
        {
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
        }

        protected virtual void DrawFollowActionGrabOffset(GrabInteractableFollowAction followAction, SerializedObject actionObject, string undoRedoWarningPropertyPath)
        {
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
        }

        protected virtual void DrawFollowActionVelocitySettings(GrabInteractableFollowAction followAction, string undoRedoWarningPropertyPath)
        {
            SerializedObject velocityMultiplierObject = new SerializedObject(followAction.VelocityMultiplier);
            showVelocityMultiplierFeatures = EditorGUILayout.Foldout(showVelocityMultiplierFeatures, velocityMultiplierTitle);
            if (showVelocityMultiplierFeatures)
            {
                EditorGUI.indentLevel++;
                SerializedProperty velocityMultiplerValue = DrawPropertyFieldWithChangeHandlers(velocityMultiplierObject, "velocityMultiplierFactor", undoRedoWarningPropertyPath);
                SerializedProperty angularVelocityMultiplerValue = DrawPropertyFieldWithChangeHandlers(velocityMultiplierObject, "angularVelocityMultiplierFactor", undoRedoWarningPropertyPath);
                EditorGUI.indentLevel--;
            }
        }

        protected virtual void DrawFollowActionAdvancedSettings(SerializedObject actionObject, string undoRedoWarningPropertyPath)
        {
            showFollowAdvancedFeatures = EditorGUILayout.Foldout(showFollowAdvancedFeatures, advancedFollowTitle);
            if (showFollowAdvancedFeatures)
            {
                EditorGUI.indentLevel++;
                DrawPropertyFieldWithChangeHandlers(actionObject, "isKinematicWhenActive", undoRedoWarningPropertyPath);
                DrawPropertyFieldWithChangeHandlers(actionObject, "isKinematicWhenInactive", undoRedoWarningPropertyPath);
                DrawPropertyFieldWithChangeHandlers(actionObject, "willInheritIsKinematicWhenInactiveFromConsumerRigidbody", undoRedoWarningPropertyPath);
                EditorGUI.indentLevel--;
            }
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
#endif
}