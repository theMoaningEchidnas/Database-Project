using AnimaniaConsole.Core.Commands.CommandContracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace AnimaniaConsole.Core.Commands
{
    public class GetPostsInPDF : ICommand
    {
        public GetPostsInPDF(IUserService userService,ISessionService sessionSerivce,UserSessionModel sessionUser)
        {
            UserService = userService;
            SessionSerivce = sessionSerivce;
            SessionUser = sessionUser;
        }

        public IUserService UserService { get; }
        public ISessionService SessionSerivce { get; }
        public UserSessionModel SessionUser { get; }

        public string Execute(IList<string> parameters)
        {
            var userPosts = UserService.GetAllPosts(SessionUser);
            var random = new Random().Next();
            var builder = new StringBuilder();
             string fileName = $"../../../AnimaniaConsole.Core/PDFReports/{random}.pdf";
            
            FileStream fs = new FileStream(fileName, FileMode.Create);
            // Create an instance of the document class which represents the PDF document itself.
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            // Create an instance to the PDF file by creating an instance of the PDF
            // Writer class using the document and the filestrem in the constructor.
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.AddSubject("This is a PDF showing current orders");
            // Open the document to enable you to write to the document

            document.Open();
            // Add a simple and wellknown phrase to the document in a flow layout manner
            document.Add(new Paragraph("Those are the current orders:"));
            foreach (var item in userPosts)
            {
                document.Add(new Paragraph(item.Title));
                document.Add(new Paragraph(item.Title));

            }
            // Close the document
            document.Close();
            // Close the writer instance
            writer.Close();
            // Always close open filehandles explicity
            fs.Close();
            return "Here you go!";
        }
    }
}
