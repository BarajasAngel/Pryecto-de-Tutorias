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
        
        
        
        public CorreoCLS(string destinatario)
        {
        
            this.destinatario = destinatario;
            this.asunto = "Registro completado";
            this.mensaje = "Has completado tu registro con exito por favor logueate con la siguiente contraseña, no olvides cambiarla una vez tengas acceso";
        
        }
        
        private void Mensaje()
        {            
            msg.To.Add(new MailAddress(destinatario));
            msg.Subject = asunto;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = mensaje;
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress(remitente_Email);
            msg.IsBodyHtml = false;                                    
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
