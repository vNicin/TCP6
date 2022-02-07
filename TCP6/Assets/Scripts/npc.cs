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
    public GameObject interacao;
    public int numeroInteracoes;
    public bool truee;
    public int nXML;

  
    public int pedro;
    public int dora;
    public int professor;
    public int jornal;


    public bool ped;
    public bool dor;
    public bool pro;
    public bool jor;

    public PedroBala pedrob;
    public PedroBala doraa;
    public PedroBala prof;
    public PedroBala jour;

    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
        

        truee = true;
        interacao.SetActive(false);
        XmlDocument doc = new XmlDocument();
        doc.Load(@"C:\Users\Raphael Mathias\Desktop\TCP6-main\TCP6\Assets\xml\npc.xml");

        foreach (XmlNode node in doc)
        {
            if (node.NodeType == XmlNodeType.XmlDeclaration)
            {
                doc.RemoveChild(node);
            }
        }
        string caminho = @"C:\Users\Raphael Mathias\Desktop\TCP6-main\TCP6\Assets\xml\npc.xml";
        string posicao = lerXml();
        ConverterXMLParaPosicao(posicao);
    }

    // Update is called once per frame
    void Update()
    {
        exportarPosicoes();

        tempo += Time.deltaTime;
        
            
        
        
            dora = doraa.numero;
          
        
            pedro = pedrob.numero;
           
       
            professor = prof.numero;
        

    }




    public void exportarPosicoes()
    {
        XmlTextWriter writer = new XmlTextWriter(@"C:\Users\Raphael Mathias\Desktop\TCP6-main\TCP6\Assets\xml\npc.xml" + nXML + ".xml", null);
        writer.WriteStartDocument();
        writer.Formatting = Formatting.Indented;
        writer.WriteStartElement("NPCs");
        writer.WriteStartElement("professor");
        writer.WriteElementString("numerointeracoes", professor.ToString());
        writer.WriteEndElement();
        writer.WriteStartElement("pedro");
        writer.WriteElementString("numerointeracoes", pedro.ToString());
        writer.WriteEndElement();
        writer.WriteStartElement("dora");
        writer.WriteElementString("numerointeracoes", dora.ToString());
        writer.WriteEndElement();
        writer.WriteStartElement("tempo");
        writer.WriteElementString("TempoTotal", tempo.ToString());
        writer.WriteEndElement();
        writer.WriteFullEndElement();
        writer.Close();



        XmlTextWriter writer2 = new XmlTextWriter(@"C:\Users\Raphael Mathias\Desktop\TCP6-main\TCP6\Assets\xml\npc.xml", null);
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
        return System.IO.File.ReadAllText(@"C:\Users\Raphael Mathias\Desktop\TCP6-main\TCP6\Assets\xml\npc.xml");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            interacao.SetActive(true);
            if (truee)
            {
                numeroInteracoes += 1;
                truee = false;
            }

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        interacao.SetActive(false);

    }

}
