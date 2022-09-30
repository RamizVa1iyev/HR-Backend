using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class Messages
    {
        public static readonly string ValidatorTypeError = "Wrong type, this is not validator!";
        public static readonly string LoggerTypeError = "Wrong type, this is not logger!";

        public static readonly string AuthorizationDenied = "Authorization denied!";
        public static readonly string TokenCreated = "Token created successfully!";
        public static readonly string UserAlreadyExists = "User already exists!";
        public static readonly string SuccessfulLogin = "Successful login!";
        public static readonly string PasswordError = "Password error!";
        public static readonly string UserNotFound = "User not found!";
        public static readonly string UserRegistered = "User registered successfully!";

        public const string Added = "Added successfully.";
        public const string Updated = "Updated successfully.";
        public const string Deleted = "Deleted successfully.";
        public const string AllDeleted = "All deleted successfully.";
        public const string DataFound = "Data found successfully.";
    }
}
