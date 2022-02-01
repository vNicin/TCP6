using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;


public class npc : MonoBehaviour
{
   
    public int numeroInteracoes;
    public bool truee;
    public int nXML;


    // Start is called before the first frame update
    void Start()
    {
        truee = true;
      
        XmlDocument doc = new XmlDocument();
        doc.Load(@"V:\GitHub\TCP6\TCP6\Assets\xml\npc.xml");

        foreach (XmlNode node in doc)
        {
            if (node.NodeType == XmlNodeType.XmlDeclaration)
            {
                doc.RemoveChild(node);
            }
        }
        string caminho = @"V:\GitHub\TCP6\TCP6\Assets\xml\npc.xml";
        string posicao = lerXml();
        ConverterXMLParaPosicao(posicao);
    }

    // Update is called once per frame
    void Update()
    {
        exportarPosicoes();
    }




    public void exportarPosicoes()
    {
        XmlTextWriter writer = new XmlTextWriter(@"V:\GitHub\TCP6\TCP6\Assets\xml" + nXML + ".xml", null);
        writer.WriteStartDocument();
        writer.Formatting = Formatting.Indented;
        writer.WriteStartElement("NPCs");
        writer.WriteStartElement("mentor");
        writer.WriteElementString("ninteracoes", numeroInteracoes.ToString());
        writer.WriteEndElement();
        writer.WriteStartElement("numero");
        writer.WriteElementString("ninteracoes", numeroInteracoes.ToString());
        writer.WriteEndElement();
        writer.WriteFullEndElement();
        writer.Close();



        XmlTextWriter writer2 = new XmlTextWriter(@"V:\GitHub\TCP6\TCP6\Assets\xml", null);
        writer2.WriteStartDocument();
        writer2.Formatting = Formatting.Indented;
        writer2.WriteStartElement("contagem");
        writer2.WriteStartElement("contou");
        writer2.WriteElementString("ninteracoes", nXML.ToString());
        writer2.WriteEndElement();
        writer2.WriteFullEndElement();
        writer2.Close();




    }


    public void ConverterXMLParaPosicao(string xml)
    {


        byte[] byteArray = Encoding.UTF8.GetBytes(xml);
        MemoryStream stream = new MemoryStream(byteArray);
        XmlTextReader xtr = new XmlTextReader(stream);



        while (xtr.Read())
        {
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "ninteracoes")
            {
                
                string interacoes = xtr.ReadElementContentAsString();
                nXML = int.Parse(interacoes);
                nXML += 1;
            }
          

        }

    }


      public string lerXml()
    {
        return System.IO.File.ReadAllText(@"V:\GitHub\TCP6\TCP6\Assets\xml");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           
            if (truee)
            {
                numeroInteracoes += 1;
                truee = false;
            }

        }
    }



}
