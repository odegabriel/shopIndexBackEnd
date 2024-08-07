namespace MyProjectWithoutDocker.Dtos
{
    public record class LogInDto
    (
        string userName,
        string password
    );

    public record class RegisterUserDto
        (
            string userName,
            string email,
            string password
        );
}
