using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class persistenciadeDados : MonoBehaviour
{
    public GameObject jogador;
    public GameObject jogadora;

    public float xjogador;
    public float yjogador;
    public float xjogadora;
    public float yjogadora;


    // Start is called before the first frame update
    void Start()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"V:\GitHub\TCP6\TCP6\Assets\xml\info.xml");

        foreach (XmlNode node in doc)
        {
            if (node.NodeType == XmlNodeType.XmlDeclaration)
            {
                doc.RemoveChild(node);
            }
        }
        string caminho = @"V:\GitHub\TCP6\TCP6\Assets\xml\info.xml";
        string posicao = lerXml();
        ConverterXMLParaPosicao(posicao);
    }

    // Update is called once per frame
    void Update()
    {
        exportarPosicoes(jogador.transform.position, jogadora.transform.position);
    }

    public void exportarPosicoes(Vector3 jogadorr, Vector3 jogadoraa)
    {
        XmlTextWriter writer = new XmlTextWriter(@"V:\GitHub\TCP6\TCP6\Assets\xml\info.xml", null);
        writer.WriteStartDocument();
        writer.Formatting = Formatting.Indented;
        writer.WriteStartElement("Jogadores");
        writer.WriteStartElement("Jogador");
        writer.WriteElementString("X1", jogadorr.x.ToString());
        writer.WriteElementString("Y1", jogadorr.y.ToString());
        writer.WriteEndElement();
        writer.WriteStartElement("Jogador");
        writer.WriteElementString("X2", jogadoraa.x.ToString());
        writer.WriteElementString("Y2", jogadoraa.y.ToString());
        writer.WriteEndElement();
        writer.WriteFullEndElement();
        writer.Close();



    }

    public void ConverterXMLParaPosicao(string xml)
    {


        byte[] byteArray = Encoding.UTF8.GetBytes(xml);
        MemoryStream stream = new MemoryStream(byteArray);
        XmlTextReader xtr = new XmlTextReader(stream);



        while (xtr.Read())
        {
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "X1")
            {
                string xjogador1 = xtr.ReadElementContentAsString();
                xjogador = float.Parse(xjogador1);
            }
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Y1")
            {
                string yjogador1 = xtr.ReadElementContentAsString();
                yjogador = float.Parse(yjogador1);
            }

            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "X2")
            {
                string xjogadora1 = xtr.ReadElementContentAsString();
                xjogadora = float.Parse(xjogadora1);
            }
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Y2")
            {
                string yjogadora1 = xtr.ReadElementContentAsString();
                yjogadora = float.Parse(yjogadora1);
            }

        }

    }


    public string lerXml()
    {
        return System.IO.File.ReadAllText(@"V:\GitHub\TCP6\TCP6\Assets\xml\info.xml");
    }

    public void PosicionarPlayers()
    {
        jogador.transform.position = new Vector3(xjogador, yjogador, 0);
        jogadora.transform.position = new Vector3(xjogadora, yjogadora, 0);
    }
}
