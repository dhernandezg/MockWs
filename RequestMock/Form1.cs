using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    File.AppendAllText(folderBrowserDialog1.SelectedPath + "\\" + row.Cells[0].Value + ".mock", string.Format("{0}|{1}\n", row.Cells[1].Value, row.Cells[3].Value));
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

            foreach (string line in FixLog(File.ReadAllLines(textBox1.Text)))
            {
                BuildData(line);
            }
        }

        private IEnumerable<string> FixLog(string[] lines)
        {
            var listLines = new List<string>();
            StringBuilder fixedLine = new StringBuilder();
            Regex startLineReg = new Regex(@"^[0-9]{2}/[0-9]{2}/[0-9]{4} [0-9]{2}:[0-9]{2}:[0-9]{2}\.[0-9]{3} \|");
            foreach (string line in lines)
            {

                if (startLineReg.IsMatch(FixLine(line)))
                {
                    listLines.Add(fixedLine.ToString());
                    fixedLine.Clear();
                }
                fixedLine.Append(line.Trim());
            }
            string lastLine = fixedLine.ToString();
            if (!string.IsNullOrEmpty(lastLine))
            {
                listLines.Add(fixedLine.ToString());
            }
            File.WriteAllLines("All.log",listLines);
            return listLines;
        }

        private string FixLine(string line)
        {
            return (line.StartsWith("∩╗┐") ? line.Substring(3) : line).Replace("├æ", "Ñ");
        }

        private void BuildData(string line)
        {
            WsBusqCte(line);
            WsAvisoPriv(line);
            WsVentanillaMexico(line);
        }

        private void WsBusqCte(string line)
        {
            if (line.Contains("infoXIdentificacion") || line.Contains("infoXNombre"))
            {
                int lastIndex = line.LastIndexOf(' ');
                int ipLastIndex = line.IndexOf("&ipAutenticacion=");
                int indexMethod = line.LastIndexOf("/");
                key = string.Format("{0}|{1}", line.Substring(indexMethod + 1, line.LastIndexOf(". ") - indexMethod - 1), line.Substring(lastIndex, ipLastIndex - lastIndex).Trim());
            }
            else if (line.Contains("CtrlWebService. RESPUESTA: {\"lstResponse\":") && !string.IsNullOrEmpty(key))
            {
                dataGridView1.Rows.Add(key.Substring(0, key.IndexOf('|')), key.Substring(key.IndexOf('|') + 1), line.Substring(0, 24), line.Substring(53));
                key = string.Empty;
            }
        }

        private void WsAvisoPriv(string line)
        {
            if (line.Contains("validaCliente . PETICION: "))
            {
                int lastIndex = line.LastIndexOf(" {");
                key = line.Substring(lastIndex + 1);
            }
            else if (line.Contains("CtrlJsonService. RESPUESTA: {\"codigo") && !string.IsNullOrEmpty(key))
            {
                int lastIndex = line.LastIndexOf(" {");
                dataGridView1.Rows.Add("AvisoPriv", key, line.Substring(0, 24), line.Substring(lastIndex + 1));
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
                int lastIndex = line.IndexOf(" [");
                string methodService = line.Substring(line.IndexOf("[a1:") + 4);
                key = methodService.Substring(0, methodService.IndexOf(" "))+"|";
                if (line.Contains("validaRestriccionesCte") || line.Contains("validaInfoCte")) 
                {
                    string tempData = line.Substring(lastIndex);
                    int startIndex = tempData.IndexOf("[nombre]");
                    key += tempData.Substring(startIndex,tempData.IndexOf("[/fechaNacimiento]") -startIndex).Replace("][","]@[");
                }
                else 
                {
                    key += FixXmlData(line.Substring(lastIndex));
                }

            }
            else if (line.Contains("CtrlWebService. RESPUESTA: [") && !string.IsNullOrEmpty(key))
            {
                int separatorKey = key.IndexOf("|");
                dataGridView1.Rows.Add(FixXmlData(key.Substring(0, separatorKey)),
                    FixXmlData(key.Substring(separatorKey+1)),
                    line.Substring(0, 24), 
                    FixXmlData(line.Substring(line.IndexOf('['))));
                key = string.Empty;
            }
        }
    }
}
