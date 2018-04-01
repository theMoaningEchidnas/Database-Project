namespace AnimaniaConsole.DTO.Contracts
{
    public interface IUserSessionModel
    {
        int Id { get; set; }

        string UserName { get; set; }

        bool Status { get; set; }

    }
}
