using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RequestMock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string currentResponse = string.Empty;
        string key = string.Empty;

        private void Examinar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Logs Multimarcas(*.log)|*.log";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                textBox1.Text = openFileDialog1.FileName;
                StarAnalisis();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                StringBuilder stringContent = new StringBuilder();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    File.AppendAllText(folderBrowserDialog1.SelectedPath+"\\"+row.Cells[0].Value + ".mock",string.Format("{0}|{1}\n",row.Cells[1].Value,row.Cells[3].Value));
                }
            }

        }

        private void StarAnalisis()
        {
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("El archivo log no es valido o no existe");
                return;
            }
            foreach (string line in File.ReadAllLines(textBox1.Text))
            {
                WsBusqCte(line);
                //WsAvisoPriv(line);
                //WsVentanillaMexico(line);
            }
        }

        private void WsBusqCte(string line)
        {
            if (line.Contains("infoXIdentificacion") || line.Contains("infoXNombre"))
            {
                key = currentResponse = string.Empty;
                int lastIndex = line.LastIndexOf(' ');
                int ipLastIndex = line.IndexOf("&ipAutenticacion=");
                int indexMethod = line.LastIndexOf("/");
                key = string.Format("{0}|{1}", line.Substring(indexMethod + 1, line.LastIndexOf(". ") - indexMethod - 1), line.Substring(lastIndex, ipLastIndex - lastIndex).Trim());
            }
            else if (line.Contains("CtrlWebService. RESPUESTA: {\"lstResponse\":"))
            {
                currentResponse += line;
                if (line.Contains("]}} "))
                {
                    dataGridView1.Rows.Add(key.Substring(0, key.IndexOf('|')), key.Substring(key.IndexOf('|') + 1), currentResponse.Substring(0, 24), currentResponse.Substring(53));
                    key = currentResponse = string.Empty;
                }
            }
            else if (!string.IsNullOrEmpty(currentResponse))
            {
                currentResponse += line;
                if (line.Contains("]}} "))
                {
                    dataGridView1.Rows.Add(key.Substring(0, key.IndexOf('|')), key.Substring(key.IndexOf('|') + 1), currentResponse.Substring(0, 24), currentResponse.Substring(53));
                }
            }
        }

        private void WsAvisoPriv(string line)
        {
            if (line.Contains("validaCliente . PETICION: "))
            {
                key = currentResponse = string.Empty;
                int lastIndex = line.LastIndexOf(" {");
                key = line.Substring(lastIndex);
            }
            else if (line.Contains("CtrlJsonService. RESPUESTA: {\"codigo"))
            {
                int lastIndex = line.LastIndexOf(" {");
                dataGridView1.Rows.Add("AvisoPriv", key, line.Substring(0, 24), line.Substring(lastIndex));
            }
        }

        private string FixXmlData(string line)
        {
            return line.Replace("[", "<").Replace("]", ">").Trim();
        }

        private void WsVentanillaMexico(string line)
        {
            if (line.Contains("WSValidacionVentanillaMexico/services"))
            {
                key = currentResponse = string.Empty;
                int lastIndex = line.IndexOf(" [");
                key = FixXmlData(line.Substring(lastIndex));
            }
            else if (line.StartsWith("[") && (!string.IsNullOrEmpty(key) || !string.IsNullOrEmpty(currentResponse)))
            {
                if (string.IsNullOrEmpty(currentResponse))
                {
                    key += FixXmlData(line);
                }
                else
                {
                    currentResponse += FixXmlData(line);
                    if (line.Contains("[/soap:Envelope]"))
                    {
                        string methodService = currentResponse.Substring(currentResponse.IndexOf("ns2:") + 4);
                        methodService = methodService.Substring(0, methodService.IndexOf(" "));
                        dataGridView1.Rows.Add(methodService, key, currentResponse.Substring(0, 24), currentResponse.Substring(24));
                        key = currentResponse = string.Empty;
                    }
                }
            }
            else if (line.Contains("CtrlWebService. RESPUESTA: [") && !string.IsNullOrEmpty(key))
            {
                currentResponse += line.Substring(0, 24);
                currentResponse += FixXmlData(line.Substring(line.IndexOf('[')));
            }
        }
    }

    public class MockEntry
    {
        public string TypeService { get; set; }
    }
}
