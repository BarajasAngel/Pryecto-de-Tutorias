using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using Titulacion.Models;

namespace Titulacion.Clases
{
    public class ComprobanteCLS
    {
        General generic = new General();
        public MemoryStream GenerarComprobante()
        {

                
            TutoriasContext db = new TutoriasContext();

            var us = db.Usuarios.Where(x => x.User == generic.Boleta).First();

            var alm = db.Alumno.Where(x => x.IdUsuario == us.IdUsuario).First();

            var inscrip = db.Inscripcion.Where(x => x.IdAlumno == alm.IdAlumno).First();

            var prof = db.Profesor.Where(x => x.IdProfesor == inscrip.IdProfesor).First();

            using (MemoryStream stream = new MemoryStream())
            {
                //Creamos un nuevo documento y lo definimos como PDF
                Document pdfDoc = new Document(PageSize.A5.Rotate());
                Font letra = new Font(Font.FontFamily.COURIER, 12, Font.NORMAL, BaseColor.BLACK);
                Font letra2 = new Font(Font.FontFamily.COURIER, 12, Font.BOLD, BaseColor.BLACK);
                //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                //writer.Open();
                pdfDoc.Open();


                //Agregamos la imagen del banner al documento
                iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance("https://multipress.com.mx/wp-content/uploads/2020/04/ipn.jpg");
                logo1.ScalePercent(11);

                logo1.SetAbsolutePosition(23, 300);
                pdfDoc.Add(logo1);
                iTextSharp.text.Image logo2 = iTextSharp.text.Image.GetInstance("https://www.cecyt13.ipn.mx/assets/files/cecyt13/img/Inicio/banderin.png");
                logo2.ScalePercent(25);

                logo2.SetAbsolutePosition(490, 300);
                pdfDoc.Add(logo2);


                pdfDoc.Add(new Paragraph("Instituto Politécnico Nacional", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("Centro de Estudios Científicos y Tecnológicos No.13", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("Ricardo Flores Magón", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(new Paragraph("Comprobante de inscripción a tutorías individuales", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(new Paragraph("Folio: " + "Hola", letra2) { Alignment = Element.ALIGN_LEFT });
                pdfDoc.Add(Chunk.NEWLINE);
                PdfPTable tabl1 = new PdfPTable(2);
                tabl1.WidthPercentage = 100;
                PdfPCell fila1 = new PdfPCell(new Phrase("Alumno: " + "Hola", letra));
                fila1.BorderWidth = 0;
                tabl1.AddCell(fila1);
                PdfPCell fila2 = new PdfPCell(new Phrase("Boleta:" + "Hola", letra));
                fila2.BorderWidth = 0;
                tabl1.AddCell(fila2);
                pdfDoc.Add(tabl1);

                PdfPTable tabl2 = new PdfPTable(2);
                tabl2.WidthPercentage = 100;
                PdfPCell fila11 = new PdfPCell(new Phrase("Profesor: " + "Hola", letra));
                fila11.BorderWidth = 0;
                PdfPCell fila22 = new PdfPCell(new Phrase("Grupo:" + "Hola", letra));
                fila22.BorderWidth = 0;
                tabl2.AddCell(fila11);
                tabl2.AddCell(fila22);
                pdfDoc.Add(tabl2);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);


                pdfDoc.Add(new Paragraph(string.Format("Comprobante generado el {0:dd/MM/yyyy} a las {0:HH:mm:ss} hrs. ", DateTime.Now), letra2) { Alignment = Element.ALIGN_BOTTOM });

                pdfDoc.Close();                
                return stream;
            }



            ////Document pdfDoc = new Document(PageSize.A5.Rotate());
            //using (FileStream stream = new FileStream(db.Usuarios + ".pdf", FileMode.Create))
            //{

            //    Document pdfDoc = new Document(PageSize.A5.Rotate());                
            //    //MemoryStream stream = new MemoryStream();
            //    //Creamos un nuevo documento y lo definimos como PDF                                          
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            //    Font letra = new Font(Font.FontFamily.COURIER, 12, Font.NORMAL, BaseColor.BLACK);
            //    Font letra2 = new Font(Font.FontFamily.COURIER, 12, Font.BOLD, BaseColor.BLACK);                
            //    pdfDoc.Open();


            //    //Agregamos la imagen del banner al documento
            //    Image logo1 = Image.GetInstance("https://multipress.com.mx/wp-content/uploads/2020/04/ipn.jpg");
            //    logo1.ScalePercent(11);

            //    logo1.SetAbsolutePosition(23, 300);
            //    pdfDoc.Add(logo1);
            //    Image logo2 = Image.GetInstance("https://www.cecyt13.ipn.mx/assets/files/cecyt13/img/Inicio/banderin.png");
            //    logo2.ScalePercent(25);

            //    logo2.SetAbsolutePosition(490, 300);
            //    pdfDoc.Add(logo2);


            //    pdfDoc.Add(new Paragraph("Instituto Politécnico Nacional", letra2) { Alignment = Element.ALIGN_CENTER });
            //    pdfDoc.Add(new Paragraph("Centro de Estudios Científicos y Tecnológicos No.13", letra2) { Alignment = Element.ALIGN_CENTER });
            //    pdfDoc.Add(new Paragraph("Ricardo Flores Magón", letra2) { Alignment = Element.ALIGN_CENTER });
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(new Paragraph("Comprobante de inscripción a tutorías individuales", letra2) { Alignment = Element.ALIGN_CENTER });
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(new Paragraph("Folio: " + inscrip.Folio, letra2) { Alignment = Element.ALIGN_LEFT });
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    PdfPTable tabl1 = new PdfPTable(2);
            //    tabl1.WidthPercentage = 100;
            //    PdfPCell fila1 = new PdfPCell(new Phrase("Alumno: " + alm.Nombre + " " + alm.ApellidoPat + " " + alm.ApellidoMat, letra));
            //    fila1.BorderWidth = 0;
            //    tabl1.AddCell(fila1);
            //    PdfPCell fila2 = new PdfPCell(new Phrase("Boleta:" + us.User, letra));
            //    fila2.BorderWidth = 0;
            //    tabl1.AddCell(fila2);
            //    pdfDoc.Add(tabl1);
            //    PdfPTable tabl2 = new PdfPTable(2);
            //    tabl2.WidthPercentage = 100;
            //    PdfPCell fila11 = new PdfPCell(new Phrase("Profesor: " + prof.Nombre + " " + prof.ApellidoPat + " " + prof.ApellidoMat, letra));
            //    fila11.BorderWidth = 0;
            //    PdfPCell fila22 = new PdfPCell(new Phrase("Grupo:" + alm.Grupo, letra));
            //    fila22.BorderWidth = 0;
            //    tabl2.AddCell(fila11);
            //    tabl2.AddCell(fila22);
            //    pdfDoc.Add(tabl2);
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(Chunk.NEWLINE);
            //    pdfDoc.Add(new Paragraph(string.Format("Comprobante generado el {0:dd/MM/yyyy} a las {0:HH:mm:ss} hrs. ", DateTime.Now), letra2) { Alignment = Element.ALIGN_BOTTOM });                
            //    pdfDoc.Close();
            //    return stream;
            //}            
        }
    }
}
