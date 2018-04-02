using AnimaniaConsole.DTO.Contracts;

namespace AnimaniaConsole.DTO.Models
{
    public class UserSessionModel: IUserSessionModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public bool Status { get; set; }
    }
}