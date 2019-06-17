using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLReader : MonoBehaviour
{

   
   public enum EComponent
    {
        eTitre,
        eDescription 

    }
    private void Start()
    {
       

    }
    public static string GetTextInfo(string _langue,int _numProduit,EComponent _component)
    {
    

        XmlNode  node = GetDocument(_langue + "_Project").GetElementsByTagName ("produit" + _numProduit.ToString()).Item(0)  ;

        switch (_component)
        {
            case EComponent.eTitre:
                return node.ChildNodes.Item(0).InnerText; 
               
            case EComponent.eDescription:
                return node.ChildNodes.Item(1).InnerText;
              
            default:
                break;
        }
        return "";
    }

    public static XmlDocument GetDocument(string _toGet)
    {

        TextAsset text = (TextAsset)Resources.Load("Xml/" + _toGet);
     
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(text.text); //la partie du texte qui est sur le fichier(parce que d autre truc dedans
        return doc;
    }
}
