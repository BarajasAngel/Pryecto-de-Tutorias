using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Titulacion.Clases
{
    public class CorreoCLS
    {
        MailMessage msg = new MailMessage();
        private string destinatario;
        private string asunto;
        private string mensaje;
        private string remitente_Email = "tutoriaexpress77@gmail.com";
        private string remitente_Pass = "Prueba123";

        public string Generar_Contraseña()
        {
            Random rd = new Random();
            string contraseña = Convert.ToChar(rd.Next(65, 90)).ToString() + Convert.ToChar(rd.Next(65, 90)).ToString();
            contraseña += Convert.ToChar(rd.Next(65, 90)) + Convert.ToChar(rd.Next(65, 90));
            contraseña += Convert.ToChar(rd.Next(65, 90)) + Convert.ToChar(rd.Next(65, 90)).ToString();
            contraseña += Convert.ToChar(rd.Next(65, 90));
            contraseña += rd.Next(0, 9);
            contraseña += Convert.ToChar(rd.Next(97, 122));
            return contraseña;
        }

        public CorreoCLS(string destinatario)
        {
            this.destinatario = destinatario;
            this.asunto = "Registro completado";
            this.mensaje = "Has completado tu registro con exito por favor logueate con la siguiente contraseña, no olvides cambiarla una vez tengas acceso \nContraseña: ";
        }

        private void Mensaje(string contraseña)
        {
            msg.To.Add(new MailAddress(destinatario));
            msg.Subject = asunto;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = mensaje + contraseña;
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress(remitente_Email);
            msg.IsBodyHtml = false;
        }
        private void Mensaje()
        {
            msg.To.Add(new MailAddress(destinatario));
            msg.Subject = asunto;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = "Tu contraseña ha sido Actualizada con Exito :3";
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress(remitente_Email);
            msg.IsBodyHtml = false;
        }
        public string smtpCorreo(string contraseña)
        {
            try
            {
                Mensaje(contraseña);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.Credentials = new NetworkCredential(remitente_Email, remitente_Pass);
                client.EnableSsl = true;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
                return "Mensaje Enviado Correctamente";

            }
            catch (Exception)
            {

                return "Hubo un erro al intentar mandar el mensaje";
            }
        }
        public string smtpCorreo()
        {
            try
            {
                Mensaje();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.Credentials = new NetworkCredential(remitente_Email, remitente_Pass);
                client.EnableSsl = true;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
                return "Mensaje Enviado Correctamente";

            }
            catch (Exception)
            {

                return "Hubo un erro al intentar mandar el mensaje";
            }
        }
    }
}
