﻿namespace MyProjectWithoutDocker.Dtos
{
    public record class UserUpdateDto
        (
            string email,
            string firstName,
            string lastName,
            string phoneNumber
        );
}
