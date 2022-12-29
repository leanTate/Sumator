using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Numerics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Sumator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtTotal.Text = "0";
            operations operations = new operations();
        }
        BigInteger total = 0;
        BigInteger subtotalmil = 0;
        BigInteger subtotalquinientos = 0;
        BigInteger subtotaldoscientos = 0;
        BigInteger subtotalcien = 0;
        BigInteger subtotalcincuenta = 0;
        BigInteger subtotalveinte = 0;
        BigInteger subtotaldiez = 0;
        BigInteger subtotalcinco = 0;
        BigInteger subtotaldos = 0;
        BigInteger subtotaluno = 0;
        PrintDocument doc = new PrintDocument();
        public void sumatotal()
        {
            total = subtotalmil + subtotalquinientos + subtotaldoscientos + subtotalcien + subtotalcincuenta + subtotalveinte + subtotaldiez + subtotalcinco + subtotaldos + subtotaluno;
            txtTotal.Text = total.ToString();
        }

        private void txtmil_TextChanged(object sender, EventArgs e)
        {
            if (txtmil.Text != "")
            {
                subtotalmil = operations.multiply(1000, txtmil.Text);
                sumatotal();
            }
            else
            {
                subtotalmil = 0;
                sumatotal();
            }
        }

        private void txtquinientos_TextChanged(object sender, EventArgs e)
        {
            if (txtquinientos.Text != "")
            {
                subtotalquinientos = operations.multiply(500, txtquinientos.Text);
                sumatotal();
            }
            else
            {
                subtotalquinientos = 0;
                sumatotal();
            }
        }

        private void txtdoscientos_TextChanged(object sender, EventArgs e)
        {
            if (txtdoscientos.Text != "")
            {
                subtotaldoscientos = operations.multiply(200, txtdoscientos.Text);
                sumatotal();
            }
            else
            {
                subtotaldoscientos = 0;
                sumatotal();
            }
        }

        private void txtcien_TextChanged(object sender, EventArgs e)
        {
            if (txtcien.Text != "")
            {
                subtotalcien = operations.multiply(100, txtcien.Text);
                sumatotal();
            }
            else
            {
                subtotalcien = 0;
                sumatotal();
            }
        }

        private void textcincuenta_TextChanged(object sender, EventArgs e)
        {
            if (textcincuenta.Text != "")
            {
                subtotalcincuenta = operations.multiply(50, textcincuenta.Text);
                sumatotal();
            }
            else
            {
                subtotalcincuenta = 0;
                sumatotal();
            }
        }

        private void txtveinte_TextChanged(object sender, EventArgs e)
        {
            if (txtveinte.Text != "")
            {
                subtotalveinte = operations.multiply(20, txtveinte.Text);
                sumatotal();
            }
            else
            {
                subtotalveinte = 0;
                sumatotal();
            }
        }

        private void txtdiez_TextChanged(object sender, EventArgs e)
        {
            if (txtdiez.Text != "")
            {
                subtotaldiez = operations.multiply(10, txtdiez.Text);
                sumatotal();
            }
            else
            {
                subtotaldiez = 0;
                sumatotal();
            }
        }

        private void txtmil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }



        private void txtcinco_TextChanged(object sender, EventArgs e)
        {
            if (txtcinco.Text != "")
            {
                subtotalcinco = operations.multiply(5, txtcinco.Text);
                sumatotal();
            }
            else
            {
                subtotalcinco = 0;
                sumatotal();
            }
        }

        private void txtdos_TextChanged(object sender, EventArgs e)
        {
            if (txtdos.Text != "")
            {
                subtotaldos = operations.multiply(2, txtdos.Text);
                sumatotal();
            }
            else
            {
                subtotaldos = 0;
                sumatotal();
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (txt1.Text != "")
            {
                subtotaluno = operations.multiply(1, txt1.Text);
                sumatotal();
            }
            else
            {
                subtotaluno = 0;
                sumatotal();
            }
        }
        private void txtmil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtmil.Text = string.Empty;
            txtmil.Focus();
            txtquinientos.Text = string.Empty;
            txtdoscientos.Text = string.Empty;
            txtcien.Text = string.Empty;
            textcincuenta.Text = string.Empty;
            txtveinte.Text = string.Empty;
            txtdiez.Text = string.Empty;
            txtcinco.Text = string.Empty;
            txtdos.Text = string.Empty;
            txt1.Text = string.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            Document document = new Document();
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PdfWriter.GetInstance(document, new FileStream($"{docs}/output {fechaActual.ToString("dd.MM.yyyy")}.pdf", FileMode.OpenOrCreate));

            document.Open();

            document.Add(new Paragraph($"Arqueo de caja {fechaActual.ToString("dd/MM/yyyy")}\n\n"));
            PdfPTable table = new PdfPTable(3); // 3 columnas
            table.WidthPercentage = 100; // Ancho de la tabla al 100%

            table.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell cell = new PdfPCell(new Phrase("Cantidad"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            PdfPCell cell2 = new PdfPCell(new Phrase("Denominacion"));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell2);
            table.AddCell(new PdfPCell(new Phrase("")));
            PdfPCell cell4 = new PdfPCell(new Phrase(txt1.Text != "" ? txt1.Text : "0"));
            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell4);
            PdfPCell cell5 = new PdfPCell(new Phrase("$1"));
            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell5);
            PdfPCell cell6 = new PdfPCell(new Phrase($"${subtotaluno.ToString()}.00"));
            cell6.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell6);
            PdfPCell cell7 = new PdfPCell(new Phrase(txtdos.Text != "" ? txtdos.Text : "0"));
            cell7.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell7);
            PdfPCell cell8 = new PdfPCell(new Phrase("$2"));
            cell8.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell8);
            PdfPCell cell9 = new PdfPCell(new Phrase($"${subtotaldos.ToString()}.00"));
            cell9.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell9);
            PdfPCell cell10 = new PdfPCell(new Phrase(txtcinco.Text != "" ? txtcinco.Text : "0"));
            cell10.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell10);
            PdfPCell cell11 = new PdfPCell(new Phrase("$5"));
            cell11.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell11);
            PdfPCell cell12 = new PdfPCell(new Phrase($"${subtotalcinco.ToString()}.00"));
            cell12.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell12);
            PdfPCell cell13 = new PdfPCell(new Phrase(txtdiez.Text != "" ? txtdiez.Text : "0"));
            cell13.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell13);
            PdfPCell cell14 = new PdfPCell(new Phrase("$10"));
            cell14.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell14);
            PdfPCell cell15 = new PdfPCell(new Phrase($"${subtotaldiez.ToString()}.00"));
            cell15.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell15);
            PdfPCell cell16 = new PdfPCell(new Phrase(txtveinte.Text != "" ? txtveinte.Text : "0"));
            cell16.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell16);
            PdfPCell cell17 = new PdfPCell(new Phrase("$20"));
            cell17.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell17);
            PdfPCell cell18 = new PdfPCell(new Phrase($"${subtotalveinte.ToString()}.00"));
            cell18.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell18);
            PdfPCell cell19 = new PdfPCell(new Phrase(textcincuenta.Text != "" ? textcincuenta.Text : "0"));
            cell19.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell19);
            PdfPCell cell20 = new PdfPCell(new Phrase("$50"));
            cell20.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell20);
            PdfPCell cell21 = new PdfPCell(new Phrase($"${subtotalcincuenta.ToString()}.00"));
            cell21.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell21);
            PdfPCell cell22 = new PdfPCell(new Phrase(txtcien.Text != "" ? txtcien.Text : "0"));
            cell22.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell22);
            PdfPCell cell23 = new PdfPCell(new Phrase("$100"));
            cell23.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell23);
            PdfPCell cell24 = new PdfPCell(new Phrase($"${subtotalcien.ToString()}.00"));
            cell24.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell24);
            PdfPCell cell25 = new PdfPCell(new Phrase(txtdoscientos.Text != "" ? txtdoscientos.Text : "0"));
            cell25.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell25);
            PdfPCell cell26 = new PdfPCell(new Phrase("$200"));
            cell26.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell26);
            PdfPCell cell27 = new PdfPCell(new Phrase($"${subtotaldoscientos.ToString()}.00"));
            cell27.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell27);
            PdfPCell cell28 = new PdfPCell(new Phrase(txtquinientos.Text != "" ? txtquinientos.Text : "0"));
            cell28.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell28);
            PdfPCell cell29 = new PdfPCell(new Phrase("$500"));
            cell29.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell29);
            PdfPCell cell30 = new PdfPCell(new Phrase($"${subtotalquinientos.ToString()}.00"));
            cell30.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell30);
            PdfPCell cell31 = new PdfPCell(new Phrase(txtmil.Text != "" ? txtmil.Text : "0"));
            cell31.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell31);
            PdfPCell cell32 = new PdfPCell(new Phrase("$1000"));
            cell32.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell32);
            PdfPCell cell33 = new PdfPCell(new Phrase($"${subtotalmil.ToString()}.00"));
            cell33.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell33);
            PdfPCell cell34 = new PdfPCell(new Phrase("--------"));
            cell34.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell34);
            PdfPCell cell35 = new PdfPCell(new Phrase("TOTAL"));
            cell35.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell35);
            PdfPCell cell36 = new PdfPCell(new Phrase($"${txtTotal.Text}.00"));
            cell36.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell36);
            document.Add(table);
            document.Close();

            Process.Start($"{docs}/output {fechaActual.ToString("dd.MM.yyyy")}.pdf");
        }
    }
}
