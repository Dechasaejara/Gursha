using ErrorOr;

namespace Gursha.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error EmailNotFound => Error.Validation(
            code: "Auth.InvalidCred",
            description: "Email not found!"
        );
        public static Error InvalidPassword => Error.Validation(
            code: "Auth.InvalidCred",
            description: "Invalid Password!"
        );
    }
}