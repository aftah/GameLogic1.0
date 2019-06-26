using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEditor;

public class TeamManager : MonoBehaviour
{

    //Creation des variables pour la list des equipes
    private List<GameObject> Team1;
    private List<GameObject> Team2;
    private bool boolTeamConstructed;
    private GameInitializer gameInitializer;
    //private Dictionary<int, string> _team1Dictionary;
    //private Dictionary<int, string> _team2Dictionary;

    private void Start()
    {
        Team1 = new List<GameObject>();
        Team2 = new List<GameObject>();
        //_team1Dictionary = new Dictionary<int, string>();
        //_team2Dictionary = new Dictionary<int, string>();
        boolTeamConstructed = false;
    }
    private void Awake()
    {
        gameInitializer = FindObjectOfType<GameInitializer>();
        gameInitializer.onSetupTeam += OnSetupTeamEventHandler;
    }

    private void OnDisable()
    {
        gameInitializer.onSetupTeam -= OnSetupTeamEventHandler;
    }

    public event EventHandler<OnTeamEventArg> onTeamInitialised;
    public class OnTeamEventArg : EventArgs
    {
        private List<GameObject> t1;
        private List<GameObject> t2;
        private bool isTeamConstructed;

        private Dictionary<int,string> team1Dictionary;
        private Dictionary<int,string> team2Dictionary;


        //property

        public Dictionary<int,string> Team1Dictionary
        {
            get { return team1Dictionary; }
            private set { team1Dictionary = value; }
        }

        public Dictionary<int, string> Team2Dictionary
        {
            get { return team2Dictionary; }
            private set { team2Dictionary = value; }
        }
        public List<GameObject> IntanceTeam1
        {

            get { return t1; }
            private set { t1 = value; }
        }

        public List<GameObject> IntanceTeam2
        {

            get { return t2; }
            private set { t2 = value; }
        }

        public bool IsTeamContructed
        {

            get { return isTeamConstructed; }
            private set { isTeamConstructed = value; }
        }

        //Constructor to init argument
        //public OnTeamEventArg(List<GameObject> team1, List<GameObject> team2, bool isTeamConstruct,Dictionary<int,string> dicoTeam1, Dictionary<int, string> dicoTeam2)
        //{
        //    t1 = team1;
        //    t2 = team2;
        //    team1Dictionary = dicoTeam1;
        //    team2Dictionary = dicoTeam2; 
        //    isTeamConstructed = isTeamConstruct;
        //}

        public OnTeamEventArg(List<GameObject> team1, List<GameObject> team2, bool isTeamConstruct)
        {
            t1 = team1;
            t2 = team2;
           
            isTeamConstructed = isTeamConstruct;
        }

    }
    private void OnTeam(OnTeamEventArg e)
    {
        onTeamInitialised?.Invoke(this, e);

    }
    private void OnSetupTeamEventHandler(object sender, GameInitializer.OnSetupTeamEventArg e)
    {
        boolTeamConstructed = CreationCharactere(e.List1, e.List2);
        OnTeam(new OnTeamEventArg(Team1, Team2, boolTeamConstructed));

    }

    public bool CreationCharactere(List<int> ch1, List<int> ch2)

    {

        if (ch1.Count > 0 && ch2.Count > 0)
        {
            try
            {
                //Instanciation Team 1
                foreach (var item in ch1)
                {
                    if (item > 0)
                    {

                        GetNameFromXml(item - 1); 
                        var  prefabFromRessources = Resources.Load<GameObject>("Characters/" + (item - 1) + "/" + (item - 1)) ;
                        //var data = Resources.Load<DataAttack>("Characters/" + (item - 1) + "/DataAttack" );
                        //Debug.Log("+++++++++++++++++ = " + data.AttackInfo.damage);
                        var prefab = Instantiate(prefabFromRessources, new Vector2(5000, 5000), Quaternion.identity);
                        // assigner la bonne équipe au joueur en question
                        Character character = prefab.GetComponent<Character>();
                        character.Team = TeamEnum.Team1;

                        Team1.Add(prefab);

                        
                       

                    }
                    else
                    {
                        Debug.LogError("Index Error for the Team 1");
                    }
                }

                //Instanciation Team 2
                foreach (var item in ch2)
                {
                    if (item > 0)
                    {
                        GetNameFromXml(item - 1);
                        var prefabFromRessources = Resources.Load("Characters/" + (item - 1) + "/" + (item - 1)) as GameObject;
                        var prefab = Instantiate(prefabFromRessources, new Vector2(5000, 5000), Quaternion.identity);
                        // assigner la bonne équipe au joueur en question
                        Character character = prefab.GetComponent<Character>();
                        character.Team  = TeamEnum.Team2;
                        Team2.Add(prefab);

                        
                       
                    }
                    else
                    {
                        Debug.LogError("Index Error for the Team 2");
                    }
                }

                return true;
            }
            catch
            {
                Debug.LogError("Instanciate Error");
                return false;
            }
        }
        else
        {
            Debug.LogError("List of team is empty");
            return false;
        }
    }
    //public bool CreationCharactere(List<int> ch1, List<int> ch2)

    //{
    //    if (ch1.Count > 0 && ch2.Count > 0)
    //    {
    //        try
    //        {
    //            //Instanciation Team 1
    //            foreach (var item in ch1)
    //            {
    //                if (item > 0)
    //                {
    //                    string name = GetNameFromXml(item -1);
    //                    DeleteTag(name); 
    //                    //var prefab = Instantiate(DataContainer.singleton.character.listPrefabCharactere[item - 1], new Vector2(5000, 5000), Quaternion.identity);
    //                    var prefabFromRessources = Resources.Load("Characters/" + name + "/" + name) as GameObject;
    //                    AddTag(name);
    //                    var prefab = Instantiate(prefabFromRessources, new Vector2(5000, 5000), Quaternion.identity) as GameObject;
    //                    prefab.tag = name; 
    //                    Team1.Add(prefab);
    //                    _team1Dictionary.Add(item - 1, name); 

    //                }
    //                else
    //                {
    //                    Debug.LogError("Index Error for the Team 1");
    //                }
    //            }

    //            //Instanciation Team 2
    //            foreach (var item in ch2)
    //            {
    //                if (item > 0)
    //                {
    //                    string name = GetNameFromXml(item - 1);
    //                    DeleteTag(name); 
    //                    var prefabFromRessources = Resources.Load("Characters/" + name +"/" + name) as GameObject ;
    //                    AddTag(name);

    //                    var prefab = Instantiate(prefabFromRessources , new Vector2(5000, 5000), Quaternion.identity) as GameObject;
    //                    prefab.tag = name;
    //                    Team2.Add(prefab);
    //                    _team2Dictionary.Add(item - 1, name);
    //                }
    //                else
    //                {
    //                    Debug.LogError("Index Error for the Team 2");
    //                }
    //            }

    //            ExecuteDebug();
    //            return true;
    //        }
    //        catch
    //        {
    //            Debug.LogError("Instanciate Error");
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("List of team is empty");
    //        return false;
    //    }
    //}

    public void GetNameFromXml(int id)
    {
        try
        {


            XmlDocument character = new XmlDocument();
            TextAsset textXml = (TextAsset)Resources.Load("Xml/Characters", typeof(TextAsset));

            character.LoadXml(textXml.text);

            XmlNodeList   elemWithId = character.GetElementsByTagName("Character") ;

            string str;
            //int start;
            //int end;
            //string result;
            string[] replaceString;
        
            foreach (XmlNode  node in elemWithId.Item(id).ChildNodes.Item(1).ChildNodes)
            {

                str = node.Attributes["description"].InnerText;
                //start = str.IndexOf("%");
                //end = str.IndexOf("%");
                //result = str.Substring(start + 1, end - start - 1);
                replaceString = str.Split('[',']'); 
              


                //Debug.Log(result);
            }


            //    //elemWithId.SelectMany (p => p.Elements<Run>()).SelectMany(r => r.Elements < Text >
            //    return elemWithId.Attributes["Name"].InnerText;
           
           
            //foreach (XmlNode node in elemWithId.SelectNodes("Spells"))
            //{
            //    Debug.Log(node.Value );
            //    i++;
            //}
        }
        catch
        {

            Debug.LogError("Erreur lecture du tag Name du fichier charactere XML");
           
        }



    }

    //public void ExecuteDebug()
    //{
    //    Debug.Log("Team 1");
    //    foreach (var item in _team1Dictionary )
    //    {
    //        Debug.Log("index=" + item.Key + " name = "+item.Value );

    //    }

    //    Debug.Log("Team 2");
    //    foreach (var item in _team2Dictionary)
    //    {
    //        Debug.Log("index=" + item.Key + " name = " + item.Value);

    //    }

        //GameObject[] obj = GameObject.FindGameObjectsWithTag("Bartholomé");

        //foreach (var item in obj)
        //{
        //    Debug.Log("yes");
        //}
    //}

    public void AddTag(string tagName)
    {
        // Open tag manager
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");

                

        // First check if it is not already present
        bool found = false;
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(tagName)) { found = true; break; }
        }

      
        // if not found, add it
        if (!found)
        {
            tagsProp.InsertArrayElementAtIndex(0);
            SerializedProperty n = tagsProp.GetArrayElementAtIndex(0);
            n.stringValue = tagName;
        }


        // and to save the changes
        tagManager.ApplyModifiedProperties();


    }
    public void DeleteTag(string tagName)
    {
        // Open tag manager
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");



        // First check if it is not already present
        bool found = false;
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(tagName)) { found = true; break; }
        }

        //if found delete it
        if (found)
        {
            tagsProp.DeleteArrayElementAtIndex(0);
        }
        


        // and to save the changes
        tagManager.ApplyModifiedProperties();


    }
}

