using AnimaniaConsole.Core.CommandContracts;
using AnimaniaConsole.Services.Contracts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace AnimaniaConsole.Core.Commands
{
    public class GetPostsInPDFCommand : ICommand
    {
        private readonly IPostServices postServices;
        private readonly IUserService userService;

        public GetPostsInPDFCommand(IPostServices postServices, IUserService userService)
        {
            this.postServices = postServices;
            this.userService = userService;
        }


        public string Execute(IList<string> parameters)
        {
            var userPosts = postServices.GetAllMyPosts(userService.GetLoggedUserId());
            var random = new Random().Next();
            string filePath = "../../../AnimaniaConsole.Core/PDFReports/";
            string fileName = $"{random}.pdf";

            FileStream fs = new FileStream(filePath + fileName, FileMode.Create);
            // Create an instance of the document class which represents the PDF document itself.
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            // Create an instance to the PDF file by creating an instance of the PDF
            // Writer class using the document and the filestrem in the constructor.
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.AddSubject("This is a PDF showing current posts");
            // Open the document to enable you to write to the document

            document.Open();
            // Add a simple and wellknown phrase to the document in a flow layout manner
            document.Add(new Paragraph("Those are the current posts:"));
            foreach (var item in userPosts)
            {
                var date = item.PostDate.ToString();
                string status = (item.Status) ? "ACTIVE" : "INACTIVE";

                document.Add(new Paragraph((date)));
                document.Add(new Paragraph((status)));

                document.Add(new Paragraph(item.Title));
                document.Add(new Paragraph(item.Description));

            }
            // Close the document
            document.Close();
            // Close the writer instance
            writer.Close();
            // Always close open filehandles explicity
            fs.Close();
            return $"PDF File has been created! You can find it in the following folder: {filePath}";
        }
    }
}
